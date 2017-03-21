public static void Listen_Callback(IAsyncResult ar){
     allDone.Set();
     Socket s = (Socket) ar.AsyncState;
     Socket s2 = s.EndAccept(ar);
     StateObject so2 = new StateObject();
     so2.workSocket = s2;
     s2.BeginReceive(so2.buffer, 0, StateObject.BUFFER_SIZE,0,
	                       new AsyncCallback(Async_Send_Receive.Read_Callback), so2);	
}