using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace SplitterEx
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			CreateMySplitControls();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		//<snippet1>
		private void CreateMySplitControls()
		{
			// Create TreeView, ListView, and Splitter controls.
			TreeView treeView1 = new TreeView();
			ListView listView1 = new ListView();
			Splitter splitter1 = new Splitter();

			// Set the TreeView control to dock to the left side of the form.
			treeView1.Dock = DockStyle.Left;
			// Set the Splitter to dock to the left side of the TreeView control.
			splitter1.Dock = DockStyle.Left;
			// Set the minimum size the ListView control can be sized to.
			splitter1.MinExtra = 100;
			// Set the minimum size the TreeView control can be sized to.
			splitter1.MinSize = 75;
			// Set the ListView control to fill the remaining space on the form.
			listView1.Dock = DockStyle.Fill;
			// Add a TreeView and a ListView item to identify the controls on the form.
            treeView1.Nodes.Add("TreeView Node");
            listView1.Items.Add("ListView Item");

			// Add the controls in reverse order to the form to ensure proper location.
			this.Controls.AddRange(new Control[]{listView1, splitter1, treeView1});
		}
		//</snippet1>

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(384, 365);
			this.Name = "Form1";
			this.Text = "Form1";

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
	}
}
