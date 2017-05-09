
'   System.Web.UI.Page.EnableViewState
'   
'   The following program demonstrates the 'EnableViewState' property of 'Page' class.
'   It displays a TextBox and a Button control on the page. On page load event it
'   sets the 'EnableViewState' property of 'Page' class to false so that the page
'   should not maintain its view state. When the button is clicked it will display
'   the content of current and previous page.


Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls


Namespace PageSample

   Public Class MyForm
      Inherits HtmlForm
      
      Public Sub New()
      End Sub 'New
      
      Protected Overrides Sub OnInit(e As EventArgs)
         ' Save the view state if there are server controls on the page.
         Page.RegisterViewStateHandler()
      End Sub 'OnInit
   End Class 'MyForm

' <Snippet1>
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
         ' Comment the following line to maintain page view state.
         Page.EnableViewState = false
         myFormObj.Method = "post"
         Controls.Add(myFormObj)
         textBoxObj.Text = "Welcome to .NET"
         
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
      
      Protected Overrides Sub LoadViewState(viewState As Object)
         If Not (viewState Is Nothing) Then
            MyBase.LoadViewState(viewState)
         End If
      End Sub 'LoadViewState
      
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
' </Snippet1>
End Namespace 'PageSample