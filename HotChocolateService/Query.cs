using System.Threading;

namespace TestHotChocolate
{
    public class Query
    {
        public DataResponse GetData()
        {
            // This controls the time each request takes.
            Thread.Sleep(100);
            
            return new DataResponse()
            {
                Value1 = "Value1",
                Value2 = "Value2",
                Value3 = "Value3"
            };
        }

        public class DataResponse
        {
            public string Value1 { get; set; }
            public string Value2 { get; set; }
            public string Value3 { get; set; }
        }
    }
}