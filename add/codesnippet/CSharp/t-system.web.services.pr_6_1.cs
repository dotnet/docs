public class MyHeader : SoapHeader {
    public string MyValue;
}

public class MyWebService {

    public MyHeader myHeader;

    [WebMethod]
    [SoapHeader("myHeader", 
                Direction=SoapHeaderDirection.InOut | SoapHeaderDirection.Fault)]
    public void MySoapHeaderReceivingMethod() {

        // Set myHeader.MyValue to some value.

    }
}
   