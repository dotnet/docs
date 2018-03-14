 ' <snippet1>
Imports System
Imports System.Windows.Forms
Imports System.Drawing

   Public Class MyContainerControl
      Inherits ScrollableControl
      Implements IContainerControl 

      Private myActiveControl As Control
      
      Public Sub New()
         ' Make the container control Blue so it can be distinguished on the form.
         Me.BackColor = Color.Blue
         
         ' Make the container scrollable.
         Me.AutoScroll = True
      End Sub 
      
      ' Add implementation to the IContainerControl.ActiveControl property.
      Public Property ActiveControl() As Control Implements IContainerControl.ActiveControl
         Get
            Return Me.myActiveControl
         End Get
         
         Set
            ' Make sure the control is a member of the ControlCollection.
            If Me.Controls.Contains(value) Then
               Me.myActiveControl = value
            End If
         End Set
      End Property
      
      ' Add implementation to the IContainerControl.ActivateControl(Control) method.
      public Function ActivateControl(active As Control) As Boolean Implements IContainerControl.ActivateControl
         If Me.Controls.Contains(active) Then
            ' Select the control and scroll the control into view if needed.
            active.Select()
            Me.ScrollControlIntoView(active)
            Me.myActiveControl = active
            Return True
         End If
         Return False
      End Function 

   End Class  
' </snippet1>