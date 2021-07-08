using DynamoParser.JsonObjects;
using DynamoParser.Poco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DynamoParser
{
    public partial class CandidateDetail : Form
    {
        public CandidateDetail()
        {
            InitializeComponent();
        }
        public CandidateDetail(LogDataPoco item)
        {
            LogData = item;
            InitializeComponent();
        }
        public LogDataPoco LogData { get; set; }
        private bool _showSourceRecord = false;


        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CandidateDetail_Shown(object sender, EventArgs e)
        {
            Parse_Bucket.Text = LogData.RawBucketName;
            Parse_Date.Text = $"{LogData.ProcessedDate}";
            Parse_Key.Text = LogData.RawFileKey;
            Parse_ProcessId.Text = $"{LogData.ProcessId}";
            Parse_ResumeName.Text = LogData.RawFileName;
            Parse_Rhuid.Text = $"{LogData.RHUID}";
            Parse_Stored.Checked = LogData.StoredInEsParse;
            Parse_Quality.Checked = LogData.QualityCheckDone;
            Parse_Valid.Checked = LogData.IsValid;
            Parse_Text.Text = LogData.QualityText;
            zengine_elastic.Checked = LogData.StoredInEsZengine;
            zengine_locator.Text = $"{LogData.LocatorKey}";
            zengine_modified.Text = $"{LogData.LastModified}";
            zengine_status.Text = LogData.Status;
            zengine_Rhuid.Text = $"{LogData.RHUID}";
            zengine_version.Text = $"Version No: {LogData.VersionNbr}";
            zengine_flags.Text = LogData.Flags;
            zengine_text.Text = LogData.Passport;
            zengine_s3.Text = LogData.S3Files;

            ZEngineGroup.Text = LogData.MixedZEngineLog ? "Z-Engine Processing Information (Mixed Log)" : "Z-Engine Processing Information";
            ParsingGroup.Text = LogData.MixedCandidateLog ? "Parsing Information (Mixed Log)" : "Parsing Information";
            button2.Visible = LogData.MixedCandidateLog || LogData.MixedZEngineLog;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (LogData.MixedCandidateLog)
            {
                Parse_Bucket.Text = _showSourceRecord ? LogData.RawBucketName : LogData.CandidateLog.rawBucketName.S;
                Parse_Date.Text = _showSourceRecord ? $"{LogData.ProcessedDate}" : LogData.CandidateLog.processedDate.S;
                Parse_Key.Text = _showSourceRecord ? LogData.RawFileKey : LogData.CandidateLog.rawFileKey.S;
                Parse_ProcessId.Text = _showSourceRecord ? $"{LogData.ProcessId}" : LogData.CandidateLog.processId.S;
                Parse_ResumeName.Text = _showSourceRecord ? LogData.RawFileName : LogData.CandidateLog.rawFileName.S;
                Parse_Rhuid.Text = _showSourceRecord ? $"{LogData.RHUID}" : LogData.CandidateLog.RHUID.S;
                Parse_Stored.Checked = _showSourceRecord ? LogData.StoredInEsParse : LogData.CandidateLog.StoredInEs.BOOL.Value;
                Parse_Quality.Checked = _showSourceRecord ? LogData.QualityCheckDone : LogData.CandidateLog.QualityCheckDone.BOOL.Value;
                Parse_Valid.Checked = _showSourceRecord ? LogData.IsValid : LogData.CandidateLog.isValid.BOOL.Value;
                Parse_Text.Text = _showSourceRecord ? LogData.QualityText : new StringBuilder().GetMultiLineText(LogData.CandidateLog.qualityText.L).ToString();

                ParsingGroup.Text = _showSourceRecord ? "Parsing Information (Original)" : "Parsing Information (Blended)";
            }
            if(LogData.MixedZEngineLog)
            {
                zengine_elastic.Checked = _showSourceRecord ? LogData.StoredInEsZengine : LogData.ZEngineLog.storedInES.N == "1";
                zengine_locator.Text = _showSourceRecord ? $"{LogData.LocatorKey}" : LogData.ZEngineLog.LocatorKey.S;
                zengine_modified.Text = _showSourceRecord ? $"{LogData.LastModified}" : LogData.ZEngineLog.LastModified.S;
                zengine_status.Text = _showSourceRecord ? LogData.Status : LogData.ZEngineLog.Status.S;
                zengine_Rhuid.Text = _showSourceRecord ? $"{LogData.RHUID}" : LogData.ZEngineLog.RHUID.S;
                zengine_version.Text = _showSourceRecord ? $"Version No: {LogData.VersionNbr}" : $"Version No: {LogData.ZEngineLog?.VersionNbr?.S}";
                zengine_flags.Text = _showSourceRecord ? LogData.Flags : new StringBuilder().GetFlags(LogData.ZEngineLog.Flags.L).ToString();
                zengine_text.Text = _showSourceRecord ? LogData.Passport : new StringBuilder().GetMultiLineText(LogData.ZEngineLog.Passport.L).ToString();
                zengine_s3.Text = _showSourceRecord ? LogData.S3Files : new StringBuilder().GetMapText(LogData.ZEngineLog.S3Files.L).ToString();

                ZEngineGroup.Text = _showSourceRecord ? "Z-Engine Processing Information (Original)" : "Z-Engine Processing Information (Blended)";
            }
            _showSourceRecord = !_showSourceRecord;
        }
    }
}
