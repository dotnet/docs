//<Snippet1>
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Permissions;

namespace UsageLibrary 
{   
    [Serializable]
    public class SerializationConstructorsRequired : ISerializable 
    {
        private  int n1;

        // This is a regular constructor.
        public SerializationConstructorsRequired ()
        {
            n1 = -1;
        }
        // This is the serialization constructor.
        // Satisfies rule: ImplementSerializationConstructors.

        protected SerializationConstructorsRequired(
           SerializationInfo info, 
           StreamingContext context)
        {
            n1 = (int) info.GetValue("n1", typeof(int));
        }

        // The following method serializes the instance.
        [SecurityPermission(SecurityAction.LinkDemand, 
            Flags=SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, 
           StreamingContext context)
        {
            info.AddValue("n1", n1);
        }
    }
}
//</Snippet1>
