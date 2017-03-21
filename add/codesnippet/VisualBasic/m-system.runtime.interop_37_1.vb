        ' Demonstrate the use of the SizeOf method of the Marshal class.
        Console.WriteLine("Number of bytes needed by a Point object: {0}", Marshal.SizeOf(GetType(Point)))
        Dim p As New Point()
        Console.WriteLine("Number of bytes needed by a Point object: {0}", Marshal.SizeOf(p))