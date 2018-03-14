 '<snippet0>
Imports System
Imports System.Text
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.Serialization
Imports System.IO
Imports System.Security.Permissions


Class Program
    
    Shared Sub Main(ByVal args() As String) 
        Try
            SerializeAndDeserialize()
        Catch exc As System.Exception
            Console.WriteLine(exc.Message)
        Finally
            Console.WriteLine("Press <Enter> to exit....")
            Console.ReadLine()
        End Try
    
    End Sub 
    
    Shared Sub SerializeAndDeserialize() 
        Dim myObject As Object = DateTime.Now
        ' Create a StreamingContext that includes a
        ' a DateTime. 
        Dim sc As New StreamingContext(StreamingContextStates.CrossProcess, myObject)
        Dim bf As New BinaryFormatter(Nothing, sc)
        Dim ms As New MemoryStream(New Byte(2047) {})
        bf.Serialize(ms, New [MyClass]())
        ms.Seek(0, SeekOrigin.Begin)
        Dim f As [MyClass] = CType(bf.Deserialize(ms), [MyClass])
        Console.WriteLine(vbTab + " MinValue: {0} " + vbLf + vbTab + " MaxValue: {1}", f.MinValue, f.MaxValue)
        Console.WriteLine("StreamingContext.State: {0}", sc.State)
        
        Dim myDateTime As DateTime = CType(sc.Context, DateTime)
        Console.WriteLine("StreamingContext.Context: {0}", myDateTime.ToLongTimeString())
    
    End Sub 
End Class 

<Serializable(), SecurityPermission(SecurityAction.Demand, SerializationFormatter := True)>  _
Class [MyClass]
    Implements ISerializable
    Private minValue_value As Integer
    Private maxValue_value As Integer
    
    Public Sub New() 
        minValue_value = Integer.MinValue
        maxValue_value = Integer.MaxValue    
    End Sub     
    
    Public Property MinValue() As Integer 
        Get
            Return minValue_value
        End Get
        Set
            minValue_value = value
        End Set
    End Property 
    
    Public Property MaxValue() As Integer 
        Get
            Return maxValue_value
        End Get
        Set
            maxValue_value = value
        End Set
    End Property
     
    Sub GetObjectData(ByVal si As SerializationInfo, ByVal context As StreamingContext)  Implements ISerializable.GetObjectData
        si.AddValue("minValue", minValue_value)
        si.AddValue("maxValue", maxValue_value)
    
    End Sub   
    
    Protected Sub New(ByVal si As SerializationInfo, ByVal context As StreamingContext) 
        minValue_value = Fix(si.GetValue("minValue", GetType(Integer)))
        maxValue_value = Fix(si.GetValue("maxValue", GetType(Integer)))
    End Sub 
End Class 
'</snippet0>