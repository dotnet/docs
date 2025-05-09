public struct Duplicate : IGetDuplicated<Duplicate>
{
    public int _num;

    public Duplicate(int num)
    {
        _num = num;
    }

    public static Duplicate operator ++(Duplicate other)
        => other with { _num = other._num + other._num };

    public override string ToString() => _num.ToString();
}
