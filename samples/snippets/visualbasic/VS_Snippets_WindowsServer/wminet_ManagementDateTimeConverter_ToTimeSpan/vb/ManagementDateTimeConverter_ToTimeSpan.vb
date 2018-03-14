'<Snippet1>
Imports System
Imports System.Management

'The sample below demonstrates the various conversions
' that can be done using ManagementDateTimeConverter class    
Class Sample_ManagementClass
    Public Overloads Shared Function Main(ByVal args() As String) _
        As Integer
        Dim dmtfDate As String = "20020408141835.999999-420"
        Dim dmtfTimeInterval As String = "00000010122532:123456:000"

        'Converting DMTF datetime and intervals to System.DateTime
        Dim dt As DateTime = _
            ManagementDateTimeConverter.ToDateTime(dmtfDate)

        'Converting System.DateTime to DMTF datetime
        dmtfDate = _
            ManagementDateTimeConverter.ToDmtfDateTime(DateTime.Now)

        ' Converting DMTF timeinterval to System.TimeSpan
        Dim tsRet As System.TimeSpan = _
            ManagementDateTimeConverter.ToTimeSpan(dmtfTimeInterval)

        'Converting System.TimeSpan to DMTF time interval format
        Dim ts As System.TimeSpan = _
            New System.TimeSpan(10, 12, 25, 32, 456)
        Dim dmtfTimeInt As String
        dmtfTimeInt = _
            ManagementDateTimeConverter.ToDmtfTimeInterval(ts)

        Return 0
    End Function
End Class
'</Snippet1>