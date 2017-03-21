    <EditorAttribute(GetType(ArrayEditor), GetType(System.Drawing.Design.UITypeEditor))> _
    Public Property componentArray() As Object()
        Get
            Return compArray
        End Get
        Set(ByVal Value As Object())
            compArray = Value
        End Set
    End Property
    Private compArray() As Object