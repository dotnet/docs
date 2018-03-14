//<Snippet1>
using System;
using System.IO;
using System.Runtime.Remoting;
using System.Security;
using System.Security.Permissions;
using System.Reflection;
using MyPermission;
// Use the command line option '/keyfile' or appropriate project settings to sign this assembly.
[assembly: System.Security.AllowPartiallyTrustedCallersAttribute ()]

namespace MyPermissionAttribute
{
    [AttributeUsage (AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Assembly, AllowMultiple = true, Inherited = false)]
    [Serializable]
    sealed public class  NameIdPermissionAttribute : CodeAccessSecurityAttribute
    {
        private String m_Name = null;
        private bool m_unrestricted = false;

        public  NameIdPermissionAttribute (SecurityAction action): base( action )
        {
        }

        public String Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public override IPermission CreatePermission ()
        {
            if (m_unrestricted)
            {
                throw new ArgumentException ("Unrestricted permissions not allowed in identity permissions.");
            }
            else
            {
                if (m_Name == null)
                    return new  NameIdPermission (PermissionState.None);

                return new  NameIdPermission (m_Name);
            }
        }
    }
}
//</Snippet1>