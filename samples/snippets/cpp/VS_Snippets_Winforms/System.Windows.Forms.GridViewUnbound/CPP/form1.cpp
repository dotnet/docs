

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;

public ref class Form1: public System::Windows::Forms::Form
{
private:
   Panel^ buttonPanel;
   DataGridView^ dataGridView1;
   Button^ addNewRowButton;
   Button^ deleteRowButton;
   Button^ ledgerStyleButton;
   bool editedLastColumn;

public:
   Form1()
   {
      buttonPanel = gcnew Panel;
      dataGridView1 = gcnew DataGridView;
      addNewRowButton = gcnew Button;
      deleteRowButton = gcnew Button;
      ledgerStyleButton = gcnew Button;
      editedLastColumn = false;
      this->Load += gcnew System::EventHandler( this, &Form1::Form1_Load );
   }


private:
   void Form1_Load( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      SetUpLayout();
      SetUpDataGridView();
      StyleCells();
      PopulateDataGridView();
   }


   // Set up the button and button panel.
   void SetUpLayout()
   {
      this->Size = System::Drawing::Size( 600, 600 );
      {
         addNewRowButton->Text = "Add Row";
         addNewRowButton->Location = Point(10,10);
      }
      {
         deleteRowButton->Text = "Delete Row";
         deleteRowButton->Location = Point(100,10);
      }
      {
         ledgerStyleButton->Text = "Ledger Style";
         ledgerStyleButton->Size = System::Drawing::Size( 80, 30 );
         ledgerStyleButton->Location = Point(200,10);
      }
      {
         buttonPanel->Controls->Add( addNewRowButton );
         buttonPanel->Controls->Add( deleteRowButton );
         buttonPanel->Controls->Add( ledgerStyleButton );
         buttonPanel->Height = 50;
         buttonPanel->Dock = DockStyle::Bottom;
      }
      this->Controls->Add( this->buttonPanel );
   }

   //<snippet1>
   void dataGridView1_CellFormatting( Object^ /*sender*/, DataGridViewCellFormattingEventArgs^ e )
   {
      // If the column is the Artist column, check the
      // value.
      if ( this->dataGridView1->Columns[ e->ColumnIndex ]->Name->Equals( "Artist" ) )
      {
         if ( e->Value != nullptr )
         {
            // Check for the string "pink" in the cell.
            String^ stringValue = dynamic_cast<String^>(e->Value);
            stringValue = stringValue->ToLower();
            if ( (stringValue->IndexOf( "pink" ) > -1) )
            {
               DataGridViewCellStyle^ pinkStyle = gcnew DataGridViewCellStyle;

               //Change the style of the cell.
               pinkStyle->BackColor = Color::Pink;
               pinkStyle->ForeColor = Color::Black;
               pinkStyle->Font = gcnew System::Drawing::Font( "Times New Roman",8,FontStyle::Bold );
               e->CellStyle = pinkStyle;
            }
            
         }
      }
      else
      if ( this->dataGridView1->Columns[ e->ColumnIndex ]->Name->Equals( "Release Date" ) )
      {
         ShortFormDateFormat( e );
      }
   }


   //Even though the date internaly stores the year as YYYY, using formatting, the
   //UI can have the format in YY.  
   void ShortFormDateFormat( DataGridViewCellFormattingEventArgs^ formatting )
   {
      if ( formatting->Value != nullptr )
      {
         try
         {
            System::Text::StringBuilder^ dateString = gcnew System::Text::StringBuilder;
            DateTime theDate = DateTime::Parse( formatting->Value->ToString() );
            dateString->Append( theDate.Month );
            dateString->Append( "/" );
            dateString->Append( theDate.Day );
            dateString->Append( "/" );
            dateString->Append( theDate.Year.ToString()->Substring( 2 ) );
            formatting->Value = dateString->ToString();
            formatting->FormattingApplied = true;
         }
         catch ( Exception^ /*notInDateFormat*/ ) 
         {
            // Set to false in case there are other handlers interested trying to
            // format this DataGridViewCellFormattingEventArgs instance.
            formatting->FormattingApplied = false;
         }

      }
   }
   //</snippet1>

   //<snippet2>
   // Handling CellParsing allows one to accept user input, then map it to a different
   // internal representation.
   void dataGridView1_CellParsing( Object^ /*sender*/, DataGridViewCellParsingEventArgs^ e )
   {
      if ( this->dataGridView1->Columns[ e->ColumnIndex ]->Name->Equals( "Release Date" ) )
      {
         if ( e != nullptr )
         {
            if ( e->Value != nullptr )
            {
               try
               {
                  // Map what the user typed into UTC.
                  e->Value = DateTime::Parse( e->Value->ToString() ).ToUniversalTime();

                  // Set the ParsingApplied property to 
                  // Show the event is handled.
                  e->ParsingApplied = true;
               }
               catch ( FormatException^ /*ex*/ ) 
               {
                  // Set to false in case another CellParsing handler
                  // wants to try to parse this DataGridViewCellParsingEventArgs instance.
                  e->ParsingApplied = false;
               }
            }
         }
      }
   }
   //</snippet2>

   //<snippet3>
   void addNewRowButton_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      this->dataGridView1->Rows->Add();
   }
   //</snippet3>

   //<snippet4>
   void deleteRowButton_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      if ( this->dataGridView1->SelectedRows->Count > 0 && this->dataGridView1->SelectedRows[ 0 ]->Index != this->dataGridView1->Rows->Count - 1 )
      {
         this->dataGridView1->Rows->RemoveAt( this->dataGridView1->SelectedRows[ 0 ]->Index );
      }
   }
   //</snippet4>

   //<snippet8>
   //<snippet7>
   void ledgerStyleButton_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Create a new cell style.
      DataGridViewCellStyle^ style = gcnew DataGridViewCellStyle;
      {
         style->BackColor = Color::Beige;
         style->ForeColor = Color::Brown;
         style->Font = gcnew System::Drawing::Font( "Verdana",8 );
      }

      // Apply the style as the default cell style.
      dataGridView1->AlternatingRowsDefaultCellStyle = style;
      ledgerStyleButton->Enabled = false;
   }
   //</snippet7>

   //<snippet5>
   void SetUpDataGridView()
   {
      this->Controls->Add( dataGridView1 );
      dataGridView1->ColumnCount = 5;
      DataGridViewCellStyle^ style = dataGridView1->ColumnHeadersDefaultCellStyle;
      style->BackColor = Color::Navy;
      style->ForeColor = Color::White;
      style->Font = gcnew System::Drawing::Font( dataGridView1->Font,FontStyle::Bold );
      dataGridView1->EditMode = DataGridViewEditMode::EditOnEnter;
      dataGridView1->Name = "dataGridView1";
      dataGridView1->Location = Point(8,8);
      dataGridView1->Size = System::Drawing::Size( 500, 300 );
      dataGridView1->AutoSizeRowsMode = DataGridViewAutoSizeRowsMode::DisplayedCellsExceptHeaders;
      dataGridView1->ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle::Raised;
      dataGridView1->CellBorderStyle = DataGridViewCellBorderStyle::Single;
      dataGridView1->GridColor = SystemColors::ActiveBorder;
      dataGridView1->RowHeadersVisible = false;
      dataGridView1->Columns[ 0 ]->Name = "Release Date";
      dataGridView1->Columns[ 1 ]->Name = "Track";
      dataGridView1->Columns[ 1 ]->DefaultCellStyle->Alignment = DataGridViewContentAlignment::MiddleCenter;
      dataGridView1->Columns[ 2 ]->Name = "Title";
      dataGridView1->Columns[ 3 ]->Name = "Artist";
      dataGridView1->Columns[ 4 ]->Name = "Album";

      // Make the font italic for row four.
      dataGridView1->Columns[ 4 ]->DefaultCellStyle->Font = gcnew System::Drawing::Font( DataGridView::DefaultFont,FontStyle::Italic );
      dataGridView1->SelectionMode = DataGridViewSelectionMode::FullRowSelect;
      dataGridView1->MultiSelect = false;
      dataGridView1->BackgroundColor = Color::Honeydew;
      dataGridView1->Dock = DockStyle::Fill;
      dataGridView1->CellFormatting += gcnew DataGridViewCellFormattingEventHandler( this, &Form1::dataGridView1_CellFormatting );
      dataGridView1->CellParsing += gcnew DataGridViewCellParsingEventHandler( this, &Form1::dataGridView1_CellParsing );
      addNewRowButton->Click += gcnew EventHandler( this, &Form1::addNewRowButton_Click );
      deleteRowButton->Click += gcnew EventHandler( this, &Form1::deleteRowButton_Click );
      ledgerStyleButton->Click += gcnew EventHandler( this, &Form1::ledgerStyleButton_Click );
      dataGridView1->CellValidating += gcnew DataGridViewCellValidatingEventHandler( this, &Form1::dataGridView1_CellValidating );
   }
   //</snippet5>

   //<snippet6>
   void PopulateDataGridView()
   {
      // Create the string array for each row of data.
      array<String^>^row0 = {"11/22/1968","29","Revolution 9","Beatles","The Beatles [White Album]"};
      array<String^>^row1 = {"4/4/1960","6","Fools Rush In","Frank Sinatra","Nice 'N' Easy"};
      array<String^>^row2 = {"11/11/1971","1","One of These Days","Pink Floyd","Meddle"};
      array<String^>^row3 = {"4/4/1988","7","Where Is My Mind?","Pixies","Surfer Rosa"};
      array<String^>^row4 = {"5/1981","9","Can't Find My Mind","Cramps","Psychedelic Jungle"};
      array<String^>^row5 = {"6/10/2003","13","Scatterbrain. (As Dead As Leaves.)","Radiohead","Hail to the Thief"};
      array<String^>^row6 = {"6/30/1992","3","Dress","P J Harvey","Dry"};

      // Add a row for each string array.
      {
         DataGridViewRowCollection^ rows = this->dataGridView1->Rows;
         rows->Add( row0 );
         rows->Add( row1 );
         rows->Add( row2 );
         rows->Add( row3 );
         rows->Add( row4 );
         rows->Add( row5 );
         rows->Add( row6 );
      }

      // Change the order the columns are displayed.
      {
         DataGridViewColumnCollection^ columns = this->dataGridView1->Columns;
         columns[ 0 ]->DisplayIndex = 3;
         columns[ 1 ]->DisplayIndex = 4;
         columns[ 2 ]->DisplayIndex = 0;
         columns[ 3 ]->DisplayIndex = 1;
         columns[ 4 ]->DisplayIndex = 2;
      }
   }
   //</snippet6>
   //</snippet8>

   //<snippet9>
   void dataGridView1_CellValidating( Object^ /*sender*/, DataGridViewCellValidatingEventArgs^ newValue )
   {
      DataGridViewColumn^ column = dataGridView1->Columns[ newValue->ColumnIndex ];
      if ( column->Name->Equals( "Track" ) )
      {
         CheckTrack( newValue );
      }
      else
      if ( column->Name->Equals( "Release Date" ) )
      {
         CheckDate( newValue );
      }
   }

   void CheckTrack( DataGridViewCellValidatingEventArgs^ newValue )
   {
      Int32 ignored;
      if ( newValue->FormattedValue->ToString() == String::Empty )
      {
         NotifyUserAndForceRedo( "Please enter a track", newValue );
      }
      else
      if (  !Int32::TryParse( newValue->FormattedValue->ToString(), ignored ) )
      {
         NotifyUserAndForceRedo( "A Track must be a number", newValue );
      }
      else
      if ( Int32::Parse( newValue->FormattedValue->ToString() ) < 1 )
      {
         NotifyUserAndForceRedo( "Not a valid track", newValue );
         editedLastColumn = true;
      }
   }

   void NotifyUserAndForceRedo( String^ errorMessage, DataGridViewCellValidatingEventArgs^ newValue )
   {
      MessageBox::Show( errorMessage );
      newValue->Cancel = true;
   }

   void CheckDate( DataGridViewCellValidatingEventArgs^ newValue )
   {
      try
      {
         DateTime::Parse( newValue->FormattedValue->ToString() ).ToLongDateString();
         AnnotateCell( String::Empty, newValue );
      }
      catch ( FormatException^ /*ex*/ ) 
      {
         AnnotateCell( "You did not enter a valid date.", newValue );
      }
   }

   void AnnotateCell( String^ errorMessage, DataGridViewCellValidatingEventArgs^ editEvent )
   {
      DataGridViewCell^ cell = dataGridView1->Rows[ editEvent->RowIndex ]->Cells[ editEvent->ColumnIndex ];
      cell->ErrorText = errorMessage;
   }
   //</snippet9>

   //Private Sub TurnOff_EditOnEnter(ByVal sender As Object, ByVal args As DataGridViewCellEventArgs) Handles dataGridView1.RowValidated
   //    If editedLastColumn Then
   //        dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically
   //    End If
   //End Sub
   //<snippet10>
   void StyleCells()
   {
      dataGridView1->CellBorderStyle = DataGridViewCellBorderStyle::None;
      dataGridView1->CellBorderStyle = DataGridViewCellBorderStyle::Single;
   }
   //</snippet10>
};

int main()
{
   try
   {
      Application::Run( gcnew Form1 );
   }
   catch ( Exception^ e ) 
   {
      MessageBox::Show( e->ToString() );
   }

}

