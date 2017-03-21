            FileIOPermission f2 = new FileIOPermission(FileIOPermissionAccess.Read, "C:\\test_r");
            f2.AddPathList(FileIOPermissionAccess.Write | FileIOPermissionAccess.Read, "C:\\example\\out.txt");
            try
            {
                f2.Demand();
            }
            catch (SecurityException s)
            {
                Console.WriteLine(s.Message);
            }