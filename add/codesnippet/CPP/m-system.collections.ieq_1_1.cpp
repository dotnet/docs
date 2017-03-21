ref class myCultureComparer : IEqualityComparer
{
private:
    CaseInsensitiveComparer^ myComparer;

public:
    myCultureComparer()
    {
        myComparer = CaseInsensitiveComparer::DefaultInvariant;
    }

    myCultureComparer(CultureInfo^ myCulture)
    {
        myComparer = gcnew CaseInsensitiveComparer(myCulture);
    }

    virtual bool Equals(Object^ x, Object^ y) 
    {
        if (myComparer->Compare(x, y) == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    virtual int GetHashCode(Object^ obj)
    {
        return obj->ToString()->ToLower()->GetHashCode();
    }
};