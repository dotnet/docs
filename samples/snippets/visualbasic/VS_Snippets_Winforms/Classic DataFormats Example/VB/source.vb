' <Snippet1>
Option Explicit
Option Strict

Imports System
Imports System.Windows.Forms

Public Class MyClass1
    Inherits Form
    Private textBox1 As TextBox

    Public Sub MyClipboardMethod()
        ' Creates a new data format.
        Dim myFormat As DataFormats.Format = _
            DataFormats.GetFormat("myFormat")
        
        ' Creates a new object and store it in a DataObject using myFormat 
        ' as the type of format. 
        Dim myObject As New MyNewObject()
        Dim myDataObject As New DataObject(myFormat.Name, myObject)
        
        ' Copies myObject into the clipboard.
        Clipboard.SetDataObject(myDataObject)
        
        ' Performs some processing steps.
        ' Retrieves the data from the clipboard.
        Dim myRetrievedObject As IDataObject = Clipboard.GetDataObject()
        
        ' Converts the IDataObject type to MyNewObject type. 
        Dim myDereferencedObject As MyNewObject = _
            CType(myRetrievedObject.GetData(myFormat.Name), MyNewObject)
        
        ' Print the value of the Object in a textBox.
        textBox1.Text = myDereferencedObject.MyObjectValue
    End Sub 'MyClipboardMethod
End Class 'MyClass


' Creates a new type.
<Serializable()> Public Class MyNewObject
    Inherits Object
    Private myValue As String
    
    
    ' Creates a default constructor for the class.
    Public Sub New()
        myValue = "This is the value of the class"
    End Sub 'New
    
    ' Creates a property to retrieve or set the value.
    
    Public Property MyObjectValue() As String
        Get
            Return myValue
        End Get
        Set
            myValue = value
        End Set
    End Property
End Class 'MyNewObject

' </Snippet1>