 ' <snippet0>
Imports System
Imports System.EnterpriseServices
Imports System.Windows.Forms



<Assembly: ApplicationName("ObjectInspector")> 
<Assembly: ApplicationActivation(ActivationOption.Server)> 
<Assembly: System.Reflection.AssemblyKeyFile("Inspector.snk")> 
 
' <snippet1>
<JustInTimeActivation(), ObjectPooling(MinPoolSize := 2, MaxPoolSize := 100, CreationTimeout := 1000)>  _
Public Class ObjectInspector
    Inherits ServicedComponent
    
    
    ' <snippet2>
    Public Function IdentifyObject(ByVal obj As [Object]) As String 
        ' Return this object to the pool after use.
        ContextUtil.DeactivateOnReturn = True
        
        ' Get the supplied object's type.        
        Dim objType As Type = obj.GetType()
        
        ' Return its name.
        Return objType.FullName
    
    End Function 'IdentifyObject
    ' </snippet2>

    ' <snippet3>
    Protected Overrides Sub Activate() 
        MessageBox.Show(String.Format("Now entering..." + vbLf + "Application: {0}" + vbLf + "Instance: {1}" + vbLf + "Context: {2}" + vbLf, ContextUtil.ApplicationId.ToString(), ContextUtil.ApplicationInstanceId.ToString(), ContextUtil.ContextId.ToString()))
    
    End Sub 'Activate
    ' </snippet3>

    ' <snippet4>
    Protected Overrides Sub Deactivate() 
        MessageBox.Show("Bye Bye!")
    
    End Sub 'Deactivate
    ' </snippet4>

    ' <snippet5>
    ' This object can be pooled.
    Protected Overrides Function CanBePooled() As Boolean 
        Return True
    
    End Function 'CanBePooled
    ' </snippet5>

End Class 'ObjectInspector
' </snippet1>
' </snippet0>

Public Class Test

    Public Shared Sub Main()

    End Sub 'Main
End Class 'Test