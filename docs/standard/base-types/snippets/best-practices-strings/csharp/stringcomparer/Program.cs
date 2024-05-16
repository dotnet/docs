
FileName file1 = new("autoexec.bat", null);
FileName file2 = new("AutoExec.BAT", null);
Console.WriteLine(file1.CompareTo(file2));

//<class>
class FileName : IComparable
{
    private readonly StringComparer _comparer;

    public string Name { get; }

    public FileName(string name, StringComparer? comparer)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

        Name = name;

        if (comparer != null)
            _comparer = comparer;
        else
            _comparer = StringComparer.OrdinalIgnoreCase;
    }

    public int CompareTo(object? obj)
    {
        if (obj == null) return 1;

        if (obj is not FileName)
            return _comparer.Compare(Name, obj.ToString());
        else
            return _comparer.Compare(Name, ((FileName)obj).Name);
    }
}
//</class>
