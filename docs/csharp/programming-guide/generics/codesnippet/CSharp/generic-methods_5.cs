        class GenericList<T>
        {
            // CS0693
            void SampleMethod<T>() { }
        }

        class GenericList2<T>
        {
            //No warning
            void SampleMethod<U>() { }
        }