using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace ListSnippets
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();
        }

        void WindowLoaded(Object sender, RoutedEventArgs args)
        {
            ListProps();
            ListConsts();
            ListItemsProp();
        }

        void ListProps()
        {
            // <Snippet_List_Props>
            List listx = new List();
            // Set the space between the markers and list content to 25 DIP.
            listx.MarkerOffset = 25;
            // Use uppercase Roman numerals.
            listx.MarkerStyle = TextMarkerStyle.UpperRoman;
            // Start list numbering at 5.
            listx.StartIndex = 5;

            // Create the list items that will go into the list.
            ListItem liV = new ListItem(new Paragraph(new Run("Boron")));
            ListItem liVI = new ListItem(new Paragraph(new Run("Carbon")));
            ListItem liVII = new ListItem(new Paragraph(new Run("Nitrogen")));
            ListItem liVIII = new ListItem(new Paragraph(new Run("Oxygen")));
            ListItem liIX = new ListItem(new Paragraph(new Run("Fluorine")));
            ListItem liX = new ListItem(new Paragraph(new Run("Neon")));

            // Finally, add the list items to the list.
            listx.ListItems.Add(liV);
            listx.ListItems.Add(liVI);
            listx.ListItems.Add(liVII);
            listx.ListItems.Add(liVIII);
            listx.ListItems.Add(liIX);
            listx.ListItems.Add(liX);
            // </Snippet_List_Props>
        }

        void ListConsts()
        {

            // <Snippet_List_Const>
            // This line uses the ListItem constructor to create a new ListItem
            // and initialize it with the specified Paragraph.
            ListItem lix = new ListItem(new Paragraph(new Run("ListItem text...")));
            // This line uses the List constructor to create a new List and populate
            // it with the previously created ListItem.
            List listx = new List(lix);
            // </Snippet_List_Const>
        }

        void ListItemsProp()
        {
            // <Snippet_List_ListItems>
            // Add ListItems to the List.
            List listx = new List();
            Span spanx = new Span();
            listx.ListItems.Add(new ListItem(new Paragraph(new Run("A bit of text content..."))));
            listx.ListItems.Add(new ListItem(new Paragraph(new Run("A bit more text content..."))));

            // Insert a ListItem at the begining of the List.
            ListItem lix = new ListItem(new Paragraph(new Run("ListItem to insert...")));
            listx.ListItems.InsertBefore(listx.ListItems.FirstListItem, lix);

            // Get the number of ListItems in the List.
            int countListItems = listx.ListItems.Count;

            // Remove the last ListItem from the List.
            listx.ListItems.Remove(listx.ListItems.LastListItem);

            // Clear all of the ListItems from the List.
            listx.ListItems.Clear();
            // </Snippet_List_ListItems>
        }
    }
}