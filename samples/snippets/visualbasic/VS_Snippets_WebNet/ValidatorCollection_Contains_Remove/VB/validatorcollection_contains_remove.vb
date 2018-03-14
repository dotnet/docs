' System.Web.UI.ValidatorCollection.Contains()
' System.Web.UI.ValidatorCollection.Remove()

' The following program demonstrates 'Contains' and 'Remove'
' methods of the 'ValidatorCollection' class in 'System.Web.UI'.
' It checks for the 'RequiredFieldValidator' in the ValidatorCollection
' and removes it from the collection.

Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Public Class MyPage
   Inherits Page
   ' Create the controls for the web page.
   Protected myTextBox As TextBox
   Protected myButton As Button
   Protected myLabel As Label
   Protected myLabel1 As Label
   Protected myRequiredFieldValidator As RequiredFieldValidator
   Protected myForm As HtmlForm

   Public Sub New()
      MyBase.New()
   End Sub 'New

   Public Sub Page_Load(sender As Object, e As EventArgs)
      If Not Me.IsPostBack Then
         Response.Write("<b>ValidatorCollection Example</b><br><br>")
         myLabel1.Text = "Enter a Number : "
         AddControls()
      Else
         Me.Validate()
         If Me.IsValid Then
            Response.Write("Page is valid")
         Else
            Response.Write("Page is not valid")
         End If
      End If
   End Sub 'Page_Load

   Public Sub Page_Init(sender As Object, e As EventArgs)
      myTextBox = New TextBox()
      myButton = New Button()
      myLabel = New Label()
      myLabel1 = New Label()
      myRequiredFieldValidator = New RequiredFieldValidator()
      myForm = New HtmlForm()

      myForm.Method = "POST"

      ' Call the required properties on the controls.
      myTextBox.ID = "Number"
      myButton.Text = "Submit"
      myRequiredFieldValidator.ControlToValidate = "Number"
      myRequiredFieldValidator.ErrorMessage = "Number entry is Mandatory."
   End Sub 'Page_Init

   ' Add all the controls to the form.
   Private Sub AddControls()
' <Snippet1>
      Controls.Add(myForm)
      myForm.Controls.Add(myLabel1)
      myForm.Controls.Add(myTextBox)
      myForm.Controls.Add(myButton)
      Me.Validators.Add(myRequiredFieldValidator)
      myForm.Controls.Add(myLabel)

     ' Remove the RequiredFieldValidator.
      If Validators.Contains(myRequiredFieldValidator) Then
         Me.Validators.Remove(myRequiredFieldValidator)
         Response.Write("RequiredFieldValidator is removed from ValidatorCollection<br>")
         Response.Write("ValidatorCollection count after removing the Validator: " + Validators.Count.ToString() + "<br>")
      Else
         Response.Write("ValidatorCollection does not contain RequiredFieldValidator")
      End If
' </Snippet1>

   End Sub 'AddControls
End Class 'MyPage