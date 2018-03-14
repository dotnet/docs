//<Snippet1>
using System;
using System.Reflection;
using System.Runtime.Serialization;

[assembly: AssemblyVersionAttribute("2.0.0.0")]
namespace UsageLibrary
{
   [SerializableAttribute]
   public class SerializationEventHandlers
   {
      [OptionalFieldAttribute(VersionAdded = 2)]
      int optionalField = 5;

      [OnDeserializingAttribute]
      void OnDeserializing(StreamingContext context)
      {
         optionalField = 5;
      }

      [OnDeserializedAttribute]
      void OnDeserialized(StreamingContext context)
      {
         // Set optionalField if dependent on other deserialized values.
      }
   }
}
//</Snippet1>
