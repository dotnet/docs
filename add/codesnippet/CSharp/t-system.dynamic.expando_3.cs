            sampleObject.number = 10;
            sampleObject.Increment = (Action)(() => { sampleObject.number++; });

            // Before calling the Increment method.
            Console.WriteLine(sampleObject.number);

            sampleObject.Increment();

            // After calling the Increment method.
            Console.WriteLine(sampleObject.number);
            // This code example produces the following output:
            // 10
            // 11