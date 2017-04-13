// <Snippet1>
using namespace System;
using namespace System::Collections::Generic;

public ref class Box : public IEquatable<Box^>
{
private:
    int height;
    int length;
    int width;

public:
    Box(int h, int l, int w)
    {
        this->height = h;
        this->length = l;
        this->width = w;
    }

    property int Height
    {
        int get() {return this->height;}
        void set(int value) {this->height = value;}
    }

    property int Length
    {
        int get() {return this->length;}
        void set(int value) {this->length = value;}
    }

    property int Width
    {
        int get() {return this->width;}
        void set(int value) {this->width = value;}
    }

    virtual bool Equals(Box^ other)
    {
        if (this->Height == other->Height & this->Length == other->Length
            & this->Width == other->Width)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
};

public ref class BoxEqDimensions : EqualityComparer<Box^>
{
public:
    virtual int GetHashCode(Box^ bx) override
    {
        int hCode = bx->Height ^ bx->Length ^ bx->Width;
        return hCode.GetHashCode();
    }

    virtual bool Equals(Box^ b1, Box^ b2) override
    {
        return EqualityComparer<Box^>::Default->Equals(b1, b2);
    }
};


public ref class BoxEqVolume : EqualityComparer<Box^>
{
public:
    virtual int GetHashCode(Box^ bx) override
    {
        int hCode = bx->Height ^ bx->Length ^ bx->Width;
        return hCode.GetHashCode();
    }

    virtual bool Equals(Box^ b1, Box^ b2) override
    {
        if (b1->Height * b1->Width * b1->Length ==
            b2->Height * b2->Width * b2->Length)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
};

public ref class Program
{
public:
    static void Main()
    {
        BoxEqDimensions^ bxd = gcnew BoxEqDimensions();
        BoxEqVolume^ bxv = gcnew BoxEqVolume();

        Dictionary<Box^, String^>^ boxesByDim = gcnew Dictionary<Box^, String^>(bxd);
        Dictionary<Box^, String^>^ boxesByVol = gcnew Dictionary<Box^, String^>(bxv);

        try
        {
            Box^ redBox = gcnew Box(8, 8, 4);
            Box^ blueBox = gcnew Box(6, 8, 4);
            Box^ greenBox = gcnew Box(4, 8, 8);

            Console::WriteLine("Adding boxes by Dimension");

            boxesByDim->Add(redBox, "red");
            boxesByDim->Add(blueBox, "blue");
            boxesByDim->Add(greenBox, "green");

            PrintBoxCollection(boxesByDim);

            Console::WriteLine("\nAdding boxes by Volume");

            boxesByVol->Add(redBox, "red");
            boxesByVol->Add(blueBox, "blue");
            boxesByVol->Add(greenBox, "green");

            PrintBoxCollection(boxesByVol);
        }
        catch (ArgumentException^ argEx)
        {
            Console::WriteLine(argEx->Message);
        }
    }
private:
    static void PrintBoxCollection(Dictionary<Box^,String^>^ boxes)
    {
        for each (KeyValuePair<Box^, String^> kvp in boxes)
        {
            Console::WriteLine("{0} x {1} x {2} - {3}", kvp.Key->Height.ToString(),
                                                       kvp.Key->Length.ToString(),
                                                       kvp.Key->Width.ToString(), kvp.Value);
        }
    }
};

int main()
{
    Program::Main();
}

/* This example produces the following output:
 * 
   Adding boxes by Dimension
    8 x 8 x 4 - red
    6 x 8 x 4 - blue
    4 x 8 x 8 - green

    Adding boxes by Volume
    An item with the same key has already been added.
 * 
 */ 
// </Snippet1>