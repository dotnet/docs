' <snippet1>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Text

' The SerializeReadOnlyPropertyDescriptor shows how to implement a 
' custom property descriptor. It provides a read-only wrapper 
' around the specified PropertyDescriptor. 
Friend NotInheritable Class SerializeReadOnlyPropertyDescriptor
    Inherits PropertyDescriptor
    Private _pd As PropertyDescriptor = Nothing


    Public Sub New(ByVal pd As PropertyDescriptor)
        MyBase.New(pd)
        Me._pd = pd

    End Sub


    Public Overrides ReadOnly Property Attributes() As AttributeCollection
        Get
            Return AppendAttributeCollection(Me._pd.Attributes, ReadOnlyAttribute.Yes)
        End Get
    End Property


    Protected Overrides Sub FillAttributes(ByVal attributeList As IList)
        attributeList.Add(ReadOnlyAttribute.Yes)

    End Sub


    Public Overrides ReadOnly Property ComponentType() As Type
        Get
            Return Me._pd.ComponentType
        End Get
    End Property


    ' The type converter for this property.
    ' A translator can overwrite with its own converter.
    Public Overrides ReadOnly Property Converter() As TypeConverter
        Get
            Return Me._pd.Converter
        End Get
    End Property


    ' Returns the property editor 
    ' A translator can overwrite with its own editor.
    Public Overrides Function GetEditor(ByVal editorBaseType As Type) As Object
        Return Me._pd.GetEditor(editorBaseType)

    End Function

    ' Specifies the property is read only.
    Public Overrides ReadOnly Property IsReadOnly() As Boolean
        Get
            Return True
        End Get
    End Property


    Public Overrides ReadOnly Property PropertyType() As Type
        Get
            Return Me._pd.PropertyType
        End Get
    End Property


    Public Overrides Function CanResetValue(ByVal component As Object) As Boolean
        Return Me._pd.CanResetValue(component)

    End Function


    Public Overrides Function GetValue(ByVal component As Object) As Object
        Return Me._pd.GetValue(component)

    End Function


    Public Overrides Sub ResetValue(ByVal component As Object)
        Me._pd.ResetValue(component)

    End Sub


    Public Overrides Sub SetValue(ByVal component As Object, ByVal val As Object)
        Me._pd.SetValue(component, val)

    End Sub

    ' Determines whether a value should be serialized.
    Public Overrides Function ShouldSerializeValue(ByVal component As Object) As Boolean
        Dim result As Boolean = Me._pd.ShouldSerializeValue(component)

        If Not result Then
            Dim dva As DefaultValueAttribute = _
                CType(_pd.Attributes(GetType(DefaultValueAttribute)), DefaultValueAttribute)
            If Not (dva Is Nothing) Then
                result = Not [Object].Equals(Me._pd.GetValue(component), dva.Value)
            Else
                result = True
            End If
        End If

        Return result

    End Function


    ' The following Utility methods create a new AttributeCollection
    ' by appending the specified attributes to an existing collection.
    Public Shared Function AppendAttributeCollection( _
        ByVal existing As AttributeCollection, _
        ByVal ParamArray newAttrs() As Attribute) As AttributeCollection

        Return New AttributeCollection(AppendAttributes(existing, newAttrs))

    End Function

    Public Shared Function AppendAttributes( _
        ByVal existing As AttributeCollection, _
        ByVal ParamArray newAttrs() As Attribute) As Attribute()

        If existing Is Nothing Then
            Throw New ArgumentNullException("existing")
        End If

        If newAttrs Is Nothing Then
            newAttrs = New Attribute(-1) {}
        End If

        Dim attributes() As Attribute

        Dim newArray(existing.Count + newAttrs.Length) As Attribute
        Dim actualCount As Integer = existing.Count
        existing.CopyTo(newArray, 0)

        Dim idx As Integer
        For idx = 0 To newAttrs.Length
            If newAttrs(idx) Is Nothing Then
                Throw New ArgumentNullException("newAttrs")
            End If

            ' Check if this attribute is already in the existing
            ' array.  If it is, replace it.
            Dim match As Boolean = False
            Dim existingIdx As Integer
            For existingIdx = 0 To existing.Count
                If newArray(existingIdx).TypeId.Equals(newAttrs(idx).TypeId) Then
                    match = True
                    newArray(existingIdx) = newAttrs(idx)
                    Exit For
                End If
            Next existingIdx

            If Not match Then
                actualCount += 1
                newArray(actualCount) = newAttrs(idx)
            End If
        Next idx

        ' If some attributes were collapsed, create a new array.
        If actualCount < newArray.Length Then
            attributes = New Attribute(actualCount) {}
            Array.Copy(newArray, 0, attributes, 0, actualCount)
        Else
            attributes = newArray
        End If

        Return attributes

    End Function
End Class
' </snippet1>