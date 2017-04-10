// <Snippet1>
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;


class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Get a list of the files to use for the sorted set.
            IEnumerable<string> files1 =
                Directory.EnumerateFiles(@"\\archives\2007\media",
                "*", SearchOption.AllDirectories);

            // <Snippet2>
            // Create a sorted set using the ByFileExtension comparer.
            SortedSet<string> mediaFiles1 =
                new SortedSet<string>(new ByFileExtension());
            // </Snippet2>

            // Note that there is a SortedSet constructor that takes an IEnumerable,
            // but to remove the path information they must be added individually.
            // <Snippet3>
            foreach (string f in files1)
            {
                mediaFiles1.Add(f.Substring(f.LastIndexOf(@"\") + 1));
            }
            // </Snippet3>

            // <Snippet4>
            // Remove elements that have non-media extensions.
            // See the 'isDoc' method.
            Console.WriteLine("Remove docs from the set...");
            Console.WriteLine("\tCount before: {0}", mediaFiles1.Count.ToString());
            mediaFiles1.RemoveWhere(isDoc);
            Console.WriteLine("\tCount after: {0}", mediaFiles1.Count.ToString());
            // </Snippet4>


            Console.WriteLine();

            // <Snippet5>
            // List all the avi files.
            SortedSet<string> aviFiles = mediaFiles1.GetViewBetween("avi", "avj");

            Console.WriteLine("AVI files:");
            foreach (string avi in aviFiles)
            {
                Console.WriteLine("\t{0}", avi);
            }
            // </Snippet5>

            Console.WriteLine();

            // Create another sorted set.
            IEnumerable<string> files2 =
                Directory.EnumerateFiles(@"\\archives\2008\media",
                    "*", SearchOption.AllDirectories);

            SortedSet<string> mediaFiles2 = new SortedSet<string>(new ByFileExtension());

            foreach (string f in files2)
            {
                mediaFiles2.Add(f.Substring(f.LastIndexOf(@"\") + 1));
            }

            // <Snippet6>
            // Remove elements in mediaFiles1 that are also in mediaFiles2.
            Console.WriteLine("Remove duplicates (of mediaFiles2) from the set...");
            Console.WriteLine("\tCount before: {0}", mediaFiles1.Count.ToString());
            mediaFiles1.ExceptWith(mediaFiles2);
            Console.WriteLine("\tCount after: {0}", mediaFiles1.Count.ToString());
            // </Snippet6>

            Console.WriteLine();

            Console.WriteLine("List of mediaFiles1:");
            foreach (string f in mediaFiles1)
            {
                Console.WriteLine("\t{0}",f);
            }

            // <Snippet7>
            // Create a set of the sets.
            IEqualityComparer<SortedSet<string>> comparer =
                SortedSet<string>.CreateSetComparer();

            HashSet<SortedSet<string>> allMedia =
                new HashSet<SortedSet<string>>(comparer);
            allMedia.Add(mediaFiles1);
            allMedia.Add(mediaFiles2);
            // </Snippet7>
        }
        catch(IOException ioEx)
        {
            Console.WriteLine(ioEx.Message);
        }

        catch (UnauthorizedAccessException AuthEx)
        {
            Console.WriteLine(AuthEx.Message);

        }
    }

    // <Snippet8>
    // Defines a predicate delegate to use
    // for the SortedSet.RemoveWhere method.
    private static bool isDoc(string s)
    {
        if (s.ToLower().EndsWith(".txt") ||
            s.ToLower().EndsWith(".doc") ||
            s.ToLower().EndsWith(".xls") ||
            s.ToLower().EndsWith(".xlsx") ||
            s.ToLower().EndsWith(".pdf") ||
            s.ToLower().EndsWith(".doc") ||
            s.ToLower().EndsWith(".docx"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    // </Snippet8>


}

// <Snippet9>
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
// </Snippet9>
// </Snippet1>


