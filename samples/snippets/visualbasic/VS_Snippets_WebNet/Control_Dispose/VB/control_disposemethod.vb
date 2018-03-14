' System.Web.UI.Control.Dispose()

'   The following example demonstrates the Dispose() method of class Control.
'   In Dispose() method all resources are cleaned up and Dispose() of
'   the child control(Button) is invoked.

Imports System
Imports System.IO
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace CustomControlNameSpace

   Public Class MyCustomControl
      Inherits Control
      Private myTextWriter As TextWriter
      Private myButton As Button

      Public Sub New()
         Try
            myTextWriter = File.CreateText("MyTestFile.txt")
            myButton = New Button()
            myButton.Text = "MyButton"
            Controls.Add(myButton)
         Catch myExeception As Exception
            Context.Response.Write("Execption occured:" & myExeception.Message)
         End Try
      End Sub

' <Snippet1>
      Public Overrides Sub Dispose()
         Try
            Context.Response.Write("Disposing " & ToString())
            ' Perform resource cleanup.
            myTextWriter.Close()
            myButton.Dispose()
         Catch myException As Exception
            Context.Response.Write("Exception occurred: " & myException.Message)
         End Try
      End Sub
' </Snippet1>

      Protected Overrides Sub Render(myWriter As HtmlTextWriter)
         Me.RenderChildren(myWriter)
         myWriter.Write("My Custom Control")
      End Sub
   End Class 
End Namespace 