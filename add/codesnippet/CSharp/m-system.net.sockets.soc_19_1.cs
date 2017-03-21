	StateObject so = (StateObject) ar.AsyncState;
	Socket s = so.workSocket;

	int send = s.EndSend(ar);

       Console.WriteLine("The size of the message sent was :" + send.ToString());
	
	s.Close();