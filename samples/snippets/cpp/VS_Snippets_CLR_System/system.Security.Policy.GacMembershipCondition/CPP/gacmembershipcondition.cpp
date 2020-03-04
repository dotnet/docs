
// <Snippet1>
using namespace System;
using namespace System::Security;
using namespace System::Security::Policy;
using namespace System::Collections;
public ref class GacMembershipConditionDemo
{
private:

    // Demonstrate the Copy method, which creates an identical 
    // copy of the current permission.
    bool CopyDemo()
    {
        Console::WriteLine(
            "************************************************************");
        //<Snippet2>
        GacMembershipCondition ^ Gac1 = gcnew GacMembershipCondition;
        Console::WriteLine("Original membership condition = ");
        Console::WriteLine(Gac1->ToXml());
        try
        {
            IMembershipCondition^ membershipCondition = Gac1->Copy();
            Console::WriteLine("Result of Copy = ");
            Console::WriteLine(
                (dynamic_cast<GacMembershipCondition^>(membershipCondition))
                ->ToXml());
        }
        catch (Exception^ e) 
        {
             Console::WriteLine("Copy failed : {0}{1}", Gac1, e);
             return false;
        }
      //</Snippet2>

        return true;
    }

    // Demonstrate the Check method, which determines whether the specified 
    // evidence satisfies the membership condition.
    bool CheckDemo()
    {
        Console::WriteLine(
            "************************************************************");
        //<Snippet3>
        GacMembershipCondition ^ Gac1 = gcnew GacMembershipCondition;
        GacInstalled ^ myGac = gcnew GacInstalled;
        try
        {
             array<Object^>^hostEvidence = {myGac};
             array<Object^>^assemblyEvidence = {};
             Evidence^ myEvidence = 
                 gcnew Evidence(hostEvidence,assemblyEvidence);
             bool retCode = Gac1->Check(myEvidence);
             Console::WriteLine("Result of Check = {0}\n", retCode);
        }
        catch (Exception^ e) 
        {
             Console::WriteLine("Check failed : {0}{1}", Gac1, e);
             return false;
        }
      //</Snippet3>

        return true;
    }

    // Demonstrate the GetHashCode method, which returns a hash code 
    // for the specified membership condition.
    bool GetHashCodeDemo()
    {
        Console::WriteLine(
            "************************************************************");
        //<Snippet4>
        GacMembershipCondition ^ Gac1 = gcnew GacMembershipCondition;
        try
        {
            Console::WriteLine(
                "Result of GetHashCode for a GacMembershipCondition = {0}\n",
                Gac1->GetHashCode());
        }
        catch (Exception^ e) 
        {
             Console::WriteLine("GetHashCode failed : {0}{1}", Gac1, e);
             return false;
        }
        //</Snippet4>

        return true;
    }

    // Demonstrate the ToXml and FromXml methods, including the overloads. 
    // ToXml creates an XML encoding of the membership condition and its 
    // current state; FromXml reconstructs a membership condition with the 
    // specified state from the XML encoding.
    bool ToFromXmlDemo()
    {
        Console::WriteLine(
            "************************************************************");
        try
        {
            //<Snippet5>
            GacMembershipCondition ^ Gac1 = gcnew GacMembershipCondition;
            GacMembershipCondition ^ Gac2 = gcnew GacMembershipCondition;

            // Roundtrip a GacMembershipCondition to and from an XML encoding.
            Gac2->FromXml(Gac1->ToXml());
            bool result = Gac2->Equals(Gac1);
            if (result)
            {
                Console::WriteLine("Result of ToXml() = {0}", Gac2->ToXml());
                Console::WriteLine(
                    "Result of ToFromXml roundtrip = {0}", Gac2);
            }
            else
            {
                Console::WriteLine(Gac2->ToString());
                Console::WriteLine(Gac1->ToString());
                return false;
            }
            //</Snippet5>

            //<Snippet6>
            GacMembershipCondition ^ Gac3 = gcnew GacMembershipCondition;
            GacMembershipCondition ^ Gac4 = gcnew GacMembershipCondition;
            IEnumerator^ policyEnumerator = SecurityManager::PolicyHierarchy();
            while (policyEnumerator->MoveNext())
            {
                PolicyLevel^ currentLevel = 
                    dynamic_cast<PolicyLevel^>(policyEnumerator->Current);
                if (currentLevel->Label->Equals("Machine"))
                {
                    Console::WriteLine("Result of ToXml(level) = {0}", 
                        Gac3->ToXml(currentLevel));
                    Gac4->FromXml(Gac3->ToXml(), currentLevel);
                    Console::WriteLine(
                        "Result of FromXml(element, level) = {0}", Gac4);
                }
            }
            //</Snippet6>
        }
        catch (Exception^ e) 
        {
            Console::WriteLine("ToFromXml failed. {0}", e);
            return false;
        }

        return true;
    }

public:

    // Invoke all demos.
    bool RunDemo()
    {
        bool returnCode = true;
        bool tempReturnCode;

        // Call the Copy demo.
        if (tempReturnCode = CopyDemo())
            Console::WriteLine("Copy demo completed successfully.");
        else
            Console::WriteLine("Copy demo failed.");

        returnCode = tempReturnCode && returnCode;

        // Call the Check demo.
        if (tempReturnCode = CheckDemo())
            Console::WriteLine("Check demo completed successfully.");
        else
            Console::WriteLine("Check demo failed.");

        returnCode = tempReturnCode && returnCode;

        // Call the GetHashCode demo.
        if (tempReturnCode = GetHashCodeDemo())
            Console::WriteLine("GetHashCode demo completed successfully.");
        else
            Console::WriteLine("GetHashCode demo failed.");

        returnCode = tempReturnCode && returnCode;

        // Call the ToFromXml demo. 
        if (tempReturnCode = ToFromXmlDemo())
            Console::WriteLine("ToFromXml demo completed successfully.");
        else
            Console::WriteLine("ToFromXml demo failed.");

        returnCode = tempReturnCode && returnCode;
        return (returnCode);
    }
};

// Test harness.
int main()
{
    try
    {
        GacMembershipConditionDemo^ testcase = 
            gcnew GacMembershipConditionDemo;
        bool returnCode = testcase->RunDemo();
        if (returnCode)
        {
            Console::WriteLine(
                "The GacMembershipCondition demo completed successfully.");
            Console::WriteLine("Press the Enter key to exit.");
            Console::ReadLine();
            System::Environment::ExitCode = 100;
        }
        else
        {
            Console::WriteLine("The GacMembershipCondition demo failed.");
            Console::WriteLine("Press the ENTER key to exit.");
            Console::ReadLine();
            System::Environment::ExitCode = 101;
        }
    }
    catch (Exception^ e) 
    {
        Console::WriteLine("The GacIdentityPermission demo failed.");
        Console::WriteLine(e);
        Console::WriteLine("Press the Enter key to exit.");
        Console::ReadLine();
        System::Environment::ExitCode = 101;
    }
}
// </Snippet1>

