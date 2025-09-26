public interface ISingleton<T> where T : new()
{
    public static virtual T Instance
    {
        get
        {
            field ??= new T();
            return field;
        }
        private set
        {
            field = value;
        }
    }
}
