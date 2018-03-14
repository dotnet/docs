
'   The following program demonstrates the 'RegisterViewStateHandler' method of 'Page' class.
'   
'   The program creates 'MyForm' derived from 'HtmlForm' and calls 'RegisterViewStateHandler'
'   method of 'Page' class which tells the page to save its view state if there are server 
'   controls on the page. Dsiplay a textbox and a button and saves the content of text box.
'   When a click event of button is raised it will displays the content of previous and 
'   current textbox.


Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls


Namespace PageSample

' <Snippet1>
   ' Create a custom HtmlForm server control named MyForm.
   Public Class MyForm
      Inherits HtmlForm
      
      ' MyForm inherits all the base funcitionality
      ' of the HtmlForm control.
      Public Sub New()
      End Sub 'New
      
      ' Override the OnInit method that MyForm inherited from HtmlForm.
      <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
      Protected Overrides Sub OnInit(e As EventArgs)
         ' Save the view state if there are server controls on
         ' a page that calls MyForm.
         Page.RegisterViewStateHandler()
      End Sub 'OnInit
   End Class 'MyForm

' </Snippet1>
   Public Class WebPage
      Inherits System.Web.UI.Page
      Private myFormObj As MyForm
      Private label1 As Label
      Private label2 As Label
      Private textBoxObj As TextBox
      Private buttonObj As Button
      
      
      Public Sub New()
         AddHandler Page.Init, AddressOf Page_Init
      End Sub 'New
      
      
      Private Sub Page_Load(sender As Object, e As System.EventArgs)
         myFormObj.Method = "post"
         Controls.Add(myFormObj)
         textBoxObj.Text = "Welcone to ASP.Net"
         
         label1.Text = "Enter a name"
         buttonObj.Text = "ClickMe"
         AddHandler buttonObj.Click, AddressOf Button_Click
         myFormObj.Controls.Add(label1)
         myFormObj.Controls.Add(textBoxObj)
         myFormObj.Controls.Add(buttonObj)
         myFormObj.Controls.Add(label2)
      End Sub 'Page_Load
      
      Private Sub Button_Click(sender As Object, e As EventArgs)
         Dim temp As [String] = "<br>Name is " + textBoxObj.Text + "<br>"
         temp += "Saved content of previous page is " + CType(ViewState("name"), String)
         label2.Text = temp
      End Sub 'Button_Click
      
      <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
      Protected Overrides Sub LoadViewState(viewState As Object)
         If Not (viewState Is Nothing) Then
            MyBase.LoadViewState(viewState)
         End If
      End Sub 'LoadViewState
      
      <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
      Protected Overrides Function SaveViewState() As Object
         ViewState("name") = textBoxObj.Text
         Return MyBase.SaveViewState()
      End Function 'SaveViewState
      
      Private Sub Page_Init(sender As Object, e As EventArgs)
         AddHandler Me.Load, AddressOf Me.Page_Load
         myFormObj = New MyForm()
         label1 = New Label()
         label2 = New Label()
         textBoxObj = New TextBox()
         buttonObj = New Button()
      End Sub 'Page_Init
   End Class 'WebPage
End Namespace 'PageSample