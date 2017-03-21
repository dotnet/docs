    Sub MyMethod(o As Object)
        ' handle object ...
    End Sub

    Public Sub DoWrap()
        Dim o As Object = new MyObject()
        MyMethod(o)                      ' passes o as VT_UNKNOWN
        MyMethod(new DispatchWrapper(o)) ' passes o as VT_DISPATCH

        '...
    End Sub