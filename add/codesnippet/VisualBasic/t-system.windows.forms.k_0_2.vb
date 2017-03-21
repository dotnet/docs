    Private myKeyPressHandler As New myKeyPressClass()
    
    Public Sub New()
        InitializeComponent()
        
        AddHandler textBox1.KeyPress, AddressOf myKeyPressHandler.myKeyCounter
    End Sub 'New
    