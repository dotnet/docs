Option Explicit On
Option Strict On

''' <summary>
''' This class provides a simple counter.
''' </summary>
''' <remarks>
''' The <c>Counter</c> property gets incemented by one every
''' time the property is accessed.
''' <para>To reset the counter, use the <c>ResetCounter</c> method.</para>
''' </remarks>
Public Class CounterSample

    ''' <summary>
    ''' Private store for the <see cref="Counter"/> property.
    ''' </summary>
    ''' <remarks>
    ''' Use the <see cref="ResetCounter"/> method to reset
    ''' the value of the <see cref="Counter"/> property to zero.
    ''' <seealso cref="ResetCounter"/>
    ''' <seealso cref="Counter"/>
    ''' </remarks>
    Private counterValue As Integer = 0

    ''' <summary>
    ''' Resets the value of the <c>Counter</c> field.
    ''' </summary>
    ''' <remarks>
    ''' This method sets the value of 
    ''' the <see cref="Counter"/> property to zero.
    ''' <seealso cref="Counter"/>
    ''' </remarks>
    Public Sub ResetCounter()
        counterValue = 0
    End Sub

    ''' <summary>
    ''' Returns the number of times Counter was called.
    ''' </summary>
    ''' <value>Number of times Counter was called.</value>
    ''' <remarks>
    ''' Use the <see cref="ResetCounter"/> method to reset
    ''' the value of the <see cref="Counter"/> property to zero.
    ''' <seealso cref="counterValue"/>
    ''' <seealso cref="Counter"/>
    ''' </remarks>
    Public ReadOnly Property Counter() As Integer
        Get
            counterValue += 1
            Return counterValue
        End Get
    End Property

End Class

'<c>	snippet1
'<code>	snippet2
'<example>	snippet2
'<exception>	snippet3
'<include>	snippet4
'<list>	snippet5
'<para>	snippet6
'<param>	snippet6
'<paramref>	snippet6
'<permission>	snippet7
'<remarks>	snippet6
'<returns>	snippet6
'<see>	snippet6
'<seealso>	snippet6
'<summary>	snippet1
'<typeparam>	snippet8
'<value>	snippet1


Public Class Test

    ' <snippet1>
    ''' <summary>
    ''' Resets the value of the <c>Counter</c> field.
    ''' </summary>
    Public Sub ResetCounter()
        counterValue = 0
    End Sub
    Private counterValue As Integer = 0
    ''' <summary>
    ''' Returns the number of times Counter was called.
    ''' </summary>
    ''' <value>Number of times Counter was called.</value>
    Public ReadOnly Property Counter() As Integer
        Get
            counterValue += 1
            Return counterValue
        End Get
    End Property
    ' </snippet1>

    ' <snippet3>
    ''' <exception cref="System.OverflowException">
    ''' Thrown when <paramref name="denominator"/><c> = 0</c>.
    ''' </exception>
    Public Function IntDivide( 
            ByVal numerator As Integer, 
            ByVal denominator As Integer 
    ) As Integer
        Return numerator \ denominator
    End Function
    ' </snippet3>

    ' <include>	    ba8e9173-82cd-460b-8938-a075a2dfb36d.xml
    '<snippet4>
    ''' <include file="commentFile.xml" 
    ''' path="Docs/Members[@name='Open']/*" />
    Public Sub Open(ByVal filename As String)
        ' Code goes here.
    End Sub
    ''' <include file="commentFile.xml" 
    ''' path="Docs/Members[@name='Close']/*" />
    Public Sub Close(ByVal filename As String)
        ' Code goes here.
    End Sub
    '</snippet4>

    ' <list>	    ec35fced-d58e-4520-a764-0691256e014b.xml
    ' <remarks>	    c6241773-a7ed-41c9-9a8b-9722a0c606a9.xml
    '<snippet5>
    ''' <remarks>Before calling the <c>Reset</c> method, be sure to:
    ''' <list type="bullet">
    ''' <item><description>Close all connections.</description></item>
    ''' <item><description>Save the object state.</description></item>
    ''' </list>
    ''' </remarks>
    Public Sub Reset()
        ' Code goes here.
    End Sub
    '</snippet5>


    ' <para>	    a3a18b6c-6416-4358-94ec-37b22675fd37.xml
    ' <param>	    4e32e86f-f6f3-4301-b7fc-2f321fb54368.xml
    ' <paramref>	8979d53b-beb1-41b7-b41e-6bbea1c17a03.xml
    ' <see>	        7e18f60b-ef4a-4678-a797-5eb918635ca9.xml
    ' <seealso>	    36050c95-1af2-4284-b9b6-1a70691ed978.xml
    ' <returns>	    a03a6469-d907-425d-882f-083187950e7e.xml
    ' <snippet6>
    ''' <param name="id">The ID of the record to update.</param>
    ''' <remarks>Updates the record <paramref name="id"/>.
    ''' <para>Use <see cref="DoesRecordExist"/> to verify that
    ''' the record exists before calling this method.</para>
    ''' </remarks>
    Public Sub UpdateRecord(ByVal id As Integer)
        ' Code goes here.
    End Sub
    ''' <param name="id">The ID of the record to check.</param>
    ''' <returns><c>True</c> if <paramref name="id"/> exists,
    ''' <c>False</c> otherwise.</returns>
    ''' <remarks><seealso cref="UpdateRecord"/></remarks>
    Public Function DoesRecordExist(ByVal id As Integer) As Boolean
        ' Code goes here.
    End Function
    ' </snippet6>

    ' <permission>	0edf0500-5cd7-49c0-9255-64c48f972b77.xml
    ' <snippet7>
    ''' <permission cref="System.Security.Permissions.FileIOPermission">
    ''' Needs full access to the specified file.
    ''' </permission>
    Public Sub ReadFile(ByVal filename As String)
        ' Code goes here.
    End Sub
    ' </snippet7>
End Class

' <code>	    925e5342-be05-45f2-bf66-7398bbd6710e.xml
' <example>	    90eeda1c-3fc4-427c-879c-5046d265a97c.xml
' <snippet2>
Public Class Employee
    ''' <remarks>
    ''' <example> This sample shows how to set the <c>ID</c> field.
    ''' <code>
    ''' Dim alice As New Employee
    ''' alice.ID = 1234
    ''' </code>
    ''' </example>
    ''' </remarks>
    Public ID As Integer
End Class
' </snippet2>

' <typeparam>	1bb5ba78-f060-478c-905c-77a2e43639af.xml
' <snippet8>
''' <typeparam name="T">
''' The base item type. Must implement IComparable.
''' </typeparam>
Public Class itemManager(Of T As IComparable)
    ' Insert code that defines class members.
End Class
' </snippet8>


' 78a15cd0-7708-4e79-85d1-c154b7a14a8c
' Processing the XML File (Visual Basic)

' <snippet10>
Namespace SampleNamespace

  ''' <summary>Signature is 
  ''' "T:SampleNamespace.SampleClass"
  ''' </summary>
  Public Class SampleClass

    ''' <summary>Signature is 
    ''' "M:SampleNamespace.SampleClass.#ctor"
    ''' </summary>
    Public Sub New()
    End Sub

    ''' <summary>Signature is 
    ''' "M:SampleNamespace.SampleClass.#ctor(System.Int32)"
    ''' </summary>
    Public Sub New(ByVal i As Integer)
    End Sub

    ''' <summary>Signature is 
    ''' "F:SampleNamespace.SampleClass.SampleField"
    ''' </summary>
    Public SampleField As String

    ''' <summary>Signature is 
    ''' "F:SampleNamespace.SampleClass.SampleConstant"
    ''' </summary>
    Public Const SampleConstant As Integer = 42

    ''' <summary>Signature is 
    ''' "M:SampleNamespace.SampleClass.SampleFunction"
    ''' </summary>
    Public Function SampleFunction() As Integer
    End Function

    ''' <summary>Signature is 
    ''' "M:SampleNamespace.SampleClass.
    ''' SampleFunction(System.Int16[],System.Int32[0:,0:])"
    ''' </summary>
    Public Function SampleFunction( 
        ByVal array1D() As Short, 
        ByVal array2D(,) As Integer) As Integer
    End Function

    ''' <summary>Signature is 
    ''' "M:SampleNamespace.SampleClass. 
    ''' op_Addition(SampleNamespace.SampleClass,
    '''             SampleNamespace.SampleClass)"
    ''' </summary>
    Public Shared Operator +( 
        ByVal operand1 As SampleClass, 
        ByVal operand2 As SampleClass) As SampleClass

      Return Nothing
    End Operator

    ''' <summary>Signature is 
    ''' "P:SampleNamespace.SampleClass.SampleProperty"
    ''' </summary>
    Public Property SampleProperty() As Integer
      Get
      End Get
      Set(ByVal value As Integer)
      End Set
    End Property

    ''' <summary>Signature is
    ''' "P:SampleNamespace.SampleClass.Item(System.String)"
    ''' </summary>
    Default Public ReadOnly Property Item( 
        ByVal s As String) As Integer

      Get
      End Get
    End Property

    ''' <summary>Signature is 
    ''' "T:SampleNamespace.SampleClass.NestedClass"
    ''' </summary>
    Public Class NestedClass
    End Class

    ''' <summary>Signature is 
    ''' "E:SampleNamespace.SampleClass.SampleEvent(System.Int32)"
    ''' </summary>
    Public Event SampleEvent As SampleDelegate

    ''' <summary>Signature is 
    ''' "T:SampleNamespace.SampleClass.SampleDelegate"
    ''' </summary>
    Public Delegate Sub SampleDelegate(ByVal i As Integer)
  End Class
End Namespace
' </snippet10>


