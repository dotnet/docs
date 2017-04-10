' System.Web.UI.Control.Page;

' The following example demonstrates the 'Page' property
' of 'Control' Class. 

Imports System
Imports System.Web
Imports System.Web.UI

Namespace SimpleControlSample

   Public Class Simple
      Inherits Control

' <Snippet1>
      Protected Overrides Sub Render(output As HtmlTextWriter)
         output.Write("Welcome to Control Development!<br>")
         
         ' Test if the page is loaded for the first time
         If Not Page.IsPostBack Then
            output.Write("Page has just been loaded")
         Else
            output.Write("Postback has occured")
         End If
      End Sub 
' </Snippet1>

   End Class
End Namespace