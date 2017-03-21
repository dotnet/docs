	StateObject so = (StateObject) ar.AsyncState;
	Socket s = so.workSocket;

	int send = s.EndSendTo(ar);

       Console.WriteLine("The size of the message sent was :" + send.ToString());
	
	s.Close();