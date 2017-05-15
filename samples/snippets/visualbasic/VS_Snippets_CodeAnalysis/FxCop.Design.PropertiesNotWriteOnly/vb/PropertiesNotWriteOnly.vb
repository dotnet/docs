'<Snippet1>
Imports System

Namespace DesignLibrary

   Public Class BadClassWithWriteOnlyProperty

      Dim someName As String

      ' Violates rule PropertiesShouldNotBeWriteOnly.
      WriteOnly Property Name As String
         Set 
            someName = Value
         End Set 
      End Property

   End Class

   Public Class GoodClassWithReadWriteProperty

      Dim someName As String

      Property Name As String
         Get 
            Return someName
         End Get 

         Set 
            someName = Value
         End Set 
      End Property

   End Class

End Namespace
'</Snippet1>
