
namespace DynamoParser
{
    partial class CandidateDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ParsingGroup = new System.Windows.Forms.GroupBox();
            this.Parse_Text = new System.Windows.Forms.TextBox();
            this.Parse_Valid = new System.Windows.Forms.CheckBox();
            this.Parse_Stored = new System.Windows.Forms.CheckBox();
            this.Parse_Quality = new System.Windows.Forms.CheckBox();
            this.Parse_Date = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Parse_ProcessId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Parse_Key = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Parse_Bucket = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Parse_ResumeName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Parse_Rhuid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ZEngineGroup = new System.Windows.Forms.GroupBox();
            this.zengine_version = new System.Windows.Forms.Label();
            this.zengine_text = new System.Windows.Forms.TextBox();
            this.zengine_elastic = new System.Windows.Forms.CheckBox();
            this.zengine_status = new System.Windows.Forms.TextBox();
            this.Status = new System.Windows.Forms.Label();
            this.zengine_flags = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.zengine_s3 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.zengine_locator = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.zengine_modified = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.zengine_Rhuid = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ParsingGroup.SuspendLayout();
            this.ZEngineGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // ParsingGroup
            // 
            this.ParsingGroup.Controls.Add(this.Parse_Text);
            this.ParsingGroup.Controls.Add(this.Parse_Valid);
            this.ParsingGroup.Controls.Add(this.Parse_Stored);
            this.ParsingGroup.Controls.Add(this.Parse_Quality);
            this.ParsingGroup.Controls.Add(this.Parse_Date);
            this.ParsingGroup.Controls.Add(this.label6);
            this.ParsingGroup.Controls.Add(this.Parse_ProcessId);
            this.ParsingGroup.Controls.Add(this.label5);
            this.ParsingGroup.Controls.Add(this.Parse_Key);
            this.ParsingGroup.Controls.Add(this.label4);
            this.ParsingGroup.Controls.Add(this.Parse_Bucket);
            this.ParsingGroup.Controls.Add(this.label3);
            this.ParsingGroup.Controls.Add(this.Parse_ResumeName);
            this.ParsingGroup.Controls.Add(this.label2);
            this.ParsingGroup.Controls.Add(this.Parse_Rhuid);
            this.ParsingGroup.Controls.Add(this.label1);
            this.ParsingGroup.Location = new System.Drawing.Point(12, 12);
            this.ParsingGroup.Name = "ParsingGroup";
            this.ParsingGroup.Size = new System.Drawing.Size(776, 203);
            this.ParsingGroup.TabIndex = 0;
            this.ParsingGroup.TabStop = false;
            this.ParsingGroup.Text = "Parsing Information";
            // 
            // Parse_Text
            // 
            this.Parse_Text.Location = new System.Drawing.Point(461, 22);
            this.Parse_Text.Multiline = true;
            this.Parse_Text.Name = "Parse_Text";
            this.Parse_Text.ReadOnly = true;
            this.Parse_Text.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Parse_Text.Size = new System.Drawing.Size(309, 168);
            this.Parse_Text.TabIndex = 15;
            // 
            // Parse_Valid
            // 
            this.Parse_Valid.AutoSize = true;
            this.Parse_Valid.Enabled = false;
            this.Parse_Valid.Location = new System.Drawing.Point(311, 169);
            this.Parse_Valid.Name = "Parse_Valid";
            this.Parse_Valid.Size = new System.Drawing.Size(133, 19);
            this.Parse_Valid.TabIndex = 14;
            this.Parse_Valid.Text = "Sovren Marked Valid";
            this.Parse_Valid.UseVisualStyleBackColor = true;
            // 
            // Parse_Stored
            // 
            this.Parse_Stored.AutoSize = true;
            this.Parse_Stored.Enabled = false;
            this.Parse_Stored.Location = new System.Drawing.Point(311, 140);
            this.Parse_Stored.Name = "Parse_Stored";
            this.Parse_Stored.Size = new System.Drawing.Size(144, 19);
            this.Parse_Stored.TabIndex = 13;
            this.Parse_Stored.Text = "Stored in ElasticSearch";
            this.Parse_Stored.UseVisualStyleBackColor = true;
            // 
            // Parse_Quality
            // 
            this.Parse_Quality.AutoSize = true;
            this.Parse_Quality.Enabled = false;
            this.Parse_Quality.Location = new System.Drawing.Point(311, 111);
            this.Parse_Quality.Name = "Parse_Quality";
            this.Parse_Quality.Size = new System.Drawing.Size(131, 19);
            this.Parse_Quality.TabIndex = 12;
            this.Parse_Quality.Text = "Quality Check Done";
            this.Parse_Quality.UseVisualStyleBackColor = true;
            // 
            // Parse_Date
            // 
            this.Parse_Date.Location = new System.Drawing.Point(96, 138);
            this.Parse_Date.Name = "Parse_Date";
            this.Parse_Date.ReadOnly = true;
            this.Parse_Date.Size = new System.Drawing.Size(209, 23);
            this.Parse_Date.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Process Date";
            // 
            // Parse_ProcessId
            // 
            this.Parse_ProcessId.Location = new System.Drawing.Point(96, 109);
            this.Parse_ProcessId.Name = "Parse_ProcessId";
            this.Parse_ProcessId.ReadOnly = true;
            this.Parse_ProcessId.Size = new System.Drawing.Size(209, 23);
            this.Parse_ProcessId.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Process Id";
            // 
            // Parse_Key
            // 
            this.Parse_Key.Location = new System.Drawing.Point(96, 80);
            this.Parse_Key.Name = "Parse_Key";
            this.Parse_Key.ReadOnly = true;
            this.Parse_Key.Size = new System.Drawing.Size(359, 23);
            this.Parse_Key.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "S3 Key";
            // 
            // Parse_Bucket
            // 
            this.Parse_Bucket.Location = new System.Drawing.Point(96, 51);
            this.Parse_Bucket.Name = "Parse_Bucket";
            this.Parse_Bucket.ReadOnly = true;
            this.Parse_Bucket.Size = new System.Drawing.Size(359, 23);
            this.Parse_Bucket.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "S3 Bucket";
            // 
            // Parse_ResumeName
            // 
            this.Parse_ResumeName.Location = new System.Drawing.Point(96, 167);
            this.Parse_ResumeName.Name = "Parse_ResumeName";
            this.Parse_ResumeName.ReadOnly = true;
            this.Parse_ResumeName.Size = new System.Drawing.Size(209, 23);
            this.Parse_ResumeName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Resume Name";
            // 
            // Parse_Rhuid
            // 
            this.Parse_Rhuid.Location = new System.Drawing.Point(96, 22);
            this.Parse_Rhuid.Name = "Parse_Rhuid";
            this.Parse_Rhuid.ReadOnly = true;
            this.Parse_Rhuid.Size = new System.Drawing.Size(359, 23);
            this.Parse_Rhuid.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "RHUID";
            // 
            // ZEngineGroup
            // 
            this.ZEngineGroup.Controls.Add(this.zengine_version);
            this.ZEngineGroup.Controls.Add(this.zengine_text);
            this.ZEngineGroup.Controls.Add(this.zengine_elastic);
            this.ZEngineGroup.Controls.Add(this.zengine_status);
            this.ZEngineGroup.Controls.Add(this.Status);
            this.ZEngineGroup.Controls.Add(this.zengine_flags);
            this.ZEngineGroup.Controls.Add(this.label8);
            this.ZEngineGroup.Controls.Add(this.zengine_s3);
            this.ZEngineGroup.Controls.Add(this.label9);
            this.ZEngineGroup.Controls.Add(this.zengine_locator);
            this.ZEngineGroup.Controls.Add(this.label10);
            this.ZEngineGroup.Controls.Add(this.zengine_modified);
            this.ZEngineGroup.Controls.Add(this.label11);
            this.ZEngineGroup.Controls.Add(this.zengine_Rhuid);
            this.ZEngineGroup.Controls.Add(this.label12);
            this.ZEngineGroup.Location = new System.Drawing.Point(12, 221);
            this.ZEngineGroup.Name = "ZEngineGroup";
            this.ZEngineGroup.Size = new System.Drawing.Size(776, 201);
            this.ZEngineGroup.TabIndex = 1;
            this.ZEngineGroup.TabStop = false;
            this.ZEngineGroup.Text = "Z-Engine Processing Information";
            // 
            // zengine_version
            // 
            this.zengine_version.Location = new System.Drawing.Point(311, 170);
            this.zengine_version.Name = "zengine_version";
            this.zengine_version.Size = new System.Drawing.Size(144, 15);
            this.zengine_version.TabIndex = 30;
            this.zengine_version.Text = "Version No: ";
            this.zengine_version.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // zengine_text
            // 
            this.zengine_text.Location = new System.Drawing.Point(461, 22);
            this.zengine_text.Multiline = true;
            this.zengine_text.Name = "zengine_text";
            this.zengine_text.ReadOnly = true;
            this.zengine_text.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.zengine_text.Size = new System.Drawing.Size(309, 168);
            this.zengine_text.TabIndex = 29;
            // 
            // zengine_elastic
            // 
            this.zengine_elastic.AutoSize = true;
            this.zengine_elastic.Enabled = false;
            this.zengine_elastic.Location = new System.Drawing.Point(311, 140);
            this.zengine_elastic.Name = "zengine_elastic";
            this.zengine_elastic.Size = new System.Drawing.Size(144, 19);
            this.zengine_elastic.TabIndex = 28;
            this.zengine_elastic.Text = "Stored in ElasticSearch";
            this.zengine_elastic.UseVisualStyleBackColor = true;
            // 
            // zengine_status
            // 
            this.zengine_status.Location = new System.Drawing.Point(96, 138);
            this.zengine_status.Name = "zengine_status";
            this.zengine_status.ReadOnly = true;
            this.zengine_status.Size = new System.Drawing.Size(209, 23);
            this.zengine_status.TabIndex = 27;
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(4, 141);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(39, 15);
            this.Status.TabIndex = 26;
            this.Status.Text = "Status";
            // 
            // zengine_flags
            // 
            this.zengine_flags.Location = new System.Drawing.Point(96, 109);
            this.zengine_flags.Name = "zengine_flags";
            this.zengine_flags.ReadOnly = true;
            this.zengine_flags.Size = new System.Drawing.Size(359, 23);
            this.zengine_flags.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 15);
            this.label8.TabIndex = 24;
            this.label8.Text = "Flags";
            // 
            // zengine_s3
            // 
            this.zengine_s3.Location = new System.Drawing.Point(96, 80);
            this.zengine_s3.Name = "zengine_s3";
            this.zengine_s3.ReadOnly = true;
            this.zengine_s3.Size = new System.Drawing.Size(359, 23);
            this.zengine_s3.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 15);
            this.label9.TabIndex = 22;
            this.label9.Text = "S3 Files";
            // 
            // zengine_locator
            // 
            this.zengine_locator.Location = new System.Drawing.Point(96, 51);
            this.zengine_locator.Name = "zengine_locator";
            this.zengine_locator.ReadOnly = true;
            this.zengine_locator.Size = new System.Drawing.Size(359, 23);
            this.zengine_locator.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 15);
            this.label10.TabIndex = 20;
            this.label10.Text = "Locator Key";
            // 
            // zengine_modified
            // 
            this.zengine_modified.Location = new System.Drawing.Point(96, 167);
            this.zengine_modified.Name = "zengine_modified";
            this.zengine_modified.ReadOnly = true;
            this.zengine_modified.Size = new System.Drawing.Size(209, 23);
            this.zengine_modified.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 170);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 15);
            this.label11.TabIndex = 18;
            this.label11.Text = "Last Modified";
            // 
            // zengine_Rhuid
            // 
            this.zengine_Rhuid.Location = new System.Drawing.Point(96, 22);
            this.zengine_Rhuid.Name = "zengine_Rhuid";
            this.zengine_Rhuid.ReadOnly = true;
            this.zengine_Rhuid.Size = new System.Drawing.Size(359, 23);
            this.zengine_Rhuid.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 15);
            this.label12.TabIndex = 16;
            this.label12.Text = "RHUID";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(705, 429);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(108, 429);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Toggle Info";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // CandidateDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 460);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ZEngineGroup);
            this.Controls.Add(this.ParsingGroup);
            this.Name = "CandidateDetail";
            this.Text = "Candidate Parsing Details";
            this.Shown += new System.EventHandler(this.CandidateDetail_Shown);
            this.ParsingGroup.ResumeLayout(false);
            this.ParsingGroup.PerformLayout();
            this.ZEngineGroup.ResumeLayout(false);
            this.ZEngineGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ParsingGroup;
        private System.Windows.Forms.GroupBox ZEngineGroup;
        private System.Windows.Forms.TextBox Parse_ResumeName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Parse_Rhuid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Parse_Bucket;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Parse_Key;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Parse_Text;
        private System.Windows.Forms.CheckBox Parse_Valid;
        private System.Windows.Forms.CheckBox Parse_Stored;
        private System.Windows.Forms.CheckBox Parse_Quality;
        private System.Windows.Forms.TextBox Parse_Date;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Parse_ProcessId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox zengine_text;
        private System.Windows.Forms.CheckBox zengine_elastic;
        private System.Windows.Forms.TextBox zengine_status;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.TextBox zengine_flags;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox zengine_s3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox zengine_locator;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox zengine_modified;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox zengine_Rhuid;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label zengine_version;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}