   // Create a NetworkStream that owns clientSocket and 
   // then create a BufferedStream on top of the NetworkStream.
   NetworkStream^ netStream = gcnew NetworkStream( clientSocket,true );
   BufferedStream^ bufStream = gcnew BufferedStream( netStream,streamBufferSize );
   