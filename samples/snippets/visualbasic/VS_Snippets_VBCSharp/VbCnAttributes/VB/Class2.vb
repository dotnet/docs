' <snippet27>
Imports System.Attribute
' </snippet27>

'  Class Class253a32d815314504b687088554ab71d2
' Global Attributes in Visual Basic


' <snippet11>
'Set version number for assembly.
<Assembly: Reflection.AssemblyVersionAttribute("4.3.2.1")> 
'Set culture as German.
<Assembly: Reflection.AssemblyCultureAttribute("de")> 
' </snippet11>


' <snippet12>
<Assembly: Reflection.AssemblyKeyFile("myKey.snk")> 
<Assembly: Reflection.AssemblyDelaySign(True)> 
' </snippet12>

'End Class
Class Class039609c4ec434f44945faa3b5b535c6a
    ' How to: Define Your Own Attributes

    ' <snippet1>
    <AttributeUsage(AttributeTargets.All)> Class TestAttribute
        ' </snippet1>
        ' <snippet2>
        Inherits System.Attribute
        ' </snippet2>


        ' <snippet3>
        Private m_SomeValue As String
        ' </snippet3>


        ' <snippet4>
        Public Sub New(ByVal Value As String)
            m_SomeValue = Value
        End Sub
        ' </snippet4>

        ' <snippet5>
        Public Sub Attr(ByVal AttrValue As String)
            'Add method code here.
        End Sub
        Public Property SomeValue() As String  ' A named parameter.
            Get
                Return m_SomeValue
            End Get
            Set(ByVal Value As String)
                m_SomeValue = Value
            End Set
        End Property
        ' </snippet5>

        ' <snippet6>
    End Class
    ' </snippet6>
End Class

Class Class0bedc36e7a024b22ac006570e17bef6e
    ' How to: Apply Multiple Attributes

    ' <snippet7>
    <System.ComponentModel.EditorBrowsable(
        System.ComponentModel.EditorBrowsableState.Never),
    Obsolete("This method should not be used.")>
    Public Shadows Function Update(ByVal x As Integer) As Integer
        ' The function code goes here.
    End Function
    ' </snippet7>

End Class

Class Class222313188a4049af9245e0aab723563b
    ' Attributes Used in Visual Basic

    ' <snippet8>
    Structure Worker
        ' The runtime uses VBFixedString to determine 
        ' if the field should be written out as a fixed size.
        <VBFixedString(10)> Public LastName As String
        <VBFixedString(7)> Public Title As String
        <VBFixedString(2)> Public Rank As String
    End Structure
    ' </snippet8>

End Class


Public Class Class5c2f0835921047dcbc595c1769953574
    ' ComClassAttribute Class

    ' <snippet21>
    <ComClass(ComClass1.ClassId, ComClass1.InterfaceId, ComClass1.EventsId)>
    Public Class ComClass1
        ' Use the Region directive to define a section named COM Guids. 
#Region "COM GUIDs"
        ' These  GUIDs provide the COM identity for this class 
        ' and its COM interfaces. You can generate 
        ' these guids using guidgen.exe
        Public Const ClassId As String = "7666AC25-855F-4534-BC55-27BF09D49D46"
        Public Const InterfaceId As String = "54388137-8A76-491e-AA3A-853E23AC1217"
        Public Const EventsId As String = "EA329A13-16A0-478d-B41F-47583A761FF2"
#End Region

        Public Sub New()
            MyBase.New()
        End Sub

        Function AddNumbers(ByVal X As Integer, ByVal Y As Integer)
            AddNumbers = X + Y
        End Function
    End Class
    ' </snippet21>

End Class

Class Class7b7e9ef628544114892ee7ae45dd0b49
    ' VBFixedArrayAttribute Class

    ' <snippet22>
    Structure Book
        <VBFixedArray(4)> Public Chapter() As Integer
    End Structure

    Sub WriteData()
        Dim FileNum As Integer = FreeFile()
        Dim MyBook As Book
        ReDim MyBook.Chapter(4)
        ' Add code to populate the array.
        MyBook.Chapter(0) = 1
        MyBook.Chapter(1) = 2
        MyBook.Chapter(2) = 3
        MyBook.Chapter(3) = 4
        MyBook.Chapter(4) = 5
        ' Write the array to a file.
        FileOpen(FileNum, "C:\testfile", OpenMode.Binary,
                 OpenAccess.Write, OpenShare.Default)
        FilePut(FileNum, MyBook) ' Write data.
        FileClose(FileNum)
    End Sub
    ' </snippet22>

End Class

Class Class811562f1a80841639a7e9aa383d0e679
    ' VBFixedStringAttribute Class

    ' <snippet23>
    Structure Person
        Public ID As Integer
        Public MonthlySalary As Decimal
        Public LastReviewDate As Long
        <VBFixedString(15)> Public FirstName As String
        <VBFixedString(15)> Public LastName As String
        <VBFixedString(15)> Public Title As String
        <VBFixedString(150)> Public ReviewComments As String
    End Structure
    ' </snippet23>

End Class

Class Classb302731759d24366b63ebdd35ebf4efe
    ' Examples of Custom Attribute Usage

    ' <snippet24>
    <AttributeUsage(AttributeTargets.Class)> Public Class CustomAttribute
        Inherits System.Attribute

        'Declare two private fields to store the property values.
        Private m_LlabelValue As String
        Private m_VValueValue As Integer

        'The Sub New constructor is the only way to set the properties.
        Public Sub New(ByVal _Label As String, ByVal _Value As Integer)
            m_LlabelValue = _Label
            m_VValueValue = _Value
        End Sub

        Public ReadOnly Property Label() As String
            Get
                Return m_LlabelValue
            End Get
        End Property

        Public ReadOnly Property Value() As Integer
            Get
                Return m_VValueValue
            End Get
        End Property
    End Class
    ' </snippet24>

    ' <snippet25>
    ' Apply the custom attribute to this class.
    <Custom("Some metadata", 66)> Class ThisClass
        ' Add class members here.
    End Class
    ' </snippet25>

End Class

'Class Classcec6e4645e22426c89d91ad12cc7eb09
' HideModuleNameAttribute Class

' <snippet26>
Namespace My
    <HideModuleName()> Module CustomMyDatabase
        Public ReadOnly Property Database() As MyDatabase
            Get
                Return databaseValue
            End Get
        End Property
        Private ReadOnly databaseValue As MyDatabase = New MyDatabase
    End Module
End Namespace

Class MyDatabase
    ' The members of the My.Database object go here.
End Class
' </snippet26>


Class Classd404ed869d404982bd874863a4c9fdf6
    ' How to: Retrieve Custom Attributes


    ' <snippet28>
    Sub RetrieveAttribute()

    End Sub
    ' </snippet28>

    Sub RetrieveAttributeTest()
        ' <snippet29>
        Dim Attr As Attribute
        Dim CustAttr As CustomAttribute
        ' </snippet29>

        ' <snippet30>
        Attr = GetCustomAttribute(Me.GetType,
                                  GetType(CustomAttribute), False)
        ' </snippet30>

        ' <snippet31>
        CustAttr = CType(Attr, CustomAttribute)
        ' </snippet31>

        ' <snippet32>
        If CustAttr Is Nothing Then
            MsgBox("The attribute was not found.")
        Else
            'Get the label and value from the custom attribute.
            MsgBox("The attribute label is: " & CustAttr.Label)
            MsgBox("The attribute value is: " & CustAttr.Value)
        End If
        ' </snippet32>
    End Sub


    Private Class CustomAttribute
        Inherits System.Attribute
        Public Sub New(Optional ByVal Update As Boolean = True, Optional ByVal Keep As Boolean = True)
        End Sub
        Public Property Label() As Boolean
            Get
            End Get
            Set(ByVal Value As Boolean)
            End Set
        End Property
        Public Property Value() As Boolean
            Get
            End Get
            Set(ByVal Value As Boolean)
            End Set
        End Property
    End Class

End Class

Class Classd72d8a5c8f644614b15bcad66845d047
    ' Custom Attributes in Visual Basic

    ' <snippet33>
    <AttributeUsage(AttributeTargets.All, Inherited:=True, AllowMultiple:=False)>
    Class TestAttribute1
        Inherits Attribute
    End Class
    ' </snippet33>

    ' <snippet34>
    <AttributeUsage(AttributeTargets.Class Or AttributeTargets.Method)>
    Class TestAttribute2
        Inherits Attribute
    End Class
    ' </snippet34>

End Class


