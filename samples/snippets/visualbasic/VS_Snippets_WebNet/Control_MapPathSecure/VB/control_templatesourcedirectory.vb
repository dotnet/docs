' System.Web.Control.MapPathSecure
' System.Web.Control.TemplateSourceDirectory

'   The following example demonstrates 'TemplateSourceDirectory' and 
'   'MapPathSecure' properties of 'Control' class. A new CustomControl 
'   derived from control class is instantiated and the 
'   'TemplateSourceDirectory' property is displayed. The absolute path 
'   of the control is obtained and all the files in the directory are 
'   rendered onto the browser.

Imports System
Imports System.IO
Imports System.Web
Imports System.Web.Util
Imports System.Web.UI

Namespace Control_TemplateSource

   Public Class MyControl
      Inherits Control

      Protected Overrides Sub Render(output As HtmlTextWriter)
         Try
' <Snippet1>
' <Snippet2>
            ' An HttpException occurs if the server control does not,;
            ' have permissions to read the resulting mapped file.
            output.Write("The Actual Path of the virtual directory : " & _
                        MapPathSecure(TemplateSourceDirectory) & "<br>")

            ' Get all the files from the absolute path of 'MyControl';
            ' using TemplateSourceDirectory which gives the virtual Directory.
            Dim myFiles As String() = Directory.GetFiles(MapPathSecure(TemplateSourceDirectory))
            output.Write("The files in this Directory are <br>")

            ' List all the files.
            Dim i As Integer
            For i = 0 To myFiles.Length - 1
               output.Write(myFiles(i) & "<br>")
            Next i
' </Snippet2>
' </Snippet1>
         Catch e As HttpException
            output.Write("<br>The following Exception occurred:</b>" & e.Message)
         End Try
      End Sub
   End Class
End Namespace