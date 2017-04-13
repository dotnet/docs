' <Snippet1>
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel
Imports Microsoft.VisualBasic
Imports UserControls

Namespace MyApplication    
    
    Public Class MyUserControlHost
        Inherits System.Windows.Forms.Form

        ' Create the controls.
        Private components As System.ComponentModel.IContainer
        Private panel1 As System.Windows.Forms.Panel
        Private myUserControl As UserControls.MyCustomerInfoUserControl
                
        ' Define the constructor.
        Public Sub New()
            Me.InitializeComponent()
        End Sub        
        
        <System.STAThreadAttribute()> _
        Public Shared Sub Main()
            System.Windows.Forms.Application.Run(New MyUserControlHost())
        End Sub        
        
        ' Add a Panel control to a Form and host the UserControl in the Panel.
        Private Sub InitializeComponent()
            components = New System.ComponentModel.Container()
            panel1 = New System.Windows.Forms.Panel()
            myUserControl = New UserControls.MyCustomerInfoUserControl()
            ' Set the DockStyle of the UserControl to Fill.
            myUserControl.Dock = System.Windows.Forms.DockStyle.Fill
            
            ' Make the Panel the same size as the UserControl and give it a border.
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            panel1.Size = myUserControl.Size
            panel1.Location = New System.Drawing.Point(5, 5)
            ' Add the user control to the Panel.
            panel1.Controls.Add(myUserControl)
            ' Size the Form to accommodate the Panel.
            Me.ClientSize = New System.Drawing.Size(panel1.Size.Width + 10, panel1.Size.Height + 10)
            Me.Text = "Please enter the information below..."
            ' Add the Panel to the Form.
            Me.Controls.Add(panel1)
        End Sub
    End Class
End Namespace
' </Snippet1>


' /////////////////////////////////////////////////////////////////////////////////////////////////


Namespace UserControls

   Public Class MyCustomerInfoUserControl
      Inherits System.Windows.Forms.UserControl

      ' Create the controls.
      Private errorProvider1 As System.Windows.Forms.ErrorProvider
      Private textName As System.Windows.Forms.TextBox
      Private textAddress As System.Windows.Forms.TextBox
      Private textCity As System.Windows.Forms.TextBox
      Private textStateProvince As System.Windows.Forms.TextBox
      Private textPostal As System.Windows.Forms.TextBox
      Private textCountryRegion As System.Windows.Forms.TextBox
      Private WithEvents textEmail As System.Windows.Forms.TextBox
      Private labelName As System.Windows.Forms.Label
      Private labelAddress As System.Windows.Forms.Label
      Private labelCityStateProvincePostal As System.Windows.Forms.Label
      Private labelCountryRegion As System.Windows.Forms.Label
      Private labelEmail As System.Windows.Forms.Label
      Private components As System.ComponentModel.IContainer        
        
      ' Define the constructor.
      Public Sub New()
         InitializeComponent()
      End Sub        
        
      ' Initialize the control elements.
      Public Sub InitializeComponent()
         ' Initialize the controls.
         components = New System.ComponentModel.Container()
         errorProvider1 = New System.Windows.Forms.ErrorProvider()
         textName = New System.Windows.Forms.TextBox()
         textAddress = New System.Windows.Forms.TextBox()
         textCity = New System.Windows.Forms.TextBox()
         textStateProvince = New System.Windows.Forms.TextBox()
         textPostal = New System.Windows.Forms.TextBox()
         textCountryRegion = New System.Windows.Forms.TextBox()
         textEmail = New System.Windows.Forms.TextBox()
         labelName = New System.Windows.Forms.Label()
         labelAddress = New System.Windows.Forms.Label()
         labelCityStateProvincePostal = New System.Windows.Forms.Label()
         labelCountryRegion = New System.Windows.Forms.Label()
         labelEmail = New System.Windows.Forms.Label()
           
         ' Set the tab order, text alignment, size, and location of the controls.
         textName.Location = New System.Drawing.Point(120, 8)
         textName.Size = New System.Drawing.Size(232, 20)
         textName.TabIndex = 0
         textAddress.Location = New System.Drawing.Point(120, 32)
         textAddress.Size = New System.Drawing.Size(232, 20)
         textAddress.TabIndex = 1
         textCity.Location = New System.Drawing.Point(120, 56)
         textCity.Size = New System.Drawing.Size(96, 20)
         textCity.TabIndex = 2
         textStateProvince.Location = New System.Drawing.Point(216, 56)
         textStateProvince.Size = New System.Drawing.Size(56, 20)
         textStateProvince.TabIndex = 3
         textPostal.Location = New System.Drawing.Point(272, 56)
         textPostal.Size = New System.Drawing.Size(80, 20)
         textPostal.TabIndex = 4
         textCountryRegion.Location = New System.Drawing.Point(120, 80)
         textCountryRegion.Size = New System.Drawing.Size(232, 20)
         textCountryRegion.TabIndex = 5
         textEmail.Location = New System.Drawing.Point(120, 104)
         textEmail.Size = New System.Drawing.Size(232, 20)
         textEmail.TabIndex = 6
         labelName.Location = New System.Drawing.Point(8, 8)
         labelName.Size = New System.Drawing.Size(112, 23)
         labelName.Text = "Name:"
         labelName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         labelAddress.Location = New System.Drawing.Point(8, 32)
         labelAddress.Size = New System.Drawing.Size(112, 23)
         labelAddress.Text = "Address:"
         labelAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         labelCityStateProvincePostal.Location = New System.Drawing.Point(8, 56)
         labelCityStateProvincePostal.Size = New System.Drawing.Size(112, 23)
         labelCityStateProvincePostal.Text = "City, St/Prov. Postal:"
         labelCityStateProvincePostal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         labelCountryRegion.Location = New System.Drawing.Point(8, 80)
         labelCountryRegion.Size = New System.Drawing.Size(112, 23)
         labelCountryRegion.Text = "Country/Region:"
         labelCountryRegion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
         labelEmail.Location = New System.Drawing.Point(8, 104)
         labelEmail.Size = New System.Drawing.Size(112, 23)
         labelEmail.Text = "email:"
         labelEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
          
         ' Add the controls to the user control.
         Controls.AddRange(New System.Windows.Forms.Control() {labelName, _
           labelAddress, labelCityStateProvincePostal, labelCountryRegion, _
           labelEmail, textName, textAddress, textCity, textStateProvince, _
           textPostal, textCountryRegion, textEmail})
            
         ' Size the user control.
         Size = New System.Drawing.Size(375, 150)
      End Sub        

      Private Sub MyValidatingCode()
         ' Confirm there is text in the control.
         If textEmail.Text.Length = 0 Then
            Throw New Exception("Email address is a required field")
         Else
            ' Confirm that there is a "." and an "@" in the e-mail address.
            If textEmail.Text.IndexOf(".") = - 1 Or textEmail.Text.IndexOf("@") = - 1 Then
               Throw New Exception("Email address must be valid e-mail address format." + _
                 Microsoft.VisualBasic.ControlChars.Cr + "For example 'someone@example.com'")
            End If
         End If
      End Sub 

      ' Validate the data input by the user into textEmail.
      Private Sub textEmail_Validating(sender As Object, _
                                       e As System.ComponentModel.CancelEventArgs) Handles textEmail.Validating
         Try
            MyValidatingCode()
   
         Catch ex As Exception
            ' Cancel the event and select the text to be corrected by the user.
            e.Cancel = True
            textEmail.Select(0, textEmail.Text.Length)
      
            ' Set the ErrorProvider error with the text to display. 
            Me.errorProvider1.SetError(textEmail, ex.Message)
         End Try
      End Sub 


      Private Sub textEmail_Validated(sender As Object, _
                                      e As System.EventArgs) Handles textEmail.Validated
         ' If all conditions have been met, clear the error provider of errors.
         errorProvider1.SetError(textEmail, "")
      End Sub        

   End Class
End Namespace