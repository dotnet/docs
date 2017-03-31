Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

' <Snippet1>
Public Enum EmployeeStatus
   <XmlEnumAttribute("Single")> One
   <XmlEnumAttribute("Double")> Two
   <XmlEnumAttribute("Triple")> Three
End Enum
' </Snippet1>
