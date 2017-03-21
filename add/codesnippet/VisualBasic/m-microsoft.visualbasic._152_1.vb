        Dim sysDateName As String = "System.DateTime"
        Dim sysShortName As String = "Int16"
        Dim sysBadName As String = "Nonsense"
        Dim testVbName As String
        testVbName = VbTypeName(sysDateName)
        ' Returns "Date".
        testVbName = VbTypeName(sysShortName)
        ' Returns "Short".
        testVbName = VbTypeName(sysBadName)
        ' Returns Nothing.