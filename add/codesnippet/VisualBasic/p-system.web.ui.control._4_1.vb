        ' Add property values to view state with set; 
        ' retrieve them from view state with get.
        Public Property [Text]() As String
            Get
                Dim o As Object = ViewState("Text")
                If (IsNothing(o)) Then
                    Return String.Empty
                Else
                    Return CStr(o)
                End If
            End Get
            Set(ByVal value As String)
                ViewState("Text") = value
            End Set
        End Property
