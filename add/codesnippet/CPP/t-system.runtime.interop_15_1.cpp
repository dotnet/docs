    void MyMethod(Object^ o);

    void DoWrap()
    {
        Object^ o = gcnew MyObject();
        MyMethod(o);                        // passes o as VT_UNKNOWN
        MyMethod(gcnew DispatchWrapper(o)); // passes o as VT_DISPATCH

        //...
    }