// Defines a comparer to create a sorted set
// that is sorted by the file extensions.
public class ByFileExtension : IComparer<string>
{
    string xExt, yExt;

	CaseInsensitiveComparer caseiComp = new CaseInsensitiveComparer();

    public int Compare(string x, string y)
    {
        // Parse the extension from the file name. 
        xExt = x.Substring(x.LastIndexOf(".") + 1);
        yExt = y.Substring(y.LastIndexOf(".") + 1);

        // Compare the file extensions. 
        int vExt = caseiComp.Compare(xExt, yExt);
        if (vExt != 0)
        {
            return vExt;
        }
        else
        {
            // The extension is the same, 
            // so compare the filenames. 
            return caseiComp.Compare(x, y);
        }
    }
}