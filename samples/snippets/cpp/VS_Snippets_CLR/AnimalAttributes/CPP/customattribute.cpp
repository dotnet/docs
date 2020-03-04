
//<Snippet1>
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
};

// A test class where each method has its own pet.
ref class AnimalTypeTestClass
{
public:

    [AnimalType(Animal::Dog)]
    void DogMethod(){}


    [AnimalType(Animal::Cat)]
    void CatMethod(){}

    [AnimalType(Animal::Bird)]
    void BirdMethod(){}

};

int main()
{
    AnimalTypeTestClass^ testClass = gcnew AnimalTypeTestClass;
    Type^ type = testClass->GetType();

    // Iterate through all the methods of the class.
    System::Collections::IEnumerator^ myEnum = 
        type->GetMethods()->GetEnumerator();
    while ( myEnum->MoveNext() )
    {
        MethodInfo^ mInfo = safe_cast<MethodInfo^>(myEnum->Current);

        // Iterate through all the Attributes for each method.
        System::Collections::IEnumerator^ myEnum1 = 
            Attribute::GetCustomAttributes( mInfo )->GetEnumerator();
        while ( myEnum1->MoveNext() )
        {
            Attribute^ attr = safe_cast<Attribute^>(myEnum1->Current);

            // Check for the AnimalType attribute.
            if ( attr->GetType() == AnimalTypeAttribute::typeid )
                Console::WriteLine( "Method {0} has a pet {1} attribute.", 
                mInfo->Name, (dynamic_cast<AnimalTypeAttribute^>(attr))->Pet );
        }
    }
}

/*
 * Output:
 * Method DogMethod has a pet Dog attribute.
 * Method CatMethod has a pet Cat attribute.
 * Method BirdMethod has a pet Bird attribute.
 */
//</Snippet1>
