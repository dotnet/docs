        public class GenericClass2<T, U> { }

        [CustomAttribute(info = typeof(GenericClass2<,>))]
        class ClassB { }