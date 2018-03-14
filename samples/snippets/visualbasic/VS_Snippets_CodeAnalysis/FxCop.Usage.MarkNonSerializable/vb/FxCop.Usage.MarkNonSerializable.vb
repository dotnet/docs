'<Snippet1>
Imports System
Imports System.Runtime.Serialization

Namespace UsageLibrary

   Public Class Mouse
   
      Dim buttons As Integer
      Dim scanTypeValue As String

      ReadOnly Property NumberOfButtons As Integer
         Get
            Return buttons
         End Get
      End Property

      ReadOnly Property ScanType As String
         Get
            Return scanTypeValue
         End Get
      End Property

      Sub New(numberOfButtons As Integer, scanType As String)
         buttons = numberOfButtons
         scanTypeValue = scanType
      End Sub

   End Class

   <SerializableAttribute> _ 
   Public Class InputDevices1
   
      ' Violates MarkAllNonSerializableFields.
      Dim opticalMouse As Mouse 

      Sub New()
         opticalMouse = New Mouse(5, "optical") 
      End Sub

   End Class

   <SerializableAttribute> _ 
   Public Class InputDevices2
   
      ' Satisfies MarkAllNonSerializableFields.
      <NonSerializedAttribute> _ 
      Dim opticalMouse As Mouse 

      Sub New()
         opticalMouse = New Mouse(5, "optical") 
      End Sub

   End Class

End Namespace
'</Snippet1>
