 ' System.Windows.Forms.DataFormats.UnicodeText;System.Windows.Forms.Text;
 ' The following example demonstrates the 'UnicodeText' and 'Text' field of 'DataFormats' class.
 ' It stores a String object in Clipboard using the Clipboard's 'SetDataObject' method.
 ' It retrieves the String object stored in the Clipboard by using the GetDataObject method
 ' which returns the 'IDataObject'.  It checks whether the Unicodetext data is present 
 ' or not by using the 'GetDataPresent' method of 'IDataObject'. If data is there then it
 ' displays the data to the console. It also checks 'Text' format data is present or not. 
 ' If the data is there it displays the data to the console.

Imports System
Imports System.Drawing.Imaging
Imports System.Windows.Forms

Public Class DataFormats_UnicodeText
   
   Public Overloads Shared Sub Main()
      Main(System.Environment.GetCommandLineArgs())
   End Sub
   
   Overloads Public Shared Sub Main(args() As String)
      ' <Snippet1>
      ' <Snippet2>
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
	' </Snippet2>
	' </Snippet1>