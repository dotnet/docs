'<Snippet1>
' Example for the Attribute.TypeId property.
Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic

Namespace NDP_UE_VB

    ' Define a custom parameter attribute that takes a single message argument.
    <AttributeUsage(AttributeTargets.Parameter)>  _
    Public Class ArgumentUsageAttribute
        Inherits Attribute
           
        ' The constructor saves the message and creates a unique identifier.
        Public Sub New(UsageMsg As String)
            Me.usageMsg = UsageMsg
            Me.GUIDinstance = Guid.NewGuid()
        End Sub ' New

        ' This is storage for the attribute message and unique ID.
        Protected usageMsg As String
        Protected GUIDinstance As Guid
           
        ' This is the Message property for the attribute.
        Public Property Message() As String
            Get
                Return usageMsg
            End Get
            Set
                usageMsg = value
            End Set
        End Property 

        ' Override TypeId to provide a unique identifier for the instance.
        Public Overrides ReadOnly Property TypeId() As Object
            Get
                Return CType(GUIDinstance, Object)
            End Get
        End Property
            
        ' Override ToString() to append the message to what base the generates.
        Public Overrides Function ToString() As String
            Return MyBase.ToString() + ":" + usageMsg
        End Function ' ToString
    End Class ' ArgumentUsageAttribute

    Public Class TestClass
       
        ' Assign an ArgumentUsage attribute to each parameter.
        ' Assign a ParamArray attribute to strList.
        Public Sub TestMethod( _
            <ArgumentUsage("Must pass an array here.")> _
            strArray() As String, _
            <ArgumentUsage("Can pass a param list or array here.")> _
            ParamArray strList() As String)
        End Sub ' TestMethod
    End Class ' TestClass

    Module AttributeTypeIdDemo
       
        ' Create attributes from the derived class, 
        ' and then display the TypeId values.
        Sub ShowAttributeTypeIds()

            ' Get the class type, and then get the MethodInfo object 
            ' for TestMethod to access its metadata.
            Dim clsType As Type = GetType(TestClass)
            Dim mInfo As MethodInfo = clsType.GetMethod("TestMethod")
              
            ' There will be two elements in pInfoArray, one for each parameter.
            Dim pInfoArray As ParameterInfo() = mInfo.GetParameters()
            If Not (pInfoArray Is Nothing) Then

                ' Create an instance of the param array attribute on strList.
                Dim listArrayAttr As ParamArrayAttribute = _
                    Attribute.GetCustomAttribute(pInfoArray(1), _
                        GetType(ParamArrayAttribute))
                 
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
                 
                ' Display the attributes and corresponding TypeId values.
                Console.WriteLine(vbCrLf & """{0}"" " & vbCrLf & "TypeId: {1}", _
                    listArrayAttr.ToString(), listArrayAttr.TypeId)
                Console.WriteLine(vbCrLf & """{0}"" " & vbCrLf & "TypeId: {1}", _
                    arrayUsageAttr1.ToString(), arrayUsageAttr1.TypeId)
                Console.WriteLine(vbCrLf & """{0}"" " & vbCrLf & "TypeId: {1}", _
                    arrayUsageAttr2.ToString(), arrayUsageAttr2.TypeId)
                Console.WriteLine(vbCrLf & """{0}"" " & vbCrLf & "TypeId: {1}", _
                    listUsageAttr.ToString(), listUsageAttr.TypeId)
            Else
                Console.WriteLine("The parameters information could not " & _
                    "be retrieved for method {0}.", mInfo.Name)
            End If
        End Sub ' ShowAttributeTypeIds

        Sub Main()
            Console.WriteLine( _
                "This example of the Attribute.TypeId property" & _
                vbCrLf & "generates the following output.")
            Console.WriteLine( _
                vbCrLf & "Create instances from a derived Attribute " & _
                "class that implements TypeId, " & vbCrLf & "and then " & _
                "display the attributes and corresponding TypeId values:" )

            ShowAttributeTypeIds( )
        End Sub ' Main

    End Module ' AttributeTypeIdDemo
End Namespace ' NDP_UE_VB

' This example of the Attribute.TypeId property
' generates the following output.
' 
' Create instances from a derived Attribute class that implements TypeId,
' and then display the attributes and corresponding TypeId values:
' 
' "System.ParamArrayAttribute"
' TypeId: System.ParamArrayAttribute
' 
' "NDP_UE_VB.ArgumentUsageAttribute:Must pass an array here."
' TypeId: f312e528-3ff9-4587-9e6d-8108b62f2980
' 
' "NDP_UE_VB.ArgumentUsageAttribute:Must pass an array here."
' TypeId: 7b2cf0ec-b166-4557-a7ab-137a57c87226
' 
' "NDP_UE_VB.ArgumentUsageAttribute:Can pass a param list or array here."
' TypeId: 0b05f2a7-4a15-4d24-99f0-8503b238a18c
'</Snippet1>