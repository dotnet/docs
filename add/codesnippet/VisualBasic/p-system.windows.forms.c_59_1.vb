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