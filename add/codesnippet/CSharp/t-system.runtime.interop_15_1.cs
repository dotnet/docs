    void MyMethod(Object o);

    public void DoWrap()
    {
        Object o = new MyObject();
        MyMethod(o);                      // passes o as VT_UNKNOWN
        MyMethod(new DispatchWrapper(o)); // passes o as VT_DISPATCH

        //...
    }