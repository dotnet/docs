// <Snippet1>
// InstanceData_CopyTo.cpp : main project file.
#using <System.dll>

using namespace System;
using namespace System::Diagnostics;


///////////////////////////////////////////////////////////////////////
//
// FORWARD DECLARATIONS
//
///////////////////////////////////////////////////////////////////////

// Console Utility Functions:
void InitConsole();                          // Init console size
void TitleBlock();                           // Write the title block
void CW(String^strText ,                    // Write a colored string
        String^ C = "", int LF = 1);


// InstanceData subroutines
// Display the contents of an InstanceData object.
void ProcessInstanceDataObject(String^ name, CounterSample CSRef);

// Display the contents of an InstanceDataCollection.
void ProcessInstanceDataCollection(InstanceDataCollection^ idCol);




///////////////////////////////////////////////////////////////////////
//
// MAIN PROGRAM
//
///////////////////////////////////////////////////////////////////////

void main()
{
    InitConsole();
    TitleBlock();

    String^ categoryName;
    String^ catNumStr;
    int      categoryNum;


    array<PerformanceCounterCategory^>^ categories =
                PerformanceCounterCategory::GetCategories();

    // Create and sort an array of category names.
    array<String^>^ categoryNames = gcnew array<String^>(categories->Length);
    int catX;
    for(catX=0; catX < categories->Length; catX++)
            categoryNames[catX] = categories[catX]->CategoryName;
    Array::Sort(categoryNames);

    while(1)
    {
    CW("These PerformanceCounterCategory categories are registered \n"
      +"on this computer:","Red");

    for(catX=0; catX < categories->Length; catX++)
            Console::WriteLine("{0,4} - {1}", catX+1, categoryNames[catX]);

    // Ask the user to choose a category.
    Console::Write("\nEnter a category number from the above list: ");
    catNumStr = Console::ReadLine();

    // Validate the entered category number.
    try {
        categoryNum = int::Parse(catNumStr);
        if (categoryNum < 1 || categoryNum > categories->Length)
            throw gcnew Exception(String::Format("The category number "+
                  " must be in the range 1..{0}.", categories->Length));
        categoryName = categoryNames[(categoryNum-1)];

        // Process the InstanceDataCollectionCollection for this category.
        PerformanceCounterCategory^ pcc =
             gcnew PerformanceCounterCategory(categoryName);
        InstanceDataCollectionCollection^ idColCol = pcc->ReadCategory();
        array<InstanceDataCollection^>^ idColArray =
             gcnew array<InstanceDataCollection^>(idColCol->Count);

        CW("\nInstanceDataCollectionCollection for \"" +categoryName+"\" "
           +"has "+idColCol->Count+" elements.","Blue");

        idColCol->CopyTo(idColArray, 0);

        for each ( InstanceDataCollection ^ idCol in idColArray )
                ProcessInstanceDataCollection(idCol);
        }
    catch(Exception^ ex)
        {
        Console::WriteLine("\"{0}\" is not a valid category number." +
            "\n{1}", catNumStr, ex->Message);
        }

    CW("\n\nRun again (Y,N)?","Yellow");
    catNumStr = Console::ReadLine();
    if ("Y" != catNumStr && "y" != catNumStr) break;
    }
}


///////////////////////////////////////////////////////////////////////
//
// SUBROUTINES
//
///////////////////////////////////////////////////////////////////////

void InitConsole() 
{
  Console::BufferHeight = 4000;
  Console::WindowHeight = 40;
}

void TitleBlock()
{
Console::Title = "InstDataCopyTo.cpp Sample";

CW(
 "///////////////////////////////////////////////////////////////////\n"
+"//\n"
+"//  PROGRAM   instdatacopyto.cpp\n"
+"//  PURPOSE   Show how to use InstanceData objects\n"
+"//  OUTPUT    1) Displays a numbered list of PerformanceCounter\n"
+"//               categories that exist on the local computer.\n"
+"//            2) Prompts the user to select a category.\n"
+"//            3) Displays the instance data associated with each\n"
+"//               instance of the PerformanceCounter in the\n"
+"//               selected PerformanceCounterCategory\n"
+"//\n"
+ "///////////////////////////////////////////////////////////////////\n"
,"Yellow");
}


// Utility function:  ConsoleWrite:  Write a colored string
void CW(String^ strText , String^ C, int LF)
{
   if (C != "") Console::ForegroundColor =  *dynamic_cast<ConsoleColor^>
                               (Enum::Parse(ConsoleColor::typeid, C));
   Console::Write(strText);
   Console::ResetColor();
   Console::Write("\n{0}",LF?"\n":"");
}

// Display the contents of an InstanceDataCollection.
void ProcessInstanceDataCollection(InstanceDataCollection ^ idCol)
{
    array<InstanceData^>^ instDataArray = gcnew array<InstanceData^>(idCol->Count);

    CW("\n  InstanceDataCollection for \""
       + idCol->CounterName + "\" has " + idCol->Count + " elements.", "Red");

    // Copy and process the InstanceData array.
    idCol->CopyTo(instDataArray, 0);

    int idX;
    for(idX=0; idX < instDataArray->Length; idX++)
        ProcessInstanceDataObject(instDataArray[idX]->InstanceName,
        instDataArray[idX]->Sample);
}


// Display the contents of an InstanceData object.
void ProcessInstanceDataObject(String ^ name, CounterSample CSRef)
{
    InstanceData ^ instData = gcnew InstanceData(name, CSRef);
    CW("    Data from InstanceData object:","Red",0);

    CW("      InstanceName:     "+instData->InstanceName,"Green",0);
    CW("      RawValue:         " + instData->RawValue);

    CounterSample sample = instData->Sample;
    Console::Write("    Data from CounterSample object:\n" +
        "      CounterType:      {0,-27} SystemFrequency:  {1}\n" +
        "      BaseValue:        {2,-27} RawValue:         {3}\n" +
        "      CounterFrequency: {4,-27} CounterTimeStamp: {5}\n" +
        "      TimeStamp:        {6,-27} TimeStamp100nSec: {7}\n\n",
        sample.CounterType, sample.SystemFrequency, sample.BaseValue,
        sample.RawValue, sample.CounterFrequency, sample.CounterTimeStamp,
        sample.TimeStamp, sample.TimeStamp100nSec);
}
// </Snippet1>

