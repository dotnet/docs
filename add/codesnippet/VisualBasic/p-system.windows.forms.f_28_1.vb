   Private Sub DisplayMyScrollableForm()
      ' Create a new form.
      Dim form2 As New Form()
      ' Create a button to add to the new form.
      Dim button1 As New Button()
      ' Set text for the button.
      button1.Text = "Scrolled Button"
      ' Set the size of the button.
      button1.Size = New Size(100, 30)
      ' Set the location of the button to be outside the form's client area.
      button1.Location = New Point(form2.Size.Width + 200, form2.Size.Height + 200)

      ' Add the button control to the new form.
      form2.Controls.Add(button1)
      ' Set the AutoScroll property to true to provide scrollbars.
      form2.AutoScroll = True

      ' Display the new form as a dialog box.
      form2.ShowDialog()
   End Sub