        Private selectParams As ParameterCollection

        ' Associate the ParameterCollectionEditor with the SelectParameters. 
        <EditorAttribute(GetType(System.Web.UI.Design.WebControls. _
            ParameterCollectionEditor), _
            GetType(UITypeEditor))> _
        Public Property SelectParameters() As ParameterCollection
            Get
                If selectParams Is Nothing Then
                    selectParams = New ParameterCollection()
                End If
                Return selectParams
            End Get
            Set(ByVal value As ParameterCollection)
                selectParams = value
            End Set
        End Property ' SelectParameters