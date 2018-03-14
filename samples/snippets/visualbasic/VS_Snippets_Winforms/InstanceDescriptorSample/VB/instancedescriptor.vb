'<snippet1>
Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design.Serialization
Imports System.Drawing
Imports System.Globalization
Imports System.Reflection
Namespace Microsoft.Samples.InstanceDescriptorSample

   '  This sample shows how to support code generation for a custom type 
   '  of object using a type converter and InstanceDescriptor objects.
   '
   '  To use this code, copy it to a file and add the file to a project.  
   '  Then add a component to the project and declare a Triangle field and 
   '  a public property with accessors for the Triangle field on the component.
   '
   '  The Triangle property will be persisted using code generation.

   <TypeConverter(GetType(Triangle.TriangleConverter))> _
   Public Class Triangle
      ' Triangle members.
      Private P1 As Point
      Private P2 As Point
      Private P3 As Point

      Public Property Point1() As Point
         Get
            Return P1
         End Get
         Set(ByVal Value As Point)
            P1 = Value
         End Set
      End Property

      Public Property Point2() As Point
         Get
            Return P2
         End Get
         Set(ByVal Value As Point)
            P2 = Value
         End Set
      End Property

      Public Property Point3() As Point
         Get
            Return P3
         End Get
         Set(ByVal Value As Point)
            P3 = Value
         End Set
      End Property

      Public Sub New(ByVal point1 As Point, ByVal point2 As Point, ByVal point3 As Point)
         P1 = point1
         P2 = point2
         P3 = point3
      End Sub 'New

      ' A TypeConverter for the Triangle object.  Note that you can make it internal,
      '  private, or any scope you want and the designers will still be able to use
      '  it through the TypeDescriptor object.  This type converter provides the
      '  capability to convert to an InstanceDescriptor.  This object can be used by 
      '  the .NET Framework to generate source code that creates an instance of a 
      '  Triangle object.

      Friend Class TriangleConverter
         Inherits TypeConverter

         ' This method overrides CanConvertTo from TypeConverter.  This is called when someone
         '  wants to convert an instance of Triangle to another type.  Here,
         '  only coversition to an InstanceDescriptor is supported.
         Public Overloads Overrides Function CanConvertTo(ByVal context As ITypeDescriptorContext, ByVal destinationType As Type) As Boolean
            If destinationType Is GetType(InstanceDescriptor) Then
               Return True
            End If

            ' Always call the base to see if it can perform the conversion.
            Return MyBase.CanConvertTo(context, destinationType)
         End Function

         ' This code performs the actual conversion from a Triangle to an InstanceDescriptor.
         Public Overloads Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
            If destinationType Is GetType(InstanceDescriptor) Then
               Dim ci As ConstructorInfo = GetType(Triangle).GetConstructor(New Type() {GetType(Point), GetType(Point), GetType(Point)})
               Dim t As Triangle = CType(value, Triangle)
               Return New InstanceDescriptor(ci, New Object() {t.Point1, t.Point2, t.Point3})
            End If

            ' Always call base, even if you can't convert.
            Return MyBase.ConvertTo(context, culture, value, destinationType)
         End Function 
      End Class 
   End Class 

   Public Class TestComponent
      Inherits System.ComponentModel.Component
      Private myTriangleProp As Triangle

      Public Sub New()
         myTriangleProp = New Triangle(New Point(5, 5), _
                                    New Point(10, 10), New Point(1, 8))
      End Sub

      Public Property MyTriangle() As Triangle
         Get
            Return myTriangleProp
         End Get
         Set(ByVal Value As Triangle)
            myTriangleProp = Value
         End Set
      End Property

   End Class

End Namespace
'</snippet1>