' <snippet1>
' Create a namespace that contains a class, named 
' SimpleDesigner, that extends the ControlDesigner class.
' The DataBinding and DataBindingCollection classes 
' are available only at design time, so manipulating their 
' methods and properties must occur at design time as well.
Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel
Imports System.Web.UI.Design
Imports System.IO
Imports System.Text
Imports System.Collections

Namespace DataBindingTest

    ' <snippet2>
    ' Create the custom class that accesses the DataBinding and
    ' DataBindingCollection classes at design time.

    Public Class SimpleDesigner
        Inherits System.Web.UI.Design.ControlDesigner
        ' <snippet3>
        ' Create a Text property with accessors that obtain 
        ' the property value from and set the property value
        ' to the Text key in the DataBindingCollection class.

        Public Property [Text]() As String
            Get
                Dim myBinding As DataBinding = DataBindings("Text")
                If Not (myBinding Is Nothing) Then
                    Return myBinding.Expression
                End If
                Return String.Empty
            End Get
            Set(ByVal value As String)

                If value Is Nothing OrElse value.Length = 0 Then
                    DataBindings.Remove("Text")
                Else

                    Dim binding As DataBinding = DataBindings("Text")

                    If binding Is Nothing Then
                        binding = New DataBinding("Text", GetType(String), value)
                    Else
                        binding.Expression = value
                    End If
                    ' Call the DataBinding constructor, then add
                    ' the initialized DataBinding object to the 
                    ' DataBindingCollection for this custom designer.
                    Dim binding1 As DataBinding = CType(DataBindings.SyncRoot, DataBinding)
                    DataBindings.Add(binding)
                    DataBindings.Add(binding1)
                End If
                PropertyChanged("Text")
            End Set
        End Property

        ' </Snippet3>
        Protected Sub PropertyChanged(ByVal propName As String)
            Dim myHtmlControlDesignBehavior As IControlDesignerTag = Me.Tag
            Dim myDataBindingCollection As DataBindingCollection
            Dim myDataBinding1, myDataBinding2 As DataBinding
            Dim myStringReplace1, myDataBindingExpression1, removedBinding, removedBindingAfterReplace, myDataBindingExpression2, myStringReplace2 As [String]
            Dim removedBindings1(), removedBindings2() As String
            Dim temp As Int32

            If myHtmlControlDesignBehavior Is Nothing Then
                Return
            End If

            myDataBindingCollection = DataBindings
            ' <Snippet4>
            ' Use the DataBindingCollection constructor to 
            ' create the myDataBindingCollection1 object.
            ' Then set this object equal to the
            ' DataBindings property of the control created
            ' by this custom designer.
            Dim myDataBindingCollection1 As New DataBindingCollection()
            myDataBindingCollection1 = DataBindings
            myDataBindingCollection = DataBindings
            ' </Snippet4>
            ' <Snippet7>
            If (myDataBindingCollection.Contains(propName)) Then
                myDataBinding1 = myDataBindingCollection(propName)
                myStringReplace1 = propName.Replace(".", "-")
                If myDataBinding1 Is Nothing Then
                    myHtmlControlDesignBehavior.RemoveAttribute(myStringReplace1)
                    Return
                End If
                ' DataBinding is not null.
                myDataBindingExpression1 = [String].Concat("<%#", myDataBinding1.Expression, "%>")
                myHtmlControlDesignBehavior.SetAttribute(myStringReplace1, myDataBindingExpression1)
                Dim index As Integer = myStringReplace1.IndexOf("-")
            Else
                ' <Snippet5>
                ' Use the DataBindingCollection.RemovedBindings 
                ' property to set the value of the removedBindings
                ' arrays.
                removedBindings1 = DataBindings.RemovedBindings
                removedBindings2 = DataBindings.RemovedBindings
                ' </Snippet5>
                temp = 0
                While removedBindings2.Length > temp
                    removedBinding = removedBindings2(temp)
                    removedBindingAfterReplace = removedBinding.Replace("."c, "-"c)
                    myHtmlControlDesignBehavior.RemoveAttribute(removedBindingAfterReplace)
                    temp = temp & 1
                End While
            End If
            ' </Snippet7>
            ' <Snippet6>
            ' Use the DataBindingCollection.GetEnumerator method
            ' to iterate through the myDataBindingCollection object
            ' and write the PropertyName, PropertyType, and Expression
            ' properties to a file for each DataBinding object
            ' in the MyDataBindingCollection object. 
            myDataBindingCollection = DataBindings
            Dim myEnumerator As IEnumerator = myDataBindingCollection.GetEnumerator()

            While myEnumerator.MoveNext()
                myDataBinding2 = CType(myEnumerator.Current, DataBinding)
                Dim dataBindingOutput1, dataBindingOutput2, dataBindingOutput3 As [String]
                dataBindingOutput1 = [String].Concat("The property name is ", myDataBinding2.PropertyName)
                dataBindingOutput2 = [String].Concat("The property type is ", myDataBinding2.PropertyType.ToString(), "-", dataBindingOutput1)
                dataBindingOutput3 = [String].Concat("The expression is ", myDataBinding2.Expression, "-", dataBindingOutput2)
                WriteToFile(dataBindingOutput3)

                myDataBindingExpression2 = [String].Concat("<%#", myDataBinding2.Expression, "%>")
                myStringReplace2 = myDataBinding2.PropertyName.Replace(".", "-")
                myHtmlControlDesignBehavior.SetAttribute(myStringReplace2, myDataBindingExpression2)
                Dim index As Integer = myStringReplace2.IndexOf("-"c)
            End While ' while loop ends
        End Sub 'OnBindingsCollectionChanged
        ' </snippet6>
        Public Sub WriteToFile(ByVal input As String)
            ' The WriteToFile custom method writes
            ' the values of the DataBinding properties
            ' to a file on the C drive at design time.
            Dim myFile As StreamWriter = File.AppendText("C:\DataBindingOutput.txt")
            Dim encoder As New ASCIIEncoding()
            Dim ByteArray As Byte() = encoder.GetBytes(input)
            Dim CharArray As Char() = encoder.GetChars(ByteArray)
            myFile.WriteLine(CharArray, 0, input.Length)
            myFile.Close()
        End Sub 'WriteToFile
    End Class 'SimpleDesigner
    ' </snippet2>
End Namespace 'DataBindingTest
' </snippet1>