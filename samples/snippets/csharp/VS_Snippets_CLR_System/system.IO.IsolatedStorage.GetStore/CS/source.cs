//<Snippet1>
using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Security;
using System.Security.Policy;
using System.Security.Permissions;
using System.Security.Cryptography.X509Certificates;


class Program
{
    static void Main(string[] args)
    {
        try
        {

            if (Test())
            {
                Console.WriteLine("PASSED.");
                Environment.ExitCode = 100;
            }
            else
            {
                Console.WriteLine("FAILED.");
                Environment.ExitCode = 101;
            }

        }
        catch (Exception e)
        {
            Console.Write("Exception occured: {0}", e.ToString());
            Environment.ExitCode = 101;
        }
        return;
    }


    public static Boolean Test()
    {
        Boolean bRes = true;

        Evidence evidence1 = GetTestEvidence();
        Evidence evidence2 = GetTestEvidence();

        IsolatedStorageFile isf = IsolatedStorageFile.GetStore(
                                    IsolatedStorageScope.User | IsolatedStorageScope.Assembly,
                                    evidence1,
                                    typeof(System.Security.Policy.Publisher),
                                    evidence2,
                                    typeof(System.Security.Policy.Publisher));

        IsolatedStorageFileStream isfs = new IsolatedStorageFileStream("AdminEvd1.testfile", FileMode.OpenOrCreate, isf);
        isfs.WriteByte(5);
        isfs.Flush();
        isfs.Close();

        return bRes;

    }


    public static Evidence GetTestEvidence()
    {
        // For demonsration purposes, use a blank certificate.
        Publisher pub = new Publisher(new X509Certificate(new Byte[64]));
        Object[] arrObj = new Object[1];
        arrObj[0] = (Object)pub;
        return new Evidence(arrObj, arrObj);

    }
}
//</Snippet1>