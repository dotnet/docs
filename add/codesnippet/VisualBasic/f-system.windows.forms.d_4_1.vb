      try
	      Dim myString As [String] = "This is a String from the ClipBoard"
	      ' Sets the data to the Clipboard.   
	      Clipboard.SetDataObject(myString)
	      Dim myDataObject As IDataObject = Clipboard.GetDataObject()
	      
	      ' Checks whether the data is present or not in the Clipboard.
	      If myDataObject.GetDataPresent(DataFormats.StringFormat) Then
		 Dim clipString As [String] = CType(myDataObject.GetData(DataFormats.StringFormat), [String])
		 Console.WriteLine(clipString)
	      Else
		 Console.WriteLine("No String information was contained in the clipboard.")
	      End If
	      catch e as Exception
		Console.WriteLine(e.Message)
      End try
   End Sub 'Main 
End Class 'DataFormats_StringFormat