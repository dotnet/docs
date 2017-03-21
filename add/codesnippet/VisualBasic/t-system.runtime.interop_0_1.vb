Interface Baz
    Sub SetColor( <ComAliasName("stdole.OLE_COLOR")> cl As Integer)
    Function GetColor() As <ComAliasName("stdole.OLE_COLOR")> Integer
End Interface