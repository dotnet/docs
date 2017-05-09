using System;
using System.ComponentModel;
using System.ComponentModel.Design;

public class Sample {

    public void SampleMethod() {

        ServiceContainer serviceContainer = new ServiceContainer();
        
// <Snippet1>
// The following code shows how to publish a service using a callback function.

// Creates a service creator callback.
ServiceCreatorCallback callback1 = 
new ServiceCreatorCallback(myCallBackMethod);

// Adds the service using its type and the service creator callback.
serviceContainer.AddService(typeof(myService), callback1);
// </Snippet1>

    }

    // Method added so class will compile
    public Object myCallBackMethod
    (IServiceContainer container, Type serviceType) {
        return new Object();
    }
}

// Class added so sample will compile
public class myService {};
