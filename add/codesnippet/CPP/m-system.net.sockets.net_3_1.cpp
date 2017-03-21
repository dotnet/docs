
   // Example of EndWrite
   static void myWriteCallBack( IAsyncResult^ ar )
   {
      NetworkStream^ myNetworkStream = safe_cast<NetworkStream^>(ar->AsyncState);
      myNetworkStream->EndWrite( ar );
   }