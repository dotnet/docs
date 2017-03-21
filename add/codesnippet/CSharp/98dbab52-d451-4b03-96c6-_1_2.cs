
        // Utility to map virtual directories to physical ones.
        // In the current physical directory maps 
        // a physical sub-directory with its virtual directory.
        // A web.config file is created for the
        // default and the virtual directory at the appropriate level.
        // You must create a physical directory called config at the
        // level where your app is running.
        static WebConfigurationFileMap CreateFileMap()
        {

            WebConfigurationFileMap fileMap =
                   new WebConfigurationFileMap();

            // Get he physical directory where this app runs.
            // We'll use it to map the virtual directories
            // defined next. 
            string physDir = Environment.CurrentDirectory;

            // Create a VirtualDirectoryMapping object to use
            // as the root directory for the virtual directory
            // named config. 
            // Note: you must assure that you have a physical subdirectory
            // named config in the curremt physical directory where this
            // application runs.
            VirtualDirectoryMapping vDirMap = 
                new VirtualDirectoryMapping(physDir + "\\config", true);

            // Add vDirMap to the VirtualDirectories collection 
            // assigning to it the virtual directory name.
            fileMap.VirtualDirectories.Add("/config", vDirMap);

            // Create a VirtualDirectoryMapping object to use
            // as the default directory for all the virtual 
            // directories.
            VirtualDirectoryMapping vDirMapBase =
                new VirtualDirectoryMapping(physDir, true, "web.config");

            // Add it to the virtual directory mapping collection.
            fileMap.VirtualDirectories.Add("/", vDirMapBase);

# if DEBUG  
            // Test at debug time.
            foreach (string key in fileMap.VirtualDirectories.AllKeys)
            {
                Console.WriteLine("Virtual directory: {0} Physical path: {1}",
                fileMap.VirtualDirectories[key].VirtualDirectory, 
                fileMap.VirtualDirectories[key].PhysicalDirectory);
            }
# endif 

            // Return the mapping.
            return fileMap;

        }
