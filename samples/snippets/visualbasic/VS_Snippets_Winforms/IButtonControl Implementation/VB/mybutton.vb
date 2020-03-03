 ' <snippet1>
Imports System.Windows.Forms
Imports System.Drawing


Public Class MyButton
   Inherits ButtonBase
   Implements IButtonControl 
   Private myDialogResult As DialogResult
      
   Public Sub New()
      ' Make the button White and a Popup style      ' so it can be distinguished on the form.
      Me.FlatStyle = FlatStyle.Popup
      Me.BackColor = Color.White
   End Sub
   
   ' Add implementation to the IButtonControl.DialogResult property.
   Public Property DialogResult() As DialogResult Implements IButtonControl.DialogResult
      Get
         Return Me.myDialogResult
      End Get
      
      Set
         If [Enum].IsDefined(GetType(DialogResult), value) Then
            Me.myDialogResult = value
         End If
      End Set
   End Property
   
   ' Add implementation to the IButtonControl.NotifyDefault method.
   Public Sub NotifyDefault(value As Boolean) Implements IButtonControl.NotifyDefault
      If Me.IsDefault <> value Then
         Me.IsDefault = value
      End If
   End Sub 
      
   ' Add implementation to the IButtonControl.PerformClick method.
   Public Sub PerformClick() Implements IButtonControl.PerformClick
      If Me.CanSelect Then
         Me.OnClick(EventArgs.Empty)
      End If
   End Sub

End Class
' </snippet1>