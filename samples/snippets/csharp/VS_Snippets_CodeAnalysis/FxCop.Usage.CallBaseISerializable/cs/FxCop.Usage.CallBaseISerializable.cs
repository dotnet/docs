//<Snippet1>
using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace UsageLibrary
{
   [SerializableAttribute]
   public class BaseType : ISerializable
   {
      int baseValue;

      public BaseType()
      {
         baseValue = 3;
      }

      protected BaseType(
         SerializationInfo info, StreamingContext context)
      {
         baseValue = info.GetInt32("baseValue");
      }

      [SecurityPermissionAttribute(SecurityAction.Demand, 
          SerializationFormatter = true)]
      public virtual void GetObjectData(
         SerializationInfo info, StreamingContext context)
      {
         info.AddValue("baseValue", baseValue);
      }
   }

   [SerializableAttribute]
   public class DerivedType : BaseType
   {
      int derivedValue;

      public DerivedType()
      {
         derivedValue = 4;
      }

      protected DerivedType(
         SerializationInfo info, StreamingContext context) : 
         base(info, context)
      {
         derivedValue = info.GetInt32("derivedValue");
      }

      [SecurityPermissionAttribute(SecurityAction.Demand, 
          SerializationFormatter = true)]
      public override void GetObjectData(
         SerializationInfo info, StreamingContext context)
      {
         info.AddValue("derivedValue", derivedValue);
         base.GetObjectData(info, context);
      }
   }
}
//</Snippet1>
