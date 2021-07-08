namespace DynamoParser.JsonObjects
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


        #region Z-engine Candidate info, put into the wrong location
        public ParseObject LastModified { get; set; }
        public ParseObject LocatorKey { get; set; }
        public ParseObject ResumeTextMd5 { get; set; }
        public ParseObject storedInES { get; set; }
        public ParseObject BucketName { get; set; }
        public ParseObject S3Files { get; set; }
        public ParseObject Passport { get; set; }
        public ParseObject Flags { get; set; }
        public ParseObject VersionNbr { get; set; }
        public ParseObject Status { get; set; }
        #endregion

        public bool IsError
        {
            get
            {
                return !(isValid.BOOL.HasValue && isValid.BOOL.Value && StoredInEs.BOOL.HasValue && StoredInEs.BOOL.Value && storedInES == null ||
                storedInES != null && storedInES.N == "1");
            }
        }
    }
}
