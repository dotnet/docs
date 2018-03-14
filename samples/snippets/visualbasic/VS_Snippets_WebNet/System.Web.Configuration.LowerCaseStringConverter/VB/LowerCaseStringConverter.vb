' <Snippet1>
Imports System
Imports System.Configuration
Imports System.Web.Configuration
Imports System.Collections
Imports System.Text
Imports System.Globalization

Namespace Samples.AspNet
  Class lowerCaseDescContext : Implements System.ComponentModel.ITypeDescriptorContext

    Public Overridable ReadOnly Property Container() As System.ComponentModel.IContainer _
     Implements System.ComponentModel.ITypeDescriptorContext.Container
      Get
        Throw New Exception("The method or operation is not implemented.")
      End Get
    End Property

    Public Overridable ReadOnly Property Instance() As Object _
     Implements System.ComponentModel.ITypeDescriptorContext.Instance
      Get
        Throw New Exception("The method or operation is not implemented.")
      End Get
    End Property

    Public Overridable Sub OnComponentChanged() _
     Implements System.ComponentModel.ITypeDescriptorContext.OnComponentChanged
      Throw New Exception("The method or operation is not implemented.")
    End Sub 'OnComponentChanged

    Public Overridable Function OnComponentChanging() As Boolean _
     Implements System.ComponentModel.ITypeDescriptorContext.OnComponentChanging
      Throw New Exception("The method or operation is not implemented.")
    End Function 'OnComponentChanging

    Public Overridable ReadOnly Property PropertyDescriptor() As System.ComponentModel.PropertyDescriptor _
     Implements System.ComponentModel.ITypeDescriptorContext.PropertyDescriptor
      Get
        Throw New Exception("The method or operation is not implemented.")
      End Get
    End Property

    Public Overridable Function GetService(ByVal serviceType As Type) As Object _
      Implements System.IServiceProvider.GetService
      Throw New Exception("The method or operation is not implemented.")
    End Function 'GetService

  End Class 'lowerCaseDescContext 

  Class UsingLowerCaseStringConverter
    Public Shared Sub Main()

      ' Display title.
      Console.WriteLine("Using LowerCaseStringConverter")
      Console.WriteLine()

      Try
        ' Create string.
        Dim testStrVal As Object = "TESTVALUE"
        Dim resultStrVal As Object

        '<Snippet2>
        ' Create LowerCaseStringConverter object.
        Dim myLCStrConverter As LowerCaseStringConverter = _
         New LowerCaseStringConverter()

        ' Create lowerCaseDescContext object.
        Dim ctx As lowerCaseDescContext = _
         New lowerCaseDescContext()

        ' Create CultureInfo object.
        Dim ci As CultureInfo = New CultureInfo(1033)
        '</Snippet2>

        '<Snippet3>
        ' CanConvertFrom method.
        Console.WriteLine("CanConvertFrom: {0}", _
          myLCStrConverter.CanConvertFrom(ctx, testStrVal.GetType()))
        '</Snippet3>

        '<Snippet4>
        ' CanConvertTo method.
        Console.WriteLine("CanConvertTo: {0}", _
          myLCStrConverter.CanConvertTo(ctx, testStrVal.GetType()))
        '</Snippet4>

        '<Snippet5>
        ' ConvertFrom method.
        Console.WriteLine("Original Value: {0}", _
          testStrVal.ToString())
        resultStrVal = myLCStrConverter.ConvertFrom(ctx, ci, testStrVal)
        Console.WriteLine("ConvertFrom result: {0}", _
          resultStrVal.ToString())
        '</Snippet5>

        '<Snippet6>
        ' ConvertTo method.
        Console.WriteLine("Original Value: {0}", _
          testStrVal.ToString())
        resultStrVal = myLCStrConverter.ConvertTo _
          (ctx, ci, testStrVal, testStrVal.GetType())
        Console.WriteLine("ConvertTo result: {0}", _
          resultStrVal.ToString())
        '</Snippet6>

      Catch e As Exception
        ' Unknown error.
        Console.WriteLine(e.ToString())
      End Try

      ' Display and wait.
      Console.ReadLine()
    End Sub
  End Class
End Namespace
' </Snippet1>