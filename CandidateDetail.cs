using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamoParser
{
    public partial class CandidateDetail : Form
    {
        public CandidateDetail()
        {
            InitializeComponent();
        }
        public CandidateParseItem CandidateParseRecord{ get; set; }
        public ZEngineParseItem ZEngineRecord { get; set; }


        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CandidateDetail_Shown(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            if (CandidateParseRecord != null)
            {
                Parse_Bucket.Text = CandidateParseRecord.rawBucketName?.S;
                Parse_Date.Text = CandidateParseRecord.processedDate?.S;
                Parse_Key.Text = CandidateParseRecord.rawFileKey?.S;
                Parse_ProcessId.Text = CandidateParseRecord.processId?.S;
                Parse_ResumeName.Text = CandidateParseRecord.rawFileName?.S;
                Parse_Rhuid.Text = CandidateParseRecord.RHUID?.S;
                Parse_Stored.Checked = (CandidateParseRecord.StoredInEs.BOOL.HasValue && !CandidateParseRecord.StoredInEs.BOOL.Value);
                Parse_Quality.Checked = (CandidateParseRecord.QualityCheckDone.BOOL.HasValue && !CandidateParseRecord.QualityCheckDone.BOOL.Value);
                Parse_Valid.Checked = (CandidateParseRecord.isValid.BOOL.HasValue && !CandidateParseRecord.isValid.BOOL.Value);

                if (CandidateParseRecord.isValid.BOOL.HasValue && !CandidateParseRecord.isValid.BOOL.Value)
                    sb.AppendLine("Invalid Resume => No parsing Info");
                else
                {
                    foreach (var map in CandidateParseRecord.qualityText.L)
                    {
                        foreach (var item in map.M)
                        {
                            sb.AppendLine(string.Format("{0}: {1}", item.Key, item.Value.S));
                        }
                    }
                }
                Parse_Text.Text = sb.ToString();
            }
            if (ZEngineRecord != null)
            {
                zengine_elastic.Checked = ZEngineRecord.storedInES?.N == "0" ? false : true;
                zengine_locator.Text = ZEngineRecord.LocatorKey?.S;
                zengine_modified.Text = DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(ZEngineRecord.LastModified?.N)).LocalDateTime.ToString();
                zengine_status.Text = ZEngineRecord.Status?.S;
                zengine_Rhuid.Text = ZEngineRecord.RHUID?.S;
                zengine_version.Text = string.Format("Version No: {0}", ZEngineRecord.VersionNbr?.N);

                sb.Clear();
                if (ZEngineRecord.Flags?.L != null)
                    foreach (var map in ZEngineRecord.Flags.L)
                    {
                        sb.Append(map.S);
                        sb.Append(", ");
                    }
                zengine_flags.Text = sb.ToString();

                sb.Clear();
                if (ZEngineRecord.Passport?.L != null)
                    foreach (var map in ZEngineRecord.Passport.L)
                    {
                        foreach (var item in map.M)
                        {
                            sb.Append(string.Format("{0}: {1}", item.Key, item.Value.S));
                            sb.Append(", ");
                        }
                    }
                zengine_text.Text = sb.ToString();

                sb.Clear();
                if (ZEngineRecord.S3Files?.L != null)
                    foreach (var map in ZEngineRecord.S3Files.L)
                    {
                        foreach (var item in map.M)
                        {
                            sb.Append(string.Format("{0}: {1}", item.Key, item.Value.S));
                            sb.Append('/');
                        }
                    }
                zengine_s3.Text = sb.ToString();
            }
        }
    }
}
