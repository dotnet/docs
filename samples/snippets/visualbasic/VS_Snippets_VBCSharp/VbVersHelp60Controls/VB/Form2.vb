'*************************************************************************
Public Class Form2


'*************************************************************************
Class Microsoft
  Class VisualBasic
    Public Class ApplicationServices
      Class StartupNextInstanceEventArgs
        Inherits System.EventArgs
      End Class
    End Class
    Class Compatibility
      Class VB6
        Shared Sub SetItemString(ByRef o As Object, ByVal i As Integer, ByRef s As String)
        End Sub
        Shared Sub SetItemData(ByRef o As Object, ByVal i As Integer, ByRef v As Object)
        End Sub
        Shared Function GetItemData(ByRef o As Object, ByVal i As Integer) As String
          Return "hello"
        End Function
      End Class
    End Class
  End Class
End Class


Event StartupNextInstance(ByVal o As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs)


'*************************************************************************
'<Snippet3>
' Visual Basic
' Assumes that the Make Single Instance Application checkbox in the 
' Project Designer has been checked.

Private Sub MyApplication_StartupNextInstance() Handles Me.StartupNextInstance
    MsgBox("The application is already running!")
End Sub
'</Snippet3>


Private Sub TextChangedHandler(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
  MessageBox.Show("hello")
End Sub


Sub test()

  '<Snippet57>
  ' Visual Basic
  ' Declare a new TextBox.
  Dim TextBox2 As New TextBox
  ' Set the location below the first TextBox
  TextBox2.Left = TextBox1.Left
  TextBox2.Top = TextBox1.Top + 30
  ' Add the TextBox to the form's Controls collection.
  Me.Controls.Add(TextBox2)
  AddHandler TextBox2.TextChanged, AddressOf TextChangedHandler
  '</Snippet57>

End Sub


'*************************************************************************
'<Snippet46>
' Visual Basic
Private Sub Form1_Load()
   ' Raises the TextChanged event.
   ComboBox1.Items.Add("A")
End Sub
Private Sub Form1_Click()
   ' Uses the SetItemString method from the VB6 compatibility library; 
   ' there is no equivalent method in Visual Basic.
   ' Raises the TextChanged event.
   Microsoft.VisualBasic.Compatibility.VB6. 
      SetItemString(ComboBox1, ComboBox1.Items.Count, "B")
End Sub
'</Snippet46>


'*************************************************************************
'<Snippet10>
' Visual Basic
Private Sub Form1_Load(
    ByVal sender As System.Object,
    ByVal e As System.EventArgs) Handles MyBase.Load

   ComboBox1.Items.Add("Nancy Davolio")
   Microsoft.VisualBasic.Compatibility.VB6. 
      SetItemData(ComboBox1, ComboBox1.Items.Count() - 1, 12345)

   ComboBox1.Items.Add("Judy Phelps")
   Microsoft.VisualBasic.Compatibility.VB6. 
      SetItemData(ComboBox1, ComboBox1.Items.Count() - 1, 67890)
End Sub
'</Snippet10>


'******************************************************************************
'<Snippet8>
' Visual Basic
Private Sub ComboBox1_SelectedIndexChanged() Handles ComboBox1.SelectedIndexChanged
   Label1.Text = "Employee #" & CStr( 
   Microsoft.VisualBasic.Compatibility.VB6. 
      GetItemData(ComboBox1, ComboBox1.SelectedIndex))
End Sub
'</Snippet8>


Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
  'Form1_Load()
  'Form1_Click(New Object, New EventArgs)

  test()
End Sub

End Class