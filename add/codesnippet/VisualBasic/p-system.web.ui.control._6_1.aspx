
   Private Sub Button1_Click(sender As Object, MyEventArgs As EventArgs)
   ' Find control on page.
   Dim myControl1 As Control = FindControl("TextBox2")
   If (Not myControl1 Is Nothing)
      ' Get control's parent.
      Dim myControl2 As Control = myControl1.Parent
      Response.Write("Parent of the text box is : " & myControl2.ID)
   Else
      Response.Write("Control not found.....")
   End If
   End Sub
