using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

public class Sample : SoapExtension {
    
// <Snippet1>
public override void ProcessMessage(SoapMessage message) {
        switch (message.Stage) {

        case SoapMessageStage.BeforeSerialize:
            break;

        case SoapMessageStage.AfterSerialize:
            WriteOutput( message );
            break;

        case SoapMessageStage.BeforeDeserialize:
            WriteInput( message );
            break;

        case SoapMessageStage.AfterDeserialize:
            break;

        }
}

// </Snippet1>

public override object GetInitializer(LogicalMethodInfo lmi, SoapExtensionAttribute sea) {
// method added so sample will compile
    object myobject = new Object();
    return myobject;
}

public override void Initialize(object o) {
// method added so sample will compile
}

public void WriteOutput(SoapMessage message) {
// method added so sample will compile
}

public void WriteInput(SoapMessage message) {
// method added so sample will compile
}

    public override object GetInitializer(Type filename) {
        return (Type) filename;
    }

}

public class myentrypoint {

	public static void Main() { }
}
