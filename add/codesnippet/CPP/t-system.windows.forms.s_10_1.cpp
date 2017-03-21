        ListView^ iconListView;
        TextBox^ previousItemBox;

    private:
        void InitializeLocationSearchListView()
        {
            previousItemBox = gcnew TextBox();
            iconListView = gcnew ListView();
            previousItemBox->Location = Point(150, 20);

            // Create an image list for the icon ListView.
            iconListView->SmallImageList = gcnew ImageList();

            // Add an image to the ListView small icon list.
            iconListView->SmallImageList->Images->Add(
                gcnew Bitmap(Control::typeid, "Edit.bmp"));

            // Set the view to small icon and add some items with the image
            // in the image list.
            iconListView->View = View::SmallIcon;
            iconListView->Items->AddRange(gcnew array<ListViewItem^>{
                gcnew ListViewItem("Amy Alberts", 0),
                gcnew ListViewItem("Amy Recker", 0),
                gcnew ListViewItem("Erin Hagens", 0),
                gcnew ListViewItem("Barry Johnson", 0),
                gcnew ListViewItem("Jay Hamlin", 0),
                gcnew ListViewItem("Brian Valentine", 0),
                gcnew ListViewItem("Brian Welker", 0),
                gcnew ListViewItem("Daniel Weisman", 0) });
             this->Controls->Add(iconListView);
             this->Controls->Add(previousItemBox);

             // Handle the MouseDown event to capture user input.
             iconListView->MouseDown += gcnew MouseEventHandler(
                 this, &Form1::iconListView_MouseDown);
        }

        void iconListView_MouseDown(Object^ sender, MouseEventArgs^ e)
        {
            // Find the next item up from where the user clicked.
            ListViewItem^ foundItem = iconListView->FindNearestItem(
                SearchDirectionHint::Up, e->X, e->Y);

            // Display the results in a textbox..
            if (foundItem != nullptr)
            {
                previousItemBox->Text = foundItem->Text;
            }
            else
            {
                previousItemBox->Text = "No item found";
            }
        }