     allDone.Set();
     Socket s = (Socket) ar.AsyncState;
     s.EndConnect(ar);
     StateObject so2 = new StateObject();
     so2.workSocket = s;
     byte[] buff = Encoding.ASCII.GetBytes("This is a test");
     s.BeginSend(buff, 0, buff.Length,0,
	                       new AsyncCallback(Async_Send_Receive.Send_Callback), so2);    