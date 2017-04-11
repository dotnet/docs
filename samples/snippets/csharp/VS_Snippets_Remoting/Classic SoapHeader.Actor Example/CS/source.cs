using System.Web.Services.Protocols;
// <Snippet1>
using System;

public class Sample {
    
    public static void Main() {
        MyWebService ws = new MyWebService();

        try {
            MyHeader customHeader = new MyHeader();
            customHeader.MyValue = "Header Value for MyValue";
            customHeader.Actor = "http://www.contoso.com/MySoapHeaderHandler";
            ws.myHeader = customHeader;
            
	    int results = ws.MyWebMethod(3,5);
        }
        catch (Exception e) {
            Console.WriteLine ("Exception: {0}", e.ToString());
        }
    }
}

// </Snippet1>

// Following was added to make the sample compile.  
public class MyHeader : SoapHeader {

	public string MyValue;
}

public class MyWebService {

	public MyHeader myHeader;

	public int MyWebMethod(int num1, int num2) {return num1 + num2;}

}