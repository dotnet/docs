            // Display result of ToXml and FromXml operations.
            PermissionSet ps6 = new PermissionSet(PermissionState.None);
            ps6.FromXml(ps5.ToXml());
            Console.WriteLine("Result of ToFromXml = " + ps6.ToString() + "\n");