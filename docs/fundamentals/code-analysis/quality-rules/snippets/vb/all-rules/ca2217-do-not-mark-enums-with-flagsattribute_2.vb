Imports System
Namespace Samples

    <FlagsAttribute()> _
    Public Enum Days

        None = 0
        Monday = 1
        Tuesday = 2
        Wednesday = 4
        Thursday = 8
        Friday = 16
        All = Monday Or Tuesday Or Wednesday Or Thursday Or Friday

    End Enum
End Namespace
