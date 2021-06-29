using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoParser
{
    public class ParseObject
    {
        public string S { get; set; }
        public string N { get; set; }
        public bool? BOOL { get; set; }
        public List<ParseObject> L { get; set; } = new List<ParseObject>();
        public Dictionary<string, ParseObject> M { get; set; }
    }
}
