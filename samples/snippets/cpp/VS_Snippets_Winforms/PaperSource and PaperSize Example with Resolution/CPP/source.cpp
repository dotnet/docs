#using <System.Data.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::IO;
using namespace System::Drawing;
using namespace System::Drawing::Printing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Data;

namespace WindowsApplication3
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public ref class Form1: public System::Windows::Forms::Form
   {
   private:

      // my vars
      PrintDocument^ printDoc;
      System::Windows::Forms::Label ^ label1;
      System::Windows::Forms::Label ^ label2;
      System::Windows::Forms::Label ^ label3;
      System::Windows::Forms::Button^ MyButtonPrint;
      System::Windows::Forms::ComboBox^ comboPaperSize;
      System::Windows::Forms::ComboBox^ comboPaperSource;
      System::Windows::Forms::ComboBox^ comboPrintResolution;
      System::Windows::Forms::ComboBox^ comboInstalledPrinters;
      System::Windows::Forms::Label ^ label4;
      System::ComponentModel::Container^ components;

   public:
      Form1()
      {
         //
         // Required for Windows Form Designer support
         //
         printDoc = gcnew PrintDocument;
         components = nullptr;
         currentPageNumber = 1;
         InitializeComponent();
         
         // Setup the event handlers
         printDoc->QueryPageSettings += gcnew QueryPageSettingsEventHandler( this, &Form1::MyPrintQueryPageSettingsEvent );
         printDoc->PrintPage += gcnew PrintPageEventHandler( this, &Form1::MyPrintPageEvent );
         
         /*    // Other way to specify custom paper size is to set the paper kind and related properties.
               PaperSize* pkCustomSize2 = new PaperSize();
               pkCustomSize2.Kind = PaperSourceKind::Custom;
               pkCustomSize2.PaperName = S"Other custom size";
               pkCustomSize2.Width = 100;
               pkCustomSize2.Height = 200;
         
               comboPaperSize.Items->Add(pkCustomSize2);
         
               */

         // <Snippet1>
         // Add list of supported paper sizes found on the printer.
         // The DisplayMember property is used to identify the property that will provide the display String*.
         comboPaperSize->DisplayMember = "PaperName";
         PaperSize^ pkSize;
         for ( int i = 0; i < printDoc->PrinterSettings->PaperSizes->Count; i++ )
         {
            pkSize = printDoc->PrinterSettings->PaperSizes[ i ];
            comboPaperSize->Items->Add( pkSize );
         }

         // Create a PaperSize and specify the custom paper size through the constructor and add to combobox.
         PaperSize^ pkCustomSize1 = gcnew PaperSize( "First custom size",100,200 );
         comboPaperSize->Items->Add( pkCustomSize1 );
         // </Snippet1>

         // <Snippet2>
         // Add list of paper sources found on the printer to the combo box.
         // The DisplayMember property is used to identify the property that will provide the display String*.
         comboPaperSource->DisplayMember = "SourceName";
         PaperSource^ pkSource;
         for ( int i = 0; i < printDoc->PrinterSettings->PaperSources->Count; i++ )
         {
            pkSource = printDoc->PrinterSettings->PaperSources[ i ];
            comboPaperSource->Items->Add( pkSource );
         }
         // </Snippet2>
         
         // <Snippet3>
         // Add list of printer resolutions found on the printer to the combobox.
         // The PrinterResolution's ToString() method will be used to provide the display String.
         PrinterResolution^ pkResolution;
         for ( int i = 0; i < printDoc->PrinterSettings->PrinterResolutions->Count; i++ )
         {
            pkResolution = printDoc->PrinterSettings->PrinterResolutions[ i ];
            comboPrintResolution->Items->Add( pkResolution );
         }
         // </Snippet3>

         PopulateInstalledPrintersCombo();
      }

      // <Snippet5>
   private:
      void PopulateInstalledPrintersCombo()
      {
         // Add list of installed printers found to the combo box.
         // The pkInstalledPrinters String will be used to provide the display String.
         String^ pkInstalledPrinters;
         for ( int i = 0; i < PrinterSettings::InstalledPrinters->Count; i++ )
         {
            pkInstalledPrinters = PrinterSettings::InstalledPrinters[ i ];
            comboInstalledPrinters->Items->Add( pkInstalledPrinters );
         }
      }

      void comboInstalledPrinters_SelectionChanged( Object^ sender, System::EventArgs^ e )
      {
         // Set the printer to a printer in the combo box when the selection changes.
         if ( comboInstalledPrinters->SelectedIndex != -1 )
         {
            // The combo box's Text property returns the selected item's text, which is the printer name.
            printDoc->PrinterSettings->PrinterName = comboInstalledPrinters->Text;
         }
      }
      // </Snippet5>

   public:

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      ~Form1()
      {
         if ( components != nullptr )
         {
            delete components;
         }
      }

   private:

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      void InitializeComponent()
      {
         this->comboPrintResolution = gcnew System::Windows::Forms::ComboBox;
         this->label4 = gcnew System::Windows::Forms::Label;
         this->comboInstalledPrinters = gcnew System::Windows::Forms::ComboBox;
         this->label1 = gcnew System::Windows::Forms::Label;
         this->label3 = gcnew System::Windows::Forms::Label;
         this->comboPaperSize = gcnew System::Windows::Forms::ComboBox;
         this->comboPaperSource = gcnew System::Windows::Forms::ComboBox;
         this->label2 = gcnew System::Windows::Forms::Label;
         this->MyButtonPrint = gcnew System::Windows::Forms::Button;
         this->SuspendLayout();

         //
         // comboPrintResolution
         //
         this->comboPrintResolution->DropDownWidth = 121;
         this->comboPrintResolution->Location = System::Drawing::Point( 104, 72 );
         this->comboPrintResolution->Name = "comboPrintResolution";
         this->comboPrintResolution->Size = System::Drawing::Size( 121, 21 );
         this->comboPrintResolution->TabIndex = 3;

         //
         // label4
         //
         this->label4->Location = System::Drawing::Point( 8, 104 );
         this->label4->Name = "label4";
         this->label4->TabIndex = 4;
         this->label4->Text = "Installed Printers";

         //
         // comboInstalledPrinters
         //
         this->comboInstalledPrinters->DropDownWidth = 120;
         this->comboInstalledPrinters->Location = System::Drawing::Point( 104, 104 );
         this->comboInstalledPrinters->Name = "comboInstalledPrinters";
         this->comboInstalledPrinters->Size = System::Drawing::Size( 120, 21 );
         this->comboInstalledPrinters->TabIndex = 5;
         this->comboInstalledPrinters->SelectedIndexChanged +=
               gcnew System::EventHandler( this, &Form1::comboInstalledPrinters_SelectionChanged );

         //
         // label1
         //
         this->label1->FlatStyle = System::Windows::Forms::FlatStyle::System;
         this->label1->Location = System::Drawing::Point( 8, 13 );
         this->label1->Name = "label1";
         this->label1->Size = System::Drawing::Size( 56, 16 );
         this->label1->TabIndex = 1;
         this->label1->Text = "Paper Sizes";

         //
         // label3
         //
         this->label3->Location = System::Drawing::Point( 8, 72 );
         this->label3->Name = "label3";
         this->label3->TabIndex = 4;
         this->label3->Text = "Printer Resolution";

         //
         // comboPaperSize
         //
         this->comboPaperSize->DropDownWidth = 121;
         this->comboPaperSize->Location = System::Drawing::Point( 80, 8 );
         this->comboPaperSize->Name = "comboPaperSize";
         this->comboPaperSize->Size = System::Drawing::Size( 121, 21 );
         this->comboPaperSize->TabIndex = 0;

         //
         // comboPaperSource
         //
         this->comboPaperSource->DropDownWidth = 121;
         this->comboPaperSource->Location = System::Drawing::Point( 80, 40 );
         this->comboPaperSource->Name = "comboPaperSource";
         this->comboPaperSource->Size = System::Drawing::Size( 121, 21 );
         this->comboPaperSource->TabIndex = 0;

         //
         // label2
         //
         this->label2->FlatStyle = System::Windows::Forms::FlatStyle::System;
         this->label2->Location = System::Drawing::Point( 8, 45 );
         this->label2->Name = "label2";
         this->label2->Size = System::Drawing::Size( 72, 16 );
         this->label2->TabIndex = 1;
         this->label2->Text = "Paper Source";

         //
         // MyButtonPrint
         //
         this->MyButtonPrint->Location = System::Drawing::Point( 208, 8 );
         this->MyButtonPrint->Name = "MyButtonPrint";
         this->MyButtonPrint->TabIndex = 2;
         this->MyButtonPrint->Text = "Print";
         this->MyButtonPrint->Click += gcnew System::EventHandler( this, &Form1::MyButtonPrint_Click );

         //
         // Form1
         //
         this->ClientSize = System::Drawing::Size( 292, 133 );
         array<System::Windows::Forms::Control^>^temp0 = {this->comboInstalledPrinters,this->comboPrintResolution,this->label3,this->comboPaperSource,this->MyButtonPrint,this->label1,this->comboPaperSize,this->label2,this->label4};
         this->Controls->AddRange( temp0 );
         this->Name = "Form1";
         this->Text = "Form1";
         this->ResumeLayout( false );
      }

      // <Snippet4>
   private:
      void MyButtonPrint_Click( Object^ sender, System::EventArgs^ e )
      {
         // Set the paper size based upon the selection in the combo box.
         if ( comboPaperSize->SelectedIndex != -1 )
         {
            printDoc->DefaultPageSettings->PaperSize = printDoc->PrinterSettings->PaperSizes[ comboPaperSize->SelectedIndex ];
         }

         // Set the paper source based upon the selection in the combo box.
         if ( comboPaperSource->SelectedIndex != -1 )
         {
            printDoc->DefaultPageSettings->PaperSource = printDoc->PrinterSettings->PaperSources[ comboPaperSource->SelectedIndex ];
         }

         // Set the printer resolution based upon the selection in the combo box.
         if ( comboPrintResolution->SelectedIndex != -1 )
         {
            printDoc->DefaultPageSettings->PrinterResolution = printDoc->PrinterSettings->PrinterResolutions[ comboPrintResolution->SelectedIndex ];
         }

         // Print the document with the specified paper size, source, and print resolution.
         printDoc->Print();
      }
      // </Snippet4>

   protected:
      int currentPageNumber;

      // <Snippet6>
   private:
      void MyButtonPrint_OnClick( Object^ sender, System::EventArgs^ e )
      {
         // Set the printer name and ensure it is valid. If not, provide a message to the user.
         printDoc->PrinterSettings->PrinterName = "\\mynetworkprinter";
         if ( printDoc->PrinterSettings->IsValid )
         {
            // If the printer supports printing in color, then override the printer's default behavior.
            if ( printDoc->PrinterSettings->SupportsColor )
            {
               // Set the page default's to not print in color.
               printDoc->DefaultPageSettings->Color = false;
            }

            // Provide a friendly name, set the page number, and print the document.
            printDoc->DocumentName = "My Presentation";
            currentPageNumber = 1;
            printDoc->Print();
         }
         else
         {
            MessageBox::Show( "Printer is not valid" );
         }
      }

      void MyPrintQueryPageSettingsEvent( Object^ sender, QueryPageSettingsEventArgs^ e )
      {
         // Determines if the printer supports printing in color.
         if ( printDoc->PrinterSettings->SupportsColor )
         {
            // If the printer supports color printing, use color.
            if ( currentPageNumber == 1 )
            {
               e->PageSettings->Color = true;
            }
         }
      }
      //</Snippet6>

      void MyPrintPageEvent( Object^ sender, PrintPageEventArgs^ e ){}
   };
}

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew WindowsApplication3::Form1 );
}
