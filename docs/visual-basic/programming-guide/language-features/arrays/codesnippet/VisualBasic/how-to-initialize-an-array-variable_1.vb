        ' The following five lines of code create the same array.
        ' Preferred syntaxes are on the lines with chars1 and chars2.
        Dim chars1 = {"%"c, "&"c, "@"c}
        Dim chars2 As Char() = {"%"c, "&"c, "@"c}

        Dim chars3() As Char = {"%"c, "&"c, "@"c}
        Dim chars4 As Char() = New Char(2) {"%"c, "&"c, "@"c}
        Dim chars5() As Char = New Char(2) {"%"c, "&"c, "@"c}