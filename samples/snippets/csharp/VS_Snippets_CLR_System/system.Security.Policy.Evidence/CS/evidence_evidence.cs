//<Snippet1>

using System;
using System.Collections;
using System.Security;
using System.Security.Policy;
using System.Security.Permissions;
using System.Globalization;

public class Evidence_Example
{
    public bool CreateEvidence()
    {
        bool retVal = true;

        try
        {
            // Create empty evidence using the default contructor.
            //<Snippet15>
            Evidence ev1 = new Evidence();
            Console.WriteLine("Created empty evidence with the default constructor.");
            //</Snippet15>

            // Constructor used to create null host evidence.
            Evidence ev2a = new Evidence(null);
            Console.WriteLine("Created an Evidence object with null host evidence.");

            // Constructor used to create host evidence.
            //<Snippet2>
            Url url = new Url("http://www.treyresearch.com");
            Console.WriteLine("Adding host evidence " + url.ToString());
            ev2a.AddHost(url);
            Evidence ev2b = new Evidence(ev2a);
            Console.WriteLine("Copy evidence into new evidence");
            IEnumerator enum1 = ev2b.GetHostEnumerator();
            enum1.MoveNext();
            Console.WriteLine(enum1.Current.ToString());
            //</Snippet2>
			
            // Constructor used to create both host and assembly evidence.
            //<Snippet3>
            Object [] oa1 = {};
            Site site = new Site("www.wideworldimporters.com");
            Object [] oa2 = { url, site };
            Evidence ev3a = new Evidence(oa1, oa2);
            enum1 = ev3a.GetHostEnumerator();
            IEnumerator enum2 = ev3a.GetAssemblyEnumerator();
            enum2.MoveNext();
            Object obj1 = enum2.Current;
            enum2.MoveNext();
            Console.WriteLine("URL = " + obj1.ToString() + "  Site = " + enum2.Current.ToString());
            //</Snippet3>
			
            // Constructor used to create null host and null assembly evidence.
            Evidence ev3b = new Evidence(null, null);
            Console.WriteLine("Create new evidence with null host and assembly evidence");
			
        }
        catch (Exception e)
        {
            Console.WriteLine("Fatal error: {0}", e.ToString());
            return false;
        }

        return retVal;
    }
    public Evidence DemonstrateEvidenceMembers()
    {
        Evidence myEvidence = new Evidence();
        string sPubKeyBlob =	"00240000048000009400000006020000" + 
            "00240000525341310004000001000100" + 
            "19390E945A40FB5730204A25FA5DC4DA" + 
            "B18688B412CB0EDB87A6EFC50E2796C9" + 
            "B41AD3040A7E46E4A02516C598678636" + 
            "44A0F74C39B7AB9C38C01F10AF4A5752" + 
            "BFBCDF7E6DD826676AD031E7BCE63393" + 
            "495BAD2CA4BE03B529A73C95E5B06BE7" + 
            "35CA0F622C63E8F54171BD73E4C8F193" + 
            "CB2664163719CA41F8159B8AC88F8CD3";
        Byte[] pubkey = HexsToArray(sPubKeyBlob);

        // Create a strong name.
        StrongName mSN = new StrongName(new StrongNamePublicKeyBlob(pubkey), "SN01", new Version("0.0.0.0"));

        // Create assembly and host evidence.
        //<Snippet4>
        Console.WriteLine("Adding assembly evidence.");
        myEvidence.AddAssembly("SN01");
        myEvidence.AddAssembly(new Version("0.0.0.0"));
        myEvidence.AddAssembly(mSN);
        Console.WriteLine("Count of evidence items = " + myEvidence.Count.ToString());
        //</Snippet4>
        //<Snippet5>
        Url url = new Url("http://www.treyresearch.com");
        Console.WriteLine("Adding host evidence " + url.ToString());
        myEvidence.AddHost(url);
        PrintEvidence(myEvidence).ToString();
        Console.WriteLine("Count of evidence items = " + myEvidence.Count.ToString());
        //</Snippet5>
        //<Snippet6>
        Console.WriteLine("\nCopy the evidence to an array using CopyTo, then display the array.");
        object[] evidenceArray = new object[myEvidence.Count];
        myEvidence.CopyTo(evidenceArray, 0);
        foreach (object obj in evidenceArray)
        {
            Console.WriteLine(obj.ToString());
        }
        //</Snippet6>
        Console.WriteLine("\nDisplay the contents of the properties.");
        Console.WriteLine("Locked is the only property normally used by code.");
        Console.WriteLine("IsReadOnly, IsSynchronized, and SyncRoot properties are not normally used.");
        //<Snippet7>
        Console.WriteLine("\nThe default value for the Locked property = " + myEvidence.Locked.ToString());
        //</Snippet7>
		
        //<Snippet8>
        Console.WriteLine("\nGet the hashcode for the evidence.");
        Console.WriteLine("HashCode = " + myEvidence.GetHashCode().ToString());
        //</Snippet8>
        //<Snippet9>
        Console.WriteLine("\nGet the type for the evidence.");
        Console.WriteLine("Type = " + myEvidence.GetType().ToString());
        //</Snippet9>
        //<Snippet10>
        Console.WriteLine("\nMerge new evidence with the current evidence.");
        Object [] oa1 = {};
        Site site = new Site("www.wideworldimporters.com");
        Object [] oa2 = { url, site };
        Evidence newEvidence = new Evidence(oa1, oa2);
        myEvidence.Merge(newEvidence);
        Console.WriteLine("Evidence count = " + PrintEvidence(myEvidence).ToString());
        //</Snippet10>
        //<Snippet11>
        Console.WriteLine("\nRemove URL evidence.");
        myEvidence.RemoveType(url.GetType());
        Console.WriteLine("Evidence count is now: " + myEvidence.Count.ToString());
        //</Snippet11>
        //<Snippet12>
        Console.WriteLine("\nMake a copy of the current evidence.");
        Evidence evidenceCopy = new Evidence(myEvidence);
        Console.WriteLine("Count of new evidence items = " + evidenceCopy.Count);
        Console.WriteLine("Does the copy equal the current evidence? " + myEvidence.Equals(evidenceCopy));
        //</Snippet12>
        //<Snippet13>
        Console.WriteLine("\nClear the current evidence.");
        myEvidence.Clear();
        Console.WriteLine("Count is now " + myEvidence.Count.ToString());
        //</Snippet13>
        return myEvidence;
    }
    public static int PrintEvidence(Evidence myEvidence)
    {
        //<Snippet14>
        int p = 0;
        Console.WriteLine("\nCurrent evidence = ");
        if (null == myEvidence) return 0;
        IEnumerator list = myEvidence.GetEnumerator();
        while (list.MoveNext())
        {
            Console.WriteLine(list.Current.ToString());
        }
        //</Snippet14>

        Console.WriteLine("\n");
        return p;
    }
    // Convert a hexidecimal string to an array.
    public static byte[] HexsToArray(string sHexString)
    {
        Byte[] array = new Byte[sHexString.Length/2];
        for (int i = 0; i < sHexString.Length; i += 2)
        {
            array[i / 2] = Byte.Parse(sHexString.Substring(i, 2), NumberStyles.HexNumber);
        }
        return array;
    }



    // Main method.
    public static void Main()
    {
        try
        {
            Evidence_Example EvidenceTest = new Evidence_Example();
            bool ret = EvidenceTest.CreateEvidence();
            if (ret)
            {
                Console.WriteLine("Evidence successfully created.");
            }
            else
            {
                Console.WriteLine("Evidence creation failed.");
            }
			
            EvidenceTest.DemonstrateEvidenceMembers();
        }
        catch(Exception e)
        {
	
            Console.WriteLine(e.ToString());
            Environment.ExitCode = 101;
        }
    }
}
//</Snippet1>
