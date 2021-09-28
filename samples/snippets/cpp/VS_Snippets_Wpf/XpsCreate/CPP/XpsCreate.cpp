//XpsCreate.cpp file

using namespace System;
using namespace System::IO;
using namespace System::Collections::Generic;
using namespace System::IO::Packaging;
using namespace System::Xml;
using namespace System::Windows::Forms;
using namespace System::Windows::Xps;
using namespace System::Windows::Xps::Packaging;
using namespace System::Printing;

public ref class XpsCreate {

private: 
   literal System::String^ packageWithPrintTicketName = "XpsDocument-withPrintTicket.xps";
   literal System::String^ packageName = "XpsDocument.xps";
   literal System::String^ image1 = "picture.jpg";
   literal System::String^ image2 = "image.tif";
   literal System::String^ font1 = "courier.ttf";
   literal System::String^ font2 = "arial.ttf";
   literal System::String^ fontContentType = "application/vnd.ms-package.obfuscated-opentype";

public: 
   [STAThread()]
   static void Main (array<System::String^>^ args) 
   {
      XpsCreate^ xpsCreate = gcnew XpsCreate();
      xpsCreate->Run();
   };

public: 
   // -------------------------------- Run -----------------------------------
   /// <summary>
   ///   Creates two XpsDocument packages, the first without a PrintTicket
   ///   and a second with a PrintTicket.</summary>
   void Run () 
   {
      // First, create an XpsDocument without a PrintTicket. - - - - - - - -

      // If the document package exists from a previous run, delete it.
      if (File::Exists(packageName))
      {
         File::Delete(packageName);
      }
      //<SnippetXpsCreatePackageOpen>
      // Create an XpsDocument package (without PrintTicket).
      {
         Package^ package = Package::Open(packageName);
         try
         {
            XpsDocument^ xpsDocument = gcnew XpsDocument(package);

            // Add the package content (false=without PrintTicket).
            AddPackageContent(xpsDocument, false);

            // Close the package.
            xpsDocument->Close();
         } finally
         {
            delete package;
         }
         //</SnippetXpsCreatePackageOpen>

         // Next, create a second XpsDocument with a PrintTicket. - - - - - - -

         // If the document package exists from a previous run, delete it.
         if (File::Exists(packageWithPrintTicketName))
         {
            File::Delete(packageWithPrintTicketName);
         }

         // Create an XpsDocument with PrintTicket.
         {
            Package^ package2 = Package::Open(packageWithPrintTicketName);
            try
            {
               XpsDocument^ xpsDocumentWithPrintTicket = gcnew XpsDocument(package2);

               // Add the package content (true=with PrintTicket).
               AddPackageContent(xpsDocumentWithPrintTicket, true);

               // Close the package.
               xpsDocumentWithPrintTicket->Close();
            } finally
            {
               delete package2;
            }
         }

         System::String^ msg = "Created two XPS document packages:\n   - " + packageName + "\n   - " + packageWithPrintTicketName;
         MessageBox::Show(msg, "Normal Completion", MessageBoxButtons::OK, MessageBoxIcon::Information);
      }
   };

private: 
   //<SnippetXpsCreateAddPkgContent>
   // ------------------------- AddPackageContent ----------------------------
   /// <summary>
   ///   Adds a predefined set of content to a given XPS document.</summary>
   /// <param name="xpsDocument">
   ///   The package to add the document content to.</param>
   /// <param name="attachPrintTicket">
   ///   true to include a PrintTicket with the
   ///   document; otherwise, false.</param>
   void AddPackageContent (XpsDocument^ xpsDocument, bool attachPrintTicket) 
   {
      try
      {
         PrintTicket^ printTicket = GetPrintTicketFromPrinter();
         // PrintTicket is null, there is no need to attach one.
         if (printTicket == nullptr)
         {
            attachPrintTicket = false;
         }
         // Add a FixedDocumentSequence at the Package root
         IXpsFixedDocumentSequenceWriter^ documentSequenceWriter = xpsDocument->AddFixedDocumentSequence();

         // Add the 1st FixedDocument to the FixedDocumentSequence. - - - - -
         IXpsFixedDocumentWriter^ fixedDocumentWriter = documentSequenceWriter->AddFixedDocument();

         AddDocumentContent(fixedDocumentWriter);

         // Commit the 1st Document
         fixedDocumentWriter->Commit();

         // Add a 2nd FixedDocument to the FixedDocumentSequence. - - - - - -
         fixedDocumentWriter = documentSequenceWriter->AddFixedDocument();

         // Add content to the 2nd document.
         AddDocumentContent(fixedDocumentWriter);

         // If attaching PrintTickets, attach one at the FixedDocument level.
         if (attachPrintTicket)
         {
            fixedDocumentWriter->PrintTicket = printTicket;
         }
         // Commit the 2nd document.
         fixedDocumentWriter->Commit();

         // If attaching PrintTickets, attach one at
         // the package FixedDocumentSequence level.
         if (attachPrintTicket)
         {
            documentSequenceWriter->PrintTicket = printTicket;
         }
         // Commit the FixedDocumentSequence
         documentSequenceWriter->Commit();
      } catch (XpsPackagingException^ xpsException)
      {
         throw xpsException;

      } 
   };// end:AddPackageContent()
   //</SnippetXpsCreateAddPkgContent>


   //<SnippetXpsCreateAddDocContent>
   // ------------------------- AddDocumentContent ---------------------------
   /// <summary>
   ///   Adds a predefined set of content to a given document writer.</summary>
   /// <param name="fixedDocumentWriter">
   ///   The document writer to add the content to.</param>
   void AddDocumentContent (IXpsFixedDocumentWriter^ fixedDocumentWriter) 
   {
      // Collection of image and font resources used on the current page.
      //   Key: "XpsImage", "XpsFont"
      //   Value: List of XpsImage or XpsFont resources
      Dictionary<System::String^,List<XpsResource^>^>^ resources;

      try
      {
         // Add Page 1 to current document.
         IXpsFixedPageWriter^ fixedPageWriter = fixedDocumentWriter->AddFixedPage();
         // Add the resources for Page 1 and get the resource collection.
         resources = AddPageResources(fixedPageWriter);

         // Write page content for Page 1.
         WritePageContent(fixedPageWriter->XmlWriter, "Page 1 of " + fixedDocumentWriter->Uri->ToString(), resources);
         // Commit Page 1.
         fixedPageWriter->Commit();

         // Add Page 2 to current document.
         fixedPageWriter = fixedDocumentWriter->AddFixedPage();

         // Add the resources for Page 2 and get the resource collection.
         resources = AddPageResources(fixedPageWriter);

         // Write page content to Page 2.
         WritePageContent(fixedPageWriter->XmlWriter, "Page 2 of " + fixedDocumentWriter->Uri->ToString(), resources);
         // Commit Page 2.
         fixedPageWriter->Commit();
      } catch (XpsPackagingException^ xpsException)
      {
         throw xpsException;

      } 
   };// end:AddDocumentContent()
   //</SnippetXpsCreateAddDocContent>


   //<SnippetXpsCreateAddPageResources>
   // -------------------------- AddPageResources ----------------------------
   Dictionary<System::String^,List<XpsResource^>^>^ AddPageResources (IXpsFixedPageWriter^ fixedPageWriter) 
   {
      // Collection of all resources for this page.
      //   Key: "XpsImage", "XpsFont"
      //   Value: List of XpsImage or XpsFont
      Dictionary<System::String^,List<XpsResource^>^>^ resources = gcnew Dictionary<System::String^,List<XpsResource^>^>();

      // Collections of images and fonts used in the current page.
      List<XpsResource^>^ xpsImages = gcnew List<XpsResource^>();
      List<XpsResource^>^ xpsFonts = gcnew List<XpsResource^>();

      try
      {
         XpsImage^ xpsImage;
         XpsFont^ xpsFont;

         // Add, Write, and Commit image1 to the current page.
         xpsImage = fixedPageWriter->AddImage(XpsImageType::JpegImageType);
         WriteToStream(xpsImage->GetStream(), image1);
         xpsImage->Commit();
         xpsImages->Add(xpsImage);    // Add image1 as a required resource.

         // Add, Write, and Commit font 1 to the current page.
         xpsFont = fixedPageWriter->AddFont();
         WriteObfuscatedStream(xpsFont->Uri->ToString(), xpsFont->GetStream(), font1);
         xpsFont->Commit();
         xpsFonts->Add(xpsFont);      // Add font1 as a required resource.

         // Add, Write, and Commit image2 to the current page.
         xpsImage = fixedPageWriter->AddImage(XpsImageType::TiffImageType);
         WriteToStream(xpsImage->GetStream(), image2);
         xpsImage->Commit();
         xpsImages->Add(xpsImage);    // Add image2 as a required resource.

         // Add, Write, and Commit font2 to the current page.
         xpsFont = fixedPageWriter->AddFont(false);
         WriteToStream(xpsFont->GetStream(), font2);
         xpsFont->Commit();
         xpsFonts->Add(xpsFont);      // Add font2 as a required resource.

         // Return the image and font resources in a combined collection.
         resources->Add("XpsImage", xpsImages);
         resources->Add("XpsFont", xpsFonts);
         return resources;
      } catch (XpsPackagingException^ xpsException)
      {
         throw xpsException;

      } 
   };// end:AddPageResources()
   //</SnippetXpsCreateAddPageResources>


   //<SnippetPrinterCapabilities>
   // ---------------------- GetPrintTicketFromPrinter -----------------------
   /// <summary>
   ///   Returns a PrintTicket based on the current default printer.</summary>
   /// <returns>
   ///   A PrintTicket for the current local default printer.</returns>
   PrintTicket^ GetPrintTicketFromPrinter () 
   {
      PrintQueue^ printQueue = nullptr;

      LocalPrintServer^ localPrintServer = gcnew LocalPrintServer();

      // Retrieving collection of local printer on user machine
      PrintQueueCollection^ localPrinterCollection = localPrintServer->GetPrintQueues();

      System::Collections::IEnumerator^ localPrinterEnumerator = localPrinterCollection->GetEnumerator();

      if (localPrinterEnumerator->MoveNext())
      {
         // Get PrintQueue from first available printer
         printQueue = ((PrintQueue^)localPrinterEnumerator->Current);
      } else
      {
         return nullptr;
      }
      // Get default PrintTicket from printer
      PrintTicket^ printTicket = printQueue->DefaultPrintTicket;

      PrintCapabilities^ printCapabilites = printQueue->GetPrintCapabilities();

      // Modify PrintTicket
      if (printCapabilites->CollationCapability->Contains(Collation::Collated))
      {
         printTicket->Collation = Collation::Collated;
      }
      if (printCapabilites->DuplexingCapability->Contains(Duplexing::TwoSidedLongEdge))
      {
         printTicket->Duplexing = Duplexing::TwoSidedLongEdge;
      }
      if (printCapabilites->StaplingCapability->Contains(Stapling::StapleDualLeft))
      {
         printTicket->Stapling = Stapling::StapleDualLeft;
      }
      return printTicket;
   };// end:GetPrintTicketFromPrinter()
   //</SnippetPrinterCapabilities>


   //<SnippetXpsCreateWritePageContent>
   // --------------------------- WritePageContent ---------------------------
   void WritePageContent (System::Xml::XmlWriter^ xmlWriter, System::String^ documentUri, Dictionary<System::String^,List<XpsResource^>^>^ resources) 
   {
      List<XpsResource^>^ xpsImages = resources["XpsImage"];
      List<XpsResource^>^ xpsFonts = resources["XpsFont"];

      // Element are indented for reading purposes only
      xmlWriter->WriteStartElement("FixedPage");
      xmlWriter->WriteAttributeString("Width", "816");
      xmlWriter->WriteAttributeString("Height", "1056");
      xmlWriter->WriteAttributeString("xmlns", "http://schemas.microsoft.com/xps/2005/06");
      xmlWriter->WriteAttributeString("xml:lang", "en-US");

      xmlWriter->WriteStartElement("Glyphs");
      xmlWriter->WriteAttributeString("Fill", "#ff000000");
      xmlWriter->WriteAttributeString("FontUri", xpsFonts[0]->Uri->ToString());
      xmlWriter->WriteAttributeString("FontRenderingEmSize", "18");
      xmlWriter->WriteAttributeString("OriginX", "120");
      xmlWriter->WriteAttributeString("OriginY", "110");
      xmlWriter->WriteAttributeString("UnicodeString", documentUri);
      xmlWriter->WriteEndElement();

      xmlWriter->WriteStartElement("Glyphs");
      xmlWriter->WriteAttributeString("Fill", "#ff000000");
      xmlWriter->WriteAttributeString("FontUri", xpsFonts[1]->Uri->ToString());
      xmlWriter->WriteAttributeString("FontRenderingEmSize", "16");
      xmlWriter->WriteAttributeString("OriginX", "120");
      xmlWriter->WriteAttributeString("OriginY", "130");
      xmlWriter->WriteAttributeString("UnicodeString", "Test String in Arial");
      xmlWriter->WriteEndElement();

      xmlWriter->WriteStartElement("Path");
      xmlWriter->WriteAttributeString("Data", "M 120,187 L 301,187 301,321 120,321 z");
      xmlWriter->WriteStartElement("Path.Fill");
      xmlWriter->WriteStartElement("ImageBrush");
      xmlWriter->WriteAttributeString("ImageSource", xpsImages[0]->Uri->ToString());
      xmlWriter->WriteAttributeString("Viewbox", "0,0,181,134");
      xmlWriter->WriteAttributeString("TileMode", "None");
      xmlWriter->WriteAttributeString("ViewboxUnits", "Absolute");
      xmlWriter->WriteAttributeString("ViewportUnits", "Absolute");
      xmlWriter->WriteAttributeString("Viewport", "120,187,181,134");
      xmlWriter->WriteEndElement();
      xmlWriter->WriteEndElement();
      xmlWriter->WriteEndElement();

      xmlWriter->WriteStartElement("Path");
      xmlWriter->WriteAttributeString("Data", "M 120,357 L 324,357 324,510 120,510 z");
      xmlWriter->WriteStartElement("Path.Fill");
      xmlWriter->WriteStartElement("ImageBrush");
      xmlWriter->WriteAttributeString("ImageSource", xpsImages[1]->Uri->ToString());
      xmlWriter->WriteAttributeString("Viewbox", "0,0,204,153");
      xmlWriter->WriteAttributeString("TileMode", "None");
      xmlWriter->WriteAttributeString("ViewboxUnits", "Absolute");
      xmlWriter->WriteAttributeString("ViewportUnits", "Absolute");
      xmlWriter->WriteAttributeString("Viewport", "120,357,204,153");
      xmlWriter->WriteEndElement();
      xmlWriter->WriteEndElement();
      xmlWriter->WriteEndElement();
      xmlWriter->WriteEndElement();
   };// end:WritePageContent()
   //</SnippetXpsCreateWritePageContent>


   // ----------------------------- WriteToStream ----------------------------
   void WriteToStream (System::IO::Stream^ stream, System::String^ resource) 
   {
      int bufSize = 0x1000;
      array<System::Byte>^ buf = gcnew array<System::Byte>(bufSize);
      int bytesRead = 0;
      {
         System::IO::FileStream^ fileStream = gcnew System::IO::FileStream(resource, FileMode::Open, FileAccess::Read);
         try
         {
            while ((bytesRead = fileStream->Read(buf, 0, bufSize)) > 0)
            {
               stream->Write(buf, 0, bytesRead);
            }
         } finally
         {
            delete fileStream;
         }
      }
   };

   // ------------------------- WriteObfuscatedStream ------------------------
   void WriteObfuscatedStream (System::String^ resourceName, System::IO::Stream^ stream, System::String^ resource) {
      int bufSize = 0x1000;
      int guidByteSize = 16;
      int obfuscatedByte = 32;

      // Get the GUID byte from the resource name.  Typical Font name:
      //    /Resources/Fonts/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx.ODTTF
      int startPos = resourceName->LastIndexOf('/') + 1;
      int length = resourceName->LastIndexOf('.') - startPos;
      resourceName = resourceName->Substring(startPos, length);

      System::Guid guid = System::Guid(resourceName);

      System::String^ guidString = guid.ToString("N");

      // Parsing the guid string and coverted into byte value
      array<System::Byte>^ guidBytes = gcnew array<System::Byte>(guidByteSize);

      for (
         int i = 0;
         i < guidBytes->Length;
      i++)
      {
         guidBytes[i] = Convert::ToByte(guidString->Substring(i * 2, 2), 16);
      }

      {
         System::IO::FileStream^ filestream = gcnew System::IO::FileStream(resource, FileMode::Open);
         try
         {
            // XOR the first 32 bytes of the source
            // resource stream with GUID byte.
            array<System::Byte>^ buf = gcnew array<System::Byte>(obfuscatedByte);
            filestream->Read(buf, 0, obfuscatedByte);

            for (
               int i = 0;
               i < obfuscatedByte;
            i++)
            {
               int guidBytesPos = guidBytes->Length - (i % guidBytes->Length) - 1;
               buf[i] ^= guidBytes[guidBytesPos];
            }

            stream->Write(buf, 0, obfuscatedByte);

            // copy remaining stream from source without obfuscation
            buf = gcnew array<System::Byte>(bufSize);
            int bytesRead = 0;
            while ((bytesRead = filestream->Read(buf, 0, bufSize)) > 0)
            {
               stream->Write(buf, 0, bytesRead);
            }
         } finally
         {
            delete filestream;
         }
      }
   };

};


//Entry Point:
int main (array<System::String^>^ args)
{
   XpsCreate::Main(args);
   return 0;
}
