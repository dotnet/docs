//<Snippet1>
using System;
using System.Collections; 
using System.Windows.Forms;

public class ListViewGroupsExample : Form
{
    private ListView myListView;

    // Determine whether Windows XP or a later
    // operating system is present.
    private bool isRunningXPOrLater = 
        OSFeature.Feature.IsPresent(OSFeature.Themes);

    // Declare a Hashtable array in which to store the groups.
    private Hashtable[] groupTables;

    // Declare a variable to store the current grouping column.
    int groupColumn = 0;

    public ListViewGroupsExample()
    {
        // Initialize myListView.
        myListView = new ListView();
        myListView.Dock = DockStyle.Fill;
        myListView.View = View.Details;
        myListView.Sorting = SortOrder.Ascending;

        // Create and initialize column headers for myListView.
        ColumnHeader columnHeader0 = new ColumnHeader();
        columnHeader0.Text = "Title";
        columnHeader0.Width = -1;
        ColumnHeader columnHeader1 = new ColumnHeader();
        columnHeader1.Text = "Author";
        columnHeader1.Width = -1;
        ColumnHeader columnHeader2 = new ColumnHeader();
        columnHeader2.Text = "Year";
        columnHeader2.Width = -1;

        // Add the column headers to myListView.
        myListView.Columns.AddRange(new ColumnHeader[] 
            {columnHeader0, columnHeader1, columnHeader2});

        // Add a handler for the ColumnClick event.
        myListView.ColumnClick += 
            new ColumnClickEventHandler(myListView_ColumnClick);

        // Create items and add them to myListView.
        ListViewItem item0 = new ListViewItem( new string[] 
            {"Programming Windows", 
            "Petzold, Charles", 
            "1998"} );
        ListViewItem item1 = new ListViewItem( new string[] 
            {"Code: The Hidden Language of Computer Hardware and Software", 
            "Petzold, Charles", 
            "2000"} );
        ListViewItem item2 = new ListViewItem( new string[] 
            {"Programming Windows with C#", 
            "Petzold, Charles", 
            "2001"} );
        ListViewItem item3 = new ListViewItem( new string[] 
            {"Coding Techniques for Microsoft Visual Basic .NET", 
            "Connell, John", 
            "2001"} );
        ListViewItem item4 = new ListViewItem( new string[] 
            {"C# for Java Developers", 
            "Jones, Allen & Freeman, Adam", 
            "2002"} );
        ListViewItem item5 = new ListViewItem( new string[] 
            {"Microsoft .NET XML Web Services Step by Step", 
            "Jones, Allen & Freeman, Adam", 
            "2002"} );
        myListView.Items.AddRange(
            new ListViewItem[] {item0, item1, item2, item3, item4, item5});

        if (isRunningXPOrLater)
        {
            // Create the groupsTable array and populate it with one 
            // hash table for each column.
            groupTables = new Hashtable[myListView.Columns.Count];
            for (int column = 0; column < myListView.Columns.Count; column++)
            {
                // Create a hash table containing all the groups 
                // needed for a single column.
                groupTables[column] = CreateGroupsTable(column);
            }

            // Start with the groups created for the Title column.
            SetGroups(0);
        }

        // Initialize the form.
        this.Controls.Add(myListView);
        this.Size = new System.Drawing.Size(550, 330);
        this.Text = "ListView Groups Example";
    }

    [STAThread]
    static void Main() 
    {
        Application.EnableVisualStyles();
        Application.Run(new ListViewGroupsExample());
    }

    // Groups the items using the groups created for the clicked 
    // column.
    private void myListView_ColumnClick(
        object sender, ColumnClickEventArgs e)
    {
        // Set the sort order to ascending when changing
        // column groups; otherwise, reverse the sort order.
        if ( myListView.Sorting == SortOrder.Descending || 
            ( isRunningXPOrLater && (e.Column != groupColumn) ) )
        {
            myListView.Sorting = SortOrder.Ascending;
        }
        else 
        {
            myListView.Sorting = SortOrder.Descending;
        }
        groupColumn = e.Column;

        // Set the groups to those created for the clicked column.
        if (isRunningXPOrLater)
        {
            SetGroups(e.Column);
        }
    }

    //<Snippet2>
    // Sets myListView to the groups created for the specified column.
    private void SetGroups(int column)
    {
        // Remove the current groups.
        myListView.Groups.Clear();

        // Retrieve the hash table corresponding to the column.
        Hashtable groups = (Hashtable)groupTables[column];

        // Copy the groups for the column to an array.
        ListViewGroup[] groupsArray = new ListViewGroup[groups.Count];
        groups.Values.CopyTo(groupsArray, 0);

        // Sort the groups and add them to myListView.
        Array.Sort(groupsArray, new ListViewGroupSorter(myListView.Sorting));
        myListView.Groups.AddRange(groupsArray);

        // Iterate through the items in myListView, assigning each 
        // one to the appropriate group.
        foreach (ListViewItem item in myListView.Items)
        {
            // Retrieve the subitem text corresponding to the column.
            string subItemText = item.SubItems[column].Text;

            // For the Title column, use only the first letter.
            if (column == 0) 
            {
                subItemText = subItemText.Substring(0, 1);
            }

            // Assign the item to the matching group.
            item.Group = (ListViewGroup)groups[subItemText];
        }
    }
    //</Snippet2>

    //<Snippet3>
    // Creates a Hashtable object with one entry for each unique
    // subitem value (or initial letter for the parent item)
    // in the specified column.
    private Hashtable CreateGroupsTable(int column)
    {
        // Create a Hashtable object.
        Hashtable groups = new Hashtable();

        // Iterate through the items in myListView.
        foreach (ListViewItem item in myListView.Items)
        {
            // Retrieve the text value for the column.
            string subItemText = item.SubItems[column].Text;

            // Use the initial letter instead if it is the first column.
            if (column == 0) 
            {
                subItemText = subItemText.Substring(0, 1);
            }

            // If the groups table does not already contain a group
            // for the subItemText value, add a new group using the 
            // subItemText value for the group header and Hashtable key.
            if (!groups.Contains(subItemText))
            {
                groups.Add( subItemText, new ListViewGroup(subItemText, 
                    HorizontalAlignment.Left) );
            }
        }

        // Return the Hashtable object.
        return groups;
    }
    //</Snippet3>

    // Sorts ListViewGroup objects by header value.
    private class ListViewGroupSorter : IComparer
    {
        private SortOrder order;

        // Stores the sort order.
        public ListViewGroupSorter(SortOrder theOrder) 
        { 
            order = theOrder;
        }

        // Compares the groups by header value, using the saved sort
        // order to return the correct value.
        public int Compare(object x, object y)
        {
            int result = String.Compare(
                ((ListViewGroup)x).Header,
                ((ListViewGroup)y).Header
            );
            if (order == SortOrder.Ascending)
            {
                return result;
            }
            else 
            {
                return -result;
            }
        }
    }

}
//</Snippet1>