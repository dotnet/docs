    Public Property DataTextField() As String
        Get
            Dim o As Object = ViewState("DataTextField")
            If o Is Nothing Then
                Return String.Empty
            Else
                Return CStr(o)
            End If
        End Get
        Set(ByVal value As String)
            ViewState("DataTextField") = value
            If (Initialized) Then
                OnDataPropertyChanged()
            End If
        End Set
    End Property