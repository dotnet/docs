// <Snippet1>
using System;
using System.IO;

public class PathSnippets
{

    public void ChangeExtension()
    {
        string goodFileName = @"C:\mydir\myfile.com.extension";
        string badFileName = @"C:\mydir\";
        string result;

        result = Path.ChangeExtension(goodFileName, ".old");
        Console.WriteLine("ChangeExtension({0}, '.old') returns '{1}'",
            goodFileName, result); 

        result = Path.ChangeExtension(goodFileName, "");
        Console.WriteLine("ChangeExtension({0}, '') returns '{1}'", 
            goodFileName, result); 

        result = Path.ChangeExtension(badFileName, ".old");
        Console.WriteLine("ChangeExtension({0}, '.old') returns '{1}'", 
            badFileName, result); 

        // This code produces output similar to the following:
        //
        // ChangeExtension(C:\mydir\myfile.com.extension, '.old') returns 'C:\mydir\myfile.com.old'
        // ChangeExtension(C:\mydir\myfile.com.extension, '') returns 'C:\mydir\myfile.com.'
        // ChangeExtension(C:\mydir\, '.old') returns 'C:\mydir\.old'
        // </Snippet1>
                    
        Console.WriteLine();
    }


    public void Combine()
    {
        // <Snippet2>
        string path1 = @"  C:\mydir1";
        string path2 = @"mydir2";
        string path3 = @" mydir3";
        string combinedPaths;

        combinedPaths = Path.Combine(path1, path2);
        Console.WriteLine("Combine('{0}', '{1}') returns '{2}'",
            path1, path2, combinedPaths);

        combinedPaths = Path.Combine(path1, path3);
        Console.WriteLine("Combine('{0}', '{1}') returns '{2}'",
            path1, path3, combinedPaths);

        // This code produces output similar to the following:
        //
        // Combine('  C:\mydir1', 'mydir2') returns '  C:\mydir1\mydir2'
        // Combine('  C:\mydir1', ' mydir3') returns '  C:\mydir1\ mydir3'
        // </Snippet2>

        Console.WriteLine();
    }

    public void GetDirectoryName()
    {
        // <Snippet3>
        string filePath = @"C:\MyDir\MySubDir\myfile.ext";
        string directoryName;
        int i = 0;

        while (filePath != null)
        {
            directoryName = Path.GetDirectoryName(filePath);
            Console.WriteLine("GetDirectoryName('{0}') returns '{1}'",
                filePath, directoryName);
            filePath = directoryName;
            if (i == 1)
            {
                filePath = directoryName + @"\";  // this will preserve the previous path
            }
            i++;
        }
        /*
        This code produces the following output:

        GetDirectoryName('C:\MyDir\MySubDir\myfile.ext') returns 'C:\MyDir\MySubDir'
        GetDirectoryName('C:\MyDir\MySubDir') returns 'C:\MyDir'
        GetDirectoryName('C:\MyDir\') returns 'C:\MyDir'
        GetDirectoryName('C:\MyDir') returns 'C:\'
        GetDirectoryName('C:\') returns ''
        */
        // </Snippet3>

        Console.WriteLine();
    }

    public void GetExtension()
    {
        // <Snippet4>
        string fileName = @"C:\mydir.old\myfile.ext";
        string path = @"C:\mydir.old\";
        string extension;

        extension = Path.GetExtension(fileName);
        Console.WriteLine("GetExtension('{0}') returns '{1}'", 
            fileName, extension);

        extension = Path.GetExtension(path);
        Console.WriteLine("GetExtension('{0}') returns '{1}'", 
            path, extension);

        // This code produces output similar to the following:
        //
        // GetExtension('C:\mydir.old\myfile.ext') returns '.ext'
        // GetExtension('C:\mydir.old\') returns ''
        // </Snippet4>
                    
        Console.WriteLine();
    }

    public void GetFileName()
    {
        // <Snippet5>
        string fileName = @"C:\mydir\myfile.ext";
        string path = @"C:\mydir\";
        string result;

        result = Path.GetFileName(fileName);
        Console.WriteLine("GetFileName('{0}') returns '{1}'", 
            fileName, result);

        result = Path.GetFileName(path);
        Console.WriteLine("GetFileName('{0}') returns '{1}'", 
            path, result);

        // This code produces output similar to the following:
        //
        // GetFileName('C:\mydir\myfile.ext') returns 'myfile.ext'
        // GetFileName('C:\mydir\') returns ''
        // </Snippet5>
                    
        Console.WriteLine();
    }

    public void GetFileNameWithoutExtension()
    {
        // <Snippet6>
        string fileName = @"C:\mydir\myfile.ext";
        string path = @"C:\mydir\";
        string result;

        result = Path.GetFileNameWithoutExtension(fileName);
        Console.WriteLine("GetFileNameWithoutExtension('{0}') returns '{1}'", 
            fileName, result);

        result = Path.GetFileName(path);
        Console.WriteLine("GetFileName('{0}') returns '{1}'", 
            path, result);

        // This code produces output similar to the following:
        //
        // GetFileNameWithoutExtension('C:\mydir\myfile.ext') returns 'myfile'
        // GetFileName('C:\mydir\') returns ''
        // </Snippet6>
                    
        Console.WriteLine();
    }

    public void GetFullPath()
    {
        // <Snippet7>
        string fileName = "myfile.ext";
        string path1 = @"mydir";
        string path2 = @"\mydir";
        string fullPath;

        fullPath = Path.GetFullPath(path1);
        Console.WriteLine("GetFullPath('{0}') returns '{1}'", 
            path1, fullPath);
        
        fullPath = Path.GetFullPath(fileName);
        Console.WriteLine("GetFullPath('{0}') returns '{1}'", 
            fileName, fullPath);

        fullPath = Path.GetFullPath(path2);
        Console.WriteLine("GetFullPath('{0}') returns '{1}'", 
            path2, fullPath);

        // Output is based on your current directory, except
        // in the last case, where it is based on the root drive
        // GetFullPath('mydir') returns 'C:\temp\Demo\mydir'
        // GetFullPath('myfile.ext') returns 'C:\temp\Demo\myfile.ext'
        // GetFullPath('\mydir') returns 'C:\mydir'
        // </Snippet7>
                    
        Console.WriteLine();
    }

    public void GetPathRoot()
    {
        // <Snippet8>
        string path = @"\mydir\";
        string fileName = "myfile.ext";
        string fullPath = @"C:\mydir\myfile.ext";
        string pathRoot;

        pathRoot = Path.GetPathRoot(path);
        Console.WriteLine("GetPathRoot('{0}') returns '{1}'", 
            path, pathRoot);
        
        pathRoot = Path.GetPathRoot(fileName);
        Console.WriteLine("GetPathRoot('{0}') returns '{1}'", 
            fileName, pathRoot);

        pathRoot = Path.GetPathRoot(fullPath);
        Console.WriteLine("GetPathRoot('{0}') returns '{1}'", 
            fullPath, pathRoot);

        // This code produces output similar to the following:
        //
        // GetPathRoot('\mydir\') returns '\'
        // GetPathRoot('myfile.ext') returns ''
        // GetPathRoot('C:\mydir\myfile.ext') returns 'C:\'
        // </Snippet8>
                    
        Console.WriteLine();
    }


    public void GetTempFileName()
    {
        // <Snippet9>
        string fileName = Path.GetTempFileName();

        FileInfo  fileInfo = new FileInfo(fileName);
        Console.WriteLine("File '{0}' created of size {1} bytes", 
            fileName, fileInfo.Length);
        
        // Write some text to the file.
        FileStream f = new FileStream(fileName, FileMode.Open);
        StreamWriter s = new StreamWriter(f);
        s.WriteLine("Output to the file");
        s.Close();
        f.Close();

        fileInfo.Refresh();                                            
        Console.WriteLine("File '{0}' now has size {1} bytes", 
            fileName, fileInfo.Length);

        // This code produces output similar to the following:
        //
        // File 'D:\Documents and Settings\cliffc\Local Settings\Temp\8\tmp38.tmp' created of size 0 bytes
        // File 'D:\Documents and Settings\cliffc\Local Settings\Temp\8\tmp38.tmp' now has size 20 bytes
        // </Snippet9>
                    
        Console.WriteLine();
    }

    
    public void GetTempPath()
    {
        // <Snippet10>
        string tempPath = Path.GetTempPath();
        Console.WriteLine("Temporary path is '{0}'", tempPath);

        DirectoryInfo tempDir = new DirectoryInfo(tempPath);
        Console.WriteLine("{0} contains {1} files", tempPath, 
            tempDir.GetFiles().Length);

        // This code produces output similar to the following:
        //
        // Temporary path is 'D:\Documents and Settings\cliffc\Local Settings\Temp\8\'
        // D:\Documents and Settings\cliffc\Local Settings\Temp\8\ contains 6 files
        // </Snippet10>
                    
        Console.WriteLine();
    }


    public void HasExtension()
    {
        // <Snippet11>
        string fileName1 = "myfile.ext";
        string fileName2 = @"mydir\myfile";
        string path = @"C:\mydir.ext\";
        bool result;

        result = Path.HasExtension(fileName1);
        Console.WriteLine("HasExtension('{0}') returns {1}", 
            fileName1, result);

        result = Path.HasExtension(fileName2);
        Console.WriteLine("HasExtension('{0}') returns {1}", 
            fileName2, result);
        
        result = Path.HasExtension(path);
        Console.WriteLine("HasExtension('{0}') returns {1}", 
            path, result);

        // This code produces output similar to the following:
        //
        // HasExtension('myfile.ext') returns True
        // HasExtension('mydir\myfile') returns False
        // HasExtension('C:\mydir.ext\') returns False
        // </Snippet11>
                    
        Console.WriteLine();
    }

    public void IsPathRooted()
    {
        // <Snippet12>
        string fileName = @"C:\mydir\myfile.ext";
        string UncPath = @"\\myPc\mydir\myfile";
        string relativePath = @"mydir\sudir\";
        bool result;

        result = Path.IsPathRooted(fileName);
        Console.WriteLine("IsPathRooted('{0}') returns {1}", 
            fileName, result);

        result = Path.IsPathRooted(UncPath);
        Console.WriteLine("IsPathRooted('{0}') returns {1}", 
            UncPath, result);
        
        result = Path.IsPathRooted(relativePath);
        Console.WriteLine("IsPathRooted('{0}') returns {1}", 
            relativePath, result);

        // This code produces output similar to the following:
        //
        // IsPathRooted('C:\mydir\myfile.ext') returns True
        // IsPathRooted('\\myPc\mydir\myfile') returns True
        // IsPathRooted('mydir\sudir\') returns False
        // </Snippet12>
                    
        Console.WriteLine();
    }

    public void StaticProperties()
    {
        // <Snippet13>
        Console.WriteLine("Path.AltDirectorySeparatorChar={0}", 
            Path.AltDirectorySeparatorChar);
        Console.WriteLine("Path.DirectorySeparatorChar={0}", 
            Path.DirectorySeparatorChar);
        Console.WriteLine("Path.PathSeparator={0}", 
            Path.PathSeparator);
        Console.WriteLine("Path.VolumeSeparatorChar={0}", 
            Path.VolumeSeparatorChar);
        
        Console.Write("Path.GetInvalidPathChars()=");
        foreach (char c in Path.GetInvalidPathChars())
            Console.Write(c);
        Console.WriteLine();
        // This code produces output similar to the following:
        // Note that the InvalidPathCharacters contain characters
        // outside of the printable character set.
        //
        // Path.AltDirectorySeparatorChar=/
        // Path.DirectorySeparatorChar=\
        // Path.PathSeparator=;
        // Path.VolumeSeparatorChar=:
        // </Snippet13>

        Console.WriteLine();
    }                
                            
    public static void Main()
    {
        Console.WriteLine();
        PathSnippets pathSnippets = new PathSnippets();
        pathSnippets.StaticProperties();       
        pathSnippets.ChangeExtension();
        pathSnippets.Combine();
        pathSnippets.GetDirectoryName();
        pathSnippets.GetExtension();
        pathSnippets.GetFileName();
        pathSnippets.GetFileNameWithoutExtension();
        pathSnippets.GetFullPath();
        pathSnippets.GetPathRoot();
        pathSnippets.GetTempFileName();
        pathSnippets.GetTempPath();
        pathSnippets.HasExtension();
        pathSnippets.IsPathRooted();
    }
}