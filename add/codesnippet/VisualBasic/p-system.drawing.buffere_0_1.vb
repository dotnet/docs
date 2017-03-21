        ' Sets the maximum size for the graphics buffer 
        ' of the buffered graphics context. Any allocation 
        ' requests for a buffer larger than this will create 
        ' a temporary buffered graphics context to host 
        ' the graphics buffer.
        appDomainBufferedGraphicsContext.MaximumBuffer = New Size(400, 400)