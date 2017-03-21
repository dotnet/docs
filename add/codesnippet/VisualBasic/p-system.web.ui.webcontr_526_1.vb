        Protected Overloads ReadOnly Property Control() As _
            System.Web.UI.WebControls.Menu

            Get
                Return CType( _
                    MyBase.Control, _
                    System.Web.UI.WebControls.Menu)
            End Get
        End Property