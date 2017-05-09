using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Xml;


public class Form1 : Form
{
    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new Form1());
    }

    ListView listView1 = new ListView();
    ImageList imageList1 = new ImageList();
    // 1b35a80a-edd8-495f-a807-a28c4aae52c6
    // How to: Add and Remove Items with the Windows Forms ListView Control

    public void Method11()
    {
        // <snippet11>
        // Adds a new item with ImageIndex 3
        listView1.Items.Add("List item text", 3);

        // </snippet11>
    }
    public void Method12()
    {
        // <snippet12>
        // Removes the first item in the list.
        listView1.Items.RemoveAt(0);
        // Clears all the items.
        listView1.Items.Clear();

        // </snippet12>
    }
    // 610416a1-8da4-436c-af19-5f19e654769b
    // How to: Group Items in a Windows Forms ListView Control

    public void Method21()
    {
        // <snippet21>
        // Adds a new group that has a left-aligned header
        listView1.Groups.Add(new ListViewGroup("List item text",
            HorizontalAlignment.Left));
        // </snippet21>
    }
    public void Method22()
    {
        // <snippet22>
        // Removes the first group in the collection.
        listView1.Groups.RemoveAt(0);
        // Clears all groups.
        listView1.Groups.Clear();
        // </snippet22>
    }
    public void Method23()
    {
        // <snippet23>
        // Adds the first item to the first group
        listView1.Items[0].Group = listView1.Groups[0];
        // </snippet23>
    }
    // 79174274-12ee-4a5d-80db-6ec02976d010
    // How to: Add Columns to the Windows Forms ListView Control

    public void Method31()
    {
        // <snippet31>
        // Set to details view.
        listView1.View = View.Details;
        // Add a column with width 20 and left alignment.
        listView1.Columns.Add("File type", 20, HorizontalAlignment.Left);

        // </snippet31>
    }
    // 9d577542-8595-429b-99e5-078770ec9d35
    // How to: Display Icons for the Windows Forms ListView Control

    public void Method41()
    {
        // <snippet41>
        listView1.SmallImageList = imageList1;

        // </snippet41>
    }
    public void Method42()
    {
        // <snippet42>
        // Sets the first list item to display the 4th image.
        listView1.Items[0].ImageIndex = 3;

        // </snippet42>
    }
    // c20e67a3-2d94-413d-9fcf-ecbd0fe251da
    // How to: Enable Tile View in a Windows Forms ListView Control

    public void Method51()
    {
        // <snippet51>
        listView1.View = View.Tile;
        // </snippet51>
    }
    // e465f044-cde7-4fd9-a687-788a73a0f554
    // How to: Display Subitems in Columns with the Windows Forms ListView Control

    public void Method61()
    {
        // <snippet61>
        // Adds two subitems to the first list item.
        listView1.Items[0].SubItems.Add("John Smith");
        listView1.Items[0].SubItems.Add("Accounting");

        // </snippet61>
    }
}

