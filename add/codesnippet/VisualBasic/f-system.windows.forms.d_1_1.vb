         Dim myFileStream As FileStream = File.Open("Temp.dif", FileMode.Open)
         ' Store the data into Dif format.
         Dim myDataObject As New DataObject()
         myDataObject.SetData(DataFormats.Dif, myFileStream)
         
         ' Check whether the data is stored or not in the specified format.
         Dim formatPresent As Boolean = myDataObject.GetDataPresent(DataFormats.Dif)
         If formatPresent Then
            Console.WriteLine(("The data has been stored in the Dif format is:'" + formatPresent.ToString() + "'"))
         Else
            Console.WriteLine("The data has not been stored in the specified format")
         End If