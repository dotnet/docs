// This sample demonstrates how to use each member of the FileCodeGroup class.
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
        FileCodeGroup fileCodeGroup = constructDefaultGroup();
        
        // Create a deep copy of the FileCodeGroup.
        //<Snippet18>
        FileCodeGroup copyCodeGroup = (FileCodeGroup)fileCodeGroup.Copy();
        //</Snippet18>

        CompareTwoCodeGroups(fileCodeGroup, copyCodeGroup);

        addPolicy(ref fileCodeGroup);
        addXmlMember(ref fileCodeGroup);
        updateMembershipCondition(ref fileCodeGroup);
        addChildCodeGroup(ref fileCodeGroup);

        Console.Write("Comparing the resolved code group ");
        Console.WriteLine("with the initial code group.");
        FileCodeGroup resolvedCodeGroup =
            ResolveGroupToEvidence(fileCodeGroup);
        if (CompareTwoCodeGroups(fileCodeGroup, resolvedCodeGroup))
        {
            PrintCodeGroup(resolvedCodeGroup);
        }
        else
        {
            PrintCodeGroup(fileCodeGroup);
        }
        
        Console.WriteLine("This sample completed successfully; " +
            "press Enter to exit.");
        Console.ReadLine();
    }

    // Construct a new FileCodeGroup with Read, Write, Append 
    // and PathDiscovery access.
    private static FileCodeGroup constructDefaultGroup()
    {
        // Construct a new file code group that has complete access to
        // files in the specified path.
        //<Snippet2>
        FileCodeGroup fileCodeGroup = 
            new FileCodeGroup(
            new AllMembershipCondition(),
            FileIOPermissionAccess.AllAccess);
        //</Snippet2>

        // Set the name of the file code group.
        //<Snippet3>
        fileCodeGroup.Name = "TempCodeGroup";
        //</Snippet3>

        // Set the description of the file code group.
        //<Snippet4>
        fileCodeGroup.Description = "Temp folder permissions group";
        //</Snippet4>

        // Retrieve the string representation of the  fileCodeGroup’s 
        // attributes. FileCodeGroup does not use AttributeString, so the
        // value should be null.
        //<Snippet5>
        if (fileCodeGroup.AttributeString != null)
        {
            throw new NullReferenceException(
                "The AttributeString property should be null.");
        }
        //</Snippet5>

        return fileCodeGroup;
    }

    // Add file permission to restrict write access to all files on the
    // local machine.
    private static void addPolicy(ref FileCodeGroup fileCodeGroup)
    {
        // Set the PolicyStatement property to a policy with read access to
        // the root directory of drive C.
        //<Snippet6>
        FileIOPermission rootFilePermissions = 
            new FileIOPermission(PermissionState.None);
        rootFilePermissions.AllLocalFiles = FileIOPermissionAccess.Read;
        rootFilePermissions.SetPathList(FileIOPermissionAccess.Read,"C:\\");

        NamedPermissionSet namedPermissions =
            new NamedPermissionSet("RootPermissions");
        namedPermissions.AddPermission(rootFilePermissions);
        
        fileCodeGroup.PolicyStatement =
            new PolicyStatement(namedPermissions);
        //</Snippet6>
    }

    // Set the membership condition of the specified FileCodeGroup 
    // to the Intranet zone.
    private static void updateMembershipCondition(
        ref FileCodeGroup fileCodeGroup)
    {
        //<Snippet7>
        ZoneMembershipCondition zoneCondition =
            new ZoneMembershipCondition(SecurityZone.Intranet);
        fileCodeGroup.MembershipCondition = zoneCondition;
        //</Snippet7>
    }

    // Add a child group with read-access file permission to the specified 
    // code group.
    private static void addChildCodeGroup(ref FileCodeGroup fileCodeGroup)
    {
        // Create a file code group with read-access permission.
        //<Snippet8>
        FileCodeGroup tempFolderCodeGroup = new FileCodeGroup(
            new AllMembershipCondition(), 
            FileIOPermissionAccess.Read);

        // Set the name of the child code group and add it to 
        // the specified code group.
        tempFolderCodeGroup.Name = "Read-only group";
        fileCodeGroup.AddChild(tempFolderCodeGroup);
        //</Snippet8>
    }

    // Compare the two specified file code groups for equality.
    private static bool CompareTwoCodeGroups(
        FileCodeGroup firstCodeGroup, FileCodeGroup secondCodeGroup)
    {
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

    // Retrieve the resolved policy based on Evidence from the executing 
    // assembly found in the specified code group.
    private static string ResolveEvidence(CodeGroup fileCodeGroup)
    {
        string policyString = "";

        // Resolve the policy based on evidence in the executing assembly.
        //<Snippet19>
        Assembly assembly = typeof(Members).Assembly;
        Evidence executingEvidence = assembly.Evidence;

        PolicyStatement policy = fileCodeGroup.Resolve(executingEvidence);
        //</Snippet19>

        if (policy != null)
        {
            policyString = policy.ToString();
        }

        return policyString;
    }

    // Retrieve the resolved code group based on the Evidence from 
    // the executing assembly found in the specified code group.
    private static FileCodeGroup ResolveGroupToEvidence(
        FileCodeGroup fileCodeGroup)
    {
        // Resolve matching code groups to the executing assembly.
        //<Snippet9>
        Assembly assembly = typeof(Members).Assembly;
        Evidence evidence = assembly.Evidence;
        CodeGroup codeGroup = 
            fileCodeGroup.ResolveMatchingCodeGroups(evidence);
        //</Snippet9>

        return (FileCodeGroup)codeGroup;
    }

    // If a domain attribute is not found in the specified FileCodeGroup,
    // add a child XML element identifying a custom membership condition.
    private static void addXmlMember(ref FileCodeGroup fileCodeGroup)
    {
        //<Snippet10>
        SecurityElement xmlElement = fileCodeGroup.ToXml();
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

            fileCodeGroup.FromXml(rootElement);
            //</Snippet11>
        }

        Console.WriteLine("Added a custom membership condition:");
        Console.WriteLine(rootElement.ToString());
    }


    // Print the properties of the specified code group to the console.
    private static void PrintCodeGroup(CodeGroup codeGroup)
    {
        // Compare the type of the specified object with the FileCodeGroup
        // type.
        //<Snippet12>
        if (!codeGroup.GetType().Equals(typeof(FileCodeGroup)))
            //</Snippet12>
        {
            throw new ArgumentException("Expected the FileCodeGroup type.");
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
        if (codeGroup.MergeLogic.Equals("Union"))
            //</Snippet15>
        {
            mergeLogic = " with Union merge logic";
        }

        // Retrieve the class path for FileCodeGroup.
        //<Snippet16>
        string fileGroupClass = codeGroup.ToString();
        //</Snippet16>

        // Write summary to the console window.
        Console.WriteLine("\n*** " + fileGroupClass + " summary ***");
        Console.Write("A FileCodeGroup named ");
        Console.Write(codeGroupName + mergeLogic);
        Console.Write(" has been created with hash code" + hashCode + ".");
        Console.Write("This code group contains a " + membershipCondition);
        Console.Write(" membership condition with the ");
        Console.Write(permissionSetName + " permission set. ");

        Console.Write("The code group has the following security policy: ");
        Console.WriteLine(ResolveEvidence(codeGroup));

        
        int childCount = codeGroup.Children.Count;
        if (childCount > 0 )
        {
            Console.Write("There are " + childCount);
            Console.WriteLine(" child code groups in this code group.");

            // Iterate through the child code groups to display their names
            // and remove them from the specified code group.
            for (int i=0; i < childCount; i++)
            {
                // Get child code group as type FileCodeGroup.
                //<Snippet21>
                FileCodeGroup childCodeGroup = 
                    (FileCodeGroup)codeGroup.Children[i];
                //</Snippet21>
                
                Console.Write("Removing the " + childCodeGroup.Name + ".");
                // Remove child code group.
                //<Snippet17>
                codeGroup.RemoveChild(childCodeGroup);
                //</Snippet17>
            }

            Console.WriteLine();
        }
        else
        {
            Console.Write("There are no child code groups");
            Console.WriteLine(" in this code group.");
        }
    }
}
//
// This sample produces the following output:
//
// The two code groups are equal.
// Added a custom membership condition:
// <CodeGroup>
// <CustomMembershipCondition class="CustomMembershipCondition"
//                                version="1"
//                                domain="contoso.com"/>
//                                </CodeGroup>
// Comparing the resolved code group with the initial code group.
// The two code groups are not equal.
// 
// *** System.Security.Policy.FileCodeGroup summary ***
// A FileCodeGroup named  with Union merge logic has been created with hash
// code 113151473. This code group contains a Zone - Intranet membership
// condition with the Same directory FileIO - NoAccess permission set. The
// code group has the following security policy:
// There are 1 child code groups in this code group.
// Removing the Read-only group.
// This sample completed successfully; press Enter to exit.
//</Snippet1>
