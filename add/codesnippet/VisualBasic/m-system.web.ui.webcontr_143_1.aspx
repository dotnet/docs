            Dim myListItem As ListItem = SearchType.SelectedItem
            Dim crItem As ListItem 
            Dim searchText As String  = TextBox1.Text
            If(myListItem.Value = "Name") Then
                If(TextBox1.Text <> "" ) Then        
                    Dim searchSubfirst As String = searchText.Substring(0,1)
                    Dim searchSubsecond As String = searchText.Substring(1)
                    searchText = searchSubfirst.ToUpper()+searchSubsecond.ToLower()
                    ' Search by country or region name.                       
                    crItem = ItemCollection.FindByText(searchText)    
                End If            
            Else
                'Search by country or region code.
                crItem = ItemCollection.FindByValue(searchText.ToUpper())
            End If
            
            Dim str As String  = "Search is successful. Match is Found.<br />"
            str = str & "The results for search string '" & searchText & "' are:<br />"
            str = str & "the country or region code is: " & crItem.Value & "<br />"
            str = str & "the country or region name is: " & crItem.Text
            ' Add the string to the label.
            Label1.Text = str
          