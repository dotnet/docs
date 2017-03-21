      ' The following method uses Add to add dates that are 
      ' bolded, followed by an UpdateBoldedDates to make the
      ' added dates visible.
      Private Sub loadDates()
         Dim myInput As [String]
         Try
            Dim myInputStream As StreamReader = File.OpenText("myDates.txt")
            myInput = myInputStream.ReadLine()
            While myInput IsNot Nothing
               monthCalendar1.AddBoldedDate(DateTime.Parse(myInput.Substring(0, myInput.IndexOf(" "))))
               listBox1.Items.Add(myInput)
               myInput = myInputStream.ReadLine()
            End While
            monthCalendar1.UpdateBoldedDates()
            myInputStream.Close()
            File.Delete("myDates.txt")
         Catch fnfe As FileNotFoundException
         End Try
      End Sub 'loadDates