        // Create an instance of the SomeType class that is defined in this 
        // assembly.
        System.Runtime.Remoting.ObjectHandle oh = 
            Activator.CreateInstanceFrom(Assembly.GetEntryAssembly().CodeBase, 
                                         typeof(SomeType).FullName);

        // Call an instance method defined by the SomeType type using this object.
        SomeType st = (SomeType) oh.Unwrap();

        st.DoSomething(5);