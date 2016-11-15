        ' Valid return types with Option Strict on:

        ' Integer matches Integer.
        Dim d6 As Del1 = Function(m As Integer) m

        ' Short widens to Integer.
        Dim d7 As Del1 = Function(m As Long) CShort(m)

        ' Byte widens to Integer.
        Dim d8 As Del1 = Function(m As Double) CByte(m)