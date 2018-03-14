'<Snippet1>
Imports System

Namespace Samples

    ' Violates this rule    
    <FlagsAttribute()> _
    Public Enum Color

        None = 0
        Red = 1
        Orange = 3
        Yellow = 4

    End Enum
End Namespace
'</Snippet1>