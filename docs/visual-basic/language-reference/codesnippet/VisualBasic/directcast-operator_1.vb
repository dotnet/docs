    Dim q As Object = 2.37
    Dim i As Integer = CType(q, Integer)
    ' The following conversion fails at run time
    Dim j As Integer = DirectCast(q, Integer)
    Dim f As New System.Windows.Forms.Form
    Dim c As System.Windows.Forms.Control
    ' The following conversion succeeds.
    c = DirectCast(f, System.Windows.Forms.Control)