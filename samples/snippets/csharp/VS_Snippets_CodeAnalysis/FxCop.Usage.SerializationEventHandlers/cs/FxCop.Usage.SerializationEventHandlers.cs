//<Snippet1>
using System;
using System.Runtime.Serialization;

namespace UsageLibrary
{
   [SerializableAttribute]
   public class SerializationEventHandlers
   {
      [OnSerializingAttribute]
      void OnSerializing(StreamingContext context) {}

      [OnSerializedAttribute]
      void OnSerialized(StreamingContext context) {}

      [OnDeserializingAttribute]
      void OnDeserializing(StreamingContext context) {}

      [OnDeserializedAttribute]
      void OnDeserialized(StreamingContext context) {}
   }
}
//</Snippet1>
