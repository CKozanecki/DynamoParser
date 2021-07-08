using DynamoParser.JsonObjects;
using DynamoParser.Poco;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamoParser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            log = JsonSerializer.Deserialize<DynamoParseInfo<CandidateParseItem>>(
                File.ReadAllText(
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CandidateParsingInfo.Json")
                    )
                );
            log2 = JsonSerializer.Deserialize<DynamoParseInfo<ZEngineParseItem>>(
                File.ReadAllText(
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ZEngineParsingInfo.json")
                    )
                );
        }

        private readonly DynamoParseInfo<CandidateParseItem> log;
        private readonly DynamoParseInfo<ZEngineParseItem> log2;
        private List<LogDataPoco> resultSet;
        private int failCount;

        private void ProcessCandidates(object unused)
        {
            if (resultSet == null)
                resultSet = PocoBuilder.BuildAllObjects(log, log2, InvokeStatusUpdate);

            ThreadPool.QueueUserWorkItem(new WaitCallback(LoadList));
        }

        private void LoadList(object unused)
        {
            var noderoot = treeView1.Nodes[0];

            var batches = resultSet.Select(res => res.BatchNumber).Distinct();

            foreach (var name in batches)
            {
                var treeNode = new TreeNode { Text = name, Name = name };
                InvokeUpdateTreeNodes(noderoot, treeNode);
            }

            Parallel.ForEach(resultSet, item =>
            {
                if (checkBox1.Checked || item.IsFailureRecord)
                {
                    var parentNode = noderoot.Nodes[item.BatchNumber];
                    var candidate = new TreeNode { Text = item.RawFileName, Name = item.RawFileName };
                    if (item.IsFailureRecord)
                        failCount++;
                    InvokeUpdateTreeNodes(parentNode, candidate);
                }
            });
            InvokeStatusUpdate("Adding New Batch Number(s)");
            InvokeStatusUpdate("Candidates Loaded");
            Thread.Sleep(1);
            InvokeStatusUpdate("Refreshing tree view and sorting candidates");
            InvokeSort();
        }

        private void TreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var item = resultSet.SingleOrDefault(item => item.RawFileName == e.Node.Text);
            textBox1.Text = item.FailureText;
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Enabled = false;
            InvokeStatusUpdate("Reloading Candidates");
            treeView1.Nodes[0].Nodes.Clear();
            failCount = 0;
            ThreadPool.QueueUserWorkItem(new WaitCallback(ProcessCandidates));
        }

        private void InvokeUpdateTreeNodes(TreeNode parent, TreeNode node)
        {
            if (treeView1.InvokeRequired)
                treeView1.Invoke(new Action<TreeNode,TreeNode>(InvokeUpdateTreeNodes), parent, node);
            else
                parent.Nodes.Add(node);
        }

        private void InvokeSort()
        {
            if (treeView1.InvokeRequired)
                treeView1.Invoke(new Action(InvokeSort));
            else
            {
                treeView1.Sort();
                Cursor.Current = Cursors.Default;
                Enabled = true;
                resultSet.Count();
                InvokeStatusUpdate($"Ready.  Loaded {failCount} failures. Processed {resultSet.Count()} records.");
            }
        }

        private void InvokeStatusUpdate(string value)
        {
            if (statusStrip1.InvokeRequired)
                statusStrip1.Invoke(new Action<string>(InvokeStatusUpdate), value);
            else
                toolStripStatusLabel1.Text = value;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Enabled = false;
            ThreadPool.QueueUserWorkItem(new WaitCallback(ProcessCandidates));
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var item = resultSet.SingleOrDefault(item => item.RHUID.ToString() == textBox2.Text || item.RawFileKey.Contains(textBox2.Text));
            
            var node = treeView1.Nodes.Find(item.RawFileName, true);
            if (node == null || node.Length == 0 )
            {
                MessageBox.Show("Unable to find item in treeview.  Please try again with successes included");
                return;
            }
            else
            {
                treeView1.SelectedNode = node[0];
                treeView1.Select();
                TreeView1_NodeMouseClick(treeView1, new TreeNodeMouseClickEventArgs(node[0], MouseButtons.Left, 1, 0, 0));
            }
        }

        private void TextBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return) return;
            Button1_Click(button1, null);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var node = treeView1.SelectedNode;
            if (node == null)
            {
                MessageBox.Show("Please Select an item from the tree or search for a candidate");
                return;
            }
            var item = resultSet.SingleOrDefault(item => item.RawFileName == node.Text);
            var form2 = new CandidateDetail(item);
            form2.Show();
        }
    }
}
