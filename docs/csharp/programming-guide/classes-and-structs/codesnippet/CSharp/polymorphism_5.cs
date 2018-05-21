        DerivedClass B = new DerivedClass();
        B.DoWork();  // Calls the new method.

        BaseClass A = (BaseClass)B;
        A.DoWork();  // Calls the old method.