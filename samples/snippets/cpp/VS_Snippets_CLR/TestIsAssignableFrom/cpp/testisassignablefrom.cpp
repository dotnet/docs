//<Snippet1>
using namespace System;
using namespace System::Collections::Generic;

ref class Room
{
};

ref class Kitchen : Room
{
};

ref class Bedroom : Room
{
};

ref class Guestroom : Bedroom
{
};

ref class MasterBedroom : Bedroom
{
};

ref class Program
{
public:
    static void Main()
    {
            // Demonstrate classes:
            Console::WriteLine("Defined Classes:");
            Room^ room1 = gcnew Room();
            Kitchen^ kitchen1 = gcnew Kitchen();
            Bedroom^ bedroom1 = gcnew Bedroom();
            Guestroom^ guestroom1 = gcnew Guestroom();
            MasterBedroom^ masterbedroom1 = gcnew MasterBedroom();

            Type^ room1Type = room1->GetType();
            Type^ kitchen1Type = kitchen1->GetType();
            Type^ bedroom1Type = bedroom1->GetType();
            Type^ guestroom1Type = guestroom1->GetType();
            Type^ masterbedroom1Type = masterbedroom1->GetType();

            Console::WriteLine("room assignable from kitchen: {0}", room1Type->IsAssignableFrom(kitchen1Type));
            Console::WriteLine("bedroom assignable from guestroom: {0}", bedroom1Type->IsAssignableFrom(guestroom1Type));
            Console::WriteLine("kitchen assignable from masterbedroom: {0}", kitchen1Type->IsAssignableFrom(masterbedroom1Type));

            // Demonstrate arrays:
            Console::WriteLine();
            Console::WriteLine("Integer arrays:");
            array<Int32>^ array2 = gcnew array<Int32>(2);
            array<Int32>^ array10 = gcnew array<Int32>(10);
            array<Int32, 2>^ array22 = gcnew array<Int32, 2>(2, 2);
            array<Int32, 2>^ array24 = gcnew array<Int32, 2>(2, 4);

            Type^ array2Type = array2->GetType();
            Type^ array10Type = array10->GetType();
            Type^ array22Type = array22->GetType();
            Type^ array24Type = array24->GetType();

            Console::WriteLine("Int32[2] assignable from Int32[10]: {0}", array2Type->IsAssignableFrom(array10Type));
            Console::WriteLine("Int32[2] assignable from Int32[2,4]: {0}", array2Type->IsAssignableFrom(array24Type));
            Console::WriteLine("Int32[2,4] assignable from Int32[2,2]: {0}", array24Type->IsAssignableFrom(array22Type));

            // Demonstrate generics:
            Console::WriteLine();
            Console::WriteLine("Generics:");

            // Note that "int?[]" is the same as "Nullable<int>[]"
            //int?[] arrayNull = new int?[10];
            array<Nullable^>^ arrayNull = gcnew array<Nullable^>(10);
            List<Int32>^ genIntList = gcnew List<Int32>();
            List<Type^>^ genTList = gcnew List<Type^>();

            Type^ arrayNullType = arrayNull->GetType();
            Type^ genIntListType = genIntList->GetType();
            Type^ genTListType = genTList->GetType();

            Console::WriteLine("Int32[10] assignable from Nullable[10]: {0}", array10Type->IsAssignableFrom(arrayNullType));
            Console::WriteLine("List<Int32> assignable from List<Type^>: {0}", genIntListType->IsAssignableFrom(genTListType));
            Console::WriteLine("List<Type^> assignable from List<Int32>: {0}", genTListType->IsAssignableFrom(genIntListType));

            Console::ReadLine();
    }
};

int main()
{
    Program::Main();
}

//This code example produces the following output:
//
// Defned Classes:
// room assignable from kitchen: True
// bedroom assignable from guestroom: True
//kitchen assignable from masterbedroom: False
//
// Integer arrays:
// Int32[2] assignable from Int32[10]: True
// Int32[2] assignable from Int32[2,4]: False
// Int32[2,4] assignable from Int32[2,2]: True
//
// Generics:
// Int32[10] assignable from Nullable[10]: False
// List<Int32> assignable from List<Type^>: False
// List<Type^> assignable from List<Int32>: False
//</Snippet1>