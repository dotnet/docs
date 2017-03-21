
		HttpWebRequest myReq =
		(HttpWebRequest)WebRequest.Create("http://www.contoso.com/");
               
		myReq.ReadWriteTimeout = 100000;