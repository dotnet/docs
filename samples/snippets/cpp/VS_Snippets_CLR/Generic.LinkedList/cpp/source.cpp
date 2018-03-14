// REDMOND\glennha
// <Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Text;
using namespace System::Collections::Generic;

public ref class Example
{
public:
    static void Main()
    {
        // <Snippet2>
        // Create the link list.
        array<String^>^ words =
            { "the", "fox", "jumped", "over", "the", "dog" };
        LinkedList<String^>^ sentence = gcnew LinkedList<String^>(words);
        Display(sentence, "The linked list values:");
        Console::WriteLine("sentence.Contains(\"jumped\") = {0}",
            sentence->Contains("jumped"));
        // </Snippet2>

        // Add the word 'today' to the beginning of the linked list.
        sentence->AddFirst("today");
        Display(sentence, "Test 1: Add 'today' to beginning of the list:");

        // <Snippet3>
        // Move the first node to be the last node.
        LinkedListNode<String^>^ mark1 = sentence->First;
        sentence->RemoveFirst();
        sentence->AddLast(mark1);
        // </Snippet3>
        Display(sentence, "Test 2: Move first node to be last node:");

        // Change the last node be 'yesterday'.
        sentence->RemoveLast();
        sentence->AddLast("yesterday");
        Display(sentence, "Test 3: Change the last node to 'yesterday':");

        // <Snippet4>
        // Move the last node to be the first node.
        mark1 = sentence->Last;
        sentence->RemoveLast();
        sentence->AddFirst(mark1);
        // </Snippet4>
        Display(sentence, "Test 4: Move last node to be first node:");


        // <Snippet12>
        // Indicate, by using parentheisis, the last occurence of 'the'.
        sentence->RemoveFirst();
        LinkedListNode<String^>^ current = sentence->FindLast("the");
        // </Snippet12>
        IndicateNode(current, "Test 5: Indicate last occurence of 'the':");

        // <Snippet5>
        // Add 'lazy' and 'old' after 'the' (the LinkedListNode named current).
        sentence->AddAfter(current, "old");
        sentence->AddAfter(current, "lazy");
        // </Snippet5>
        IndicateNode(current, "Test 6: Add 'lazy' and 'old' after 'the':");

        // <Snippet6>
        // Indicate 'fox' node.
        current = sentence->Find("fox");
        IndicateNode(current, "Test 7: Indicate the 'fox' node:");

        // Add 'quick' and 'brown' before 'fox':
        sentence->AddBefore(current, "quick");
        sentence->AddBefore(current, "brown");
        // </Snippet6>
        IndicateNode(current, "Test 8: Add 'quick' and 'brown' before 'fox':");

        // Keep a reference to the current node, 'fox',
        // and to the previous node in the list. Indicate the 'dog' node.
        mark1 = current;
        LinkedListNode<String^>^ mark2 = current->Previous;
        current = sentence->Find("dog");
        IndicateNode(current, "Test 9: Indicate the 'dog' node:");

        // The AddBefore method throws an InvalidOperationException
        // if you try to add a node that already belongs to a list.
        Console::WriteLine("Test 10: Throw exception by adding node (fox) already in the list:");
        try
        {
            sentence->AddBefore(current, mark1);
        }
        catch (InvalidOperationException^ ex)
        {
            Console::WriteLine("Exception message: {0}", ex->Message);
        }
        Console::WriteLine();

        // <Snippet7>
        // Remove the node referred to by mark1, and then add it
        // before the node referred to by current.
        // Indicate the node referred to by current.
        sentence->Remove(mark1);
        sentence->AddBefore(current, mark1);
        // </Snippet7>
        IndicateNode(current, "Test 11: Move a referenced node (fox) before the current node (dog):");

        // <Snippet8>
        // Remove the node referred to by current.
        sentence->Remove(current);
        // </Snippet8>
        IndicateNode(current, "Test 12: Remove current node (dog) and attempt to indicate it:");

        // Add the node after the node referred to by mark2.
        sentence->AddAfter(mark2, current);
        IndicateNode(current, "Test 13: Add node removed in test 11 after a referenced node (brown):");

        // The Remove method finds and removes the
        // first node that that has the specified value.
        sentence->Remove("old");
        Display(sentence, "Test 14: Remove node that has the value 'old':");

        // <Snippet9>
        // When the linked list is cast to ICollection(Of String),
        // the Add method adds a node to the end of the list.
        sentence->RemoveLast();
        ICollection<String^>^ icoll = sentence;
        icoll->Add("rhinoceros");
        // </Snippet9>
        Display(sentence, "Test 15: Remove last node, cast to ICollection, and add 'rhinoceros':");

        Console::WriteLine("Test 16: Copy the list to an array:");
        //<Snippet10>
        // Create an array with the same number of
        // elements as the inked list.
        array<String^>^ sArray = gcnew array<String^>(sentence->Count);
        sentence->CopyTo(sArray, 0);

        for each (String^ s in sArray)
        {
            Console::WriteLine(s);
        }
        //</Snippet10>


        //<Snippet11>
        // Release all the nodes.
        sentence->Clear();

        Console::WriteLine();
        Console::WriteLine("Test 17: Clear linked list. Contains 'jumped' = {0}",
            sentence->Contains("jumped"));
        //</Snippet11>

        Console::ReadLine();
    }

private:
    static void Display(LinkedList<String^>^ words, String^ test)
    {
        Console::WriteLine(test);
        for each (String^ word in words)
        {
            Console::Write(word + " ");
        }
        Console::WriteLine();
        Console::WriteLine();
    }

    static void IndicateNode(LinkedListNode<String^>^ node, String^ test)
    {
        Console::WriteLine(test);
        if (node->List == nullptr)
        {
            Console::WriteLine("Node '{0}' is not in the list.\n",
                node->Value);
            return;
        }

        StringBuilder^ result = gcnew StringBuilder("(" + node->Value + ")");
        LinkedListNode<String^>^ nodeP = node->Previous;

        while (nodeP != nullptr)
        {
            result->Insert(0, nodeP->Value + " ");
            nodeP = nodeP->Previous;
        }

        node = node->Next;
        while (node != nullptr)
        {
            result->Append(" " + node->Value);
            node = node->Next;
        }

        Console::WriteLine(result);
        Console::WriteLine();
    }
};

int main()
{
    Example::Main();
}

//This code example produces the following output:
//
//The linked list values:
//the fox jumped over the dog

//Test 1: Add 'today' to beginning of the list:
//today the fox jumped over the dog

//Test 2: Move first node to be last node:
//the fox jumped over the dog today

//Test 3: Change the last node to 'yesterday':
//the fox jumped over the dog yesterday

//Test 4: Move last node to be first node:
//yesterday the fox jumped over the dog

//Test 5: Indicate last occurence of 'the':
//the fox jumped over (the) dog

//Test 6: Add 'lazy' and 'old' after 'the':
//the fox jumped over (the) lazy old dog

//Test 7: Indicate the 'fox' node:
//the (fox) jumped over the lazy old dog

//Test 8: Add 'quick' and 'brown' before 'fox':
//the quick brown (fox) jumped over the lazy old dog

//Test 9: Indicate the 'dog' node:
//the quick brown fox jumped over the lazy old (dog)

//Test 10: Throw exception by adding node (fox) already in the list:
//Exception message: The LinkedList node belongs a LinkedList.

//Test 11: Move a referenced node (fox) before the current node (dog):
//the quick brown jumped over the lazy old fox (dog)

//Test 12: Remove current node (dog) and attempt to indicate it:
//Node 'dog' is not in the list.

//Test 13: Add node removed in test 11 after a referenced node (brown):
//the quick brown (dog) jumped over the lazy old fox

//Test 14: Remove node that has the value 'old':
//the quick brown dog jumped over the lazy fox

//Test 15: Remove last node, cast to ICollection, and add 'rhinoceros':
//the quick brown dog jumped over the lazy rhinoceros

//Test 16: Copy the list to an array:
//the
//quick
//brown
//dog
//jumped
//over
//the
//lazy
//rhinoceros

//Test 17: Clear linked list. Contains 'jumped' = False
//
// </Snippet1>
