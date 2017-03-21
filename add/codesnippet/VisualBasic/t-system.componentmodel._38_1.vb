    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = "changed"
        AddHandler System.ComponentModel.TypeDescriptor.Refreshed, AddressOf OnRefreshed
        System.ComponentModel.TypeDescriptor.GetProperties(TextBox1)
        System.ComponentModel.TypeDescriptor.Refresh(TextBox1)
    End Sub

    Private Sub OnRefreshed(ByVal e As System.ComponentModel.RefreshEventArgs)
        Console.WriteLine(e.ComponentChanged.ToString())
    End Sub