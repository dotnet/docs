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