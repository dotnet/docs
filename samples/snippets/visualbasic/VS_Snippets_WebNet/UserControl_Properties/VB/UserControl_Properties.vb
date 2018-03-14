Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls

 _

Public Class MyControl
   Inherits UserControl
   Protected _message As String
   
   Public ReadOnly Property Message() As String
      Get
         Return _message
      End Get
   End Property 
End Class 'MyControl