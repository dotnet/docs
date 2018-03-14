//<Snippet1>
using System;
using System.Data;
using System.Security;
using System.Security.Permissions;
using System.Security.Policy;
using System.Reflection;
using System.Runtime.Serialization;

[assembly: KeyContainerPermissionAttribute(SecurityAction.RequestRefuse, 
    Flags = KeyContainerPermissionFlags.Import)]
namespace TestForm
{
    class EntryPoint
    {
        [STAThread]
        static void Main()
        {
            EntryPoint eP = new EntryPoint();
            eP.RunCode();
            Console.WriteLine("Press the ENTER key to exit.");
            Console.Read();
        }
        void RunCode()
        {
            try
            {
                // Deny a permission.
                KeyContainerPermission kCP1 = new KeyContainerPermission(
                    KeyContainerPermissionFlags.Decrypt);
                kCP1.Deny();

                // Demand the denied permission and display the 
                // exception properties.
                Display("Demanding a denied permission. \n\n");
                DemandDeniedPermission();
                Display("************************************************\n");
                CodeAccessPermission.RevertDeny();

                // Demand the permission refused in the 
                // assembly-level attribute.
                Display("Demanding a refused permission. \n\n");
                DemandRefusedPermission();
                Display("************************************************\n");

                // Demand the permission implicitly refused through a 
                // PermitOnly attribute. Permit only the permission that 
                // will cause the failure and the security permissions 
                // necessary to display the results of the failure.
                PermissionSet permitOnly = new PermissionSet(
                    PermissionState.None);
                permitOnly.AddPermission(new KeyContainerPermission(
                    KeyContainerPermissionFlags.Import));
                permitOnly.AddPermission(new SecurityPermission(
                    SecurityPermissionFlag.ControlEvidence |
                    SecurityPermissionFlag.ControlPolicy | 
                    SecurityPermissionFlag.SerializationFormatter));
                permitOnly.PermitOnly();
                Display("Demanding an implicitly refused permission. \n\n");
                DemandPermitOnly();
            }
            catch (Exception sE)
            {
                Display("************************************************\n");
                //<Snippet17>
                Display("Displaying an exception using the ToString method: ");
                Display(sE.ToString());
                //</Snippet17>
            }
        }

        void DemandDeniedPermission()
        {
            try
            {
                KeyContainerPermission kCP = new KeyContainerPermission(
                    KeyContainerPermissionFlags.Decrypt);
                kCP.Demand();
            }
            catch (SecurityException sE)
            {
                //<Snippet2>
                Display("The denied permission is: " + 
                    ((PermissionSet)sE.DenySetInstance).ToString());
                //</Snippet2>
                //<Snippet3>
                Display("The demanded permission is: " + 
                    sE.Demanded.ToString());
                //</Snippet3>
                //<Snippet4>
                Display("The security action is: " + sE.Action.ToString());
                //</Snippet4>
                //<Snippet5>
                Display("The method is: " + sE.Method);
                //</Snippet5>
                //<Snippet6>
                Display(
                    "The permission state at the time of the exception was: " + 
                    sE.PermissionState);
                //</Snippet6>
                //<Snippet7>
                Display("The permission that failed was: " + 
                    (IPermission)sE.FirstPermissionThatFailed);
                //</Snippet7>
                //<Snippet8>
                Display("The permission type is: " + 
                    sE.PermissionType.ToString());
                //</Snippet8>
                //<Snippet9>
                Display("Demonstrating the use of the GetObjectData method.");
                SerializationInfo si = new SerializationInfo(
                    typeof(EntryPoint), new FormatterConverter());
                sE.GetObjectData(si, 
                    new StreamingContext(StreamingContextStates.All));
                Display("The FirstPermissionThatFailed from the " +
                    "call to GetObjectData is: ");
                Display(si.GetString("FirstPermissionThatFailed"));
                //</Snippet9>
            }
        }

        void DemandRefusedPermission()
        {
            try
            {
                KeyContainerPermission kCP = new KeyContainerPermission(
                    KeyContainerPermissionFlags.Import);
                kCP.Demand();
            }
            catch (SecurityException sE)
            {
                //<Snippet10>
                Display("The refused permission set is: " + 
                    (sE.RefusedSet).ToString());
                //</Snippet10>
                //<Snippet11>
                Display("The exception message is: " + sE.Message);
                //</Snippet11>
                //<Snippet12>
                Display("The failed assembly is: " + 
                    sE.FailedAssemblyInfo.EscapedCodeBase);
                //</Snippet12>
                //<Snippet13>
                Display("The granted set is: \n" + sE.GrantedSet);
                //</Snippet13>
                Display("The permission that failed is: " + 
                    sE.FirstPermissionThatFailed);
                Display("The permission type is: " + 
                    sE.PermissionType.ToString());
                //<Snippet14>
                Display("The source is: " + sE.Source);
                //</Snippet14>
            }
        }

        void DemandPermitOnly()
        {
            try
            {
                KeyContainerPermission kCP = new KeyContainerPermission(
                    KeyContainerPermissionFlags.Decrypt);
                kCP.Demand();
            }
            catch (SecurityException sE)
            {
                //<Snippet15>
                Display("The permitted permission is: " +
                    ((PermissionSet)sE.PermitOnlySetInstance).ToString());
                //</Snippet15>
                Display("The demanded permission is: " + 
                    sE.Demanded.ToString());
                Display("The security action is: " + sE.Action.ToString());
                Display("The method is: " + sE.Method.ToString());
                Display(
                    "The permission state at the time of the exception was: " +
                    sE.PermissionState);
                Display("The permission that failed was: " +
                    (IPermission)sE.FirstPermissionThatFailed);
                Display("The permission type is: " + 
                    sE.PermissionType.ToString());

                //<Snippet16>
                //Demonstrate the SecurityException constructor by 
                // throwing the exception again.
                Display("Rethrowing the exception thrown as a result of a " + 
                    "PermitOnly security action.");
                throw new SecurityException(sE.Message, sE.DenySetInstance, 
                    sE.PermitOnlySetInstance, sE.Method, sE.Demanded, 
                    (IPermission)sE.FirstPermissionThatFailed);
                //</Snippet16>
            }
        }
        void Display(string line)
        {
            Console.WriteLine(line);
        }
    }
}
//</Snippet1>

