        class SampleClass
        {
            public static explicit operator SampleClass(int i)
            {
                SampleClass temp = new SampleClass();
                // code to convert from int to SampleClass...

                return temp;
            }
        }