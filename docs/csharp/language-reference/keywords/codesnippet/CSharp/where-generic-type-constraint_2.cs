
    public class MyGenericClass<T> where T : IComparable, new()
    {
        // The following line is not possible without new() constraint:
        T item = new T();
    }