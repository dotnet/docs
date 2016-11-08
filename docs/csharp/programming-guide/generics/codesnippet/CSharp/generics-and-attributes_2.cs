        public class GenericClass1<T> { }

        [CustomAttribute(info = typeof(GenericClass1<>))]
        class ClassA { }