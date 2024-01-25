﻿' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Collections
Imports System.Resources

Module Example
   Public Sub Main()
      Console.WriteLine("Resources in ApplicationResources.resources:")
      Dim res As New ResourceReader(".\ApplicationResources.resources")
      Dim dict As IDictionaryEnumerator = res.GetEnumerator()
      Do While dict.MoveNext()
         Console.WriteLine("   {0}: '{1}' (Type {2})", dict.Key, dict.Value, dict.Value.GetType().Name)
      Loop
      res.Close()
   End Sub
End Module
' The example displays output like the following:
'       Resources in ApplicationResources.resources:
'          Label3: '"Last Name:"' (Type String)
'          Label2: '"Middle Name:"' (Type String)
'          Label1: '"First Name:"' (Type String)
'          Label7: '"State:"' (Type String)
'          Label6: '"City:"' (Type String)
'          Label5: '"Street Address:"' (Type String)
'          Label4: '"SSN:"' (Type String)
'          Label9: '"Home Phone:"' (Type String)
'          Label8: '"Zip Code:"' (Type String)
'          Title: '"Contact Information"' (Type String)
'          Label12: '"Other Phone:"' (Type String)
'          Label13: '"Fax:"' (Type String)
'          Label10: '"Business Phone:"' (Type String)
'          Label11: '"Mobile Phone:"' (Type String)
'          Label14: '"Email Address:"' (Type String)
'          Label15: '"Alternate Email Address:"' (Type String)
' </Snippet1>