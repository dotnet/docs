Public Class Form1

  '****************************************************************************
  Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
    Dim o As New Class1

    Class1.BirthdayCollection()

    'Class1.TestGetEnumerator()
    'Class1.TestContains()
    'MessageBox.Show(Class1.TestClear())
    'o.classNamer()
  End Sub


  '****************************************************************************
  '<Snippet2>
  Public Class child
      Public name As String
      Sub New(ByVal newName As String)
          name = newName
      End Sub
  End Class
  ' Create a Collection object.
  Private family As New Collection()
  Private Sub addChild_Click() Handles Button1.Click
      Dim newName As String
      newName = InputBox("Name of new family member: ")
      If newName <> "" Then
          family.Add(New child(newName), newName)
      End If
  End Sub
  Private Sub listChild_Click() Handles Button2.Click
      For Each aChild As child In family
          MsgBox(aChild.name)
      Next
  End Sub
  '</Snippet2>

End Class
