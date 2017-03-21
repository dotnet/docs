        Dim PC As New PerformanceCounter()
        PC.CategoryName = "Process"
        PC.CounterName = "Private Bytes"
        PC.InstanceName = "Explorer"
        MessageBox.Show(PC.NextValue().ToString())