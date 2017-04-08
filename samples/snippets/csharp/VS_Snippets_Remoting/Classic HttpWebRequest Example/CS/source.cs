using System;
using System.Net;

public class Sample {

    public void Method() {

// <Snippet1>

 HttpWebRequest myReq =
 (HttpWebRequest)WebRequest.Create("http://www.contoso.com/");
 
// </Snippet1>

    }
    public void Method1() {
// <Snippet2>

		HttpWebRequest myReq =
		(HttpWebRequest)WebRequest.Create("http://www.contoso.com/");
               
		myReq.ReadWriteTimeout = 100000;
// </Snippet2>

    }

}
