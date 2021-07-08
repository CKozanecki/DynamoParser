using DynamoParser.JsonObjects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamoParser.Poco
{
    public static class PocoBuilder
    {

        internal static List<LogDataPoco> BuildAllObjects(DynamoParseInfo<CandidateParseItem> log, DynamoParseInfo<ZEngineParseItem> log2, Action<string> invokeStatusUpdate)
        {
            var objects = new List<LogDataPoco>();
            Parallel.ForEach(log.Items, item =>
            {
                var item2 = log2.Items.FirstOrDefault(x => x.RHUID.S == item.RHUID.S);
                invokeStatusUpdate($"Reading Candidate ID: {item.rawFileName.S}");
                objects.Add(BuildObject(item, item2));
            });
            return objects;
        }

        public static LogDataPoco BuildObject(CandidateParseItem item1, ZEngineParseItem item2)
        {
            var sb = new StringBuilder();
            var obj = new LogDataPoco();

            obj.RHUID = Guid.Parse(item1.RHUID.S);
            obj.LocatorKey = item1.LocatorKey?.S ?? item2?.LocatorKey?.S ?? "None Found";
            obj.ProcessId = Guid.Parse(item2?.processId?.S ?? item1.processId?.S ?? Guid.Empty.ToString());
            obj.ClientId = Guid.Parse(item2?.clientId?.S ?? item1.clientId?.S ?? Guid.Empty.ToString());
            obj.ParsedFileKey = item2?.parsedFileKey?.S ?? item1.parsedFileKey?.S ?? "None Found";
            obj.LastModified = DateTimeOffset.FromUnixTimeMilliseconds(
                 long.Parse(
                     item1.LastModified?.N ?? item2?.LastModified?.N ?? "0"
                     )).LocalDateTime;
            obj.ProcessedDate = DateTime.Parse((item2?.processedDate?.S ?? item1.processedDate?.S ?? "1/1/1900").Replace("UTC", ""), CultureInfo.CurrentCulture.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeUniversal);
            obj.StoredInEsParse = item2?.StoredInEs?.BOOL ?? item1.StoredInEs?.BOOL ?? false;
            obj.StoredInEsZengine = item1.storedInES?.N == "1"
                                    ? true
                                    : item2?.storedInES?.N == "1"
                                      ? true : false;
            obj.QualityCheckDone = item2?.QualityCheckDone?.BOOL ?? item1.QualityCheckDone?.BOOL ?? false;
            obj.IsValid = item2?.isValid?.BOOL ?? item1.isValid?.BOOL ?? false;
            obj.VersionNbr = int.Parse(item1.VersionNbr?.N ?? item2?.VersionNbr?.N ?? "0");
            obj.ResumeTextMd5 = item1.ResumeTextMd5?.S ?? item2?.ResumeTextMd5?.S ?? "None Found";
            obj.BucketName = item1.BucketName?.S ?? item2?.BucketName?.S ?? "None Found";
            obj.Status = item1.Status?.S ?? item2?.Status?.S ?? "None Found";
            obj.ResumeSource = item2?.resumeSource?.S ?? item1.resumeSource?.S ?? "None Found";
            obj.RawFileName = item2?.rawFileName?.S ?? item1.rawFileName.S ?? "None Found";
            obj.RawBucketName = item2?.rawBucketName?.S ?? item1.rawBucketName?.S ?? "None Found";
            obj.ArchiveRawFileKey = item2?.archiveRawFileKey?.S ?? item1.archiveRawFileKey?.S ?? "None Found";
            obj.RawFileKey = item2?.rawFileKey?.S ?? item1.rawFileKey?.S ?? "None Found";
            obj.RecordId = item2?.recordId?.S ?? item1.recordId?.S ?? "None Found";
            obj.ParsedFileName = item2?.parsedFileName?.S ?? item1.parsedFileName?.S ?? "None Found";
            obj.ParsedBucketName = item2?.parsedBucketName?.S ?? item1.parsedBucketName?.S ?? "None Found";
            obj.ArchiveRawFileName = item2?.archiveRawFileName?.S ?? item1.archiveRawFileName?.S ?? "None Found";
            obj.ArchiveRawBucketName = item2?.archiveRawBucketName?.S ?? item1.archiveRawBucketName?.S ?? "None Found";
            obj.CandidateLog = item1;
            obj.ZEngineLog = item2;
            obj.MixedCandidateLog = item1.Passport?.L != null;
            obj.MixedZEngineLog = item2?.qualityText?.L != null;

            if (item1.rawFileKey?.S != null && item1.rawFileKey.S.Contains("Batch"))
                obj.BatchNumber = item1.rawFileKey.S[item1.rawFileKey.S.IndexOf("Batch")..item1.rawFileKey.S.IndexOf('/', item1.rawFileKey.S.IndexOf("Batch"))];
            else if (item2?.rawFileKey?.S != null && item2.rawFileKey.S.Contains("Batch"))
                obj.BatchNumber = item2.rawFileKey.S[item2.rawFileKey.S.IndexOf("Batch")..item2.rawFileKey.S.IndexOf('/', item2.rawFileKey.S.IndexOf("Batch"))];
            else obj.BatchNumber = "misc";

            #region S3Files
            sb.Clear();
            if (item1.S3Files?.L != null)
                sb.GetMapText(item1.S3Files.L);
            else if (item2?.S3Files?.L != null)
                sb.GetMapText(item2.S3Files.L);
            else sb.Append("No S3 Info");
            obj.S3Files = sb.ToString();
            #endregion S3Files
            #region Passport
            sb.Clear();
            sb.AppendLine("Passport (z-Engine):");
            sb.AppendLine("-------------------------------------------------------------------------");
            if (item1.Passport?.L != null)
                sb.GetMultiLineText(item1.Passport.L);
            else if (item2?.Passport?.L != null)
                sb.GetMultiLineText(item2.Passport.L);
            else sb.AppendLine("No Passport Text Available");
            sb.AppendLine("-------------------------------------------------------------------------");
            sb.AppendLine();
            obj.Passport = sb.ToString();
            #endregion Passport
            #region Flags
            sb.Clear();
            if (item1.Flags?.L != null)
                sb.GetFlags(item1.Flags.L);
            else if (item2?.Flags?.L != null)
                sb.GetFlags(item2.Flags.L);
            else sb.Append("No Flag Info");
            obj.Flags = sb.ToString();
            #endregion Flags
            #region QualityText
            sb.Clear();
            sb.AppendLine("QUALITY TEXT (Sovren):");
            sb.AppendLine("-------------------------------------------------------------------------");
            if (item2?.qualityText?.L != null)
                sb.GetMultiLineText(item2.qualityText.L);
            else if (item1.qualityText?.L != null)
                sb.GetMultiLineText(item1.qualityText.L);
            else sb.AppendLine("No Quality Text Available.");
            sb.AppendLine("-------------------------------------------------------------------------");
            sb.AppendLine();
            obj.QualityText = sb.ToString();
            #endregion QualityText

            return obj;
        }
    }
    public static class ExtensionUtils
    {
        public static StringBuilder GetMultiLineText(this StringBuilder sb, List<ParseObject> LogData)
        {
            if (LogData != null)
                foreach (var map in LogData)
                {
                    foreach (var entry in map.M)
                    {
                        sb.AppendLine($"{entry.Key}: {entry.Value.S}");
                    }
                }
            return sb;
        }
        public static StringBuilder GetMapText(this StringBuilder sb, List<ParseObject> LogData)
        {
            if (LogData != null)
                foreach (var map in LogData)
                {
                    foreach (var entry in map.M)
                    {
                        sb.Append($"{entry.Key}: {entry.Value.S}; ");
                    }
                }
            return sb;
        }
        public static StringBuilder GetFlags(this StringBuilder sb, List<ParseObject> LogData)
        {
            if (LogData != null)
                foreach (var map in LogData)
                {
                        sb.Append($"{map.S}, ");
                }
            return sb;
        }
    }
}
