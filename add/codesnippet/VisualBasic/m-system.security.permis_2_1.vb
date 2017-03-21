            ' Display result of ToXml and FromXml operations.
            Dim ps6 As New PermissionSet(PermissionState.None)
            ps6.FromXml(ps5.ToXml())
            Console.WriteLine("Result of ToFromXml = " & ps6.ToString() & ControlChars.Lf)