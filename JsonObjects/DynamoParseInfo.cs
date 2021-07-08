using System.Collections.Generic;

namespace DynamoParser.JsonObjects
{
    public class DynamoParseInfo<T>
    {
        public List<T> Items { get; set; }
        public int Count { get; set; }
        public int ScannedCount { get; set; }
        public int? ConsumedCapacity { get; set; }
    }
}
