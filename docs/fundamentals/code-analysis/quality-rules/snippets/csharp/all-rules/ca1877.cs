using System.IO;

class ViolationExample
{
    // <Violation>
    public string GetFilePath(string folder, string subfolder, string filename)
    {
        // Violation.
        string temp = Path.Combine(folder, subfolder);
        return Path.Combine(temp, filename);
    }

    public string GetLogPath(string baseDir, string date, string category)
    {
        // Violation.
        return Path.Join(Path.Join(baseDir, date), category);
    }
    // </Violation>
}

class FixExample
{
    // <Fix>
    public string GetFilePath(string folder, string subfolder, string filename)
    {
        // No violation.
        return Path.Combine(folder, subfolder, filename);
    }

    public string GetLogPath(string baseDir, string date, string category)
    {
        // No violation.
        return Path.Join(baseDir, date, category);
    }
    // </Fix>
}
