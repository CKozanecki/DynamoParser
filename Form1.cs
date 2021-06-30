using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
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

        readonly DynamoParseInfo<CandidateParseItem> log;
        readonly DynamoParseInfo<ZEngineParseItem> log2;
        private delegate void LoadListCallback();

        private void ExecuteLoadList()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(LoadList));
        }

        private void LoadList(object unused)
        {
            Cursor.Current = Cursors.WaitCursor;
            var noderoot = treeView1.Nodes[0];
            
            foreach (var item in log.Items)
            {
                if (checkBox1.Checked ||( item.StoredInEs.BOOL.HasValue && !item.StoredInEs.BOOL.Value))
                {
                    if (!item.rawFileKey.S.Contains("Batch")) continue;

                    var batchNumber = item.rawFileKey.S.Substring(item.rawFileKey.S.IndexOf("Batch"), item.rawFileKey.S.IndexOf('/', item.rawFileKey.S.IndexOf("Batch")) - item.rawFileKey.S.IndexOf("Batch"));
                    if(!noderoot.Nodes.ContainsKey(batchNumber))
                    {
                        var treeNode = new TreeNode { Text = batchNumber, Name = batchNumber };
                        UpdateTreeNodes(noderoot, treeNode);
                        toolStripStatusLabel1.Text = "Adding New Batch Number";
                    }
                    var parentNode = noderoot.Nodes[batchNumber];
                    var candidate = new TreeNode { Text = item.rawFileName.S, Name = item.rawFileName.S };
                    UpdateTreeNodes(parentNode, candidate);
                    toolStripStatusLabel1.Text = string.Format("Adding Candidate ID: {0} from {1}", item.rawFileName.S, parentNode.Text);
                }
            }
            Cursor.Current = Cursors.Default;
            toolStripStatusLabel1.Text = "Candidates Loaded";
            Thread.Sleep(1);
            toolStripStatusLabel1.Text = "Refreshing tree view and sorting candidates";
            InvokeSort();
        }

        private void TreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var item1 = log.Items.SingleOrDefault(item => item.rawFileName.S == e.Node.Text);
            if (item1 != null)
            {

                var sb = new StringBuilder();
                sb.AppendLine("QUALITY TEXT (Sovren):");
                sb.AppendLine("-------------------------------------------------------------------------");
                if (item1.isValid.BOOL.HasValue && !item1.isValid.BOOL.Value)
                    sb.AppendLine("Invalid Resume => No parsing Info");
                else
                {
                    foreach (var map in item1.qualityText.L)
                    {
                        foreach (var item in map.M)
                        {
                            sb.AppendLine(string.Format("{0}: {1}", item.Key, item.Value.S));
                        }
                    }
                    sb.AppendLine("-------------------------------------------------------------------------");
                    sb.AppendLine();
                    sb.AppendLine("Passport (z-Engine):");
                    sb.AppendLine("-------------------------------------------------------------------------");

                    var item2 = log2.Items.SingleOrDefault(item => item.RHUID.S == item1.RHUID.S);
                    if (item2 != null)
                    {
                        if (item2?.Passport?.L == null || item2.Passport.L.Count == 0)
                            sb.AppendLine("No Passport Info");
                        else
                        {
                            foreach (var map in item2.Passport.L)
                            {
                                foreach (var item in map.M)
                                {
                                    sb.AppendLine(string.Format("{0}: {1}", item.Key, item.Value.S));
                                }
                            }
                        }
                    }
                    else sb.AppendLine("No Passport Info");
                    sb.AppendLine("-------------------------------------------------------------------------");
                }
                textBox1.Text = sb.ToString();
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Reloading Candidates";
            ExecuteLoadList();
        }

        private void UpdateTreeNodes(TreeNode parent, TreeNode node)
        {
            if (treeView1.InvokeRequired)
                treeView1.Invoke(new Action<TreeNode,TreeNode>(UpdateTreeNodes), parent, node);
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
                toolStripStatusLabel1.Text = "Ready";
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            ExecuteLoadList();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var item = log.Items.SingleOrDefault(item => item.RHUID.S == textBox2.Text || item.rawFileKey.S.Contains(textBox2.Text));
            var node = treeView1.Nodes.Find(item.rawFileName.S, true);
            if (node == null || node.Length ==0)
            {
                MessageBox.Show("Unable to find item in treeview.  Please try again with successes included");
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
            var item1 = log.Items.SingleOrDefault(item => item.rawFileName.S == node.Text);
            ZEngineParseItem item2 = null;
            if (item1 != null)
            {
                item2 = log2.Items.SingleOrDefault(item => item.RHUID.S == item1.RHUID.S);
            }
            var form2 = new CandidateDetail { CandidateParseRecord = item1, ZEngineRecord = item2 };
            form2.Show();
        }
    }
}
