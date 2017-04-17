
// <Snippet1>
using namespace System;
using namespace System::Reflection;

// An enumeration of animals. Start at 1 (0 = uninitialized).
public enum class Animal
{
   // Pets.
   Dog = 1,
   Cat, Bird
};


// A custom attribute to allow a target to have a pet.
public ref class AnimalTypeAttribute: public Attribute
{
public:

   // The constructor is called when the attribute is set.
   AnimalTypeAttribute( Animal pet )
   {
      thePet = pet;
   }

   // Provide a default constructor and make Dog the default.
   AnimalTypeAttribute()
   {
      thePet = Animal::Dog;
   }

protected:

   // Keep a variable internally ...
   Animal thePet;

public:

   property Animal Pet 
   {
      // .. and show a copy to the outside world.
      Animal get()
      {
         return thePet;
      }
      void set( Animal value )
      {
         thePet = value;
      }

   }

   // Override IsDefaultAttribute to return the correct response.
   virtual bool IsDefaultAttribute() override
   {
      return thePet == Animal::Dog;
   }
};

public ref class TestClass
{
public:

   // Use the default constructor.

   [AnimalType]
   void Method1(){}
};

int main()
{
   // Get the class type to access its metadata.
   Type^ clsType = TestClass::typeid;

   // Get type information for the method.
   MethodInfo^ mInfo = clsType->GetMethod( "Method1" );

   // Get the AnimalType attribute for the method.
   AnimalTypeAttribute^ atAttr = dynamic_cast<AnimalTypeAttribute^>(Attribute::GetCustomAttribute( mInfo, AnimalTypeAttribute::typeid ));

   // Check to see if the default attribute is applied.
   Console::WriteLine( "The attribute {0} for method {1} in class {2}", atAttr->Pet, mInfo->Name, clsType->Name );
   Console::WriteLine( "{0} the default for the AnimalType attribute.", atAttr->IsDefaultAttribute() ? (String^)"is" : "is not" );
}
// </Snippet1>
