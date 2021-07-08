using System.Collections.Generic;

namespace DynamoParser.JsonObjects
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
