        interface IBaseInterface1<T> { }
        interface IBaseInterface2<T, U> { }

        class SampleClass1<T> : IBaseInterface1<T> { }          //No error
        class SampleClass2<T> : IBaseInterface2<T, string> { }  //No error