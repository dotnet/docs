#pragma once

namespace PublicEnumTest
{

    //<snippet01>
    // Define the enum
    public enum class TrafficLight : int { Red, Yellow, Green }; 
    //…
    //</snippet01>

    public ref class Class1 sealed
    {
    public:
        Class1()
        {
            //<snippet02>
            // Consume the enum:
            TrafficLight myLight = TrafficLight::Red;
            if (myLight == TrafficLight::Green) 
            {
                //...
            } 
            //</snippet02>

        }

    };

    //<snippet03>
    // Underlying type is int32
    public enum class Enum1
    {
        Zero,
        One,
        Two,
        Three
    };

    public enum class Enum2
    {
        None = 0,
        First,      // First == 1
        Some = 5,
        Many = 10
    };

    // Underlying type is unsigned int
    // for Flags. Must be explicitly specified
    using namespace Platform::Metadata;
    [Flags]
    public enum class BitField : unsigned int 
    {
        Mask0 = 0x0,
        Mask2 = 0x2,
        Mask4 = 0x4,
        Mask8 = 0x8
    };

    Enum1 e1 = Enum1::One;
    int v1 = static_cast<int>(e1);
    int v2 = static_cast<int>(Enum2::First);
    //</snippet03>

    
    ref class PrivateClass
    {
        void DoSomething()
        {
            //<snippet04>
            if (e1 == Enum1::One) { /* ... */ }
            //if (e1 == Enum2::First) { /* ... */ } // yields compile error C3063
           
            static_assert(sizeof(Enum1) == 4, "sizeof(Enum1) should be 4");

            BitField x = BitField::Mask0 | BitField::Mask2 | BitField::Mask4;
            if ((x & BitField::Mask2) == BitField::Mask2) { /*   */ } 
            //</snippet04>
        }
    };
}