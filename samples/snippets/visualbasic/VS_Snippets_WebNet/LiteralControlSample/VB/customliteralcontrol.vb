' System.Web.UI.LiteralControl.Text
' System.Web.UI.LiteralControl.CreateControlCollection
' System.Web.UI.LiteralControl.Render

'  The following example demonstrates 'Text' property ,'Render' , 'CreateControlCollection'  
'  methods and  'LiteralControl()' 'LiteralControl(string)' of 'LiteralControl' class.
'  Literal controls behave as text holders.
'  They are actually used to increase the performance of the server.
'  All the controls that donot require server side execution are stored as literalcontrols.
'  A custom control is developed from Literal control.
'  A class is derived from LiteralControl class.
'  'Render' Method is overridden to be able to render the CustomControl.
'  'CreateControlCollection' method is overridden to be able to allow child control creation.
'  The  'Text'  property is overridden to be able to display the text of the control

Imports System
Imports System.Collections
Imports System.Web.UI
Imports System.Web.UI.WebControls


Namespace CustomLiteralControl
   Public Class CustomLiteralControlClass
      Inherits LiteralControl
      Implements INamingContainer 
      Private _text As String
      Private myControlCollection As ControlCollection
      
      Public Sub New()
      End Sub 'New
      
      Public Sub New(text As String)
         MyBase.New(text)
         _text = text
      End Sub 'New
' <Snippet1>
      
      Public Overrides Property Text() As String
         <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
         Get
            Return _text
         End Get
         <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
         Set
            _text = value
         End Set
      End Property
      
      
' </Snippet1>
' <Snippet2>
      <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
      Protected Overrides Function CreateControlCollection() As ControlCollection
         myControlCollection = New ControlCollection(Me)
         Return myControlCollection
      End Function 'CreateControlCollection
      
' </Snippet2>
' <Snippet3>
      <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
      Protected Overrides Sub Render(writer As HtmlTextWriter)
         Dim myEnumerator As IEnumerator = myControlCollection.GetEnumerator()
         Dim tempButton As New Button()
         writer.Write("<br><br><b> CustomLiteralControlClass has child controls = </b>" _
                     + Me.HasControls().ToString())
         While myEnumerator.MoveNext()
            Dim myObject As Object = myEnumerator.Current
            If myObject.GetType().Equals(GetType(Button)) Then
               Dim childControlButton As Button = CType(myEnumerator.Current, Button)
               writer.Write("<br><br><b> This is the  text of the child Control  :</b>"  _
                           + childControlButton.Text + "<br>")
            End If
         End While
         Dim builder As String = "<h3>"
         Dim i As Integer
         For i = 0 To _text.Length - 1
            Dim currentChar As String = _text.Substring(i, 1)
            If i Mod 2 = 0 Then
               builder += "<font color=red>" + currentChar + "</font>"
            Else
               builder += "<font color=blue>" + currentChar + "</font>"
            End If
         Next i
         builder += "</h3>"
         writer.Write(builder)
      End Sub 'Render
' </Snippet3>
   End Class 'CustomLiteralControlClass 
End Namespace 'CustomLiteralControl