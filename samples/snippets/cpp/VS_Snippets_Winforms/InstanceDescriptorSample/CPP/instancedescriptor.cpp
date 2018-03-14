

//<snippet1>
#using <system.dll>
#using <system.drawing.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design::Serialization;
using namespace System::Drawing;
using namespace System::Globalization;
using namespace System::Collections;
using namespace System::Reflection;

/*   This sample shows how to support code generation for a custom type of object 
         using a type converter and InstanceDescriptor objects.

         To use this code, copy it to a file and add the file to a project. Then add
         a component to the project and declare a Triangle field and a public property 
         with accessors for the Triangle field on the component.

         The Triangle property will be persisted using code generation.
    */
ref class TriangleConverter;

[TypeConverter(TriangleConverter::typeid)]
public ref class Triangle
{
private:

   // Triangle members
   Point P1;
   Point P2;
   Point P3;

public:

   property Point Point1 
   {
      Point get()
      {
         return P1;
      }

      void set( Point value )
      {
         P1 = value;
      }
   }

   property Point Point2 
   {
      Point get()
      {
         return P2;
      }

      void set( Point value )
      {
         P2 = value;
      }
   }

   property Point Point3 
   {
      Point get()
      {
         return P3;
      }

      void set( Point value )
      {
         P3 = value;
      }

   }
   Triangle( Point point1, Point point2, Point point3 )
   {
      P1 = point1;
      P2 = point2;
      P3 = point3;
   }


   /* A TypeConverter for the Triangle object.  Note that you can make it internal,
      private, or any scope you want and the designers will still be able to use
      it through the TypeDescriptor object.  This type converter provides the
      capability to convert to an InstanceDescriptor.  This object can be used by 
      the .NET Framework to generate source code that creates an instance of a 
      Triangle object. */
   [System::Security::Permissions::PermissionSet(System::Security::
      Permissions::SecurityAction::Demand, Name = "FullTrust")]
   ref class TriangleConverter: public TypeConverter
   {
   public:

      /* This method overrides CanConvertTo from TypeConverter. This is called when someone
            wants to convert an instance of Triangle to another type.  Here,
            only conversion to an InstanceDescriptor is supported. */
      virtual bool CanConvertTo( ITypeDescriptorContext^ context, Type^ destinationType ) override
      {
         if ( destinationType == InstanceDescriptor::typeid )
         {
            return true;
         }

         
         // Always call the base to see if it can perform the conversion.
         return TypeConverter::CanConvertTo( context, destinationType );
      }

      /* This code performs the actual conversion from a Triangle to an InstanceDescriptor. */
      virtual Object^ ConvertTo( ITypeDescriptorContext^ context, CultureInfo^ culture, Object^ value, Type^ destinationType ) override
      {
         if ( destinationType == InstanceDescriptor::typeid )
         {
            array<Type^>^type1 = {Point::typeid,Point::typeid,Point::typeid};
            ConstructorInfo^ ci = Triangle::typeid->GetConstructor( type1 );
            Triangle^ t = safe_cast<Triangle^>(value);
            array<Object^>^obj1 = {t->Point1,t->Point2,t->Point3};
            return gcnew InstanceDescriptor( ci,safe_cast<ICollection^>(obj1) );
         }

         // Always call base, even if you can't convert.
         return TypeConverter::ConvertTo( context, culture, value, destinationType );
      }
   };
};

public ref class TestComponent: public System::ComponentModel::Component
{
private:
   Triangle^ myTriangle;

public:
   TestComponent()
   {
      myTriangle = gcnew Triangle( Point(5,5),Point(10,10),Point(1,8) );
   }

   property Triangle^ MyTriangle 
   {
      Triangle^ get()
      {
         return myTriangle;
      }

      void set( Triangle^ value )
      {
         myTriangle = value;
      }
   }
};
//</snippet1>
