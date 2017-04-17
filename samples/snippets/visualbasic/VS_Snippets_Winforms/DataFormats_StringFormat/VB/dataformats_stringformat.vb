 ' System.Windows.Forms.DataFormats.StringFormat
'  The following example demonstrates the 'StringFormat' field of 'DataFormats' class. 
'  It stores a String object in Clipboard using the Clipboard's 'SetDataObject' method.
'  It retrieves the String object stored in the Clipboard by using the GetDataObject method
'  which returns the 'IDataObject'.It checks the string data is available or not 
'  by using the 'GetDataPresent' method of 'IDataObject'. If data is there then it displays the data to the console. 

Imports System
Imports System.Drawing.Imaging
Imports System.Windows.Forms

Public Class DataFormats_StringFormat
   
   Public Overloads Shared Sub Main()
      Main(System.Environment.GetCommandLineArgs())
   End Sub
   
   Overloads Public Shared Sub Main(args() As String)
      ' <Snippet1>
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
' </Snippet1>