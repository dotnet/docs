'<Snippet1>
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace ErrorProvider

    Public NotInheritable Class Form1
        Inherits System.Windows.Forms.Form
    
        Private label1 As System.Windows.Forms.Label
        Private label2 As System.Windows.Forms.Label
        Private label3 As System.Windows.Forms.Label      
        Private label4 As System.Windows.Forms.Label
        Private label5 As System.Windows.Forms.Label
        Private label6 As System.Windows.Forms.Label
        Friend WithEvents favoriteColorComboBox As System.Windows.Forms.ComboBox 
        Friend WithEvents nameTextBox1 As System.Windows.Forms.TextBox 
        Friend WithEvents ageUpDownPicker As System.Windows.Forms.NumericUpDown      
        Private ageErrorProvider As System.Windows.Forms.ErrorProvider 
        Private nameErrorProvider As System.Windows.Forms.ErrorProvider 
        Private favoriteColorErrorProvider As System.Windows.Forms.ErrorProvider
        
        <System.STAThread()>  _
        Public Shared Sub Main()
            System.Windows.Forms.Application.Run(New Form1())
        End Sub 'Main

        Public Sub New()
            
            Me.nameTextBox1 = New System.Windows.Forms.TextBox()
            Me.label1 = New System.Windows.Forms.Label()
            Me.label2 = New System.Windows.Forms.Label()
            Me.ageUpDownPicker = New System.Windows.Forms.NumericUpDown()
            Me.favoriteColorComboBox = New System.Windows.Forms.ComboBox()
            Me.label3 = New System.Windows.Forms.Label()
            Me.label4 = New System.Windows.Forms.Label()
            Me.label5 = New System.Windows.Forms.Label()
            Me.label6 = New System.Windows.Forms.Label()

            ' Name Label
            Me.label1.Location = New System.Drawing.Point(56, 32)
            Me.label1.Size = New System.Drawing.Size(40, 23)
            Me.label1.Text = "Name:"

            ' Age Label
            Me.label2.Location = New System.Drawing.Point(40, 64)
            Me.label2.Size = New System.Drawing.Size(56, 23)
            Me.label2.Text = "Age (3-5)"

            ' Favorite Color Label
            Me.label3.Location = New System.Drawing.Point(24, 96)
            Me.label3.Size = New System.Drawing.Size(80, 24)
            Me.label3.Text = "Favorite color"

            ' ErrorBlinkStyle.AlwaysBlink Label
            Me.label4.Location = New System.Drawing.Point(264, 32)
            Me.label4.Size = New System.Drawing.Size(160, 23)
            Me.label4.Text = "ErrorBlinkStyle.AlwaysBlink"

            ' ErrorBlinkStyle.BlinkIfDifferentError Label
            Me.label5.Location = New System.Drawing.Point(264, 64)
            Me.label5.Size = New System.Drawing.Size(200, 23)
            Me.label5.Text = "ErrorBlinkStyle.BlinkIfDifferentError"

            ' ErrorBlinkStyle.NeverBlink Label
            Me.label6.Location = New System.Drawing.Point(264, 96)
            Me.label6.Size = New System.Drawing.Size(200, 23)
            Me.label6.Text = "ErrorBlinkStyle.NeverBlink"

            ' Name TextBox
            Me.nameTextBox1.Location = New System.Drawing.Point(112, 32)
            Me.nameTextBox1.Size = New System.Drawing.Size(120, 20)
            Me.nameTextBox1.TabIndex = 0

            ' Age NumericUpDown
            Me.ageUpDownPicker.Location = New System.Drawing.Point(112, 64)
            Me.ageUpDownPicker.Maximum = New System.Decimal(New Integer() {150, 0, 0, 0})
            Me.ageUpDownPicker.TabIndex = 4

            ' Favorite Color ComboBox
            Me.favoriteColorComboBox.Items.AddRange(New Object() {"None", "Red", "Yellow", _
                                                                                    "Green", "Blue", "Purple"})
            Me.favoriteColorComboBox.Location = New System.Drawing.Point(112, 96)
            Me.favoriteColorComboBox.Size = New System.Drawing.Size(120, 21)
            Me.favoriteColorComboBox.TabIndex = 5

            ' Set up how the form should be displayed and add the controls to the form.
            Me.ClientSize = New System.Drawing.Size(464, 150)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.label6, Me.label5, Me.label4, _
                                          Me.label3, Me.favoriteColorComboBox, Me.ageUpDownPicker, Me.label2, _
                                          Me.label1, Me.nameTextBox1})

            Me.Text = "Error Provider Example"

            '<Snippet2>
            ' Create and set the ErrorProvider for each data entry control.
     
            nameErrorProvider = New System.Windows.Forms.ErrorProvider()
            nameErrorProvider.SetIconAlignment(Me.nameTextBox1, ErrorIconAlignment.MiddleRight)
            nameErrorProvider.SetIconPadding(Me.nameTextBox1, 2)
            nameErrorProvider.BlinkRate = 1000
            nameErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
            
            ageErrorProvider = New System.Windows.Forms.ErrorProvider()
            ageErrorProvider.SetIconAlignment(Me.ageUpDownPicker, ErrorIconAlignment.MiddleRight)
            ageErrorProvider.SetIconPadding(Me.ageUpDownPicker, 2)
            ageErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.BlinkIfDifferentError
            
            favoriteColorErrorProvider = New System.Windows.Forms.ErrorProvider()
            favoriteColorErrorProvider.SetIconAlignment(Me.favoriteColorComboBox, ErrorIconAlignment.MiddleRight)
            favoriteColorErrorProvider.SetIconPadding(Me.favoriteColorComboBox, 2)
            favoriteColorErrorProvider.BlinkRate = 1000
            favoriteColorErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
            '</Snippet2>
        End Sub 'New
 
        '<Snippet3>       
        Private Sub nameTextBox1_Validated(sender As Object, e As System.EventArgs) Handles nameTextBox1.Validated
            If IsNameValid() Then
                ' Clear the error, if any, in the error provider.
                nameErrorProvider.SetError(Me.nameTextBox1, String.Empty)
            Else
                ' Set the error if the name is not valid.
                nameErrorProvider.SetError(Me.nameTextBox1, "Name is required.")
            End If 
        End Sub 
              
        Private Sub ageUpDownPicker_Validated(sender As Object, e As System.EventArgs) Handles ageUpDownPicker.Validated
            If IsAgeTooYoung() Then
                ' Set the error if the age is too young.
                ageErrorProvider.SetError(Me.ageUpDownPicker, "Age not old enough")
            ElseIf IsAgeTooOld() Then
                ' Set the error if the age is too old.
                ageErrorProvider.SetError(Me.ageUpDownPicker, "Age is too old")
            Else
                ' Clear the error, if any, in the error provider.
                ageErrorProvider.SetError(Me.ageUpDownPicker, String.Empty)
            End If
        End Sub
         
        Private Sub favoriteColorComboBox_Validated(sender As Object, e As System.EventArgs) Handles favoriteColorComboBox.Validated
            If Not IsColorValid() Then
                ' Set the error if the favorite color is not valid.
                favoriteColorErrorProvider.SetError(Me.favoriteColorComboBox, "Must select a color.")            
            Else
                ' Clear the error, if any, in the error provider.
                favoriteColorErrorProvider.SetError(Me.favoriteColorComboBox, String.Empty)
            End If
        End Sub 
        '</Snippet3>

        ' Functions to verify data.
        Private Function IsNameValid() As Boolean
            ' Determine whether the text box contains a zero-length string.
            Return nameTextBox1.Text.Length > 0
        End Function 

        Private Function IsAgeTooYoung() As Boolean
            ' Determine whether the age value is less than three.
            Return ageUpDownPicker.Value < 3
        End Function 
        
        
        Private Function IsAgeTooOld() As Boolean
            ' Determine whether the age value is greater than five.
            Return ageUpDownPicker.Value > 5
        End Function 
                
        Private Function IsColorValid() As Boolean
            ' Determine whether the favorite color has a valid value.
            If (favoriteColorComboBox.SelectedItem IsNot Nothing) Then
                    If Not(favoriteColorComboBox.SelectedItem.ToString().Equals("None")) Then
                        Return true 
                    End If
            End If
            Return false
        End Function 

    End Class 'Form1
End Namespace 'ErrorProvider 
'</Snippet1>
