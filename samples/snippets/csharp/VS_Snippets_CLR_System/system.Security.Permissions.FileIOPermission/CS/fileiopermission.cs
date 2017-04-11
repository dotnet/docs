// This sample demonstrates the IsSubsetOf, Union, Intersect, Copy, ToXml, FromXml,
// GetPathList and SetPathList methods, and the AllFiles and AllLocalFiles properties
// of the FileIOPermission class.
// <Snippet1>
using System;
using System.Security;
using System.Security.Permissions;
using System.Collections;

[assembly: CLSCompliant(true)]

public class FileIOPermissionDemo
{
    // IsSubsetOf determines whether the current permission is a subset of the specified permission.
    // This method compares various FileIOPermission paths with FileIOPermissionAccess set to AllAccess.
    //<Snippet2>
    private bool IsSubsetOfDemo()
    {

        bool returnValue = true;

        string fileIO1, fileIO2;
        FileIOPermission fileIOPerm1, fileIOPerm2;

        FileIOGenerator fileIOGen1 = new FileIOGenerator();
        FileIOGenerator fileIOGen2 = new FileIOGenerator();

        fileIOGen1.ResetIndex();
        while (fileIOGen1.CreateFilePath(out fileIO1 ))
        {
            if(fileIO1 == "")
                fileIOPerm1 = new FileIOPermission(PermissionState.None);
            else
            fileIOPerm1 = new FileIOPermission(FileIOPermissionAccess.AllAccess, fileIO1);

            Console.WriteLine("**********************************************************\n");

            fileIOGen2.ResetIndex();

            while (fileIOGen2.CreateFilePath(out fileIO2))
            {
                if (fileIO2 == "")
                    fileIOPerm2 = new FileIOPermission(PermissionState.None);
                else
                    fileIOPerm2 = new FileIOPermission(FileIOPermissionAccess.AllAccess, fileIO2);
                string firstPermission = fileIO1 == "" | fileIO1 == null ? "null" : fileIO1;
                string secondPermission = fileIO2 == "" | fileIO2 == null ? "null" : fileIO2;
                if (fileIOPerm2 == null) continue;
                try
                {
                    if (fileIOPerm1.IsSubsetOf(fileIOPerm2))
                    {

                        Console.WriteLine(firstPermission + " is a subset of " + secondPermission + "\n");
                    }
                    else
                    {
                        Console.WriteLine(firstPermission + " is not a subset of " + secondPermission + "\n");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("An exception was thrown for subset :" + fileIO1 == "" ? "null" : fileIO1 + "\n" +
                        fileIO2 == "" ? "null" : fileIO2 + "\n" + e);
                }
            }
        }
        return returnValue;
    }
    //</Snippet2>

    // Union creates a new permission that is the union of the current permission and the specified permission.
    //<Snippet3>
    private bool UnionDemo()
    {

        bool returnValue = true;

        string fileIO1, fileIO2;
        FileIOPermission fileIOPerm1, fileIOPerm2;
        IPermission fileIOPerm3;

        FileIOGenerator fileIOGen1 = new FileIOGenerator();
        FileIOGenerator fileIOGen2 = new FileIOGenerator();

        fileIOGen1.ResetIndex();
        while (fileIOGen1.CreateFilePath( out fileIO1 ))
        {
            if (fileIO1 == "")
                fileIOPerm1 = new FileIOPermission(PermissionState.None);
            else
            fileIOPerm1 = new FileIOPermission(FileIOPermissionAccess.Read, fileIO1);
            if (fileIO1 == null) continue;

            Console.WriteLine("**********************************************************\n");
            fileIOGen2.ResetIndex();

            while (fileIOGen2.CreateFilePath( out fileIO2 ))
            {
                if (fileIO2 == "")
                    fileIOPerm2 = new FileIOPermission(PermissionState.None);
                else
                    fileIOPerm2 = new FileIOPermission(FileIOPermissionAccess.Read, fileIO2);
                try
                {
                    string firstPermission = fileIO1 == "" | fileIO1 == null ? "null" : fileIO1;
                    string secondPermission = fileIO2 == "" | fileIO2 == null ? "null" : fileIO2;
                    fileIOPerm3 = (FileIOPermission)fileIOPerm1.Union(fileIOPerm2);
                    fileIOPerm3 = fileIOPerm1.Union(fileIOPerm2);

                    if (fileIOPerm3 == null)
                    {
                        Console.WriteLine("The union of " + firstPermission + " and " + secondPermission + " is null.");
                    }
                    else
                    {
                        Console.WriteLine("The union of " + firstPermission + " and " + secondPermission +
                            " = \n\t" + ((FileIOPermission)fileIOPerm3).GetPathList(FileIOPermissionAccess.Read)[0]);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("An exception was thrown for union " + e);
                    returnValue = false;
                }

            }

        }

        return returnValue;

    }
    //</Snippet3>

    // Intersect creates and returns a new permission that is the intersection of the current
    // permission and the permission specified.
    //<Snippet4>
    private bool IntersectDemo()
    {

        bool returnValue = true;

        string fileIO1, fileIO2;
        FileIOPermission fileIOPerm1, fileIOPerm2, fileIOPerm3;

        FileIOGenerator fileIOGen1 = new FileIOGenerator();
        FileIOGenerator fileIOGen2 = new FileIOGenerator();

        fileIOGen1.ResetIndex();
        while (fileIOGen1.CreateFilePath(out fileIO1 ))
        {
            if (fileIO1 == "")
                fileIOPerm1 = new FileIOPermission(PermissionState.None);
            else
                fileIOPerm1 = new FileIOPermission(FileIOPermissionAccess.Read, fileIO1);

            Console.WriteLine("**********************************************************\n");
            fileIOGen2.ResetIndex();

            while (fileIOGen2.CreateFilePath( out fileIO2 ))
            {
                if (fileIO2 == "")
                    fileIOPerm2 = new FileIOPermission(PermissionState.None);
                else
                    fileIOPerm2 = new FileIOPermission(FileIOPermissionAccess.Read, fileIO2);
                string firstPermission = fileIO1 == "" | fileIO1 == null ? "null" : fileIO1;
                string secondPermission = fileIO2 == "" | fileIO2 == null ? "null" : fileIO2;
                try
                {

                    fileIOPerm3 = (FileIOPermission)fileIOPerm1.Intersect(fileIOPerm2);
                    if (fileIOPerm3 != null && fileIOPerm3.GetPathList(FileIOPermissionAccess.Read) != null)
                    {

                        Console.WriteLine("The intersection of " + firstPermission + " and \n\t" + secondPermission +
                            " = \n\t" + ((FileIOPermission)fileIOPerm3).GetPathList(FileIOPermissionAccess.Read)[0]);
                    }
                    else
                    {
                        Console.WriteLine("The intersection of " + firstPermission + " and " + secondPermission + " is null.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("An exception was thrown for intersection " + e);
                    returnValue = false;
                }
            }
        }

        return returnValue;

    }
    //</Snippet4>

    //Copy creates and returns an identical copy of the current permission.
    //<Snippet5>
    private bool CopyDemo()
    {
        bool returnValue = true;
        string fileIO1;
        FileIOPermission fileIOPerm1, fileIOPerm2;
        FileIOGenerator fileIOGen1 = new FileIOGenerator();
        FileIOGenerator fileIOGen2 = new FileIOGenerator();

        fileIOGen1.ResetIndex();
        while (fileIOGen1.CreateFilePath( out fileIO1 ))
        {
            if (fileIO1 == "")
                fileIOPerm1 = new FileIOPermission(PermissionState.None);
            else
                fileIOPerm1 = new FileIOPermission(FileIOPermissionAccess.Read, fileIO1);

            Console.WriteLine("**********************************************************\n");
            fileIOGen2.ResetIndex();
            try
            {
                fileIOPerm2 = (FileIOPermission)fileIOPerm1.Copy();
                if (fileIOPerm2 != null)
                {
                    Console.WriteLine("Result of copy = " + fileIOPerm2.ToString() + "\n");
                }
                else
                {
                    Console.WriteLine("Result of copy is null. \n");
                }
            }
            catch (Exception e)
            {
                {
                    if (fileIO1 == "")
                    {
                        Console.WriteLine("The target FileIOPermission is empty, copy failed.");

                    }
                    else
                        Console.WriteLine(e);
                }
                continue;
            }
        }
        return returnValue;
    }
    //</Snippet5>

    // ToXml creates an XML encoding of the permission and its current state;
    // FromXml reconstructs a permission with the specified state from the XML encoding.
    //<Snippet6>
    private bool ToFromXmlDemo()
    {

        bool returnValue = true;

        string fileIO1;
        FileIOPermission fileIOPerm1, fileIOPerm2;

        FileIOGenerator fileIOGen1 = new FileIOGenerator();
        FileIOGenerator fileIOGen2 = new FileIOGenerator();

        fileIOGen1.ResetIndex();
        while (fileIOGen1.CreateFilePath( out fileIO1 ))
        {
            if (fileIO1 == "")
                fileIOPerm1 = new FileIOPermission(PermissionState.None);
            else
                fileIOPerm1 = new FileIOPermission(FileIOPermissionAccess.Read, fileIO1);

            Console.WriteLine("********************************************************\n");
            fileIOGen2.ResetIndex();
            try
            {
                fileIOPerm2 = new FileIOPermission(PermissionState.None);
                fileIOPerm2.FromXml(fileIOPerm1.ToXml());
                Console.WriteLine("Result of ToFromXml = " + fileIOPerm2.ToString() + "\n");

            }
            catch (Exception e)
            {
                Console.WriteLine("ToFromXml failed :" + fileIOPerm1.ToString() + e);
                continue;
            }
        }

        return returnValue;

    }
    //</Snippet6>

    // AddPathList adds access for the specified files and directories to the existing state of the permission.
    // SetPathList sets the specified access to the specified files and directories, replacing the existing state
    // of the permission.
    // GetPathList gets all files and directories that have the specified FileIOPermissionAccess.
    //<Snippet7> 
    private bool SetGetPathListDemo()
    {
        try
        {
            Console.WriteLine("********************************************************\n");

            FileIOPermission fileIOPerm1;
            Console.WriteLine("Creating a FileIOPermission with AllAccess rights for 'C:\\Examples\\Test\\TestFile.txt");
            //<Snippet8> 
            fileIOPerm1 = new FileIOPermission(FileIOPermissionAccess.AllAccess, "C:\\Examples\\Test\\TestFile.txt");
            //</Snippet8>
            Console.WriteLine("Adding 'C:\\Temp' to the write access list, and \n 'C:\\Examples\\Test' to read access.");
            fileIOPerm1.AddPathList(FileIOPermissionAccess.Write, "C:\\Temp");
            fileIOPerm1.AddPathList(FileIOPermissionAccess.Read, "C:\\Examples\\Test");
            string[] paths = fileIOPerm1.GetPathList(FileIOPermissionAccess.Read);
            Console.WriteLine("Read access before SetPathList = ");
            foreach (string path in paths)
            {
                Console.WriteLine("\t" + path);
            }
            Console.WriteLine("Setting the read access list to \n'C:\\Temp'");
            fileIOPerm1.SetPathList(FileIOPermissionAccess.Read, "C:\\Temp");
            paths = fileIOPerm1.GetPathList(FileIOPermissionAccess.Read);
            Console.WriteLine("Read access list after SetPathList = ");
            foreach (string path in paths)
            {
                Console.WriteLine("\t" + path);
            }

            paths = fileIOPerm1.GetPathList(FileIOPermissionAccess.Write);
            Console.WriteLine("Write access list after SetPathList = ");
            foreach (string path in paths)
            {
                Console.WriteLine("\t" + path);
            }

            Console.WriteLine("Write access = \n" +
                fileIOPerm1.GetPathList(FileIOPermissionAccess.AllAccess));

        }
        catch (ArgumentException e)
        {
            // FileIOPermissionAccess.AllAccess can not be used as a parameter for GetPathList.
            Console.WriteLine("An ArgumentException occurred as a result of using AllAccess. "
                + "This property cannot be used as a parameter in GetPathList "
                + "because it represents more than one type of file variable access. : \n" + e);
        }

        return true;
    }
    //</Snippet7>

    // The AllFiles property gets or sets the permitted access to all files.
    // The AllLocalFiles property gets or sets the permitted access to all local files.
    //<Snippet11>
    private bool AllFilesDemo()
    {
        try
        {
            Console.WriteLine("********************************************************\n");

            FileIOPermission fileIOPerm1;
            Console.WriteLine("Creating a FileIOPermission and adding read access for all files");
            fileIOPerm1 = new FileIOPermission(FileIOPermissionAccess.AllAccess, "C:\\Examples\\Test\\TestFile.txt");
            fileIOPerm1.AllFiles = FileIOPermissionAccess.Read;
            Console.WriteLine("AllFiles access = " + fileIOPerm1.AllFiles);
            Console.WriteLine("Adding AllAccess rights for local files.");
            fileIOPerm1.AllLocalFiles = FileIOPermissionAccess.AllAccess;
            Console.WriteLine("AllLocalFiles access = " + fileIOPerm1.AllLocalFiles);

        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e);
            return false;
        }

        return true;
    }
    //</Snippet11>

    // Invoke all demos.
    public bool RunDemo()
    {

        bool ret = true;
        bool retTmp;
        // Call the IsSubsetOfPath demo.
        if (retTmp = IsSubsetOfDemo()) Console.Out.WriteLine("IsSubsetOf demo completed successfully.");
        else Console.Out.WriteLine("IsSubsetOf demo failed.");
        ret = retTmp && ret;

        // Call the Union demo.
        if (retTmp = UnionDemo()) Console.Out.WriteLine("Union demo completed successfully.");
        else Console.Out.WriteLine("Union demo failed.");
        ret = retTmp && ret;

        // Call the Intersect demo.
        if (retTmp = IntersectDemo()) Console.Out.WriteLine("Intersect demo completed successfully.");
        else Console.Out.WriteLine("Intersect demo failed.");
        ret = retTmp && ret;


        // Call the Copy demo.
        if (retTmp = CopyDemo()) Console.Out.WriteLine("Copy demo completed successfully.");
        else Console.Out.WriteLine("Copy demo failed.");
        ret = retTmp && ret;

        // Call the ToFromXml demo.
        if (retTmp = ToFromXmlDemo()) Console.Out.WriteLine("ToFromXml demo completed successfully.");
        else Console.Out.WriteLine("ToFromXml demo failed.");
        ret = retTmp && ret;

        // Call the SetGetPathList demo.
        if (retTmp = SetGetPathListDemo()) Console.Out.WriteLine("SetGetPathList demo completed successfully.");
        else Console.Out.WriteLine("SetGetPathList demo failed.");
        ret = retTmp && ret;

        // Call the AllFiles demo.
        if (retTmp = AllFilesDemo()) Console.Out.WriteLine("AllFiles demo completed successfully.");
        else Console.Out.WriteLine("AllFiles demo failed.");
        ret = retTmp && ret;

        return (ret);

    }
    // Test harness.
    public static void Main(String[] args)
    {
        try
        {
            FileIOPermissionDemo democase = new FileIOPermissionDemo();
            bool ret = democase.RunDemo();
            if (ret)
            {
                Console.Out.WriteLine("FileIOPermission demo completed successfully.");
                Console.Out.WriteLine("Press the Enter key to exit.");
                string consoleInput = Console.ReadLine();
                System.Environment.ExitCode = 100;
            }
            else
            {
                Console.Out.WriteLine("FileIOPermission demo failed.");
                Console.Out.WriteLine("Press the Enter key to exit.");
                string consoleInput = Console.ReadLine();
                System.Environment.ExitCode = 101;
            }
        }
        catch (Exception e)
        {
            Console.Out.WriteLine("FileIOPermission demo failed");
            Console.WriteLine(e.ToString());
            Console.Out.WriteLine("Press the Enter key to exit.");
            string consoleInput = Console.ReadLine();
            System.Environment.ExitCode = 101;
        }
    }
}


// This class generates FileIOPermission objects.

internal class FileIOGenerator
{


    private string[] myFile =
{
    "C:\\Examples\\Test\\TestFile.txt",
    "C:\\Examples\\Test\\",
    "C:\\Examples\\Test\\..",
    "C:\\Temp"
};

    private FileIOPermissionAccess[] myAccess =
{
    FileIOPermissionAccess.AllAccess,
    FileIOPermissionAccess.Append,
    FileIOPermissionAccess.NoAccess,
    FileIOPermissionAccess.PathDiscovery,
    FileIOPermissionAccess.Read,
    FileIOPermissionAccess.Write
};

    private int fileIndex = 0;

    public FileIOGenerator()
    {

        ResetIndex();
    }

    public void ResetIndex()
    {
        fileIndex = 0;
    }

    // Create a  file path string.
    //<Snippet10>
    public bool CreateFilePath( out string file )
    {

        if (fileIndex == myFile.Length)
        {
            
            file = "";
            fileIndex++;
            return true;

        }
        if (fileIndex > myFile.Length)
        {
            file = "";
            return false;
        }

        file = myFile[fileIndex++];

        try
        {
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Cannot create FileIOPermission: " + file + " " + e);
            file = "";
            return true;
        }
    }
    //</Snippet10>
}
//</Snippet1>

