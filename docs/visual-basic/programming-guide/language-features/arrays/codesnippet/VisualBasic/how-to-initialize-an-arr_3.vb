        ' The following five lines of code create the same array.
        ' Preferred syntaxes are on the lines with scores1 and scores2.
        Dim scores1 = {{10S, 10S, 10S}, {10S, 10S, 10S}}
        Dim scores2 As Short(,) = {{10, 10, 10}, {10, 10, 10}}

        Dim scores3(,) As Short = {{10, 10, 10}, {10, 10, 10}}
        Dim scores4 As Short(,) = New Short(1, 2) {{10, 10, 10}, {10, 10, 10}}
        Dim scores5(,) As Short = New Short(1, 2) {{10, 10, 10}, {10, 10, 10}}