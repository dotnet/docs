' System.Web.UI.DataBinding.Expression
' System.Web.UI.DataBindingCollection.Remove(string)
' System.Web.UI.DataBindingCollection.Item
' System.Web.UI.DataBinding.DataBinding
' System.Web.UI.DataBinding.Expression
' System.Web.UI.DataBindingCollection.SyncRoot
' System.Web.UI.DataBindingCollection.Add(DataBinding)
' System.Web.UI.DataBindingCollection.DataBindingCollection
' System.Web.UI.DataBindingCollection.RemovedBindings
' System.Web.UI.DataBindingCollection.GetEnumerator
' System.Web.UI.DataBinding.PropertyName
' System.Web.UI.DataBinding.PropertyType
' System.Web.UI.DataBindingCollection.Count
' System.Web.UI.DataBindingCollection.IsReadOnly
' System.Web.UI.DataBindingCollection.IsSynchronized
' System.Web.UI.DataBindingCollection.CopyTo
' System.Web.UI.DataBindingCollection.GetHashCode
' System.Web.UI.DataBindingCollection.Remove(DataBinding)
' System.Web.UI.DataBindingCollection.Remove(string,true)
' System.Web.UI.DataBindingCollection.Clear()
' System.Web.UI.DataBindingHandlerAttribute
' System.Web.UI.DataBindingHandlerAttribute.IsDefaultAttribute().


'  The following example demonstrates the  members of 'DataBinding' and
' 'DataBindingCollection'.A new control 'SimpleWebControl'  is created
'  and a 'Designer' attribute is attached to it which actually refers to the
'  DesignTimeClass.The 'OnBindingsCollectionChanged(string)' method  is overridden
'  to actually capture the DataBindingCollection instance and add the
'  DataBinding Expression to the property in the ASPX file. When 'Text' property of the
'  SimpleWebControl is bound to the 'Text' property of 'Button1' at the DesignTime
'  using the IDE, the 'OnBindingCollectionChanged' method is called and
'  the 'Text' property of the 'SimpleWebControl' is updated in .aspx file.
'  The actual DataBinding is done at the runtime.The  properties of the 'DataBinding'
'  and 'DataBindingCollection' are written into a text file (DataBindingOutput.txt)
'  in drive C.The Output is written at the design time itself.

'Note:This program has to be tested at "DesignTime".
'These are the instructions to be followed to successfully test the functionality of the program.
'  1)Create a new "VB WebApplication" project.
'  2)Add Reference "System.Design.dll" to the project.
'  3)Add the 'DataBinding.aspx' and 'WebCustomControl1.cs' files to the project,
'  which are provided with this example.'
'  4)In the 'DataBinding.aspx' file, make the assembly name same as the
'     "Project Name", created in step1.
'  5)Build the project.
'  6)Go to the "DesignTab" of the 'DataBinding.aspx' file.
'  7)Go to the properties window of the SimpleWebcontrol, built in Step5.
'  8)Go to the DataBindings column.
'  9)Select the "Text" property.
'  10)Select the "CustomBindingExpression" option.
'  11)Associate the Text property to any property of any control which is of the
'     type string.
'  12)Observe in "C:\" a file created with the name "DataBindingOutput.txt".
'     This file contains the properties of 'DataBinding' and 'DataBindingCollection' 
'     classes demonstrated.

Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.ComponentModel
Imports System.Web.UI.Design
Imports System.IO
Imports System.Text
Imports System.Collections


Namespace DataBindingTest



   Public Class SimpleDesigner
      Inherits System.Web.UI.Design.ControlDesigner
      'The DesigneTime manipulation is done by this class.

      Public Property Text() As String
         Get
'<Snippet1>
            Dim myBinding As DataBinding = DataBindings("Text")
            If Not (myBinding Is Nothing) Then
               Return myBinding.Expression
            End If
            Return [String].Empty
         End Get
'</Snippet1>
         Set(ByVal Value As String)
'<Snippet2>
            If Value Is Nothing Or Value.Length = 0 Then
               DataBindings.Remove("Text")
'</Snippet2>
            Else
'<Snippet3>
               Dim binding As DataBinding = DataBindings("Text")
'</Snippet3>
'<Snippet4>
               If binding Is Nothing Then
                  binding = New DataBinding("Text", GetType(String), Value)
'</Snippet4>
'<Snippet5>
               Else
                  binding.Expression = Value
               End If
'</Snippet5>
'<Snippet7>
'<Snippet6>
               Dim binding1 As DataBinding = CType(DataBindings.SyncRoot, DataBinding)
               DataBindings.Add(binding)
               DataBindings.Add(binding1)
            End If
'</Snippet6>
'</Snippet7>
            OnBindingsCollectionChanged("Text")
         End Set
      End Property


      Protected Overrides Sub OnBindingsCollectionChanged(ByVal propName As String)
         'This method actually forms an DataBindingExpression of the design time and associates it to the Property of the Control.
         Dim myHtmlControlDesignBehavior As IHtmlControlDesignerBehavior = Behavior
         Dim myDataBindingCollection As DataBindingCollection
         Dim myDataBinding1, myDataBinding2 As DataBinding
         Dim myStringReplace1, myDataBindingExpression1, removedBinding, removedBindingAfterReplace, myDataBindingExpression2, myStringReplace2 As String
         Dim removedBindings1(), removedBindings2() As String
         Dim temp As Int32
         Dim myEnumerator As IEnumerator

         If myHtmlControlDesignBehavior Is Nothing Then
            Return
         End If
'<Snippet8>
         Dim myDataBindingCollection1 As New DataBindingCollection()

         myDataBindingCollection1 = DataBindings
         myDataBindingCollection = DataBindings

'</Snippet8>
         If Not (propName Is Nothing) Then
            myDataBinding1 = myDataBindingCollection(propName)
            myStringReplace1 = propName.Replace(".", "-")
            If myDataBinding1 Is Nothing Then
               myHtmlControlDesignBehavior.RemoveAttribute(myStringReplace1, True)
               Return
            End If
            ' DataBinding is not null.
            myDataBindingExpression1 = [String].Concat("<%#", myDataBinding1.Expression, "%>")
            myHtmlControlDesignBehavior.SetAttribute(myStringReplace1, myDataBindingExpression1, True)
            Dim index As Integer = myStringReplace1.IndexOf("-")
         Else
'<Snippet9>

            removedBindings1 = DataBindings.RemovedBindings
            removedBindings2 = DataBindings.RemovedBindings

'</Snippet9>
            temp = 0
            While removedBindings2.Length > temp
               removedBinding = removedBindings2(temp)
               removedBindingAfterReplace = removedBinding.Replace("."c, "-"c)
               myHtmlControlDesignBehavior.RemoveAttribute(removedBindingAfterReplace, True)
               temp = temp + 1
            End While
'<Snippet10>
            myDataBindingCollection = DataBindings
            myEnumerator = myDataBindingCollection.GetEnumerator()
            While myEnumerator.MoveNext()

'<Snippet11>
'<Snippet12>
               myDataBinding2 = CType(myEnumerator.Current, DataBinding)
               Dim dataBindingOutput1, dataBindingOutput2, dataBindingOutput3 As [String]
               dataBindingOutput1 = [String].Concat("The property name is ", myDataBinding2.PropertyName)
               dataBindingOutput2 = [String].Concat("The property type is ", myDataBinding2.PropertyType.ToString(), "-", dataBindingOutput1)
               dataBindingOutput3 = [String].Concat("The expression is ", myDataBinding2.Expression, "-", dataBindingOutput2)
               WriteToFile(dataBindingOutput3)
'</Snippet12>
'</Snippet11>

               myDataBindingExpression2 = [String].Concat("<%#", myDataBinding2.Expression, "%>")
               myStringReplace2 = myDataBinding2.PropertyName.Replace(".", "-")
               myHtmlControlDesignBehavior.SetAttribute(myStringReplace2, myDataBindingExpression2, True)
               Dim index As Integer = myStringReplace2.IndexOf("-"c)
            End While ' while loop ends
'</Snippet10>
'<Snippet13>
'<Snippet14>
'<Snippet15>
            Dim dataBindingOutput4, dataBindingOutput5, dataBindingOutput6, dataBindingOutput7, dataBindingOutput8 As String
            dataBindingOutput4 = [String].Concat("The Count of the collection is ", myDataBindingCollection1.Count)
            dataBindingOutput5 = [String].Concat("The IsSynchronised property of the collection is ", myDataBindingCollection1.IsSynchronized, "-", dataBindingOutput4)
            dataBindingOutput6 = [String].Concat("The IsReadOnly property of the collection is ", myDataBindingCollection1.IsReadOnly, "-", dataBindingOutput5)
            WriteToFile(dataBindingOutput6)
'</Snippet15>
'</Snippet14>
'</Snippet13>
'<Snippet16>
            Dim dataBindingCollectionArray As System.Array = Array.CreateInstance(GetType(Object), myDataBindingCollection1.Count)
            myDataBindingCollection1.CopyTo(dataBindingCollectionArray, 0)

            dataBindingOutput7 = [String].Concat("The count of DataBindingArray is  ", dataBindingCollectionArray.Length)

            WriteToFile(dataBindingOutput7)
            '</Snippet16>
            Dim myEnumerator1 As IEnumerator = myDataBindingCollection1.GetEnumerator()
            If myEnumerator1.MoveNext() Then
               '<Snippet17>
               myDataBinding1 = CType(myEnumerator1.Current, DataBinding)
               dataBindingOutput8 = [String].Concat("The HashCode is", myDataBinding1.GetHashCode().ToString())
               WriteToFile(dataBindingOutput8)
               '<Snippet18>
               myDataBindingCollection1.Remove(myDataBinding1)
               dataBindingOutput8 = [String].Concat("The Count of the collection after DataBinding is removed is  ", myDataBindingCollection1.Count)
               WriteToFile(dataBindingOutput8)
'</Snippet18>
'</Snippet17>
            Else
               myDataBinding1 = CType(myEnumerator1.Current, DataBinding)
'<Snippet19>
               myDataBindingCollection1.Remove("Text", True)
               dataBindingOutput8 = [String].Concat("The Count of the collection after DataBinding is removed is  ", myDataBindingCollection1.Count)
               WriteToFile(dataBindingOutput8)
'</Snippet19>
'<Snippet20>
               myDataBindingCollection1.Clear()
               dataBindingOutput8 = [String].Concat("The Count of the collection after clear method is called  ", myDataBindingCollection1.Count)
               WriteToFile(dataBindingOutput8)
            End If 
'</Snippet20>
         End If
      End Sub 'OnBindingsCollectionChanged

      Public Sub WriteToFile(ByVal input As String)
         'This method writes the values of the properties at the design time into a Text file DataBindingOutput.txt in the "C"  of the system.
         Dim myFile As StreamWriter = File.AppendText("C:\DataBindingOutput.txt")
         Dim encoder As New ASCIIEncoding()
         Dim ByteArray As Byte() = encoder.GetBytes(input)
         Dim CharArray As Char() = encoder.GetChars(ByteArray)
         myFile.WriteLine(CharArray, 0, input.Length)
         myFile.Close()
      End Sub 'WriteToFile
   End Class 'SimpleDesigner
'<Snippet21>
   <DefaultProperty("Text"), ToolboxData("<{0}:Simple runat=server></{0}:Simple>"), Designer("DataBindingTest.SimpleDesigner"), DataBindingHandlerAttribute(GetType(System.Web.UI.Design.TextDataBindingHandler))> Public Class SimpleWebControl
'</Snippet21>
      Inherits WebControl
      'A control derived from 'System.Web.UI.WebControl' class with single property 'Text'.
      Private _Text As String

      <Bindable(True)> Public Property Text() As String
         Get
            Return _Text
         End Get
         Set(ByVal Value As String)
            _Text = Value
         End Set
      End Property

      Protected Overrides Sub Render(ByVal output As HtmlTextWriter)
         output.Write(("<br>This is the Text of SimpleWebControl : " + _Text))
         Dim attribute As Object
         For Each attribute In GetType(SimpleWebControl).GetCustomAttributes(True)
            If TypeOf attribute Is DataBindingHandlerAttribute Then
               Dim myDataBindingHandlerAttribute As DataBindingHandlerAttribute = CType(attribute, DataBindingHandlerAttribute)
'<Snippet22>
               output.Write(("<br><br><br>The IsDefaultAttribute of DataBindingHandlerAttribute is :" + myDataBindingHandlerAttribute.IsDefaultAttribute().ToString()))
               output.Write(("<br><br><br>DataBinding HandlerTypeName:" + myDataBindingHandlerAttribute.HandlerTypeName.ToString()))
            End If
'</Snippet22>
         Next attribute
      End Sub 'Render
   End Class 'SimpleWebControl
End Namespace 'DataBindingTest