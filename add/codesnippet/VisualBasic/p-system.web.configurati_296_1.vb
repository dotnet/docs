         ' Get the current MinIOThreads property value.
            Dim minIOThreads As Integer = _
            processModelSection.MinIOThreads
         
         ' Set the MinIOThreads property to 1.
         processModelSection.MinIOThreads = 1
         