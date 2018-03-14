' Visual Basic .NET Document
Option Strict On

' <Snippet11>
Imports System.Runtime.InteropServices

<Assembly:ComVisible(True)>

' Define two classes, and assign one an explicit GUID.
<GuidAttribute("d055cba3-1f83-4bd7-ba19-e22b1b8ec3c4")>
Public Class ExplicitGuid
End Class

Public Class NoExplicitGuid
End Class

Module Example
   Public Sub Main()
      Dim explicitType As Type = GetType(ExplicitGuid)
      Dim explicitGuid As Guid = explicitType.GUID
      
      ' Get type of ExplicitGuid from its GUID.
      Dim explicitCOM As Type = Type.GetTypeFromCLSID(explicitGuid)
      Console.WriteLine("Created {0} type from CLSID {1}",
                        explicitCOM.Name, explicitGuid)
                        
      ' Compare the two type objects.
      Console.WriteLine("{0} and {1} equal: {2}",
                        explicitType.Name, explicitCOM.Name,
                        explicitType.Equals(explicitCOM))                  
      
      ' Instantiate an ExplicitGuid object.
      Try 
         Dim obj As Object = Activator.CreateInstance(explicitCOM)
         Console.WriteLine("Instantiated a {0} object", obj.GetType().Name)
      Catch e As COMException
         Console.WriteLine("COM Exception:{1}{0}{1}", e.Message, vbCrLf)   
      End Try 
        
      Dim notExplicit As Type = GetType(NoExplicitGuid)
      Dim notExplicitGuid As Guid = notExplicit.GUID
      
      ' Get type of ExplicitGuid from its GUID.
      Dim notExplicitCOM As Type = Type.GetTypeFromCLSID(notExplicitGuid)
      Console.WriteLine("Created {0} type from CLSID {1}",
                        notExplicitCOM.Name, notExplicitGuid)
                        
      ' Compare the two type objects.
      Console.WriteLine("{0} and {1} equal: {2}",
                        notExplicit.Name, notExplicitCOM.Name,
                        notExplicit.Equals(notExplicitCOM))                  
      
      ' Instantiate an ExplicitGuid object.
      Try 
         Dim obj As Object = Activator.CreateInstance(notExplicitCOM)
         Console.WriteLine("Instantiated a {0} object", obj.GetType().Name)
      Catch e As COMException
         Console.WriteLine("COM Exception:{1}{0}{1}", e.Message, vbCrLf)   
      End Try 
   End Sub
End Module
' The example displays the following output:
'       Created __ComObject type from CLSID d055cba3-1f83-4bd7-ba19-e22b1b8ec3c4
'       ExplicitGuid and __ComObject equal: False
'       COM Exception:
'       Retrieving the COM class factory for component with CLSID 
'       {D055CBA3-1F83-4BD7-BA19-E22B1B8EC3C4} failed due to the following error: 
'       80040154 Class not registered 
'       (Exception from HRESULT: 0x80040154 (REGDB_E_CLASSNOTREG)).
'       
'       Created __ComObject type from CLSID 74f03346-a718-3516-ac78-f351c7459ffb
'       NoExplicitGuid and __ComObject equal: False
'       COM Exception:
'       Retrieving the COM class factory for component with CLSID 
'       {74F03346-A718-3516-AC78-F351C7459FFB} failed due to the following error: 
'       80040154 Class not registered 
'       (Exception from HRESULT: 0x80040154 (REGDB_E_CLASSNOTREG)).
' </Snippet11>
