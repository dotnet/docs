//<Snippet1>
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using System.Security.Permissions;

[assembly: AllowPartiallyTrustedCallersAttribute()]
namespace SecurityRulesLibrary
{   
    [Serializable]
    public class SerializationConstructorsRequireSecurity : ISerializable 
    {
        private  int n1;
        // This is a regular constructor secured by a demand.
        [FileIOPermissionAttribute(SecurityAction.Demand, Unrestricted = true)]
        public SerializationConstructorsRequireSecurity ()
        {
           n1 = -1;
        }
        // This is the serialization constructor.
        // Violates rule: SecureSerializationConstructors.
        protected SerializationConstructorsRequireSecurity (SerializationInfo info, StreamingContext context)
        {
           n1 = (int) info.GetValue("n1", typeof(int));
        }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
           info.AddValue("n1", n1);
        }
    }

 }
//</Snippet1>
