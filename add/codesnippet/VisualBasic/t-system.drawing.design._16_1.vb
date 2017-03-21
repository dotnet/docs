    Public Function CreatePaintValueEventArgs(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal value As Object, ByVal graphics As Graphics, ByVal bounds As Rectangle) As PaintValueEventArgs
        Dim e As New PaintValueEventArgs(context, value, graphics, bounds)
        ' The context of the paint value event         e.Context
        ' The object representing the value to paint   e.Value
        ' The graphics to use to paint                 e.Graphics
        ' The rectangle in which to paint              e.Bounds                       
        Return e
    End Function
