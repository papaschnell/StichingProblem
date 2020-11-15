using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    public class GetValuesOperation
        : IOperation<IGetValues>
    {
        public string Name => "GetValues";

        public IDocument Document => Querys.Default;

        public Type ResultType => typeof(IGetValues);

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            return Array.Empty<VariableValue>();
        }
    }
}
