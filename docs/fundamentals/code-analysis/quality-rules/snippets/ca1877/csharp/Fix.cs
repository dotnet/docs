using System.IO;

class Example
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
