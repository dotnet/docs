class myCultureComparer : IEqualityComparer
{
    public CaseInsensitiveComparer myComparer;

    public myCultureComparer()
    {
        myComparer = CaseInsensitiveComparer.DefaultInvariant;
    }

    public myCultureComparer(CultureInfo myCulture)
    {
        myComparer = new CaseInsensitiveComparer(myCulture);
    }

    public new bool Equals(object x, object y)
    {
        if (myComparer.Compare(x, y) == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int GetHashCode(object obj)
    {
        return obj.ToString().ToLower().GetHashCode();
    }
}