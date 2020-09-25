Imports System

Namespace ca1028
    '<snippet1>
    <Flags()>
    Public Enum Days As UInteger
        None = 0
        Monday = 1
        Tuesday = 2
        Wednesday = 4
        Thursday = 8
        Friday = 16
        All = Monday Or Tuesday Or Wednesday Or Thursday Or Friday
    End Enum

    Public Enum Color As SByte
        None = 0
        Red = 1
        Orange = 3
        Yellow = 4
    End Enum
    '</snippet1>
End Namespace

Namespace ca1028_2
    '<snippet2>
    <Flags()>
    Public Enum Days As Integer
        None = 0
        Monday = 1
        Tuesday = 2
        Wednesday = 4
        Thursday = 8
        Friday = 16
        All = Monday Or Tuesday Or Wednesday Or Thursday Or Friday
    End Enum

    Public Enum Color As Integer
        None = 0
        Red = 1
        Orange = 3
        Yellow = 4
    End Enum
    '</snippet2>
End Namespace
