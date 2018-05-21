            // The .NET Framework 2.0 way to create a list
            List<int> list1 = new List<int>();

            // No boxing, no casting:
            list1.Add(3);

            // Compile-time error:
            // list1.Add("It is raining in Redmond.");