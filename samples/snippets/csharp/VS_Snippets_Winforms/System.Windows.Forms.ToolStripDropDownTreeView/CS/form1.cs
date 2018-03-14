//<Snippet1>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;

public class Form1 : Form
{
    public Form1()
    {
        MyTreeViewCombo treeCombo = new MyTreeViewCombo();
        treeCombo.TreeView.Nodes.Add("one");
        treeCombo.TreeView.Nodes.Add("two");
        treeCombo.TreeView.Nodes.Add("three");
        this.Controls.Add(treeCombo);
    }
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());
    }

    [SecurityPermissionAttribute(
        SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
    public class MyTreeViewCombo : ComboBox
    {   
        ToolStripControlHost treeViewHost;
        ToolStripDropDown dropDown;
        public MyTreeViewCombo()
        {
            TreeView treeView = new TreeView();
            treeView.BorderStyle = BorderStyle.None;
            treeViewHost = new ToolStripControlHost(treeView);
            dropDown = new ToolStripDropDown();
            dropDown.Items.Add(treeViewHost);
        }

        public TreeView TreeView
        {
            get { return treeViewHost.Control as TreeView; }
        }

        private void ShowDropDown()
        {
            if (dropDown != null)
            {
                treeViewHost.Width = DropDownWidth;
                treeViewHost.Height = DropDownHeight;
                dropDown.Show(this, 0, this.Height);
            }
        }

        private const int WM_USER = 0x0400,
                          WM_REFLECT = WM_USER + 0x1C00,
                          WM_COMMAND = 0x0111,
                          CBN_DROPDOWN = 7;

        public static int HIWORD(int n)
        {
            return (n >> 16) & 0xffff;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == (WM_REFLECT + WM_COMMAND))
            {
                if (HIWORD((int)m.WParam) == CBN_DROPDOWN)
                {
                    ShowDropDown();
                    return;
                }
            }
            base.WndProc(ref m);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (dropDown != null)
                {
                    dropDown.Dispose();
                    dropDown = null;
                }
            }
            base.Dispose(disposing);
        }
    }
}
//</Snippet1>