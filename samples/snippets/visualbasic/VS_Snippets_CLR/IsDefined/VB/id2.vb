'<Snippet2>
Imports System
Imports System.Reflection
Imports System.Diagnostics

' Add the Debuggable attribute to the module.
<Module: Debuggable(True, False)> 

Module DemoModule
    Sub Main()
        ' Get the module type information to access its metadata.
        Dim modType As Type = GetType(DemoModule)
        ' See if the Debuggable attribute is defined.
        Dim isDef As Boolean = Attribute.IsDefined(modType.Module, _
                               GetType(DebuggableAttribute))
        Dim strDef As String
        If isDef = True Then
            strDef = "is"
        Else
            strDef = "is not"
        End If
        ' Display the result
        Console.WriteLine("The debuggable attribute {0} defined for " & _
                          "module {1}.", strDef, modType.Name)
        ' If the attribute is defined, display the JIT settings.
        If isDef = True Then
            ' Retrieve the attribute itself.
            Dim attr As Attribute = _
                Attribute.GetCustomAttribute(modType.Module, _
                GetType(DebuggableAttribute))
            If Not attr Is Nothing And TypeOf attr Is DebuggableAttribute Then
                Dim dbgAttr As DebuggableAttribute = _
                    CType(attr, DebuggableAttribute)
                Console.WriteLine("JITTrackingEnabled is {0}.", _
                    dbgAttr.IsJITTrackingEnabled.ToString())
                Console.WriteLine("JITOptimizerDisabled is {0}.", _
                    dbgAttr.IsJITOptimizerDisabled.ToString())
            Else
                Console.WriteLine("The Debuggable attribute could " & _
                                  "not be retrieved.")
            End If
        End If
    End Sub
End Module

' Output:
' The debuggable attribute is defined for module DemoModule.
' JITTrackingEnabled is True.
' JITOptimizerDisabled is False.
'</Snippet2>
