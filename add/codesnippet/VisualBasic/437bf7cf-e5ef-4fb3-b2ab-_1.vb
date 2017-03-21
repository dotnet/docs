        Protected Overloads ReadOnly Property Control() As _
            System.Web.UI.WebControls.TreeView

            Get
                Return CType( _
                    MyBase.Control, _
                    System.Web.UI.WebControls.TreeView)
            End Get
        End Property