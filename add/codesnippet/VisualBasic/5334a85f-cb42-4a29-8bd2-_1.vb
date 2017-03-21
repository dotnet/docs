        ' Allocates a graphics buffer using the pixel format 
        ' of the specified handle to device context.
        grafx = appDomainBufferedGraphicsContext.Allocate(Me.Handle, New Rectangle(0, 0, 400, 400))