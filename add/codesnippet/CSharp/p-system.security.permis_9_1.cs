            FileIOPermission f3 = new FileIOPermission(PermissionState.None);
            f3.AllFiles = FileIOPermissionAccess.Read;
            try
            {
                f3.Demand();
            }
            catch (SecurityException s)
            {
                Console.WriteLine(s.Message);
            }
