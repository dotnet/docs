//<snippet1>
using System;
using System.IO;

public class ChangeExtensionTest {

    public static void Main() {

        string path1 = "c:\\temp";
        string path2 = "subdir\\file.txt";
        string path3 = "c:\\temp.txt";
        string path4 = "c:^*&)(_=@#'\\^&#2.*(.txt";
        string path5 = "";
        string path6 = null;

        CombinePaths(path1, path2);
        CombinePaths(path1, path3);
        CombinePaths(path3, path2);
        CombinePaths(path4, path2);
        CombinePaths(path5, path2);
        CombinePaths(path6, path2);
    }

    private static void CombinePaths(string p1, string p2) {

        try {
            string combination = Path.Combine(p1, p2);

            Console.WriteLine("When you combine '{0}' and '{1}', the result is: {2}'{3}'",
                        p1, p2, Environment.NewLine, combination);
        } catch (Exception e) {
            if (p1 == null)
                p1 = "null";
            if (p2 == null)
                p2 = "null";
            Console.WriteLine("You cannot combine '{0}' and '{1}' because: {2}{3}",
                        p1, p2, Environment.NewLine, e.Message);
        }

        Console.WriteLine();
    }
}
// This code produces output similar to the following:
//
// When you combine 'c:\temp' and 'subdir\file.txt', the result is: 
// 'c:\temp\subdir\file.txt'
// 
// When you combine 'c:\temp' and 'c:\temp.txt', the result is: 
// 'c:\temp.txt'
// 
// When you combine 'c:\temp.txt' and 'subdir\file.txt', the result is: 
// 'c:\temp.txt\subdir\file.txt'
// 
// When you combine 'c:^*&)(_=@#'\^&#2.*(.txt' and 'subdir\file.txt', the result is: 
// 'c:^*&)(_=@#'\^&#2.*(.txt\subdir\file.txt'
// 
// When you combine '' and 'subdir\file.txt', the result is: 
// 'subdir\file.txt'
// 
// You cannot combine '' and 'subdir\file.txt' because: 
// Value cannot be null.
// Parameter name: path1
//</snippet1>