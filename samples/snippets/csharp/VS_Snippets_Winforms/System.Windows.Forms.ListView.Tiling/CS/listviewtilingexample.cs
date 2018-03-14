//<Snippet1>
using System;
using System.Drawing;
using System.Windows.Forms;

public class ListViewTilingExample : Form
{
    private ImageList myImageList;

    public ListViewTilingExample()
    {
        // Initialize myListView.
        ListView myListView = new ListView();
        myListView.Dock = DockStyle.Fill;
        myListView.View = View.Tile;

        // Initialize the tile size.
        myListView.TileSize = new Size(400, 45);
        
        // Initialize the item icons.
        myImageList = new ImageList();
        using (Icon myIcon = new Icon("book.ico"))
        {
            myImageList.Images.Add(myIcon);
        }
        myImageList.ImageSize = new Size(32, 32);
        myListView.LargeImageList = myImageList;
        
        // Add column headers so the subitems will appear.
        myListView.Columns.AddRange(new ColumnHeader[] 
            {new ColumnHeader(), new ColumnHeader(), new ColumnHeader()});

        // Create items and add them to myListView.
        ListViewItem item0 = new ListViewItem( new string[] 
            {"Programming Windows", 
            "Petzold, Charles", 
            "1998"}, 0 );
        ListViewItem item1 = new ListViewItem( new string[] 
            {"Code: The Hidden Language of Computer Hardware and Software", 
            "Petzold, Charles", 
            "2000"}, 0 );
        ListViewItem item2 = new ListViewItem( new string[] 
            {"Programming Windows with C#", 
            "Petzold, Charles", 
            "2001"}, 0 );
        ListViewItem item3 = new ListViewItem( new string[] 
            {"Coding Techniques for Microsoft Visual Basic .NET", 
            "Connell, John", 
            "2001"}, 0 );
        ListViewItem item4 = new ListViewItem( new string[] 
            {"C# for Java Developers", 
            "Jones, Allen & Freeman, Adam", 
            "2002"}, 0 );
        ListViewItem item5 = new ListViewItem( new string[] 
            {"Microsoft .NET XML Web Services Step by Step", 
            "Jones, Allen & Freeman, Adam", 
            "2002"}, 0 );
        myListView.Items.AddRange(
            new ListViewItem[] {item0, item1, item2, item3, item4, item5});
                  
        // Initialize the form.
        this.Controls.Add(myListView);
        this.Size = new System.Drawing.Size(430, 330);
        this.Text = "ListView Tiling Example";
    }

    // Clean up any resources being used.        
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            myImageList.Dispose();
        }
        base.Dispose(disposing);
    }

    [STAThread]
    static void Main() 
    {
        Application.EnableVisualStyles();
        Application.Run(new ListViewTilingExample());
    }

}
//</Snippet1>