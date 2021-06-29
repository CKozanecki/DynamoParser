using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoParser
{
    public class CandidateParseItem
    {
        public ParseObject resumeSource { get; set; }
        public ParseObject processId { get; set; }
        public ParseObject rawFileName { get; set; }
        public ParseObject RHUID { get; set; }
        public ParseObject QualityCheckDone { get; set; }
        public ParseObject rawBucketName { get; set; }
        public ParseObject isValid { get; set; }
        public ParseObject archiveRawFileKey { get; set; }
        public ParseObject rawFileKey { get; set; }
        public ParseObject StoredInEs { get; set; }
        public ParseObject recordId { get; set; }
        public ParseObject clientId { get; set; }
        public ParseObject parsedFileName { get; set; }
        public ParseObject processedDate { get; set; }
        public ParseObject parsedBucketName { get; set; }
        public ParseObject archiveRawFileName { get; set; }
        public ParseObject archiveRawBucketName { get; set; }
        public ParseObject qualityText { get; set; }
        public ParseObject parsedFileKey { get; set; }

    }
}
