//<Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Collections::Generic;
using namespace System::Collections::ObjectModel;

// An enumeration used by the ExampleAttribute class.
public enum class ExampleKind
{
   FirstKind, SecondKind, ThirdKind, FourthKind
};

// An example attribute. The attribute can be applied to all
// targets, from assemblies to parameters.
//
[AttributeUsage(AttributeTargets::All)]
public ref class ExampleAttribute: public Attribute
{
private:
   // Data for properties.
   ExampleKind kindValue;
   String^ noteValue;
   array<String^>^ arrayStrings;
   array<int>^ arrayNumbers;

   // Constructors. 
   void ExampleAttributeInitialize( ExampleKind initKind, array<String^>^ initStrings )
   {
      kindValue = initKind;
      arrayStrings = initStrings;
   }
public:
   ExampleAttribute()
   {
      ExampleAttributeInitialize( ExampleKind::FirstKind, nullptr );
   }
   ExampleAttribute( ExampleKind initKind )
   {
      ExampleAttributeInitialize( initKind, nullptr );
   }
   ExampleAttribute( ExampleKind initKind, array<String^>^ initStrings )
   {
      ExampleAttributeInitialize( initKind, initStrings );
   }

   // Properties. The Note and Numbers properties must be read/write, so they
   // can be used as named parameters.
   //
   property ExampleKind Kind 
   {
      ExampleKind get()
      {
         return kindValue;
      }
   }
   property array<String^>^ Strings
   {
      array<String^>^ get()
      {
         return arrayStrings;
      }
   }
   property String^ Note 
   {
      String^ get()
      {
         return noteValue;
      }

      void set( String^ value )
      {
         noteValue = value;
      }
   }
   property array<int>^ Numbers
   {
      array<int>^ get()
      {
         return arrayNumbers;
      }

      void set( array<int>^ value )
      {
         arrayNumbers = value;
      }
   }
};

// The example attribute is applied to the assembly.
[assembly:Example(ExampleKind::ThirdKind,Note="This is a note on the assembly.")];

// The example attribute is applied to the test class.
//
[Example(ExampleKind::SecondKind, 
         gcnew array<String^> { "String array argument, line 1", 
                        "String array argument, line 2", 
                        "String array argument, line 3" }, 
         Note="This is a note on the class.",
         Numbers = gcnew array<int> { 53, 57, 59 })] 
public ref class Test
{
public:
   // The example attribute is applied to a method, using the
   // parameterless constructor and supplying a named argument.
   // The attribute is also applied to the method parameter.
   //
   [Example(Note="This is a note on a method.")]
   void TestMethod( [Example] Object^ arg ){}

   // Main() gets objects representing the assembly, the test
   // type, the test method, and the method parameter. Custom
   // attribute data is displayed for each of these.
   //
   static void Main()
   {
      Assembly^ assembly = Assembly::ReflectionOnlyLoad( "Source" );
      Type^ t = assembly->GetType( "Test" );
      MethodInfo^ m = t->GetMethod( "TestMethod" );
      array<ParameterInfo^>^p = m->GetParameters();

      Console::WriteLine( "\r\nAttributes for assembly: '{0}'", assembly );
      ShowAttributeData( CustomAttributeData::GetCustomAttributes( assembly ) );
      Console::WriteLine( "\r\nAttributes for type: '{0}'", t );
      ShowAttributeData( CustomAttributeData::GetCustomAttributes( t ) );
      Console::WriteLine( "\r\nAttributes for member: '{0}'", m );
      ShowAttributeData( CustomAttributeData::GetCustomAttributes( m ) );
      Console::WriteLine( "\r\nAttributes for parameter: '{0}'", p );
      ShowAttributeData( CustomAttributeData::GetCustomAttributes( p[ 0 ] ) );
   }

private:
    static void ShowValueOrArray(CustomAttributeTypedArgument^ cata)
    {
        if (cata->Value->GetType() == ReadOnlyCollection<CustomAttributeTypedArgument>::typeid)
        {
            Console::WriteLine("         Array of '{0}':", cata->ArgumentType);

            for each (CustomAttributeTypedArgument^ cataElement in 
                (ReadOnlyCollection<CustomAttributeTypedArgument>^) cata->Value)
            {
                Console::WriteLine("             Type: '{0}'  Value: '{1}'",
                    cataElement->ArgumentType, cataElement->Value);
            }
        }
        else
        {
            Console::WriteLine( "         Type: '{0}'  Value: '{1}'",
               cata->ArgumentType, cata->Value );
        }
    }

   static void ShowAttributeData( IList< CustomAttributeData^ >^ attributes )
   {
      for each ( CustomAttributeData^ cad in attributes )
      {
         Console::WriteLine( "   {0}", cad );
         Console::WriteLine( "      Constructor: '{0}'", cad->Constructor );

         Console::WriteLine( "      Constructor arguments:" );
         for each ( CustomAttributeTypedArgument^ cata in cad->ConstructorArguments )
         {
            ShowValueOrArray(cata);
         }

         Console::WriteLine( "      Named arguments:" );
         for each ( CustomAttributeNamedArgument cana in cad->NamedArguments )
         {
            Console::WriteLine( "         MemberInfo: '{0}'", cana.MemberInfo );
            ShowValueOrArray(cana.TypedValue);
         }
      }
   }
};

int main()
{
   Test::Main();
}

/* This code example produces output similar to the following:

Attributes for assembly: 'source, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null'
   [System.Runtime.CompilerServices.CompilationRelaxationsAttribute((Int32)8)]
      Constructor: 'Void .ctor(Int32)'
      Constructor arguments:
         Type: 'System.Int32'  Value: '8'
      Named arguments:
   [System.Runtime.CompilerServices.RuntimeCompatibilityAttribute(WrapNonExceptionThrows = True)]
      Constructor: 'Void .ctor()'
      Constructor arguments:
      Named arguments:
         MemberInfo: 'Boolean WrapNonExceptionThrows'
         Type: 'System.Boolean'  Value: 'True'
   [ExampleAttribute((ExampleKind)2, Note = "This is a note on the assembly.")]
      Constructor: 'Void .ctor(ExampleKind)'
      Constructor arguments:
         Type: 'ExampleKind'  Value: '2'
      Named arguments:
         MemberInfo: 'System.String Note'
         Type: 'System.String'  Value: 'This is a note on the assembly.'

Attributes for type: 'Test'
   [ExampleAttribute((ExampleKind)1, new String[3] { "String array argument, line 1", "String array argument, line 2", "String array argument, line 3" }, Note = "This is a note on the class.", Numbers = new Int32[3] { 53, 57, 59 })]
      Constructor: 'Void .ctor(ExampleKind, System.String[])'
      Constructor arguments:
         Type: 'ExampleKind'  Value: '1'
         Array of 'System.String[]':
             Type: 'System.String'  Value: 'String array argument, line 1'
             Type: 'System.String'  Value: 'String array argument, line 2'
             Type: 'System.String'  Value: 'String array argument, line 3'
      Named arguments:
         MemberInfo: 'System.String Note'
         Type: 'System.String'  Value: 'This is a note on the class.'
         MemberInfo: 'Int32[] Numbers'
         Array of 'System.Int32[]':
             Type: 'System.Int32'  Value: '53'
             Type: 'System.Int32'  Value: '57'
             Type: 'System.Int32'  Value: '59'

Attributes for member: 'Void TestMethod(System.Object)'
   [ExampleAttribute(Note = "This is a note on a method.")]
      Constructor: 'Void .ctor()'
      Constructor arguments:
      Named arguments:
         MemberInfo: 'System.String Note'
         Type: 'System.String'  Value: 'This is a note on a method.'

Attributes for parameter: 'System.Object arg'
   [ExampleAttribute()]
      Constructor: 'Void .ctor()'
      Constructor arguments:
      Named arguments:
*/
//</Snippet1>
