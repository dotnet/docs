

//<Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Globalization;
public ref class SamplesDateTimeFormatInfo
{
public:
   static void Main()
   {
      
      // Creates a new DateTimeFormatinfo.
      DateTimeFormatInfo^ myDtfi = gcnew DateTimeFormatInfo;
      
      // Gets and prints all the patterns
      array<String^>^myPatternsArray = myDtfi->GetAllDateTimePatterns();
      Console::WriteLine(  "ALL the patterns:" );
      PrintIndexAndValues( myPatternsArray );
      
      // Gets and prints the pattern(s) associated with some of the format characters.
      myPatternsArray = myDtfi->GetAllDateTimePatterns( 'd' );
      Console::WriteLine(  "The patterns for 'd':" );
      PrintIndexAndValues( myPatternsArray );
      myPatternsArray = myDtfi->GetAllDateTimePatterns( 'D' );
      Console::WriteLine(  "The patterns for 'D':" );
      PrintIndexAndValues( myPatternsArray );
      myPatternsArray = myDtfi->GetAllDateTimePatterns( 'f' );
      Console::WriteLine(  "The patterns for 'f':" );
      PrintIndexAndValues( myPatternsArray );
      myPatternsArray = myDtfi->GetAllDateTimePatterns( 'F' );
      Console::WriteLine(  "The patterns for 'F':" );
      PrintIndexAndValues( myPatternsArray );
      myPatternsArray = myDtfi->GetAllDateTimePatterns( 'r' );
      Console::WriteLine(  "The patterns for 'r':" );
      PrintIndexAndValues( myPatternsArray );
      myPatternsArray = myDtfi->GetAllDateTimePatterns( 'R' );
      Console::WriteLine(  "The patterns for 'R':" );
      PrintIndexAndValues( myPatternsArray );
   }

    public:
       static void PrintIndexAndValues( array<String^>^myArray )  {
       int i = 0;
       for each ( String^ s in myArray )
           Console::WriteLine( "\t[{0}]:\t{1}", i++, s );
       Console::WriteLine();
    }
};

int main()
{
   SamplesDateTimeFormatInfo::Main();
}

/* 
This code produces the following output.

ALL the patterns:
        [0]:    MM/dd/yyyy
        [1]:    dddd, dd MMMM yyyy
        [2]:    dddd, dd MMMM yyyy HH:mm
        [3]:    dddd, dd MMMM yyyy hh:mm tt
        [4]:    dddd, dd MMMM yyyy H:mm
        [5]:    dddd, dd MMMM yyyy h:mm tt
        [6]:    dddd, dd MMMM yyyy HH:mm:ss
        [7]:    MM/dd/yyyy HH:mm
        [8]:    MM/dd/yyyy hh:mm tt
        [9]:    MM/dd/yyyy H:mm
        [10]:   MM/dd/yyyy h:mm tt
        [11]:   MM/dd/yyyy HH:mm:ss
        [12]:   MMMM dd
        [13]:   MMMM dd
        [14]:   ddd, dd MMM yyyy HH':'mm':'ss 'GMT'
        [15]:   ddd, dd MMM yyyy HH':'mm':'ss 'GMT'
        [16]:   yyyy'-'MM'-'dd'T'HH':'mm':'ss
        [17]:   HH:mm
        [18]:   hh:mm tt
        [19]:   H:mm
        [20]:   h:mm tt
        [21]:   HH:mm:ss
        [22]:   yyyy'-'MM'-'dd HH':'mm':'ss'Z'
        [23]:   dddd, dd MMMM yyyy HH:mm:ss
        [24]:   yyyy MMMM
        [25]:   yyyy MMMM

The patterns for 'd':
        [0]:    MM/dd/yyyy

The patterns for 'D':
        [0]:    dddd, dd MMMM yyyy

The patterns for 'f':
        [0]:    dddd, dd MMMM yyyy HH:mm
        [1]:    dddd, dd MMMM yyyy hh:mm tt
        [2]:    dddd, dd MMMM yyyy H:mm
        [3]:    dddd, dd MMMM yyyy h:mm tt

The patterns for 'F':
        [0]:    dddd, dd MMMM yyyy HH:mm:ss

The patterns for 'r':
        [0]:    ddd, dd MMM yyyy HH':'mm':'ss 'GMT'

The patterns for 'R':
        [0]:    ddd, dd MMM yyyy HH':'mm':'ss 'GMT'
*/
// </Snippet1>
