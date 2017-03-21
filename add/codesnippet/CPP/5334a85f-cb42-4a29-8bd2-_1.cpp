      // Allocates a graphics buffer using the pixel format 
      // of the specified handle to a device context.
      grafx = appDomainBufferedGraphicsContext->Allocate( this->Handle,
         Rectangle( 0, 0, 400, 400 ) );