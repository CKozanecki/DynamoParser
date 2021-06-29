using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoParser
{
    public class DynamoParseInfo<T>
    {
        public List<T> Items { get; set; }
        public int Count { get; set; }
        public int ScannedCount { get; set; }
        public int? ConsumedCapacity { get; set; }
    }
}
