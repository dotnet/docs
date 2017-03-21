    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Set the maximum size, so if user maximizes form, it 
        'will not cover entire desktop.  
        Me.MaximumSize = New Size(500, 500)


    End Sub