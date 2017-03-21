   <DesignerSerializer(GetType(MyCodeDomSerializer), GetType(CodeDomSerializer))> _
   Public Class MyComponent
      Inherits Component
      Private localProperty As String = "Component Property Value"

      Public Property LocalProp() As String
         Get
            Return localProperty
         End Get
         Set(ByVal Value As String)
            localProperty = Value
         End Set
      End Property
   End Class 'MyComponent