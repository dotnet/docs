   ' Utility to map virtual directories to physical ones.
   ' In the current physical directory maps 
   ' a physical sub-directory with its virtual directory.
   ' A web.config file is created for the
    ' default and the virtual directory at the appropriate level.
    'You must create a physical directory called config at the
    'level where your app is running.
   Shared Function CreateFileMap() As WebConfigurationFileMap
      
      Dim fileMap As New WebConfigurationFileMap()
      
      ' Get he physical directory where this app runs.
      ' We'll use it to map the virtual directories
      ' defined next. 
      Dim physDir As String = Environment.CurrentDirectory
      
      ' Create a VirtualDirectoryMapping object to use
      ' as the root directory for the virtual directory
      ' named config. 
      ' Note: you must assure that you have a physical subdirectory
      ' named config in the curremt physical directory where this
      ' application runs.
        Dim vDirMap As New VirtualDirectoryMapping(physDir + _
        "\config", True)
      
      ' Add vDirMap to the VirtualDirectories collection 
      ' assigning to it the virtual directory name.
      fileMap.VirtualDirectories.Add("/config", vDirMap)
      
      ' Create a VirtualDirectoryMapping object to use
      ' as the default directory for all the virtual 
      ' directories.
        Dim vDirMapBase As New VirtualDirectoryMapping(physDir, _
        True, "web.config")
      
      ' Add it to the virtual directory mapping collection.
      fileMap.VirtualDirectories.Add("/", vDirMapBase)
      
    
#If DEBUG Then
      Dim key As String
      For Each key In  fileMap.VirtualDirectories.AllKeys
            Console.WriteLine("Virtual directory: {0} Physical path: {1}", _
            fileMap.VirtualDirectories(key).VirtualDirectory, _
            fileMap.VirtualDirectories(key).PhysicalDirectory)
      Next key
#End If

      ' Return the mapping.
      Return fileMap

    End Function 'CreateFileMap
    
   