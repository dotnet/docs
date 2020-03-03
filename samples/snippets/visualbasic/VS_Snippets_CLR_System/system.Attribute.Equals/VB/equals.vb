Imports System.Reflection

' Define a custom parameter attribute that takes a single message argument.
<AttributeUsage(AttributeTargets.Parameter)>  _
Public Class ArgumentUsageAttribute : Inherits Attribute
          
    ' This is the attribute constructor.
    Public Sub New(UsageMsg As String)
        Me.usageMsg = UsageMsg
    End Sub 

    ' usageMsg is storage for the attribute message.
    Protected usageMsg As String
           
    ' Append the message to what the base generates.
    Public Overrides Function ToString() As String
        Return $"{MyBase.ToString()}: {usageMsg}"
    End Function 
End Class 

' Define a custom parameter attribute that generates a GUID for each instance.
<AttributeUsage(AttributeTargets.Parameter)>  _
Public Class ArgumentIDAttribute : Inherits Attribute
           
    ' This is the attribute constructor, which generates the GUID.
    Public Sub New()
        Me.GUIDinstance = Guid.NewGuid()
    End Sub

    ' instanceGUID is storage for the generated GUID.
    Protected GUIDinstance As Guid
          
    ' Append the GUID to what the base generates.
    Public Overrides Function ToString() As String
        Return $"{MyBase.ToString()}.{ GUIDinstance}"
    End Function 
End Class

Public Class TestClass
    ' Assign an ArgumentID and an ArgumentUsage attribute to each parameter.
    Public Sub TestMethod( 
        <ArgumentID, ArgumentUsage("Must pass an array here.")> 
        strArray() As String, 
        <ArgumentID, ArgumentUsage("Can pass param list or array here.")> 
        ParamArray strList() As String)
    End Sub
End Class 
    
Module AttributeEqualsDemo
    Sub Main()
        ' Get the class type. 
        Dim clsType As Type = GetType(TestClass)
        ' Get the MethodInfo object for TestMethod to access its metadata.    
        Dim mInfo As MethodInfo = clsType.GetMethod("TestMethod")
                                                                                                                                   
       ' There will be two elements in pInfoArray, one for each parameter.
        Dim pInfoArray As ParameterInfo() = mInfo.GetParameters()
        If pInfoArray IsNot Nothing Then
            ' Create an instance of the argument usage attribute on strArray.
            Dim arrayUsageAttr1 As ArgumentUsageAttribute = 
                Attribute.GetCustomAttribute(pInfoArray(0), 
                    GetType(ArgumentUsageAttribute))
                 
            ' Create another instance of the argument usage attribute on strArray.
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
            Console.WriteLine($"   ""{arrayUsageAttr1}"" = {vbCrLf}" + 
                    $"   ""{arrayUsageAttr2}""? {arrayUsageAttr1.Equals(arrayUsageAttr2)}")  
                 
            Console.WriteLine(vbCrLf & _
                "Compare a usage attribute to another usage attribute:")
            Console.WriteLine($"   ""{arrayUsageAttr1}"" = {vbCrLf}" + 
                    $"   ""{listUsageAttr}""? {arrayUsageAttr1.Equals(listUsageAttr)}") 
                 
            Console.WriteLine(vbCrLf & "Compare an ID attribute instance " & _
                "to another instance of the same attribute:")
            Console.WriteLine($"   ""{arrayIDAttr1}"" = {vbCrLf}" +
                    $"   ""{arrayIDAttr2}""? {arrayIDAttr1.Equals(arrayIDAttr2)}")
                 
            Console.WriteLine(vbCrLf & _
                "Compare an ID attribute to another ID attribute:")
            Console.WriteLine($"   ""{arrayIDAttr1}"" ={vbCrLf}" + 
                    $"   ""{listIDAttr}"" ? {arrayIDAttr1.Equals(listIDAttr)}")
        Else
            Console.WriteLine("The parameters information could " & _
                "not be retrieved for method {0}.", mInfo.Name)
        End If
    End Sub 
End Module 
' The example displays the following output.
'     Compare a usage attribute instance to another instance of the same attribute:
'        "ArgumentUsageAttribute: Must pass an array here." =
'        "ArgumentUsageAttribute: Must pass an array here."? True
'     
'     Compare a usage attribute to another usage attribute:
'        "ArgumentUsageAttribute: Must pass an array here." =
'        "ArgumentUsageAttribute: Can pass param list or array here."? False
'     
'     Compare an ID attribute instance to another instance of the same attribute:
'        "ArgumentIDAttribute.d4f78468-f1d0-4a08-b6da-58cad249f8ea" =
'        "ArgumentIDAttribute.9b1151bd-9c87-4e9f-beb0-92375f8c24f7"? False
'     
'     Compare an ID attribute to another ID attribute:
'        "ArgumentIDAttribute.d4f78468-f1d0-4a08-b6da-58cad249f8ea" =
'        "ArgumentIDAttribute.7eba47d0-ff29-4e46-9740-e0ba05b39947"? False

