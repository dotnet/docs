' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
           
Module Example
   Public Sub Main()
      Dim serialized As Boolean = False
      Dim formatter As New BinaryFormatter()
      Dim values() As Double = { 3, 2, 1 }
      Dim divisor As Double = 0
      For Each value In values
         Try
            Dim ex As BadDivisionException = Nothing
            If divisor = 0 Then 
               If Not serialized Then
                  ' Instantiate the exception object.
                  ex = New BadDivisionException(0)
                  ' Serialize the exception object.
                  Dim fs As New FileStream("BadDivision1.dat", 
                                           FileMode.Create)
                  formatter.Serialize(fs, ex)
                  fs.Close()
                  Console.WriteLine("Serialized the exception...")
               Else
                  ' Deserialize the exception.
                  Dim fs As New FileStream("BadDivision1.dat",
                                           FileMode.Open)
                  ex = CType(formatter.Deserialize(fs), BadDivisionException)
                  ' Reserialize the exception.
                  fs.Position = 0
                  formatter.Serialize(fs, ex)
                  fs.Close()
                  Console.WriteLine("Reserialized the exception...")                                            
               End If   
              Throw ex 
            End If 
            Console.WriteLine("{0} / {1} = {1}", value, divisor, value/divisor)
         Catch e As BadDivisionException
            Console.WriteLine("Bad divisor from a {0} exception: {1}",
                              If(serialized, "deserialized", "new"), e.Divisor)             
            serialized = True
         End Try   
      Next
   End Sub
End Module

<Serializable> Public Class BadDivisionException : Inherits Exception
   ' Maintain an internal BadDivisionException state object.
   <NonSerialized> Private state As New BadDivisionExceptionState()

   Public Sub New(divisor As Double)
      state.Divisor = divisor
      HandleSerialization()      
   End Sub
   
   Private Sub HandleSerialization()
      AddHandler SerializeObjectState, 
                 Sub(exception As Object, eventArgs As SafeSerializationEventArgs)
                    eventArgs.AddSerializedState(state)
                 End Sub
   End Sub
   
   Public ReadOnly Property Divisor As Double
      Get
         Return state.Divisor
      End Get      
   End Property

   <Serializable> Private Structure BadDivisionExceptionState 
                                    Implements ISafeSerializationData
      private badDivisor As Double
      
      Public Property Divisor As Double
         Get
            Return badDivisor
         End Get
         Set
            badDivisor = value
         End Set
      End Property 

      Sub CompleteDeserialization(deserialized As Object) _
            Implements ISafeSerializationData.CompleteDeserialization
         Dim ex As BadDivisionException = TryCast(deserialized, BadDivisionException)
         ex.HandleSerialization()
         ex.state = Me 
      End Sub
   End Structure
End Class
' The example displays the following output:
'       Serialized the exception...
'       Bad divisor from a new exception: 0
'       Reserialized the exception...
'       Bad divisor from a deserialized exception: 0
'       Reserialized the exception...
'       Bad divisor from a deserialized exception: 0
' </Snippet1>

