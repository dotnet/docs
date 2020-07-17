
// This example demonstrates using images to create a 
// TicTacToe game.
//<snippet0>
#using <System.Drawing.dll>
#using <System.dll>
#using <system.windows.forms.dll>

using namespace System::IO;
using namespace System::Windows::Forms;
using namespace System::Drawing;
using namespace System;
public ref class TicTacToe: public System::Windows::Forms::Form
{
public:
   TicTacToe()
      : Form()
   {
      oBytes = gcnew array<Byte>{
        0x42, 0x4D, 0xC6, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x76, 
        0x0, 0x0, 0x0, 0x28, 0x0, 0x0, 0x0, 0xB, 0x0, 0x0, 0x0, 0xA,
        0x0, 0x0, 0x0, 0x1, 0x0, 0x4, 0x0, 0x0, 0x0, 0x0, 0x0, 0x50,
        0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x10,
        0x0, 0x0, 0x0, 0x10, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0,
        0x0, 0x80, 0x0, 0x0, 0x80, 0x0, 0x0, 0x0, 0x80, 0x80, 0x0, 
        0x80, 0x0, 0x0, 0x0, 0x80, 0x0, 0x80, 0x0, 0x80, 0x80, 0x0, 
        0x0, 0xC0, 0xC0, 0xC0, 0x0, 0x80, 0x80, 0x80, 0x0, 0x0, 0x0,
        0xFF, 0x0, 0x0, 0xFF, 0x0, 0x0, 0x0, 0xFF, 0xFF, 0x0, 0xFF, 
        0x0, 0x0, 0x0, 0xFF, 0x0, 0xFF, 0x0, 0xFF, 0xFF, 0x0, 0x0, 
        0xFF, 0xFF, 0xFF, 0x0, 0xFF, 0xFF, 0x0, 0xF, 0xFF, 0xF0, 
        0x0, 0x0, 0xFF, 0x0, 0xFF, 0xF0, 0xF, 0xF0, 0x0, 0x0, 0xF0, 
        0xFF, 0xFF, 0xFF, 0xF0, 0xF0, 0x0, 0x0, 0xF0, 0xFF, 0xFF, 
        0xFF, 0xF0, 0xF0, 0x0, 0x0, 0xF, 0xFF, 0xFF, 0xFF, 0xFF, 
        0x0, 0x0, 0x0, 0xF, 0xFF, 0xFF, 0xFF, 0xFF, 0x0, 0x0, 0x0, 
        0xF0, 0xFF, 0xFF, 0xFF, 0xF0, 0xF0, 0x0, 0x0, 0xF0, 0xFF, 
        0xFF, 0xFF, 0xF0, 0xF0, 0x0, 0x0, 0xFF, 0x0, 0xFF, 0xF0, 
        0xF, 0xF0, 0x0, 0x0, 0xFF, 0xFF, 0x0, 0xF, 0xFF, 0xF0, 0x0, 
        0x0};
      xBytes = gcnew array<Byte>{
        0x42, 0x4D, 0xC6, 0x0, 0x0, 0x0, 0x0, 
        0x0, 0x0, 0x0, 0x76, 0x0, 0x0, 0x0, 0x28, 0x0, 0x0, 0x0, 
        0xB, 0x0, 0x0, 0x0, 0xA, 0x0, 0x0, 0x0, 0x1, 0x0, 0x4, 0x0, 
        0x0, 0x0, 0x0, 0x0, 0x50, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0,
        0x0, 0x0, 0x0, 0x0, 0x10, 0x0, 0x0, 0x0, 0x10, 0x0, 0x0, 
        0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x80, 0x0, 0x0, 0x80, 
        0x0, 0x0, 0x0, 0x80, 0x80, 0x0, 0x80, 0x0, 0x0, 0x0, 0x80, 
        0x0, 0x80, 0x0, 0x80, 0x80, 0x0, 0x0, 0xC0, 0xC0, 0xC0, 0x0,
        0x80, 0x80, 0x80, 0x0, 0x0, 0x0, 0xFF, 0x0, 0x0, 0xFF, 0x0, 
        0x0, 0x0, 0xFF, 0xFF, 0x0, 0xFF, 0x0, 0x0, 0x0, 0xFF, 0x0, 
        0xFF, 0x0, 0xFF, 0xFF, 0x0, 0x0, 0xFF, 0xFF, 0xFF, 0x0, 
        0xF0, 0xFF, 0xFF, 0xFF, 0xF0, 0xF0, 0x0, 0x0, 0xFF, 0xF, 
        0xFF, 0xFF, 0xF, 0xF0, 0x0, 0x0, 0xFF, 0xF0, 0xFF, 0xF0, 
        0xFF, 0xF0, 0x0, 0x0, 0xFF, 0xFF, 0xF, 0xF, 0xFF, 0xF0, 0x0,
        0x0, 0xFF, 0xFF, 0xF, 0xF, 0xFF, 0xF0, 0x0, 0x0, 0xFF, 0xFF,
        0xF, 0xF, 0xFF, 0xF0, 0x0, 0x0, 0xFF, 0xF0, 0xFF, 0xF0, 
        0xFF, 0xF0, 0x0, 0x0, 0xFF, 0xF, 0xFF, 0xFF, 0xF, 0xF0, 0x0,
        0x0, 0xF0, 0xFF, 0xFF, 0xFF, 0xF0, 0xF0, 0x0, 0x0, 0xFF, 
        0xFF, 0xFF, 0xFF, 0xFF, 0xF0, 0x0, 0x0};
      blankBytes = gcnew array<Byte>{
        0x42, 0x4D, 0xC6, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x76, 
        0x0, 0x0, 0x0, 0x28, 0x0, 0x0, 0x0, 0xB, 0x0, 0x0, 0x0, 0xA,
        0x0, 0x0, 0x0, 0x1, 0x0, 0x4, 0x0, 0x0, 0x0, 0x0, 0x0, 0x50,
        0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x10,
        0x0, 0x0, 0x0, 0x10, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0,
        0x0, 0x80, 0x0, 0x0, 0x80, 0x0, 0x0, 0x0, 0x80, 0x80, 0x0, 
        0x80, 0x0, 0x0, 0x0, 0x80, 0x0, 0x80, 0x0, 0x80, 0x80, 0x0, 
        0x0, 0xC0, 0xC0, 0xC0, 0x0, 0x80, 0x80, 0x80, 0x0, 0x0, 0x0,
        0xFF, 0x0, 0x0, 0xFF, 0x0, 0x0, 0x0, 0xFF, 0xFF, 0x0, 0xFF, 
        0x0, 0x0, 0x0, 0xFF, 0x0, 0xFF, 0x0, 0xFF, 0xFF, 0x0, 0x0, 
        0xFF, 0xFF, 0xFF, 0x0, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xF0, 
        0x0, 0x0, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xF0, 0x0, 0x0, 
        0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xF0, 0x0, 0x0, 0xFF, 0xFF, 
        0xFF, 0xFF, 0xFF, 0xF0, 0x0, 0x0, 0xFF, 0xFF, 0xFF, 0xFF, 
        0xFF, 0xF0, 0x0, 0x0, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xF0, 
        0x0, 0x0, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xF0, 0x0, 0x0, 
        0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xF0, 0x0, 0x0, 0xFF, 0xFF, 
        0xFF, 0xFF, 0xFF, 0xF0, 0x0, 0x0, 0xFF, 0xFF, 0xFF, 0xFF, 
        0xFF, 0xF0, 0x0, 0x0};
      blank = gcnew Bitmap( gcnew MemoryStream( blankBytes ) );
      x = gcnew Bitmap( gcnew MemoryStream( xBytes ) );
      o = gcnew Bitmap( gcnew MemoryStream( oBytes ) );
      this->AutoSize = true;
      turn = gcnew Label;
      Button1 = gcnew Button;
      Button2 = gcnew Button;
      Button3 = gcnew Button;
      Button4 = gcnew Button;
      Button5 = gcnew Button;
      Panel1 = gcnew FlowLayoutPanel;
	  SetupButtons();
      InitializeDataGridView( nullptr, nullptr );

      xString = L"X's turn";
      oString = L"O's turn";
      gameOverString = L"Game Over";
      bitmapPadding = 6;
   }


private:
   DataGridView^ dataGridView1;
   Button^ Button1;
   Label^ turn;
   Button^ Button2;
   Button^ Button3;
   Button^ Button4;
   Button^ Button5;
   FlowLayoutPanel^ Panel1;

#pragma region S " bitmaps " 
   array<Byte>^oBytes;
   array<Byte>^xBytes;
   array<Byte>^blankBytes;

#pragma endregion 
   Bitmap^ blank;
   Bitmap^ x;
   Bitmap^ o;
   String^ xString;
   String^ oString;
   String^ gameOverString;
   int bitmapPadding;
   void InitializeDataGridView( Object^ ignored, EventArgs^ e )
   {
      this->Panel1->SuspendLayout();
      this->SuspendLayout();
      ConfigureForm();
      SizeGrid();
      CreateColumns();
      CreateRows();
      this->Panel1->ResumeLayout( false );
      this->ResumeLayout( false );
   }

   void ConfigureForm()
   {
      AutoSize = true;
      turn->Size = System::Drawing::Size( 75, 34 );
      turn->TextAlign = ContentAlignment::MiddleLeft;
      Panel1->Location = System::Drawing::Point( 0, 8 );
      Panel1->Size = System::Drawing::Size( 120, 196 );
      Panel1->FlowDirection = FlowDirection::TopDown;
      ClientSize = System::Drawing::Size( 355, 200 );
      Controls->Add( this->Panel1 );
      Text = L"TicTacToe";
      dataGridView1 = gcnew System::Windows::Forms::DataGridView;
      dataGridView1->Location = Point(120,0);
      dataGridView1->AllowUserToAddRows = false;
      dataGridView1->CellClick += gcnew DataGridViewCellEventHandler( this, &TicTacToe::dataGridView1_CellClick );
      dataGridView1->CellMouseEnter += gcnew DataGridViewCellEventHandler( this, &TicTacToe::dataGridView1_CellMouseEnter );
      dataGridView1->CellMouseLeave += gcnew DataGridViewCellEventHandler( this, &TicTacToe::dataGridView1_CellMouseLeave );
      Controls->Add( dataGridView1 );
      turn->Text = xString;
      turn->AutoSize = true;
   }

   void SetupButtons()
   {
      Button1->AutoSize = true;
      SetupButton( Button1, L"Restart", gcnew EventHandler( this, &TicTacToe::Reset ) );
      Panel1->Controls->Add( turn );
      SetupButton( Button2, L"Increase Cell Size", gcnew EventHandler( this, &TicTacToe::MakeCellsLarger ) );
      SetupButton( Button3, L"Stretch Images", gcnew EventHandler( this, &TicTacToe::Stretch ) );
      SetupButton( Button4, L"Zoom Images", gcnew EventHandler( this, &TicTacToe::ZoomToImage ) );
      SetupButton( Button5, L"Normal Images", gcnew EventHandler( this, &TicTacToe::NormalImage ) );
   }

   void SetupButton( Button^ button, String^ buttonLabel, EventHandler^ handler )
   {
      Panel1->Controls->Add( button );
      button->Text = buttonLabel;
      button->AutoSize = true;
      button->Click += handler;
   }


   //<snippet5>
   void CreateColumns()
   {
      DataGridViewImageColumn^ imageColumn;
      int columnCount = 0;
      do
      {
         Bitmap^ unMarked = blank;
         imageColumn = gcnew DataGridViewImageColumn;
         
         //Add twice the padding for the left and 
         //right sides of the cell.
         imageColumn->Width = x->Width + 2 * bitmapPadding + 1;
         imageColumn->Image = unMarked;
         dataGridView1->Columns->Add( imageColumn );
         columnCount = columnCount + 1;
      }
      while ( columnCount < 3 );
   }


   //</snippet5>
   void CreateRows()
   {
      dataGridView1->Rows->Add();
      dataGridView1->Rows->Add();
      dataGridView1->Rows->Add();
   }


   //<snippet7>
   void SizeGrid()
   {
      dataGridView1->ColumnHeadersVisible = false;
      dataGridView1->RowHeadersVisible = false;
      dataGridView1->AllowUserToResizeColumns = false;
      dataGridView1->AllowUserToResizeRows = false;
      dataGridView1->BorderStyle = BorderStyle::None;
      
      //Add twice the padding for the top of the cell 
      //and the bottom.
      dataGridView1->RowTemplate->Height = x->Height + 2 * bitmapPadding + 1;
      dataGridView1->AutoSize = true;
   }


   //</snippet7>
   void Reset( Object^ sender, System::EventArgs^ e )
   {
      dataGridView1->~DataGridView();
      InitializeDataGridView( nullptr, nullptr );
   }


   //<snippet10>
   void dataGridView1_CellClick( Object^ sender, DataGridViewCellEventArgs^ e )
   {
      if ( turn->Equals( gameOverString ) )
      {
         return;
      }

      DataGridViewImageCell^ cell = dynamic_cast<DataGridViewImageCell^>(dataGridView1->Rows[ e->RowIndex ]->Cells[ e->ColumnIndex ]);
      if ( cell->Value == blank )
      {
         if ( IsOsTurn() )
         {
            cell->Value = o;
         }
         else
         {
            cell->Value = x;
         }

         ToggleTurn();
      }

      if ( IsAWin( cell ) )
      {
         turn->Text = gameOverString;
      }
   }


   //</snippet10>
   //<snippet15>
   void dataGridView1_CellMouseEnter( Object^ sender, DataGridViewCellEventArgs^ e )
   {
      Bitmap^ markingUnderMouse = dynamic_cast<Bitmap^>(dataGridView1->Rows[ e->RowIndex ]->Cells[ e->ColumnIndex ]->Value);
      if ( markingUnderMouse == blank )
      {
         dataGridView1->Cursor = Cursors::Default;
      }
      else
      if ( markingUnderMouse == o || markingUnderMouse == x )
      {
         dataGridView1->Cursor = Cursors::No;
         ToolTip(e,true);
      }
   }

   void ToolTip( DataGridViewCellEventArgs^ e, bool showTip )
   {
      DataGridViewImageCell^ cell = dynamic_cast<DataGridViewImageCell^>(dataGridView1->Rows[ e->RowIndex ]->Cells[ e->ColumnIndex ]);
      DataGridViewImageColumn^ imageColumn = dynamic_cast<DataGridViewImageColumn^>(dataGridView1->Columns[ cell->ColumnIndex ]);
      if ( showTip )
            cell->ToolTipText = imageColumn->Description;
      else
      {
         cell->ToolTipText = String::Empty;
      }
   }

   void dataGridView1_CellMouseLeave( Object^ sender, DataGridViewCellEventArgs^ e )
   {
      ToolTip( e, false );
      dataGridView1->Cursor = Cursors::Default;
   }


   //</snippet15>
   //<snippet20>
   void Stretch( Object^ sender, EventArgs^ e )
   {
      System::Collections::IEnumerator^ myEnum = dataGridView1->Columns->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         DataGridViewImageColumn^ column = safe_cast<DataGridViewImageColumn^>(myEnum->Current);
         column->ImageLayout = DataGridViewImageCellLayout::Stretch;
         column->Description = L"Stretched";
      }
   }

   void ZoomToImage( Object^ sender, EventArgs^ e )
   {
      System::Collections::IEnumerator^ myEnum1 = dataGridView1->Columns->GetEnumerator();
      while ( myEnum1->MoveNext() )
      {
         DataGridViewImageColumn^ column = safe_cast<DataGridViewImageColumn^>(myEnum1->Current);
         column->ImageLayout = DataGridViewImageCellLayout::Zoom;
         column->Description = L"Zoomed";
      }
   }

   void NormalImage( Object^ sender, EventArgs^ e )
   {
      System::Collections::IEnumerator^ myEnum2 = dataGridView1->Columns->GetEnumerator();
      while ( myEnum2->MoveNext() )
      {
         DataGridViewImageColumn^ column = safe_cast<DataGridViewImageColumn^>(myEnum2->Current);
         column->ImageLayout = DataGridViewImageCellLayout::Normal;
         column->Description = L"Normal";
      }
   }


   //</snippet20>
   void MakeCellsLarger( Object^ sender, EventArgs^ e )
   {
      System::Collections::IEnumerator^ myEnum3 = dataGridView1->Columns->GetEnumerator();
      while ( myEnum3->MoveNext() )
      {
         DataGridViewImageColumn^ column = safe_cast<DataGridViewImageColumn^>(myEnum3->Current);
         column->Width = column->Width * 2;
      }

      System::Collections::IEnumerable^ temp = safe_cast<System::Collections::IEnumerable^>(dataGridView1->Rows);
      System::Collections::IEnumerator^ myEnum4 = temp->GetEnumerator();

      //System::Collections::IEnumerator^ myEnum4 = dataGridView1->Rows->GetEnumerator();
      while ( myEnum4->MoveNext() )
      {
         DataGridViewRow^ row = safe_cast<DataGridViewRow^>(myEnum4->Current);
         if ( row->IsNewRow )
                  break;
         row->Height = (int)(row->Height * 1.5);
      }
   }

   bool IsAWin( DataGridViewCell^ cell )
   {
      if ( ARowIsSame() || AColumnIsSame() || ADiagonalIsSame() )
            return true;
      else
            return false;
   }

   bool ARowIsSame()
   {
      Bitmap^ marking = nullptr;
      System::Collections::IEnumerable^ temp = safe_cast<System::Collections::IEnumerable^>(dataGridView1->Rows);
      System::Collections::IEnumerator^ myEnum5 = temp->GetEnumerator();
      //System::Collections::IEnumerator^ myEnum5 = dataGridView1->Rows->GetEnumerator();
      while ( myEnum5->MoveNext() )
      {
         DataGridViewRow^ row = safe_cast<DataGridViewRow^>(myEnum5->Current);
         if ( row->IsNewRow )
                  break;

         marking = dynamic_cast<Bitmap^>(row->Cells[ 0 ]->Value);
         if ( marking != blank )
         {
            if ( marking == row->Cells[ 1 ]->Value && marking == row->Cells[ 2 ]->Value )
                        return true;
         }
      }

      return false;
   }

   bool AColumnIsSame()
   {
      int columnIndex = 0;
      Bitmap^ marking;
      do
      {
         marking = dynamic_cast<Bitmap^>(dataGridView1->Rows[ 0 ]->Cells[ columnIndex ]->Value);
         if ( marking != blank )
         {
            if ( marking == dynamic_cast<Bitmap^>(dataGridView1->Rows[ 1 ]->Cells[ columnIndex ]->Value) && marking == dynamic_cast<Bitmap^>(dataGridView1->Rows[ 2 ]->Cells[ columnIndex ]->Value) )
                        return true;
         }

         columnIndex = columnIndex + 1;
      }
      while ( columnIndex < dataGridView1->Columns->GetColumnCount( DataGridViewElementStates::Visible ) );

      return false;
   }

   bool ADiagonalIsSame()
   {
      if ( LeftToRightDiagonalIsSame() )
      {
         return true;
      }

      if ( RightToLeftDiagonalIsSame() )
      {
         return true;
      }

      return false;
   }

   bool LeftToRightDiagonalIsSame()
   {
      return IsDiagonalSame( 0, 2 );
   }

   bool RightToLeftDiagonalIsSame()
   {
      return IsDiagonalSame( 2, 0 );
   }

   bool IsDiagonalSame( int startingColumn, int lastColumn )
   {
      Bitmap^ marking = dynamic_cast<Bitmap^>(dataGridView1->Rows[ 0 ]->Cells[ startingColumn ]->Value);
      if ( marking == blank )
            return false;

      if ( marking == dataGridView1->Rows[ 1 ]->Cells[ 1 ]->Value && marking == dataGridView1->Rows[ 2 ]->Cells[ lastColumn ]->Value )
            return true;

      return false;
   }

   void ToggleTurn()
   {
      if ( turn->Text->Equals( xString ) )
      {
         turn->Text = oString;
      }
      else
      {
         turn->Text = xString;
      }
   }

   bool IsOsTurn()
   {
      if ( turn->Text->Equals( oString ) )
            return true;

      return false;
   }


public:

   [STAThread]
   static void Main()
   {
      Application::Run( gcnew TicTacToe );
   }

};

int main()
{
   TicTacToe::Main();
}

//</snippet0>
