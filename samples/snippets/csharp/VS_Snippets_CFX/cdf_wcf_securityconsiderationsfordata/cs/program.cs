using System;
using System.Runtime.Serialization;
using System.Security;
using System.IO;

//<snippet2>
[assembly:System.Runtime.CompilerServices.InternalsVisibleTo("System.Runtime.Serialization, PublicKey = 00000000000000000400000000000000")]
//</snippet2>

namespace SecurityConsiderationsForData
{
    //<snippet1>
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
//              PermissionsHelper.InternetZone corresponds to the PermissionSet for partial trust. 
//              PermissionsHelper.InternetZone.PermitOnly();
                MemoryStream memoryStream = new MemoryStream();
                new DataContractSerializer(typeof(DataNode)).
                    WriteObject(memoryStream, new DataNode());
            }
            finally
            {
                CodeAccessPermission.RevertPermitOnly();
            }
        }

        [DataContract]
        public class DataNode
        {
            [DataMember]
            internal string Value = "Default";
        }
    }
    //</snippet1>
}