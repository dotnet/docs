// This sample demonstrates how to use each member of the FirstMatchCodeGroup
// class.
//<Snippet1>
using System;
using System.Security;
using System.Security.Policy;
using System.Security.Permissions;
using System.Reflection;

class Members
{
    [STAThread]
    static void Main(string[] args)
    {
        // Create a new FirstMatchCodeGroup.
        FirstMatchCodeGroup codeGroup = constructDefaultGroup();

        // Create a deep copy of the FirstMatchCodeGroup.
        //<Snippet18>
        FirstMatchCodeGroup copyCodeGroup = 
            (FirstMatchCodeGroup)codeGroup.Copy();
        //</Snippet18>
        // Compare the original code group with the copy.
        CompareTwoCodeGroups(codeGroup, copyCodeGroup);

        addPolicy(ref codeGroup);
        addXmlMember(ref codeGroup);
        updateMembershipCondition(ref codeGroup);
        addChildCodeGroup(ref codeGroup);

        Console.Write("Comparing the resolved code group ");
        Console.WriteLine("with the initial code group.");
        FirstMatchCodeGroup resolvedCodeGroup =
            ResolveGroupToEvidence(codeGroup);
        if (CompareTwoCodeGroups(codeGroup, resolvedCodeGroup))
        {
            PrintCodeGroup(resolvedCodeGroup);
        }
        else
        {
            PrintCodeGroup(codeGroup);
        }
        
        Console.WriteLine("This sample completed successfully; " +
            "press Enter to exit.");
        Console.ReadLine();
    }

    // Create a FirstMatchCodeGroup with an exclusive policy and membership
    // condition.
    private static FirstMatchCodeGroup constructDefaultGroup()
    {
        // Construct a new FirstMatchCodeGroup with Read, Write, Append
        // and PathDiscovery access.
        // Create read access permission to the root directory on drive C.
        //<Snippet2>
        FileIOPermission rootFilePermissions =
            new FileIOPermission(PermissionState.None);
        rootFilePermissions.AllLocalFiles = FileIOPermissionAccess.Read;
        rootFilePermissions.SetPathList(FileIOPermissionAccess.Read,"C:\\");

        // Add a permission to a named permission set.
        NamedPermissionSet namedPermissions =
            new NamedPermissionSet("RootPermissions");
        namedPermissions.AddPermission(rootFilePermissions);

        // Create a PolicyStatement with exclusive rights to the policy.
        PolicyStatement policy = new PolicyStatement(
            namedPermissions,PolicyStatementAttribute.Exclusive);

        // Create a FirstMatchCodeGroup with a membership condition that
        // matches all code, and an exclusive policy.
        FirstMatchCodeGroup codeGroup =
            new FirstMatchCodeGroup(
            new AllMembershipCondition(),
            policy);
        //</Snippet2>

        // Set the name of the first match code group.
        //<Snippet3>
        codeGroup.Name = "TempCodeGroup";
        //</Snippet3>

        // Set the description of the first match code group.
        //<Snippet4>
        codeGroup.Description = "Temp folder permissions group";
        //</Snippet4>

        return codeGroup;
    }

    // Add file permission to restrict write access to all files 
    // on the local machine.
    private static void addPolicy(ref FirstMatchCodeGroup codeGroup)
    {
        // Set the PolicyStatement property to a policy with read access to
        // the root directory on drive C.
        //<Snippet6>
        FileIOPermission rootFilePermissions =
            new FileIOPermission(PermissionState.None);
        rootFilePermissions.AllLocalFiles = FileIOPermissionAccess.Read;
        rootFilePermissions.SetPathList(FileIOPermissionAccess.Read,"C:\\");

        NamedPermissionSet namedPermissions =
            new NamedPermissionSet("RootPermissions");
        namedPermissions.AddPermission(rootFilePermissions);

        // Create a PolicyStatement with exclusive rights to the policy.
        PolicyStatement policy = new PolicyStatement(
            namedPermissions,
            PolicyStatementAttribute.Exclusive);

        codeGroup.PolicyStatement = policy;
        //</Snippet6>
    }

    // Set the membership condition of the code group.
    private static void updateMembershipCondition(
        ref FirstMatchCodeGroup codeGroup)
    {
        // Set the membership condition of the specified FirstMatchCodeGroup
        // to the Intranet zone.
        //<Snippet7>
        ZoneMembershipCondition zoneCondition =
            new ZoneMembershipCondition(SecurityZone.Intranet);
        codeGroup.MembershipCondition = zoneCondition;
        //</Snippet7>
    }

    // Create a child code group with read-access file permissions and add it
    // to the specified code group.
    private static void addChildCodeGroup(ref FirstMatchCodeGroup codeGroup)
    {
        // Create a first match code group with read access.
        //<Snippet8>
        FileIOPermission rootFilePermissions = 
            new FileIOPermission(PermissionState.None);
        rootFilePermissions.AllLocalFiles = FileIOPermissionAccess.Read;
        rootFilePermissions.SetPathList(FileIOPermissionAccess.Read,"C:\\");

        PermissionSet permissions =
            new PermissionSet(PermissionState.Unrestricted);
        permissions.AddPermission(rootFilePermissions);

        FirstMatchCodeGroup tempFolderCodeGroup = new FirstMatchCodeGroup(
            new AllMembershipCondition(), 
            new PolicyStatement(permissions));

        // Set the name of the child code group and add it to 
        // the specified code group.
        tempFolderCodeGroup.Name = "Read-only code group";
        codeGroup.AddChild(tempFolderCodeGroup);
        //</Snippet8>
    }

    // Compare the two FirstMatchCodeGroups.
    private static bool CompareTwoCodeGroups(
        FirstMatchCodeGroup firstCodeGroup, 
        FirstMatchCodeGroup secondCodeGroup)
    {
        // Compare the two specified FirstMatchCodeGroups for equality.
        //<Snippet20>
        if (firstCodeGroup.Equals(secondCodeGroup))
            //</Snippet20>
        {
            Console.WriteLine("The two code groups are equal.");
            return true;
        }
        else 
        {
            Console.WriteLine("The two code groups are not equal.");
            return false;
        }
    }

    // Retrieve the resolved policy based on executing evidence found 
    // in the specified code group.
    private static string ResolveEvidence(CodeGroup codeGroup)
    {
        string policyString = "None";

        // Resolve the policy based on the executing assembly's evidence.
        //<Snippet19>
        Assembly assembly = typeof(Members).Assembly;
        Evidence executingEvidence = assembly.Evidence;

        PolicyStatement policy = codeGroup.Resolve(executingEvidence);
        //</Snippet19>

        if (policy != null)
        {
            policyString = policy.ToString();
        }

        return policyString;
    }

    // Retrieve the resolved code group based on the evidence from the 
    // specified code group.
    private static FirstMatchCodeGroup ResolveGroupToEvidence(
        FirstMatchCodeGroup codeGroup)
    {
        // Resolve matching code groups to the executing assembly.
        //<Snippet9>
        Assembly assembly = typeof(Members).Assembly;
        Evidence evidence = assembly.Evidence;
        CodeGroup resolvedCodeGroup = 
            codeGroup.ResolveMatchingCodeGroups(evidence);
        //</Snippet9>

        return (FirstMatchCodeGroup)resolvedCodeGroup;
    }

    // If a domain attribute is not found in the specified 
    // FirstMatchCodeGroup, add a child XML element identifying a custom
    // membership condition.
    private static void addXmlMember(ref FirstMatchCodeGroup codeGroup)
    {
        //<Snippet10>
        SecurityElement xmlElement = codeGroup.ToXml();
        //</Snippet10>

        SecurityElement rootElement = new SecurityElement("CodeGroup");

        if (xmlElement.Attribute("domain") == null) 
        {
            //<Snippet11>
            SecurityElement newElement = 
                new SecurityElement("CustomMembershipCondition");
            newElement.AddAttribute("class","CustomMembershipCondition");
            newElement.AddAttribute("version","1");
            newElement.AddAttribute("domain","contoso.com");

            rootElement.AddChild(newElement);

            codeGroup.FromXml(rootElement);
            //</Snippet11>
        }

        Console.WriteLine("Added a custom membership condition:");
        Console.WriteLine(rootElement.ToString());
    }


    // Print the properties of the specified code group to the console.
    private static void PrintCodeGroup(CodeGroup codeGroup)
    {
        // Compare the type of the specified object with the
        // FirstMatchCodeGroup type.
        //<Snippet12>
        if (!codeGroup.GetType().Equals(typeof(FirstMatchCodeGroup)))
            //</Snippet12>
        {
            throw new ArgumentException(
                "Expected the FirstMatchCodeGroup type.");
        }
        
        string codeGroupName = codeGroup.Name;
        string membershipCondition = codeGroup.MembershipCondition.ToString();
        //<Snippet13>
        string permissionSetName = codeGroup.PermissionSetName;
        //</Snippet13>

        //<Snippet14>
        int hashCode = codeGroup.GetHashCode();
        //</Snippet14>

        string mergeLogic = "";
        //<Snippet15>
        if (codeGroup.MergeLogic.Equals("First Match"))
            //</Snippet15>
        {
            mergeLogic = "with first-match merge logic";
        }

        // Retrieve the class path for the FirstMatchCodeGroup.
        //<Snippet16>
        string firstMatchGroupClass = codeGroup.ToString();
        //</Snippet16>

        string attributeString = "";
        // Retrieve the string representation of the FirstMatchCodeGroup's
        // attributes.
        //<Snippet5>
        if (codeGroup.AttributeString != null)
        {
            attributeString = codeGroup.AttributeString;
        }
        //</Snippet5>

        // Write a summary to the console window.
        Console.WriteLine("\n*** " + firstMatchGroupClass + " summary ***");
        Console.Write("A FirstMatchCodeGroup named ");
        Console.Write(codeGroupName + mergeLogic);
        Console.Write(" has been created with hash code(" + hashCode + ").");
        Console.Write("\nThis code group contains a " + membershipCondition);
        Console.Write(" membership condition with the ");
        Console.WriteLine(permissionSetName + " permission set.");

        Console.Write("The code group contains the following policy: ");
        Console.Write(ResolveEvidence(codeGroup));
        Console.Write("\nIt also contains the following attributes: ");
        Console.WriteLine(attributeString);

        int childCount = codeGroup.Children.Count;
        if (childCount > 0 )
        {
            Console.Write("There are " + childCount);
            Console.WriteLine(" child elements in the code group.");

            // Iterate through the child code groups to display their names
            // and then remove them from the specified code group.
            for (int i=0; i < childCount; i++)
            {
                // Retrieve a child code group, which has been cast as a
                // FirstMatchCodeGroup type.
                //<Snippet21>
                FirstMatchCodeGroup childCodeGroup = 
                    (FirstMatchCodeGroup)codeGroup.Children[i];
                //</Snippet21>

                Console.Write("Removing the " + childCodeGroup.Name + ".");
                // Remove the child code group.
                //<Snippet17>
                codeGroup.RemoveChild(childCodeGroup);
                //</Snippet17>
            }

            Console.WriteLine();
        }
        else
        {
            Console.WriteLine(" No child code groups were found in this" + 
                " code group.");
        }
    }
}
//
// This sample produces the following output:
//
// The two code groups are equal.
// Added a custom membership condition:
// <CodeGroup>
//   <CustomMembershipCondition class="CustomMembershipCondition"
//                              version="1"
//                              domain="contoso.com"/>
// </CodeGroup>
//
// Comparing the resolved code group with the initial code group.
// The two code groups are not equal.
//
// *** System.Security.Policy.FirstMatchCodeGroup summary ***
// A FirstMatchCodeGroup named with first-match merge logic has been created
// with hash code(113151525).
// This code group contains a Zone - Intranet membership condition with the 
// permission set.The code group contains the following policy: 
// It also contains the following attributes:
// There are 1 child elements in the code group.
// Removing the Read-only code group.
// This sample completed successfully; press Enter to exit.
//</Snippet1>