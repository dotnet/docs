// <Snippet1>
using System;
using System.Security; 
using System.Security.Policy; 
using System.Collections;

public class GacMembershipConditionDemo
{
    // Demonstrate the Copy method, which creates an identical
    // copy of the current permission.
    private bool CopyDemo()
    {
        Console.WriteLine(
            "************************************************************");
        //<Snippet2>
        GacMembershipCondition Gac1 = new GacMembershipCondition();
        Console.WriteLine("Original membership condition = ");
        Console.WriteLine(Gac1.ToXml().ToString());
        try
        {
            IMembershipCondition membershipCondition = Gac1.Copy();
            Console.WriteLine("Result of Copy = ");
            Console.WriteLine(
                ((GacMembershipCondition)membershipCondition).ToXml().ToString()
                );
        }
        catch (Exception e)
        {
            Console.WriteLine("Copy failed : " + Gac1.ToString() + e);
            return false;
        }

        //</Snippet2>
        return true;

    }
    // Demonstrate the Check method, which determines whether the specified 
    // evidence satisfies the membership condition.
    private bool CheckDemo()
    {
        Console.WriteLine(
            "************************************************************");
        //<Snippet3>
        GacMembershipCondition Gac1 = new GacMembershipCondition();
        GacInstalled myGac = new GacInstalled();
        try
        {
            Object [] hostEvidence = {myGac};
            Object [] assemblyEvidence = {};

            Evidence myEvidence = new Evidence(hostEvidence,assemblyEvidence);
            bool retCode = Gac1.Check(myEvidence);
            Console.WriteLine("Result of Check = " + retCode.ToString() + "\n");
        }
        catch (Exception e)
        {
            Console.WriteLine("Check failed : " + Gac1.ToString() + e);
            return false;
        }
        //</Snippet3>

        return true;
    }

    // Demonstrate the GetHashCode method, which returns a hash code
    // for the specified membership condition.
    private bool GetHashCodeDemo()
    {
        Console.WriteLine(
            "************************************************************");
        //<Snippet4>
        GacMembershipCondition Gac1 = new GacMembershipCondition();
        try
        {
            Console.WriteLine(
                "Result of GetHashCode for a GacMembershipCondition = " + 
                Gac1.GetHashCode().ToString() + "\n");
        }
        catch (Exception e)
        {
            Console.WriteLine("GetHashCode failed : " + Gac1.ToString() + e);
            return false;
        }
        //</Snippet4>

        return true;
    }

    // Demonstrate the ToXml and FromXml methods, including the overloads.
    // ToXml creates an XML encoding of the membership condition and its 
    // current state; FromXml reconstructs a membership condition with the 
    // specified state from the XML encoding.
    private bool ToFromXmlDemo()
    {
        Console.WriteLine(
            "************************************************************");
        try
        {
            //<Snippet5>
            GacMembershipCondition Gac1 = new GacMembershipCondition();
            GacMembershipCondition Gac2 = new GacMembershipCondition();

            // Roundtrip a GacMembershipCondition to and from an XML encoding.
            Gac2.FromXml(Gac1.ToXml());
            bool result = Gac2.Equals(Gac1);
            if (result)
            {
                Console.WriteLine(
                    "Result of ToXml() = " + Gac2.ToXml().ToString());
                Console.WriteLine(
                    "Result of ToFromXml roundtrip = " + Gac2.ToString());
            }
            else
            {
                Console.WriteLine(Gac2.ToString());
                Console.WriteLine(Gac1.ToString());
                return false;
            }
            //</Snippet5>

            //<Snippet6>
            GacMembershipCondition Gac3 = new GacMembershipCondition();
            GacMembershipCondition Gac4 = new GacMembershipCondition();
            IEnumerator policyEnumerator = SecurityManager.PolicyHierarchy();
            while (policyEnumerator.MoveNext())
            {
                PolicyLevel currentLevel = 
                    (PolicyLevel)policyEnumerator.Current;
                if (currentLevel.Label == "Machine")
                {
                    Console.WriteLine("Result of ToXml(level) = " + 
                        Gac3.ToXml(currentLevel));
                    Gac4.FromXml(Gac3.ToXml(), currentLevel);
                    Console.WriteLine("Result of FromXml(element, level) = " + 
                        Gac4.ToString());
                }
            }
            //</Snippet6>
        }
        catch (Exception e)
        {
            Console.WriteLine("ToFromXml failed. " + e);
            return false;
        }

        return true;

    }

    // Invoke all demos.
    public bool RunDemo()
    {

        bool returnCode =true;
        bool tempReturnCode;

        // Call the Copy demo.
        if (tempReturnCode = CopyDemo())
            Console.Out.WriteLine("Copy demo completed successfully.");
        else 
            Console.Out.WriteLine("Copy demo failed.");

        returnCode = tempReturnCode && returnCode;

        // Call the Check demo.
        if (tempReturnCode = CheckDemo())
            Console.Out.WriteLine("Check demo completed successfully.");
        else 
            Console.Out.WriteLine("Check demo failed.");

        returnCode = tempReturnCode && returnCode;

        // Call the GetHashCode demo.
        if (tempReturnCode = GetHashCodeDemo())
            Console.Out.WriteLine("GetHashCode demo completed successfully.");
        else 
            Console.Out.WriteLine("GetHashCode demo failed.");

        returnCode = tempReturnCode && returnCode;

        // Call the ToFromXml demo.	
        if (tempReturnCode = ToFromXmlDemo())
            Console.Out.WriteLine("ToFromXml demo completed successfully.");
        else 
            Console.Out.WriteLine("ToFromXml demo failed.");

        returnCode = tempReturnCode && returnCode;
        return (returnCode);	
    }

    // Test harness.
    public static void Main(String[] args)
    {
        try
        {
            GacMembershipConditionDemo testcase = 
                new GacMembershipConditionDemo();
            bool returnCode = testcase.RunDemo();
            if (returnCode)
            {
                Console.Out.WriteLine(
                    "The GacMembershipCondition demo completed successfully.");
                Console.Out.WriteLine("Press the Enter key to exit.");
                string consoleInput = Console.ReadLine();
                System.Environment.ExitCode = 100;
            }
            else
            {
                Console.Out.WriteLine("The GacMembershipCondition demo failed.");
                Console.Out.WriteLine("Press the ENTER key to exit.");
                string consoleInput = Console.ReadLine();
                System.Environment.ExitCode = 101;
            }
        }
        catch (Exception e)
        {
            Console.Out.WriteLine("The GacIdentityPermission demo failed.");
            Console.WriteLine(e.ToString());
            Console.Out.WriteLine("Press the Enter key to exit.");
            string consoleInput = Console.ReadLine();
            System.Environment.ExitCode = 101;
        }
    }
}
// </Snippet1>

