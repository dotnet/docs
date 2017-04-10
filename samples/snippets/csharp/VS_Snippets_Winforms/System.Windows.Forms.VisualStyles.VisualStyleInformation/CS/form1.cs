//<Snippet0>
// This is a simple example for VisualStyleInformation that displays
// all of the visual style values in a ListView.


using System;
using System.Drawing;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace VisualStyleInformationSample
{
	public class Form1 : Form
	{
		private ListView listView1 = new ListView();

		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.Run(new Form1());
		}

		public Form1()
		{
			this.ClientSize = new Size(500, 500);
			this.Text = "VisualStyleInformation Property Values";

			listView1.Bounds = new Rectangle(new Point(10, 10),
				new Size(400, 300));
			listView1.View = View.Details;
			listView1.FullRowSelect = true;
			listView1.Sorting = SortOrder.Ascending;

			Type typeInfo = typeof(VisualStyleInformation);
			StringBuilder name = new StringBuilder();
			object propertyValue;

			// Declare an array of static/Shared property details for the
			// VisualStyleInformation class.
			PropertyInfo[] elementProperties =
				typeInfo.GetProperties(BindingFlags.Static | BindingFlags.Public);

			// Insert each property name and value into the ListView.
			foreach (PropertyInfo property in elementProperties)
			{
				name.Append(property.Name);
				propertyValue = property.GetValue(null,
					BindingFlags.Static, null, null, null);
				ListViewItem newItem = new ListViewItem(name.ToString(), 0);
				newItem.SubItems.Add(propertyValue.ToString());
				listView1.Items.Add(newItem);
				name.Remove(0, name.Length);
			}

			// Create columns for the items and subitems.
			listView1.Columns.Add("Property", -2, System.Windows.Forms.HorizontalAlignment.Left);
			listView1.Columns.Add("Value", -2, System.Windows.Forms.HorizontalAlignment.Left);

			// Add the ListView to the control collection.
			this.Controls.Add(listView1);
		}
	}
}
//</Snippet0>