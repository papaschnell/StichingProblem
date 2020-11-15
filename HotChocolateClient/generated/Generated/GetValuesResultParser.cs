using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using StrawberryShake;
using StrawberryShake.Http;

namespace Client
{
    public class GetValuesResultParser
        : JsonResultParserBase<IGetValues>
    {
        private readonly IValueSerializer _stringSerializer;

        public GetValuesResultParser(IEnumerable<IValueSerializer> serializers)
        {
            IReadOnlyDictionary<string, IValueSerializer> map = serializers.ToDictionary();

            if (!map.TryGetValue("String", out IValueSerializer serializer))
            {
                throw new ArgumentException(
                    "There is no serializer specified for `String`.",
                    nameof(serializers));
            }
            _stringSerializer = serializer;
        }

        protected override IGetValues ParserData(JsonElement data)
        {
            return new GetValues
            (
                ParseGetValuesData(data, "data")
            );

        }

        private IDataResponse ParseGetValuesData(
            JsonElement parent,
            string field)
        {
            if (!parent.TryGetProperty(field, out JsonElement obj))
            {
                return null;
            }

            if (obj.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return new DataResponse
            (
                DeserializeNullableString(obj, "value1"),
                DeserializeNullableString(obj, "value2"),
                DeserializeNullableString(obj, "value3")
            );
        }

        private string DeserializeNullableString(JsonElement obj, string fieldName)
        {
            if (!obj.TryGetProperty(fieldName, out JsonElement value))
            {
                return null;
            }

            if (value.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return (string)_stringSerializer.Deserialize(value.GetString());
        }
    }
}
