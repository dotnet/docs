            ListItem myListItem = SearchType.SelectedItem;
            ListItem crItem = null;
            String searchText = TextBox1.Text;
            if(myListItem.Value == "Name")
            {
                if(TextBox1.Text != "")
                {
                    String searchSubfir = searchText.Substring(0,1);
                    String searchSubsec = searchText.Substring(1);
                    searchText = searchSubfir.ToUpper()+searchSubsec.ToLower();

                    // Search by country or region name.
                    crItem = ItemCollection.FindByText(searchText);
                }
            }
            else
            {
                // Search by country or region code.
                crItem = ItemCollection.FindByValue(searchText.ToUpper());
            }

            String str = "Search is successful. Match is Found.<br />";
            str =str + "The results for search string '" + searchText + "' are:<br />";
            str = str + "the country or region code is " + crItem.Value + "<br />";
            str = str + "the country or region name is " + crItem.Text;
            
            // Add the string to the label.
            Label1.Text = str;
