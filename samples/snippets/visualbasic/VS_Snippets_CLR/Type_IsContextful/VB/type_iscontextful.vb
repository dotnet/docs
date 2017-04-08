' <Snippet1>
Imports System.Runtime.Remoting.Contexts

Public Class ContextBoundClass : Inherits ContextBoundObject
    Public Value As String = "The Value property."
End Class

Public Class Example
    Public Shared Sub Main()
         ' Determine whether the types can be hosted in a Context.
         Console.WriteLine("The IsContextful property for the {0} type is {1}.",
                           GetType(Example).Name, GetType(Example).IsContextful)
         Console.WriteLine("The IsContextful property for the {0} type is {1}.",
                           GetType(ContextBoundClass).Name, GetType(ContextBoundClass).IsContextful)
         ' Determine whether the types are marshalled by reference.
         Console.WriteLine("The IsMarshalByRef property of {0} is {1}.",
                           GetType(Example).Name, GetType(Example).IsMarshalByRef)
         Console.WriteLine("The IsMarshalByRef property of {0} is {1}.",
                           GetType(ContextBoundClass).Name, GetType(ContextBoundClass).IsMarshalByRef)
         ' Determine whether the types are primitive datatypes.
         Console.WriteLine("{0} is a primitive data type: {1}.",
                           GetType(Integer).Name, GetType(Integer).IsPrimitive)
         Console.WriteLine("{0} is a primitive data type: {1}.",
                           GetType(String).Name, GetType(String).IsPrimitive)
    End Sub
End Class
' The example displays the following output:
'    The IsContextful property for the Example type is False.
'    The IsContextful property for the ContextBoundClass type is True.
'    The IsMarshalByRef property of Example is False.
'    The IsMarshalByRef property of ContextBoundClass is True.
'    Int32 is a primitive data type: True.
'    String is a primitive data type: False.
' </Snippet1>