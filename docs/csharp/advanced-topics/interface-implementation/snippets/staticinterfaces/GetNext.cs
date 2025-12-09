public interface IGetNext<T> where T : IGetNext<T>
{
    static abstract T operator ++(T other);
}
