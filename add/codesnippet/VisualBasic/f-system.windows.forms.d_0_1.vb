      try
	      Dim myString As [String] = "This is a String from the ClipBoard"
	      
	      ' Sets the data into the Clipboard.
	      Clipboard.SetDataObject(myString)
	      Dim myDataObject As IDataObject = Clipboard.GetDataObject()
	      ' Checks whether the format of the data is 'UnicodeText' or not.
	      If myDataObject.GetDataPresent(DataFormats.UnicodeText) Then
		 Console.WriteLine(("Data in 'UnicodeText' format:" + myDataObject.GetData(DataFormats.UnicodeText)))
	      Else
		 Console.WriteLine("No String information was contained in the clipboard.")
	      End If
	      
	      ' Checks whether the format of the data is 'Text' or not.
	      If myDataObject.GetDataPresent(DataFormats.Text) Then
		 Dim clipString As [String] = CType(myDataObject.GetData(DataFormats.StringFormat), [String])
		 Console.WriteLine(("Data in 'Text' format:" + clipString))
	      End If
	      catch e as Exception
		Console.WriteLine(e.Message)
      End try
   End Sub 'Main 
End Class 'DataFormats_UnicodeText 