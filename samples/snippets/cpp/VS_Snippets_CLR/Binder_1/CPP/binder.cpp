
// <Snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Globalization;
using namespace System::Runtime::InteropServices;
public ref class MyBinder: public Binder
{
public:
   MyBinder()
      : Binder()
   {}

private:
   ref class BinderState
   {
   public:
      array<Object^>^args;
   };

public:
   virtual FieldInfo^ BindToField( BindingFlags bindingAttr, array<FieldInfo^>^match, Object^ value, CultureInfo^ culture ) override
   {
      if ( match == nullptr )
            throw gcnew ArgumentNullException( "match" );

      // Get a field for which the value parameter can be converted to the specified field type.
      for ( int i = 0; i < match->Length; i++ )
         if ( ChangeType( value, match[ i ]->FieldType, culture ) != nullptr )
                  return match[ i ];

      return nullptr;
   }

   virtual MethodBase^ BindToMethod( BindingFlags bindingAttr, array<MethodBase^>^match, array<Object^>^%args, array<ParameterModifier>^ modifiers, CultureInfo^ culture, array<String^>^names, [Out]Object^% state ) override
   {
      // Store the arguments to the method in a state Object*.
      BinderState^ myBinderState = gcnew BinderState;
      array<Object^>^arguments = gcnew array<Object^>(args->Length);
      args->CopyTo( arguments, 0 );
      myBinderState->args = arguments;
      state = myBinderState;
      if ( match == nullptr )
            throw gcnew ArgumentNullException;

      // Find a method that has the same parameters as those of the args parameter.
      for ( int i = 0; i < match->Length; i++ )
      {
         // Count the number of parameters that match.
         int count = 0;
         array<ParameterInfo^>^parameters = match[ i ]->GetParameters();

         // Go on to the next method if the number of parameters do not match.
         if ( args->Length != parameters->Length )
                  continue;

         // Match each of the parameters that the user expects the method to have.
         for ( int j = 0; j < args->Length; j++ )
         {
            // If the names parameter is not 0, then reorder args.
            if ( names != nullptr )
            {
               if ( names->Length != args->Length )
                              throw gcnew ArgumentException( "names and args must have the same number of elements." );

               for ( int k = 0; k < names->Length; k++ )
                  if ( String::Compare( parameters[ j ]->Name, names[ k ] ) == 0 )
                                    args[ j ] = myBinderState->args[ k ];
            }

            // Determine whether the types specified by the user can be converted to the parameter type.
            if ( ChangeType( args[ j ], parameters[ j ]->ParameterType, culture ) != nullptr )
                        count += 1;
            else
                        break;
         }
         if ( count == args->Length )
                  return match[ i ];
      }
      return nullptr;
   }

   virtual Object^ ChangeType( Object^ value, Type^ myChangeType, CultureInfo^ culture ) override
   {
      // Determine whether the value parameter can be converted to a value of type myType.
      if ( CanConvertFrom( value->GetType(), myChangeType ) )
         // Return the converted Object*.
         return Convert::ChangeType( value, myChangeType ); 
      else
         return nullptr;
   }

   virtual void ReorderArgumentArray( array<Object^>^%args, Object^ state ) override
   {
      // Return the args that had been reordered by BindToMethod.
      (safe_cast<BinderState^>(state))->args->CopyTo( args, 0 );
   }

   virtual MethodBase^ SelectMethod( BindingFlags bindingAttr, array<MethodBase^>^match, array<Type^>^types, array<ParameterModifier>^ modifiers ) override
   {
      if ( match == nullptr )
            throw gcnew ArgumentNullException( "match" );

      for ( int i = 0; i < match->Length; i++ )
      {
         // Count the number of parameters that match.
         int count = 0;
         array<ParameterInfo^>^parameters = match[ i ]->GetParameters();

         // Go on to the next method if the number of parameters do not match.
         if ( types->Length != parameters->Length )
                  continue;

         // Match each of the parameters that the user expects the method to have.
         for ( int j = 0; j < types->Length; j++ )
         {
            // Determine whether the types specified by the user can be converted to parameter type.
            if ( CanConvertFrom( types[ j ], parameters[ j ]->ParameterType ) )
                        count += 1;
            else
                        break;
         }
         // Determine whether the method has been found.
         if ( count == types->Length )
                  return match[ i ];
      }
      return nullptr;
   }

   virtual PropertyInfo^ SelectProperty( BindingFlags bindingAttr, array<PropertyInfo^>^match, Type^ returnType, array<Type^>^indexes, array<ParameterModifier>^ modifiers ) override
   {
      if ( match == nullptr )
            throw gcnew ArgumentNullException( "match" );

      for ( int i = 0; i < match->Length; i++ )
      {
         // Count the number of indexes that match.
         int count = 0;
         array<ParameterInfo^>^parameters = match[ i ]->GetIndexParameters();

         // Go on to the next property if the number of indexes do not match.
         if ( indexes->Length != parameters->Length )
                  continue;

         // Match each of the indexes that the user expects the property to have.
         for ( int j = 0; j < indexes->Length; j++ )
            // Determine whether the types specified by the user can be converted to index type.
            if ( CanConvertFrom( indexes[ j ], parameters[ j ]->ParameterType ) )
                        count += 1;
            else
                        break;

         // Determine whether the property has been found.
         if ( count == indexes->Length )
         {
            // Determine whether the return type can be converted to the properties type.
            if ( CanConvertFrom( returnType, match[ i ]->PropertyType ) )
                  return match[ i ];
            else
                  continue;
         }
      }
      return nullptr;
   }

private:

   // Determines whether type1 can be converted to type2. Check only for primitive types.
   bool CanConvertFrom( Type^ type1, Type^ type2 )
   {
      if ( type1->IsPrimitive && type2->IsPrimitive )
      {
         TypeCode typeCode1 = Type::GetTypeCode( type1 );
         TypeCode typeCode2 = Type::GetTypeCode( type2 );

         // If both type1 and type2 have the same type, return true.
         if ( typeCode1 == typeCode2 )
                  return true;

         // Possible conversions from Char follow.
         if ( typeCode1 == TypeCode::Char )
         {
            switch ( typeCode2 )
            {
               case TypeCode::UInt16:
                  return true;

               case TypeCode::UInt32:
                  return true;

               case TypeCode::Int32:
                  return true;

               case TypeCode::UInt64:
                  return true;

               case TypeCode::Int64:
                  return true;

               case TypeCode::Single:
                  return true;

               case TypeCode::Double:
                  return true;

               default:
                  return false;
            }
         }

         // Possible conversions from Byte follow.
         if ( typeCode1 == TypeCode::Byte )
         {
            switch ( typeCode2 )
            {
               case TypeCode::Char:
                  return true;

               case TypeCode::UInt16:
                  return true;

               case TypeCode::Int16:
                  return true;

               case TypeCode::UInt32:
                  return true;

               case TypeCode::Int32:
                  return true;

               case TypeCode::UInt64:
                  return true;

               case TypeCode::Int64:
                  return true;

               case TypeCode::Single:
                  return true;

               case TypeCode::Double:
                  return true;

               default:
                  return false;
            }
         }

         // Possible conversions from SByte follow.
         if ( typeCode1 == TypeCode::SByte )
         {
            switch ( typeCode2 )
            {
               case TypeCode::Int16:
                  return true;

               case TypeCode::Int32:
                  return true;

               case TypeCode::Int64:
                  return true;

               case TypeCode::Single:
                  return true;

               case TypeCode::Double:
                  return true;

               default:
                  return false;
            }
         }

         // Possible conversions from UInt16 follow.
         if ( typeCode1 == TypeCode::UInt16 )
         {
            switch ( typeCode2 )
            {
               case TypeCode::UInt32:
                  return true;

               case TypeCode::Int32:
                  return true;

               case TypeCode::UInt64:
                  return true;

               case TypeCode::Int64:
                  return true;

               case TypeCode::Single:
                  return true;

               case TypeCode::Double:
                  return true;

               default:
                  return false;
            }
         }

         // Possible conversions from Int16 follow.
         if ( typeCode1 == TypeCode::Int16 )
         {
            switch ( typeCode2 )
            {
               case TypeCode::Int32:
                  return true;

               case TypeCode::Int64:
                  return true;

               case TypeCode::Single:
                  return true;

               case TypeCode::Double:
                  return true;

               default:
                  return false;
            }
         }

         // Possible conversions from UInt32 follow.
         if ( typeCode1 == TypeCode::UInt32 )
         {
            switch ( typeCode2 )
            {
               case TypeCode::UInt64:
                  return true;

               case TypeCode::Int64:
                  return true;

               case TypeCode::Single:
                  return true;

               case TypeCode::Double:
                  return true;

               default:
                  return false;
            }
         }

         // Possible conversions from Int32 follow.
         if ( typeCode1 == TypeCode::Int32 )
         {
            switch ( typeCode2 )
            {
               case TypeCode::Int64:
                  return true;

               case TypeCode::Single:
                  return true;

               case TypeCode::Double:
                  return true;

               default:
                  return false;
            }
         }

         // Possible conversions from UInt64 follow.
         if ( typeCode1 == TypeCode::UInt64 )
         {
            switch ( typeCode2 )
            {
               case TypeCode::Single:
                  return true;

               case TypeCode::Double:
                  return true;

               default:
                  return false;
            }
         }

         // Possible conversions from Int64 follow.
         if ( typeCode1 == TypeCode::Int64 )
         {
            switch ( typeCode2 )
            {
               case TypeCode::Single:
                  return true;

               case TypeCode::Double:
                  return true;

               default:
                  return false;
            }
         }

         // Possible conversions from Single follow.
         if ( typeCode1 == TypeCode::Single )
         {
            switch ( typeCode2 )
            {
               case TypeCode::Double:
                  return true;

               default:
                  return false;
            }
         }
      }

      return false;
   }

};

public ref class MyClass1
{
public:
   short myFieldB;
   int myFieldA;
   void MyMethod( long i, char k )
   {
      Console::WriteLine( "\nThis is MyMethod(long i, char k)" );
   }

   void MyMethod( long i, long j )
   {
      Console::WriteLine( "\nThis is MyMethod(long i, long j)" );
   }
};

int main()
{
   // Get the type of MyClass1.
   Type^ myType = MyClass1::typeid;

   // Get the instance of MyClass1.
   MyClass1^ myInstance = gcnew MyClass1;
   Console::WriteLine( "\nDisplaying the results of using the MyBinder binder.\n" );

   // Get the method information for MyMethod.
   array<Type^>^types = {short::typeid,short::typeid};
   MethodInfo^ myMethod = myType->GetMethod( "MyMethod", static_cast<BindingFlags>(BindingFlags::Public | BindingFlags::Instance), gcnew MyBinder, types, nullptr );
   Console::WriteLine( myMethod );

   // Invoke MyMethod.
   array<Object^>^obj = {32,32};
   myMethod->Invoke( myInstance, BindingFlags::InvokeMethod, gcnew MyBinder, obj, CultureInfo::CurrentCulture );
}
// </Snippet1>
