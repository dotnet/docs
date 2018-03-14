'<Snippet1>
' Example for the Attribute.GetCustomAttribute( ParameterInfo, Type ) method.
Imports System
Imports System.Reflection
Imports Microsoft.VisualBasic

Namespace NDP_UE_VB

    '<Snippet2> 
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
           
        ' This is the Message property for the attribute.
        Public Property Message() As String
            Get
                Return usageMsg
            End Get
            Set
                usageMsg = value
            End Set
        End Property
    End Class ' ArgumentUsageAttribute 
    '</Snippet2>

    Public Class BaseClass
       
        ' Assign an ArgumentUsage attribute to the strArray parameter.
        ' Assign a ParamArray attribute to strList using the ParamArray keyword.
        Public Overridable Sub TestMethod( _
            <ArgumentUsage("Must pass an array here.")> _
            strArray() As String, _
            ParamArray strList() As String)
        End Sub ' TestMethod
    End Class ' BaseClass

    Public Class DerivedClass
        Inherits BaseClass
           
        ' Assign an ArgumentUsage attribute to the strList parameter.
        ' Assign a ParamArray attribute to strList using the ParamArray keyword.
        Public Overrides Sub TestMethod( _
            strArray() As String, _
            <ArgumentUsage("Can pass a parameter list or array here.")> _
            ParamArray strList() As String)
        End Sub ' TestMethod
    End Class ' DerivedClass

    Module CustomParamDemo
       
        Sub Main()
            Console.WriteLine( _
                "This example of Attribute.GetCustomAttribute" & _
                "( ParameterInfo, Type )" & vbCrLf & _
                "generates the following output.")
              
            ' Get the class type, and then get the MethodInfo object 
            ' for TestMethod to access its metadata.
            Dim clsType As Type = GetType(DerivedClass)
            Dim mInfo As MethodInfo = clsType.GetMethod("TestMethod")
              
            ' Iterate through the ParameterInfo array for the method parameters.
            Dim pInfoArray As ParameterInfo() = mInfo.GetParameters()
            If Not (pInfoArray Is Nothing) Then
                Dim paramInfo As ParameterInfo
                For Each paramInfo In  pInfoArray

                    ' See if the ParamArray attribute is defined.
                    Dim isDef As Boolean = _
                        Attribute.IsDefined(paramInfo, _
                            GetType(ParamArrayAttribute))

                    If isDef Then
                        Console.WriteLine( vbCrLf & _
                            "The ParamArray attribute is defined for " & _
                            vbCrLf & "parameter {0} of method {1}.", _
                            paramInfo.Name, mInfo.Name)
                    End If
                    
                    ' See if ParamUsageAttribute is defined.  
                    ' If so, display a message.
                    Dim usageAttr As ArgumentUsageAttribute = _
                        Attribute.GetCustomAttribute(paramInfo, _
                            GetType(ArgumentUsageAttribute))

                    If Not (usageAttr Is Nothing) Then
                        Console.WriteLine( vbCrLf & "The " & _
                            "ArgumentUsage attribute is defined for " & _
                            vbCrLf & "parameter {0} of method {1}.", _
                            paramInfo.Name, mInfo.Name)
                        Console.WriteLine( vbCrLf & _
                            "    The usage message for {0} is: " & _
                            vbCrLf & "    ""{1}"".", _
                            paramInfo.Name, usageAttr.Message)
                    End If
                Next paramInfo
            Else
                Console.WriteLine( _
                    "The parameters information could " & _
                    "not be retrieved for method {0}.", mInfo.Name)
            End If
        End Sub ' Main

    End Module ' DemoClass
End Namespace ' NDP_UE_VB

' This example of Attribute.GetCustomAttribute( ParameterInfo, Type )
' generates the following output.
' 
' The ArgumentUsage attribute is defined for
' parameter strArray of method TestMethod.
' 
'     The usage message for strArray is:
'     "Must pass an array here.".
' 
' The ParamArray attribute is defined for
' parameter strList of method TestMethod.
' 
' The ArgumentUsage attribute is defined for
' parameter strList of method TestMethod.
' 
'     The usage message for strList is:
'     "Can pass a parameter list or array here.".
'</Snippet1>