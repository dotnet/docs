            MethodClass obj = new MethodClass();
            Del d1 = obj.Method1;
            Del d2 = obj.Method2;
            Del d3 = DelegateMethod;

            //Both types of assignment are valid.
            Del allMethodsDelegate = d1 + d2;
            allMethodsDelegate += d3;