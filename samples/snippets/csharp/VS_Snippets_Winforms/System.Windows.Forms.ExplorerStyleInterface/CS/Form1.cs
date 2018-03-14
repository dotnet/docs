using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
//<snippet4>
using System.IO;
//</snippet4>
namespace ExplorerStyleInterface
{
    public class Form1 : Form
    {
        private SplitContainer splitContainer1;
		private TreeView treeView1;
		private ImageList imageList1;
		private IContainer components;
		private ColumnHeader nameColumn;
		private ColumnHeader typeColumn;
		private ColumnHeader modifiedColumn;
        private ListView listView1;
    
		//<snippet2>
		public Form1()
		{
			InitializeComponent();
			PopulateTreeView();
		}
		//</snippet2>
		//<snippet3>
		void treeView1_NodeMouseClick(object sender,
			TreeNodeMouseClickEventArgs e) 
		{
			TreeNode newSelected = e.Node;
			listView1.Items.Clear();
			DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;
			ListViewItem.ListViewSubItem[] subItems;
			ListViewItem item = null;

			foreach (DirectoryInfo dir in nodeDirInfo.GetDirectories())
			{
				item = new ListViewItem(dir.Name, 0);
				subItems = new ListViewItem.ListViewSubItem[]
                    {new ListViewItem.ListViewSubItem(item, "Directory"), 
                     new ListViewItem.ListViewSubItem(item, 
						dir.LastAccessTime.ToShortDateString())};
				item.SubItems.AddRange(subItems);
				listView1.Items.Add(item);
			}
			foreach (FileInfo file in nodeDirInfo.GetFiles())
			{
				item = new ListViewItem(file.Name, 1);
				subItems = new ListViewItem.ListViewSubItem[]
                    { new ListViewItem.ListViewSubItem(item, "File"), 
                     new ListViewItem.ListViewSubItem(item, 
						file.LastAccessTime.ToShortDateString())};

				item.SubItems.AddRange(subItems);
				listView1.Items.Add(item);
			}

			listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
		}
		//</snippet3>
        
	//<snippet1>
        private void PopulateTreeView()
        {
            TreeNode rootNode;
			
			DirectoryInfo info = new DirectoryInfo(@"../..");
            if (info.Exists)
            {
                rootNode = new TreeNode(info.Name);
                rootNode.Tag = info;
                GetDirectories(info.GetDirectories(), rootNode);
                treeView1.Nodes.Add(rootNode);
            }
        }

        private void GetDirectories(DirectoryInfo[] subDirs, 
			TreeNode nodeToAddTo)
        {
            TreeNode aNode;
            DirectoryInfo[] subSubDirs;
            foreach (DirectoryInfo subDir in subDirs)
            {
                aNode = new TreeNode(subDir.Name, 0, 0);
                aNode.Tag = subDir;
				aNode.ImageKey = "folder";
                subSubDirs = subDir.GetDirectories();
                if (subSubDirs.Length != 0)
                {
                    GetDirectories(subSubDirs, aNode);
                }
                nodeToAddTo.Nodes.Add(aNode);
            }
        }
	//</snippet1>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }

        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.listView1 = new System.Windows.Forms.ListView();
			this.nameColumn = new System.Windows.Forms.ColumnHeader("");
			this.typeColumn = new System.Windows.Forms.ColumnHeader("");
			this.modifiedColumn = new System.Windows.Forms.ColumnHeader("");
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.treeView1);
			// 
			// Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.listView1);
			this.splitContainer1.Size = new System.Drawing.Size(492, 466);
			this.splitContainer1.SplitterDistance = 166;
			this.splitContainer1.TabIndex = 0;
			this.splitContainer1.Text = "splitContainer1";
			// 
			// treeView1
			// 
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView1.ImageList = this.imageList1;
			this.treeView1.Location = new System.Drawing.Point(0, 0);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(166, 466);
			this.treeView1.TabIndex = 0;
			//<snippet5>
			this.treeView1.NodeMouseClick += 
				new TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
			//</snippet5>			
		 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.Images.SetKeyName(0, "FOLDER.ICO");
			this.imageList1.Images.SetKeyName(1, "DOC.ICO");
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumn,
            this.typeColumn,
            this.modifiedColumn});
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.Location = new System.Drawing.Point(0, 0);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(322, 466);
			this.listView1.SmallImageList = this.imageList1;
			this.listView1.TabIndex = 0;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// nameColumn
			// 
			this.nameColumn.Text = "Name";
			this.nameColumn.Width = 82;
			// 
			// typeColumn
			// 
			this.typeColumn.Text = "Type";
			this.typeColumn.Width = 78;
			// 
			// modifiedColumn
			// 
			this.modifiedColumn.Text = "Last Modified";
			this.modifiedColumn.Width = 109;
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(492, 466);
			this.Controls.Add(this.splitContainer1);
			this.Name = "Form1";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
    }
}