        Dim vbLongName As String = "Long"
        Dim vbDateName As String = "Date"
        Dim vbBadName As String = "Number"
        Dim testSysName As String
        testSysName = SystemTypeName(vbLongName)
        ' The preceding call returns "System.Int64".
        testSysName = SystemTypeName(vbDateName)
        ' The preceding call returns "System.DateTime".
        testSysName = SystemTypeName(vbBadName)
        ' The preceding call returns Nothing.