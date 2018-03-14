        ' Valid lambda expression assignments with Option Strict on or off:

        ' Integer matches Integer.
        Dim d1 As Del1 = Function(m As Integer) 3

        ' Integer widens to Long
        Dim d2 As Del1 = Function(m As Long) 3

        ' Integer widens to Double
        Dim d3 As Del1 = Function(m As Double) 3