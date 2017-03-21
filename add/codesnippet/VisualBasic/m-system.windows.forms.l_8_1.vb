    ' Declare the ListView and Button for the example.
    Private findListView As New ListView()
    Private WithEvents findButton As New Button()


    Private Sub InitializeFindListView()

        ' Set up the location and event handling for the button.
        findButton.Location = New Point(10, 10)

        ' Set up the location of the ListView and add some items.
        findListView.Location = New Point(10, 30)
        findListView.Items.Add(New ListViewItem("angle bracket"))
        findListView.Items.Add(New ListViewItem("bracket holder"))
        findListView.Items.Add(New ListViewItem("bracket"))

        ' Add the button and ListView to the form.
        Me.Controls.Add(findButton)
        Me.Controls.Add(findListView)

    End Sub

    Private Sub findButton_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles findButton.Click

        ' Call FindItemWithText, sending output to MessageBox.
        Dim item1 As ListViewItem = findListView.FindItemWithText("brack")
        If (item1 IsNot Nothing) Then
            MessageBox.Show("Calling FindItemWithText passing 'brack': " _
                & item1.ToString())
        Else
            MessageBox.Show("Calling FindItemWithText passing 'brack': null")
        End If

    End Sub