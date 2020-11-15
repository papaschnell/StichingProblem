using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    public class DataResponse
        : IDataResponse
    {
        public DataResponse(
            string value1, 
            string value2, 
            string value3)
        {
            Value1 = value1;
            Value2 = value2;
            Value3 = value3;
        }

        public string Value1 { get; }

        public string Value2 { get; }

        public string Value3 { get; }
    }
}
