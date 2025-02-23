public interface IGetDuplicated<T> where T : IGetDuplicated<T>
{
    static virtual T operator ++(T other) => throw new NotImplementedException();
}
