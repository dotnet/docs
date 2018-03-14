'The following example demonstrates the 'GetFormat(int)' method of 'DataFormats' class. It creates a 'DataFormats' object using a integer into the 'GetFormat' method. By using the 'DatFormats' object it displays the format name with 'respective the id.

' <Snippet1>
Imports System
Imports System.Windows.Forms
Imports Microsoft.Visualbasic


Public Class DataFormat_GetFormat
   
   Shared Sub Main()
      
     ' Create a DataFormats.Format for the Unicode data format.

      Dim myFormat As DataFormats.Format = DataFormats.GetFormat(13)

      ' Display the contents of myFormat.

      Console.WriteLine(("The Format Name corresponding to the ID " + myFormat.Id.ToString + " is :"))
      Console.WriteLine(myFormat.Name)

   End Sub 'Main 

End Class 'DataFormat_GetFormat 

' </Snippet1>