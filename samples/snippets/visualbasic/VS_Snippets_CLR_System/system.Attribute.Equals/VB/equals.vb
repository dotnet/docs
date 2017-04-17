'<Snippet1>
' Example for the Attribute.Equals( Object ) method.
Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic

Namespace NDP_UE_VB

    ' Define a custom parameter attribute that takes a single message argument.
    <AttributeUsage(AttributeTargets.Parameter)>  _
    Public Class ArgumentUsageAttribute
        Inherits Attribute
           
        ' This is the attribute constructor.
        Public Sub New(UsageMsg As String)
            Me.usageMsg = UsageMsg
        End Sub ' New

        ' usageMsg is storage for the attribute message.
        Protected usageMsg As String
           
        ' Override ToString() to append the message to what the base generates.
        Public Overrides Function ToString() As String
            Return MyBase.ToString() + ":" + usageMsg
        End Function ' ToString
    End Class ' ArgumentUsageAttribute

    ' Define a custom parameter attribute that generates a GUID for each instance.
    <AttributeUsage(AttributeTargets.Parameter)>  _
    Public Class ArgumentIDAttribute
        Inherits Attribute
           
        ' This is the attribute constructor, which generates the GUID.
        Public Sub New()
            Me.GUIDinstance = Guid.NewGuid()
        End Sub ' New

        ' instanceGUID is storage for the generated GUID.
        Protected GUIDinstance As Guid
           
        ' Override ToString() to append the GUID to what the base generates.
        Public Overrides Function ToString() As String
            Return MyBase.ToString() + "." + GUIDinstance.ToString()
        End Function ' ToString
    End Class ' ArgumentIDAttribute

    Public Class TestClass
           
        ' Assign an ArgumentID attribute to each parameter.
        ' Assign an ArgumentUsage attribute to each parameter.
        Public Sub TestMethod( _
            <ArgumentID(), ArgumentUsage("Must pass an array here.")> _
            strArray() As String, _
            <ArgumentID(), ArgumentUsage("Can pass param list or array here.")> _
            ParamArray strList() As String)
        End Sub ' TestMethod
    End Class ' TestClass

    Module AttributeEqualsDemo
       
        ' Create Attribute objects and compare them.
        Sub CompareAttributes()

            ' Get the class type, and then get the MethodInfo object 
            ' for TestMethod to access its metadata.
            Dim clsType As Type = GetType(TestClass)
            Dim mInfo As MethodInfo = clsType.GetMethod("TestMethod")
              
            ' There will be two elements in pInfoArray, one for each parameter.
            Dim pInfoArray As ParameterInfo() = mInfo.GetParameters()
            If Not (pInfoArray Is Nothing) Then

                ' Create an instance of the argument usage attribute on strArray.
                Dim arrayUsageAttr1 As ArgumentUsageAttribute = _
                    Attribute.GetCustomAttribute(pInfoArray(0), _
                        GetType(ArgumentUsageAttribute))
                 
                ' Create another instance of the argument usage attribute 
                ' on strArray.
                Dim arrayUsageAttr2 As ArgumentUsageAttribute = _
                    Attribute.GetCustomAttribute(pInfoArray(0), _
                        GetType(ArgumentUsageAttribute))
                 
                ' Create an instance of the argument usage attribute on strList.
                Dim listUsageAttr As ArgumentUsageAttribute = _
                    Attribute.GetCustomAttribute(pInfoArray(1), _
                        GetType(ArgumentUsageAttribute))
                 
                ' Create an instance of the argument ID attribute on strArray.
                Dim arrayIDAttr1 As ArgumentIDAttribute = _
                    Attribute.GetCustomAttribute(pInfoArray(0), _
                        GetType(ArgumentIDAttribute))
                 
                ' Create another instance of the argument ID attribute on strArray.
                Dim arrayIDAttr2 As ArgumentIDAttribute = _
                    Attribute.GetCustomAttribute(pInfoArray(0), _
                        GetType(ArgumentIDAttribute))
                
                ' Create an instance of the argument ID attribute on strList.
                Dim listIDAttr As ArgumentIDAttribute = _
                    Attribute.GetCustomAttribute(pInfoArray(1), _
                        GetType(ArgumentIDAttribute))
                 
                ' Compare various pairs of attributes for equality.
                Console.WriteLine(vbCrLf & "Compare a usage attribute instance " & _
                    "to another instance of the same attribute:")
                Console.WriteLine("   ""{0}"" = " & vbCrLf & "   ""{1}"" ? {2}", _
                    arrayUsageAttr1.ToString(), arrayUsageAttr2.ToString(), _
                    arrayUsageAttr1.Equals(arrayUsageAttr2))
                 
                Console.WriteLine(vbCrLf & _
                    "Compare a usage attribute to another usage attribute:")
                Console.WriteLine("   ""{0}"" = " & vbCrLf & "   ""{1}"" ? {2}", _
                    arrayUsageAttr1.ToString(), listUsageAttr.ToString(), _
                    arrayUsageAttr1.Equals(listUsageAttr))
                 
                Console.WriteLine(vbCrLf & "Compare an ID attribute instance " & _
                    "to another instance of the same attribute:")
                Console.WriteLine("   ""{0}"" = " & vbCrLf & "   ""{1}"" ? {2}", _
                    arrayIDAttr1.ToString(), arrayIDAttr2.ToString(), _
                    arrayIDAttr1.Equals(arrayIDAttr2))
                 
                Console.WriteLine(vbCrLf & _
                    "Compare an ID attribute to another ID attribute:")
                Console.WriteLine("   ""{0}"" = " & vbCrLf & "   ""{1}"" ? {2}", _
                    arrayIDAttr1.ToString(), listIDAttr.ToString(), _
                    arrayIDAttr1.Equals(listIDAttr))
            Else
                Console.WriteLine("The parameters information could " & _
                    "not be retrieved for method {0}.", mInfo.Name)
            End If
        End Sub ' CompareAttributes

        Sub Main()
            Console.WriteLine("This example of Attribute.Equals( Object ) " & _
                "generates the following output." )

            CompareAttributes( )
              
        End Sub ' Main
    End Module ' AttributeEqualsDemo
End Namespace ' NDP_UE_VB

' This example of Attribute.Equals( Object ) generates the following output.
' 
' Compare a usage attribute instance to another instance of the same attribute:
'    "NDP_UE_VB.ArgumentUsageAttribute:Must pass an array here." =
'    "NDP_UE_VB.ArgumentUsageAttribute:Must pass an array here." ? True
' 
' Compare a usage attribute to another usage attribute:
'    "NDP_UE_VB.ArgumentUsageAttribute:Must pass an array here." =
'    "NDP_UE_VB.ArgumentUsageAttribute:Can pass param list or array here." ? False
' 
' Compare an ID attribute instance to another instance of the same attribute:
'    "NDP_UE_VB.ArgumentIDAttribute.aa2c2346-ca87-40d6-afb7-5e3bc1637351" =
'    "NDP_UE_VB.ArgumentIDAttribute.4192c26c-9a7b-4a74-97fc-6c3dfbc2cdfe" ? False
' 
' Compare an ID attribute to another ID attribute:
'    "NDP_UE_VB.ArgumentIDAttribute.aa2c2346-ca87-40d6-afb7-5e3bc1637351" =
'    "NDP_UE_VB.ArgumentIDAttribute.237a7337-15f1-469b-a5ce-7503def917b2" ? False
'</Snippet1>