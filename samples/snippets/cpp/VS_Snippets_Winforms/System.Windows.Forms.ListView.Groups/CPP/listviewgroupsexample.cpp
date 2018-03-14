

//<Snippet1>
#using <mscorlib.dll>
#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>
using namespace System;
using namespace System::Collections; 
using namespace System::Windows::Forms;

public ref class ListViewGroupsExample : public Form
{
private:
   ListView^ myListView;
   bool isRunningXPOrLater;

   // Declare a Hashtable array in which to store the groups.
   array<Hashtable^>^ groupTables;

   // Declare a variable to store the current grouping column.
   int groupColumn;

public:
   ListViewGroupsExample()
   {
      groupColumn = 0;
      // Initialize myListView.
      myListView = gcnew ListView();
      myListView->Dock = DockStyle::Fill;
      myListView->View = View::Details;
      myListView->Sorting = SortOrder::Ascending;

      // Create and initialize column headers for myListView.
      ColumnHeader^ columnHeader0 = gcnew ColumnHeader();
      columnHeader0->Text = "Title";
      columnHeader0->Width = -1;
      ColumnHeader^ columnHeader1 = gcnew ColumnHeader();
      columnHeader1->Text = "Author";
      columnHeader1->Width = -1;
      ColumnHeader^ columnHeader2 = gcnew ColumnHeader();
      columnHeader2->Text = "Year";
      columnHeader2->Width = -1;

      // Add the column headers to myListView.

      array<ColumnHeader^>^ temp0 = {columnHeader0, columnHeader1, columnHeader2};
      myListView->Columns->AddRange(temp0);

      // Add a handler for the ColumnClick event.
      myListView->ColumnClick += 
         gcnew ColumnClickEventHandler(this, &ListViewGroupsExample::myListView_ColumnClick);

      // Create items and add them to myListView.

      array<String^>^ temp1 = {"Programming Windows", "Petzold, Charles", "1998"};
      ListViewItem^ item0 = gcnew ListViewItem( temp1 );

      array<String^>^ temp2 = {"Code: The Hidden Language of Computer Hardware and Software",
         "Petzold, Charles", "2000"};
      ListViewItem^ item1 = gcnew ListViewItem( temp2 );

      array<String^>^ temp3 = {"Programming Windows with C#", "Petzold, Charles", "2001"};
      ListViewItem^ item2 = gcnew ListViewItem( temp3 );

      array<String^>^ temp4 = {"Coding Techniques for Microsoft Visual Basic .NET",
         "Connell, John", "2001"};
      ListViewItem^ item3 = gcnew ListViewItem( temp4 );

      array<String^>^ temp5 = {"C# for Java Developers", "Jones, Allen & Freeman, Adam",
         "2002"};
      ListViewItem^ item4 = gcnew ListViewItem( temp5 );

      array<String^>^ temp6 = {"Microsoft .NET XML Web Services Step by Step",
         "Jones, Allen & Freeman, Adam", "2002"};
      ListViewItem^ item5 = gcnew ListViewItem( temp6 );

      array<ListViewItem^>^ temp7 = {item0, item1, item2, item3, item4, item5};
      myListView->Items->AddRange( temp7 );

      // Determine whether Windows XP or a later 
      // operating system is present.
      isRunningXPOrLater = false;

      if (System::Environment::OSVersion->Version->Major > 5 ||
         ( System::Environment::OSVersion->Version->Major == 5 &&
         System::Environment::OSVersion->Version->Minor >= 1) )
      {
         isRunningXPOrLater = true;
      }

      if (isRunningXPOrLater)
      {
         // Create the groupsTable array and populate it with one 
         // hash table for each column.
         groupTables = gcnew array<Hashtable^>(myListView->Columns->Count);
         for (int column = 0; column < myListView->Columns->Count; column++)
         {
            // Create a hash table containing all the groups 
            // needed for a single column.
            groupTables[column] = CreateGroupsTable(column);
         }

         // Start with the groups created for the Title column.
         SetGroups(0);
      }

      // Initialize the form.
      this->Controls->Add(myListView);
      this->Size = System::Drawing::Size(550, 330);
      this->Text = "ListView Groups Example";
   }

   // Groups the items using the groups created for the clicked 
   // column.
private:
   void myListView_ColumnClick(
      Object^ /*sender*/, ColumnClickEventArgs^ e)
   {
      // Set the sort order to ascending when changing
      // column groups; otherwise, reverse the sort order.
      if ( myListView->Sorting == SortOrder::Descending || 
         ( isRunningXPOrLater && (e->Column != groupColumn) ) )
      {
         myListView->Sorting = SortOrder::Ascending;
      }
      else 
      {
         myListView->Sorting = SortOrder::Descending;
      }
      groupColumn = e->Column;

      // Set the groups to those created for the clicked column.
      if (isRunningXPOrLater)
      {
         SetGroups(e->Column);
      }
   }

   //<Snippet2>
   // Sets myListView to the groups created for the specified column.
private:
   void SetGroups(int column)
   {
      // Remove the current groups.
      myListView->Groups->Clear();

      // Retrieve the hash table corresponding to the column.
      Hashtable^ groups = dynamic_cast<Hashtable^>(groupTables[column]);

      // Copy the groups for the column to an array.
      array<ListViewGroup^>^ groupsArray = gcnew array<ListViewGroup^>(groups->Count);
      groups->Values->CopyTo(groupsArray, 0);

      // Sort the groups and add them to myListView.
      Array::Sort(groupsArray, gcnew ListViewGroupSorter(myListView->Sorting));
      myListView->Groups->AddRange(groupsArray);

      // Iterate through the items in myListView, assigning each 
      // one to the appropriate group.
      IEnumerator^ myEnum = myListView->Items->GetEnumerator();
      while (myEnum->MoveNext())
      {
         ListViewItem^ item = safe_cast<ListViewItem^>(myEnum->Current);
         // Retrieve the subitem text corresponding to the column.
         String^ subItemText = item->SubItems[column]->Text;

         // For the Title column, use only the first letter.
         if (column == 0) 
         {
            subItemText = subItemText->Substring(0, 1);
         }

         // Assign the item to the matching group.
         item->Group = dynamic_cast<ListViewGroup^>(groups[subItemText]);
      }
   }
   //</Snippet2>

   //<Snippet3>
   // Creates a Hashtable object with one entry for each unique
   // subitem value (or initial letter for the parent item)
   // in the specified column.
private:
   Hashtable^ CreateGroupsTable(int column)
   {
      // Create a Hashtable object.
      Hashtable^ groups = gcnew Hashtable();

      // Iterate through the items in myListView.
      IEnumerator^ myEnum1 = myListView->Items->GetEnumerator();
      while (myEnum1->MoveNext())
      {
         ListViewItem^ item = safe_cast<ListViewItem^>(myEnum1->Current);
         // Retrieve the text value for the column.
         String^ subItemText = item->SubItems[column]->Text;

         // Use the initial letter instead if it is the first column.
         if (column == 0) 
         {
            subItemText = subItemText->Substring(0, 1);
         }

         // If the groups table does not already contain a group
         // for the subItemText value, add a new group using the 
         // subItemText value for the group header and Hashtable key.
         if (!groups->Contains(subItemText))
         {
            groups->Add( subItemText, gcnew ListViewGroup(subItemText, 
               HorizontalAlignment::Left) );
         }
      }

      // Return the Hashtable object.
      return groups;
   }
   //</Snippet3>

   // Sorts ListViewGroup objects by header value.
   ref class ListViewGroupSorter : public IComparer
   {
   private:
      SortOrder order;

      // Stores the sort order.
   public:
      ListViewGroupSorter(SortOrder theOrder) 
      { 
         order = theOrder;
      }

      // Compares the groups by header value, using the saved sort
      // order to return the correct value.
      virtual int Compare(Object^ x, Object^ y)
      {
         int result = String::Compare(
            (dynamic_cast<ListViewGroup^>(x))->Header,
            (dynamic_cast<ListViewGroup^>(y))->Header
            );
         if (order == SortOrder::Ascending)
         {
            return result;
         }
         else 
         {
            return -result;
         }
      }
   };
};

[STAThread]
int main() 
{
   Application::EnableVisualStyles();
   Application::Run(gcnew ListViewGroupsExample());
}
//</Snippet1>
