Option Explicit
Option Strict

Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization


' <Snippet1>
Public Enum EmployeeStatus
   <XmlEnum("Single")> One = 1
   <XmlEnum("Double")> Two = 2
   <XmlEnum("Triple")> Three = 3
End Enum
' </Snippet1>
