 ' <snippet1>
Imports System
Imports System.Windows.Forms
Imports Accessibility
Imports System.Drawing

Namespace MyCustomControls
   Public Class MyCheckBox
      Inherits CheckBox
      
      Public Sub New()
         ' Make the check box appear like a toggle button.
         Me.Appearance = Appearance.Button
         ' Center the text on the button.
         Me.TextAlign = ContentAlignment.MiddleCenter
      End Sub
      
      ' Create an instance of the AccessibleObject 
      ' defined for the 'MyCheckBox' control 
      Protected Overrides Function CreateAccessibilityInstance() _
        As AccessibleObject
         Return New MyCheckBoxAccessibleObject(Me)
      End Function
   End Class
    
   ' Accessible object for use with the 'MyCheckBox' control.
   Friend Class MyCheckBoxAccessibleObject
      Inherits Control.ControlAccessibleObject
      
      Public Sub New(owner As MyCheckBox)
         MyBase.New(owner)
      End Sub
      
      Public Overrides ReadOnly Property DefaultAction() As String
         Get
            ' Return the DefaultAction based upon 
            ' the state of the control. 
            If CType(Owner, MyCheckBox).Checked Then
               Return "Toggle button up"
            Else
               Return "Toggle button down"
            End If
         End Get
      End Property
      
      Public Overrides Property Name() As String
         Get
            ' Return the Text property of the control 
            ' if the AccessibleName is null. 
            Dim accessibleName As String = Owner.AccessibleName
            If (accessibleName IsNot Nothing) Then
               Return accessibleName
            End If
            Return CType(Owner, MyCheckBox).Text
         End Get

         Set
            MyBase.Name = value
         End Set
      End Property
      
      Public Overrides ReadOnly Property Role() As AccessibleRole
         Get
            ' Since the check box appears like a button,
            ' make the Role the same as a button. 
            Return AccessibleRole.PushButton
         End Get
      End Property
   End Class
End Namespace
' </snippet1>


Namespace ControlAccessibility
   Public Class MyForm
      Inherits System.Windows.Forms.Form
      Private components As System.ComponentModel.Container = Nothing
      
      Protected Overrides Overloads Sub Dispose(disposing As Boolean)
         If disposing Then
            If (components IsNot Nothing) Then
               components.Dispose()
            End If
         End If
         MyBase.Dispose(disposing)
      End Sub 'Dispose
      
      Private Sub InitializeComponent()
         ' 
         ' Form1
         ' 
         Me.ClientSize = New System.Drawing.Size(292, 273)
         Me.Name = "Form1"
         Me.Text = "Form1"
      End Sub 'InitializeComponent

      <STAThread()> _
      Shared Sub Main()
        Application.Run(New MyForm())
      End Sub 'Main
      
' <snippet2>
Public Sub New()
   ' Create a 'MyCheckBox' control and 
   ' display an image on it. 
   Dim myCheckBox As New MyCustomControls.MyCheckBox()
   myCheckBox.Location = New Point(5, 5)
   myCheckBox.Image = Image.FromFile( _
     Application.CommonAppDataPath + "\Preview.jpg")

   ' Set the AccessibleName property
   ' since there is no Text displayed. 
   myCheckBox.AccessibleName = "Preview"

   ' Set the AccessibleDescription text.
   myCheckBox.AccessibleDescription = _
     "A toggle button used to show the document preview."
   Me.Controls.Add(myCheckBox)
End Sub
' </snippet2>

   End Class 'MyForm ' 

End Namespace 'ControlAccessibility