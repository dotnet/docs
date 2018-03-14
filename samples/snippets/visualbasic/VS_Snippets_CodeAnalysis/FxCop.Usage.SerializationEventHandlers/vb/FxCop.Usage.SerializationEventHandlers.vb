'<Snippet1>
Imports System
Imports System.Runtime.Serialization

Namespace UsageLibrary

   <SerializableAttribute> _ 
   Public Class SerializationEventHandlers

      <OnSerializingAttribute> _ 
      Private Sub OnSerializing(context As StreamingContext) 
      End Sub

      <OnSerializedAttribute> _ 
      Private Sub OnSerialized(context As StreamingContext) 
      End Sub

      <OnDeserializingAttribute> _ 
      Private Sub OnDeserializing(context As StreamingContext)
      End Sub

      <OnDeserializedAttribute> _ 
      Private Sub OnDeserialized(context As StreamingContext)
      End Sub

   End Class

End Namespace
'</Snippet1>
