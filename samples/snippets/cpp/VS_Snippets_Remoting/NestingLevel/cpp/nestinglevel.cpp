//<Snippet1>
#using <System.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Xml;
using namespace System::Xml::Serialization;
using namespace System::IO;

public ref class Forest
{
    // Set the NestingLevel for each array. The first
    // attribute (NestingLevel = 0) is optional.
public:
    [XmlArrayItem(ElementName = "tree", NestingLevel = 0)]
    [XmlArrayItem(ElementName = "branch", NestingLevel = 1)]
    [XmlArrayItem(ElementName = "leaf",NestingLevel = 2)]
    array<array<array<String^>^>^>^ TreeArray;
};

int main()
{
    XmlSerializer^ serializer = gcnew XmlSerializer(Forest::typeid);

    Forest^ constructedForest = gcnew Forest();
    array<array<array<String^>^>^>^ tree = 
        gcnew array<array<array<String^>^>^>(2);

    array<array<String^>^>^ firstBranch = gcnew array<array<String^>^>(1);
    firstBranch[0] = gcnew array<String^>{"One"};
    tree[0] = firstBranch;

    array<array<String^>^>^ secondBranch = gcnew array<array<String^>^>(2);
    secondBranch[0] = gcnew array<String^>{"One","Two"};
    secondBranch[1] = gcnew array<String^>{"One","Two","Three"};
    tree[1] = secondBranch;

    constructedForest->TreeArray = tree;

    serializer->Serialize(Console::Out, constructedForest);
}

//</Snippet1>