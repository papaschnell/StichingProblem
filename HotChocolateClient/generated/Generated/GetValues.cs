using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    public class GetValues
        : IGetValues
    {
        public GetValues(
            IDataResponse data)
        {
            Data = data;
        }

        public IDataResponse Data { get; }
    }
}
