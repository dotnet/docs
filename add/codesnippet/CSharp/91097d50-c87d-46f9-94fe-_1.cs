	StateObject so = (StateObject) ar.AsyncState;
	Socket s = so.workSocket;

       // Creates a temporary EndPoint to pass to EndReceiveFrom.
       IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
	EndPoint tempRemoteEP = (EndPoint)sender;

       int read = s.EndReceiveFrom(ar, ref tempRemoteEP); 


	if (read > 0) {
            so.sb.Append(Encoding.ASCII.GetString(so.buffer, 0, read));
            s.BeginReceiveFrom(so.buffer, 0, StateObject.BUFFER_SIZE, 0, ref tempRemoteEP,
            	                     new AsyncCallback(Async_Send_Receive.ReceiveFrom_Callback), so);
	}
	else{
	     if (so.sb.Length > 1) {
	          //All the data has been read, so displays it to the console.
	          string strContent;
	          strContent = so.sb.ToString();
	          Console.WriteLine(String.Format("Read {0} byte from socket" + 
	          	               "data = {1} ", strContent.Length, strContent));
	     }
	     s.Close();
	     
	}