        ' Create an instance of the SomeType class that is defined in this assembly.
        Dim oh As System.Runtime.Remoting.ObjectHandle = _
            Activator.CreateInstanceFrom(Assembly.GetEntryAssembly().CodeBase, _
                                         GetType(SomeType).FullName)

        ' Call an instance method defined by the SomeType type using this object.
        Dim st As SomeType = CType(oh.Unwrap(), SomeType)

        st.DoSomething(5)