

#using <system.dll>
#using <system.drawing.dll>
#using <system.data.dll>
#using <system.windows.forms.dll>
#using <system.xml.dll>

using namespace System;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Windows::Forms;

#define NULL 0L
public ref class Form1: public Form
{
private:
   DataGrid^ DataGrid1;
   DataSet^ DataSet1;
   void Setup()
   {
      DataGrid1 = gcnew DataGrid;
      DataSet1 = gcnew DataSet( "myDataSet" );
   }


   // <Snippet1>
   void PrintColumnInformation( DataGrid^ grid )
   {
      Console::WriteLine( "Count: {0}", grid->TableStyles->Count );
      GridColumnStylesCollection^ myColumns;
      DataGridTableStyle^ myTableStyle;
      for ( __int32 i = 0; i < grid->TableStyles->Count; i++ )
      {
         myTableStyle = grid->TableStyles[ i ];
         myColumns = myTableStyle->GridColumnStyles;
         
         /* Iterate through the collection and print each 
                  object's type and width. */
         DataGridColumnStyle^ dgCol;
         for ( __int32 j = 0; j < myColumns->Count; j++ )
         {
            dgCol = myColumns[ j ];
            Console::WriteLine( dgCol->MappingName );
            Console::WriteLine( dgCol->GetType()->ToString() );
            Console::WriteLine( dgCol->Width );

         }

      }
   }

   // </Snippet1>
};

int main()
{
   Form1^ f = gcnew Form1;
   return 0;
}
