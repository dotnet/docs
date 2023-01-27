public class Class1
{
    public Class1()
    {
        _storedNames = Array.Empty<string>();
    }

    // <no_compare>
    // Incorrect
    string[] _storedNames;

    public void StoreNames(string[] names)
    {
        _storedNames = new string[names.Length];

        // Copy the array contents into a new array
        Array.Copy(names, _storedNames, names.Length);

        Array.Sort(_storedNames); // Line A
    }

    public bool DoesNameExist(string name) =>
        Array.BinarySearch(_storedNames, name) >= 0; // Line B
    // </no_compare>
}

public class Class2
{
    public Class2()
    {
        _storedNames = Array.Empty<string>();
    }

    // <ordinal>
    // Correct
    string[] _storedNames;

    public void StoreNames(string[] names)
    {
        _storedNames = new string[names.Length];

        // Copy the array contents into a new array
        Array.Copy(names, _storedNames, names.Length);

        Array.Sort(_storedNames, StringComparer.Ordinal); // Line A
    }

    public bool DoesNameExist(string name) =>
        Array.BinarySearch(_storedNames, name, StringComparer.Ordinal) >= 0; // Line B
    // </ordinal>
}

public class Class3
{
    public Class3()
    {
        _storedNames = Array.Empty<string>();
    }

    // <invariant>
    // Correct
    string[] _storedNames;

    public void StoreNames(string[] names)
    {
        _storedNames = new string[names.Length];

        // Copy the array contents into a new array
        Array.Copy(names, _storedNames, names.Length);

        Array.Sort(_storedNames, StringComparer.InvariantCulture); // Line A
    }

    public bool DoesNameExist(string name) =>
        Array.BinarySearch(_storedNames, name, StringComparer.InvariantCulture) >= 0; // Line B
    // </invariant>
}
