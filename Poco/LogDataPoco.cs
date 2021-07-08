using DynamoParser.JsonObjects;
using System;

namespace DynamoParser.Poco
{
    public struct LogDataPoco
    {
        public DateTime LastModified { get; set; }
        public Guid RHUID { get; set; }
        public string LocatorKey { get; set; }
        public string ResumeTextMd5 { get; set; }
        public bool StoredInEsParse { get; set; }
        public bool StoredInEsZengine { get; set; }
        public string BucketName { get; set; }
        public string S3Files { get; set; }
        public string Passport { get; set; }
        public string Flags { get; set; }
        public int VersionNbr { get; set; }
        public string Status { get; set; }
        public string ResumeSource { get; set; }
        public Guid ProcessId { get; set; }
        public string RawFileName { get; set; }
        public bool QualityCheckDone { get; set; }
        public string RawBucketName { get; set; }
        public bool IsValid { get; set; }
        public string ArchiveRawFileKey { get; set; }
        public string RawFileKey { get; set; }
        public string RecordId { get; set; }
        public Guid ClientId { get; set; }
        public string ParsedFileName { get; set; }
        public DateTime ProcessedDate { get; set; }
        public string ParsedBucketName { get; set; }
        public string ArchiveRawFileName { get; set; }
        public string ArchiveRawBucketName { get; set; }
        public string QualityText { get; set; }
        public string ParsedFileKey { get; set; }

        public CandidateParseItem CandidateLog { get; set; }
        public ZEngineParseItem ZEngineLog { get; set; }

        public bool MixedCandidateLog { get; set; }
        public bool MixedZEngineLog { get; set; }

        public string BatchNumber { get; set; }


        public string FailureText => QualityText + Passport;

        public bool IsFailureRecord => !(IsValid && StoredInEsParse && StoredInEsZengine);
    }
}
