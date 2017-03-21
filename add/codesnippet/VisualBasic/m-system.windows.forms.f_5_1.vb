    Shared x As Integer = 200
    Shared y As Integer = 200

    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        ' Create a new Form1 and set its Visible property to true.
        Dim form2 As New Form1
        form2.Visible = True

        ' Set the new form's desktop location so it appears below and 
        ' to the right of the current form.
        form2.SetDesktopLocation(x, y)
        x += 30
        y += 30

        ' Keep the current form active by calling the Activate method.
        Me.Activate()
        Me.Button1.Enabled = False
    End Sub



    ' Updates the label text to reflect the current values of x and y, 
    ' which was were incremented in the Button1 control's click event.
    Private Sub Form1_Activated(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles MyBase.Activated
        Label1.Text = "x: " & x & " y: " & y
        Label2.Text = "Number of forms currently open: " & count
    End Sub

    Shared count As Integer = 0

    Private Sub Form1_Closed(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles MyBase.Closed
        count -= 1
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles MyBase.Load
        count += 1
    End Sub