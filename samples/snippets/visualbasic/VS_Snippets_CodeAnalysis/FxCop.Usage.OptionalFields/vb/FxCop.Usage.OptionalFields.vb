'<Snippet1>
Imports System
Imports System.Reflection
Imports System.Runtime.Serialization

<Assembly: AssemblyVersionAttribute("2.0.0.0")>
Namespace UsageLibrary

   <SerializableAttribute> _ 
   Public Class SerializationEventHandlers

      <OptionalFieldAttribute(VersionAdded := 2)> _ 
      Dim optionalField As Integer = 5

      <OnDeserializingAttribute> _ 
      Private Sub OnDeserializing(context As StreamingContext)
         optionalField = 5
      End Sub

      <OnDeserializedAttribute> _ 
      Private Sub OnDeserialized(context As StreamingContext)
         ' Set optionalField if dependent on other deserialized values.
      End Sub

   End Class

End Namespace
'</Snippet1>
