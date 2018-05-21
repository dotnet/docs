        public class GenericClass3<T, U, V> { }

        [CustomAttribute(info = typeof(GenericClass3<int, double, string>))]
        class ClassC { }