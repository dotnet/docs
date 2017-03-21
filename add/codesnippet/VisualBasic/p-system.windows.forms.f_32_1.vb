   Private Sub CreateMyChildForm()
      ' Create a new form to represent the child form.
      Dim child As New Form()
      ' Increment the private child count.
      childCount += 1
      ' Set the text of the child form using the count of child forms.
      Dim formText As String = "Child " + childCount.ToString()
      child.Text = formText

      ' Make the new form a child form.
      child.MdiParent = Me
      ' Display the child form.
      child.Show()
   End Sub