//<Snippet2>
#using <System.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Resources;
using namespace System::ComponentModel::Design;

namespace UseDataNodesExample
{
    public ref class Program
    {
    public:
        static void Main()
        {
            Console::WriteLine("\nEnumerating as data items...");
            EnumResourceItems("Resource1.resx", false);

            Console::WriteLine("\nEnumerating as data nodes...");
            EnumResourceItems("Resource1.resx", true);
        }

        static void EnumResourceItems(String^ resxFile, bool useDataNodes)
        {
            ResXResourceReader^ reader = gcnew ResXResourceReader(resxFile);

            reader->UseResXDataNodes = useDataNodes;

            //<Snippet3>
            // Enumerate using IEnumerable.GetEnumerator().
            Console::WriteLine("\n  Default enumerator:");
            for each (DictionaryEntry entry in reader)
            {
                ShowResourceItem(entry, useDataNodes);
            }
            //</Snippet3>

            //<Snippet4>
            // Enumerate using GetMetadataEnumerator()
            IDictionaryEnumerator^ metadataEnumerator = reader->GetMetadataEnumerator();

            Console::WriteLine("\n  MetadataEnumerator:");
            while (metadataEnumerator->MoveNext())
            {
                ShowResourceItem(metadataEnumerator->Entry, useDataNodes);
            }
            //</Snippet4>

            //<Snippet5>
            // Enumerate using GetEnumerator()
            IDictionaryEnumerator^ enumerator = reader->GetEnumerator();

            Console::WriteLine("\n  Enumerator:");
            while (enumerator->MoveNext())
            {
                ShowResourceItem(enumerator->Entry, useDataNodes);
            }
            //</Snippet5>
            delete reader;
        }

        static void ShowResourceItem(DictionaryEntry entry, bool isDataNode)
        {
            // Use a nullptr type resolver.
            ITypeResolutionService^ typeres = nullptr;
            ResXDataNode^ dnode;

            if (isDataNode)
            {
                // Display from node info.
                dnode = (ResXDataNode^)entry.Value;
                Console::WriteLine("  {0}={1}", dnode->Name, dnode->GetValue(typeres));
            }
            else
            {
                // Display as DictionaryEntry info.
                Console::WriteLine("  {0}={1}", entry.Key, entry.Value);
            }
        }
    };
}

int main()
{
    UseDataNodesExample::Program::Main();
}
// The example program will have the following output:
//
// Enumerating as data items...
//
//   Default enumerator:
//   DataSample=Sample DATA value
//
//   MetadataEnumerator:
//   MetadataSample=Sample METADATA value
//
//   Enumerator:
//   DataSample=Sample DATA value
//
// Enumerating as data nodes...
//
//   Default enumerator:
//   DataSample=Sample DATA value
//   MetadataSample=Sample METADATA value
//
//   MetadataEnumerator:
//
//   Enumerator:
//   DataSample=Sample DATA value
//   MetadataSample=Sample METADATA value
//</Snippet2>