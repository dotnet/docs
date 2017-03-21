// Example of EndWrite
public static void myWriteCallBack(IAsyncResult ar){

     NetworkStream myNetworkStream = (NetworkStream)ar.AsyncState;
     myNetworkStream.EndWrite(ar);
}
