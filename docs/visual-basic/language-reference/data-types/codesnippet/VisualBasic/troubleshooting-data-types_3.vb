    Dim charVar As Char
    ' The following statement attempts to convert a String literal to Char.
    ' Because Option Strict is On, it generates a compiler error.
    charVar = "Z"
    ' The following statement succeeds because it specifies a Char literal.
    charVar = "Z"c
    ' The following statement succeeds because it converts String to Char.
    charVar = CChar("Z")