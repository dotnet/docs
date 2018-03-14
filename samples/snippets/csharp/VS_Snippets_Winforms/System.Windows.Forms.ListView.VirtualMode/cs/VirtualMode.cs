//<snippet1>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;

public class Form1 : Form
{
    private ListViewItem[] myCache; //array to cache items for the virtual list
    private int firstItem; //stores the index of the first item in the cache

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());
    }

    public Form1()
    {
        //Create a simple ListView.
        ListView listView1 = new ListView();
        listView1.View = View.SmallIcon;
        listView1.VirtualMode = true;
        listView1.VirtualListSize = 10000;

        //Hook up handlers for VirtualMode events.
        listView1.RetrieveVirtualItem += new RetrieveVirtualItemEventHandler(listView1_RetrieveVirtualItem);
        listView1.CacheVirtualItems += new CacheVirtualItemsEventHandler(listView1_CacheVirtualItems);
        listView1.SearchForVirtualItem += new SearchForVirtualItemEventHandler(listView1_SearchForVirtualItem);

        //Add ListView to the form.
        this.Controls.Add(listView1);

        //Search for a particular virtual item.
        //Notice that we never manually populate the collection!
        //If you leave out the SearchForVirtualItem handler, this will return null.
        ListViewItem lvi = listView1.FindItemWithText("111111");

        //Select the item found and scroll it into view.
        if (lvi != null)
        {
            listView1.SelectedIndices.Add(lvi.Index);
            listView1.EnsureVisible(lvi.Index);
        }
    }

    //<snippet2>
    //The basic VirtualMode function.  Dynamically returns a ListViewItem
    //with the required properties; in this case, the square of the index.
    void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
    {
        //Caching is not required but improves performance on large sets.
        //To leave out caching, don't connect the CacheVirtualItems event 
        //and make sure myCache is null.

        //check to see if the requested item is currently in the cache
        if (myCache != null && e.ItemIndex >= firstItem && e.ItemIndex < firstItem + myCache.Length)
        {
            //A cache hit, so get the ListViewItem from the cache instead of making a new one.
            e.Item = myCache[e.ItemIndex - firstItem];
        }
        else
        {
            //A cache miss, so create a new ListViewItem and pass it back.
            int x = e.ItemIndex * e.ItemIndex;
            e.Item = new ListViewItem(x.ToString());
        }
    }
    //</snippet2>

    //<snippet3>
    //Manages the cache.  ListView calls this when it might need a 
    //cache refresh.
    void listView1_CacheVirtualItems(object sender, CacheVirtualItemsEventArgs e)
    {
        //We've gotten a request to refresh the cache.
        //First check if it's really neccesary.
        if (myCache != null && e.StartIndex >= firstItem && e.EndIndex <= firstItem + myCache.Length)
        {
            //If the newly requested cache is a subset of the old cache, 
            //no need to rebuild everything, so do nothing.
            return;
        }

        //Now we need to rebuild the cache.
        firstItem = e.StartIndex;
        int length = e.EndIndex - e.StartIndex + 1; //indexes are inclusive
        myCache = new ListViewItem[length];
        
        //Fill the cache with the appropriate ListViewItems.
        int x = 0;
        for (int i = 0; i < length; i++)
        {
            x = (i + firstItem) * (i + firstItem);
            myCache[i] = new ListViewItem(x.ToString());
        }

    }
    //</snippet3>

    //<snippet4>
    //This event handler enables search functionality, and is called
    //for every search request when in Virtual mode.
    void listView1_SearchForVirtualItem(object sender, SearchForVirtualItemEventArgs e)
    {
        //We've gotten a search request.
        //In this example, finding the item is easy since it's
        //just the square of its index.  We'll take the square root
        //and round.
        double x = 0;
        if (Double.TryParse(e.Text, out x)) //check if this is a valid search
        {
            x = Math.Sqrt(x);
            x = Math.Round(x);
            e.Index = (int)x;
               
        }
        //If e.Index is not set, the search returns null.
        //Note that this only handles simple searches over the entire
        //list, ignoring any other settings.  Handling Direction, StartIndex,
        //and the other properties of SearchForVirtualItemEventArgs is up
        //to this handler.
    }
    //</snippet4>
}
//</snippet1>