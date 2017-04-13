
' <snippet1>
Public Class Form1

    ' Use this Random object to choose random icons for the squares
    Private random As New Random

    ' Each of these letters is an interesting icon
    ' in the Webdings font,
    ' and each icon appears twice in this list
    Private icons =
      New List(Of String) From {"!", "!", "N", "N", ",", ",", "k", "k",
                                "b", "b", "v", "v", "w", "w", "z", "z"}
    ' </snippet1>

    ' <snippet2>
    ''' <summary>
    ''' Assign each icon from the list of icons to a random square
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AssignIconsToSquares()

        ' The TableLayoutPanel has 16 labels,
        ' and the icon list has 16 icons,
        ' so an icon is pulled at random from the list
        ' and added to each label
        For Each control In TableLayoutPanel1.Controls
            ' <snippet16>
            Dim iconLabel = TryCast(control, Label)
            If iconLabel IsNot Nothing Then
                Dim randomNumber = random.Next(icons.Count)
                iconLabel.Text = icons(randomNumber)
                ' iconLabel.ForeColor = iconLabel.BackColor
                icons.RemoveAt(randomNumber)
            End If
            ' </snippet16>
        Next

    End Sub
    ' </snippet2>

    ' <snippet3>
    Public Sub New()
        ' This call is required by Windows Form Designer
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call
        AssignIconsToSquares()
    End Sub
    ' </snippet3>

    Private Sub PlaceHolder2()

        ' <snippet14>
        For Each control In TableLayoutPanel1.Controls
            ' The statements you want to execute 
            ' for each label go here
            ' The statements use iconLabel to access 
            ' each label's properties and methods
        Next
        ' </snippet14>

        For Each control In TableLayoutPanel1.Controls
            Dim iconLabel = TryCast(control, Label)
            If iconLabel IsNot Nothing Then
                Dim randomNumber = random.Next(icons.Count)
                iconLabel.Text = icons(randomNumber)
                ' <snippet15>
                iconLabel.ForeColor = iconLabel.BackColor
                ' </snippet15>
                icons.RemoveAt(randomNumber)
            End If
        Next

    End Sub


    ' <snippet4>
    ''' <summary>
    ''' Every label's Click event is handled by this event handler
    ''' </summary>
    ''' <param name="sender">The label that was clicked</param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub label_Click(ByVal sender As System.Object, 
                            ByVal e As System.EventArgs) Handles Label9.Click, 
        Label8.Click, Label7.Click, Label6.Click, Label5.Click, Label4.Click, 
        Label3.Click, Label2.Click, Label16.Click, Label15.Click, Label14.Click, 
        Label13.Click, Label12.Click, Label11.Click, Label10.Click, Label1.Click

        Dim clickedLabel = TryCast(sender, Label)

        If clickedLabel IsNot Nothing Then

            ' If the clicked label is black, the player clicked 
            ' an icon that's already been revealed -- 
            ' ignore the click
            If clickedLabel.ForeColor = Color.Black Then Exit Sub

            clickedLabel.ForeColor = Color.Black
        End If
    End Sub
    ' </snippet4>

End Class




