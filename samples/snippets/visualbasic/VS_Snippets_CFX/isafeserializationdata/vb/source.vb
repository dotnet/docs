'<snippet1>
Imports System
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.Serialization
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Soap
Imports System.Security
' Imports System.Security.Permissions

'[assembly: SecurityCritical(SecurityCriticalScope.Everything)] 
' Using the SecurityCriticalAttribute prohibits usage of the 
' ISafeSerializationData interface.
<Assembly: AllowPartiallyTrustedCallers()> 
Namespace ISafeSerializationDataExample

    Class SerializationDemo

        Shared Sub Main()
            ' This code forces a division by 0 and catches the 
            ' resulting exception.
            Try

                Dim zero As Integer = 0
                Dim ecks As Integer = 1 / zero

            Catch ex As Exception

                ' Create a new exception to throw again.
                Dim newExcept As New NewException("Divided by.", 0)

                Console.WriteLine(
                    "Forced a division by 0, caught the resulting exception, \n" & _
                    "and created a derived exception with custom data:\n")
                Console.WriteLine("StringData: {0}", newExcept.StringData)
                Console.WriteLine("intData:   {0}", newExcept.IntData)

                ' This FileStream is used for the serialization.
                Dim fs As New FileStream("NewException.dat", _
                                         FileMode.Create)

                Try
                    ' Serialize the derived exception.
                    Dim Formatter As New BinaryFormatter()
                    Formatter.Serialize(fs, newExcept)

                    ' Rewind the stream and deserialize the exception.
                    fs.Position = 0
                    Dim deserExcept As NewException = _
                    CType(Formatter.Deserialize(fs), NewException)

                Catch se As SerializationException
                    Console.WriteLine("Failed to serialize: {0}", _
                                      se.ToString())

                Catch NewEx As NewException
                    Console.WriteLine("StringData: {0}", _
                                      NewEx.StringData)
                    Console.WriteLine("IntData:   {0}", _
                                      NewEx.IntData)

                Finally
                    fs.Close()
                    Console.ReadLine()

                End Try
            End Try
        End Sub
    End Class

    <Serializable()> Public Class NewException
        Inherits Exception
        <NonSerialized()> Private m_state As NewExceptionState = New NewExceptionState()


        Public Sub New(ByVal stringData As String, ByVal intData As Integer)

            ' Instance data is stored directly in the exception 
            ' state(Object.
            m_state.StringData = stringData
            m_state.IntData = intData

            ' In response to SerializeObjectState, we need to provide 
            ' any state to serialize with the exception. In this 
            ' case, since our state is already stored in an
            ' ISafeSerializationData implementation, we can
            ' just provide that.

            ' An alternate implementation would be to store the state 
            ' as local member variables, and in response to this 
            ' method create a new instance of an ISafeSerializationData
            ' object and populate it with the local state here before 
            ' passing it through to AddSerializedState.

            AddHandler SerializeObjectState, _
                Sub(exception As Object, _
                    eventArgs As SafeSerializationEventArgs)
                    eventArgs.AddSerializedState(m_state)
                End Sub
        End Sub

        ' Because we don't want the exception state to be serialized 
        ' normally, we take care of that in the constructor.

        ' Data access is through the state object, rather than locally.
        Public Property StringData As String

            Get
                Return m_state.StringData
            End Get
            Set(ByVal value As String)
                m_state.StringData = value
            End Set
        End Property


        Public Property IntData As Integer

            Get
                Return m_state.IntData
            End Get
            Set(ByVal value As Integer)
                m_state.IntData = value
            End Set
        End Property


        'There is no need to supply a deserialization constructor 
        '(with SerializationInfo and StreamingContext parameters), 
        'and no need to supply a GetObjectData implementation.
        'Implement the ISafeSerializationData interface to serialize
        'custom exception data in a partially trusted assembly. 
        'Use this interface to replace the Exception.GetObjectData 
        'method, which is now marked with the SecurityCriticalAttribute.

        <Serializable()> Private Structure NewExceptionState
            Implements ISafeSerializationData
            Private m_stringData As String
            Private m_intData As Integer
            '<snippet2>
            ' This method is called when deserialization of the 
            ' exception is complete.
            Sub CompleteDeserialization(ByVal obj As Object) _
                Implements ISafeSerializationData.CompleteDeserialization

                ' Since the exception simply contains an instance 
                ' of the exception state object, we can repopulate it 
                ' here by just setting its instance field
                ' to be equal to this deserialized state instance.
                Dim exception As NewException = _
                    CType(obj, NewException)
                exception.m_state = Me
            End Sub
            '</snippet2>

            Public Property StringData As String
                Get
                    Return m_stringData
                End Get
                Set(ByVal value As String)
                    m_stringData = value
                End Set
            End Property

            Public Property IntData As Integer
                Get
                    Return m_intData
                End Get

                Set(ByVal value As Integer)
                    m_intData = value
                End Set
            End Property
        End Structure
    End Class
End Namespace

'</snippet1>