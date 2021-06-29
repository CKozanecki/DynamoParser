using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoParser
{
    public class ZEngineParseItem
    {
        public ParseObject LastModified { get; set; }
        public ParseObject RHUID { get; set; }
        public ParseObject LocatorKey { get; set; }
        public ParseObject ResumeTextMd5 { get; set; }
        public ParseObject storedInES { get; set; }
        public ParseObject BucketName { get; set; }
        public ParseObject S3Files { get; set; }
        public ParseObject Passport { get; set; }
        public ParseObject Flags { get; set; }
        public ParseObject VersionNbr { get; set; }
        public ParseObject Status { get; set; }
    }
}
