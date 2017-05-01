//<Snippet1>
using System;
using System.IO;
using System.Data.Sql;
using System.Data.SqlTypes;
using System.Text;
using Microsoft.SqlServer.Server;


[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedAggregate(
   Microsoft.SqlServer.Server.Format.UserDefined, 
   IsInvariantToNulls = true,			
   IsInvariantToDuplicates = false,		
   IsInvariantToOrder = false,			
   MaxByteSize = 8000)				
        ]
public class Concatenate : Microsoft.SqlServer.Server.IBinarySerialize
{
//</Snippet1>

   public void Read(BinaryReader r)
   {
            
   }

   public void Write(BinaryWriter w)
   {
            
   }
}
        