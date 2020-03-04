

// Snippet for: F:System.Drawing.Imaging.Encoder.SaveFlag
// <snippet4>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Drawing::Imaging;
static ImageCodecInfo^ GetEncoderInfo( String^ mimeType );
int main()
{
   Bitmap^ multi;
   Bitmap^ page2;
   Bitmap^ page3;
   ImageCodecInfo^ myImageCodecInfo;
   Encoder^ myEncoder;
   EncoderParameter^ myEncoderParameter;
   EncoderParameters^ myEncoderParameters;
   
   // Create three Bitmap objects.
   multi = gcnew Bitmap( "Shapes.bmp" );
   page2 = gcnew Bitmap( "Iron.jpg" );
   page3 = gcnew Bitmap( "House.png" );
   
   // Get an ImageCodecInfo object that represents the TIFF codec.
   myImageCodecInfo = GetEncoderInfo( "image/tiff" );
   
   // Create an Encoder object based on the GUID
   // for the SaveFlag parameter category.
   myEncoder = Encoder::SaveFlag;
   
   // Create an EncoderParameters object.
   // An EncoderParameters object has an array of EncoderParameter
   // objects. In this case, there is only one
   // EncoderParameter object in the array.
   myEncoderParameters = gcnew EncoderParameters( 1 );
   
   // Save the first page (frame).
   myEncoderParameter = gcnew EncoderParameter( myEncoder,(__int64)EncoderValue::MultiFrame );
   myEncoderParameters->Param[ 0 ] = myEncoderParameter;
   multi->Save( "Multiframe.tiff", myImageCodecInfo, myEncoderParameters );
   
   // Save the second page (frame).
   myEncoderParameter = gcnew EncoderParameter( myEncoder,(__int64)EncoderValue::FrameDimensionPage );
   myEncoderParameters->Param[ 0 ] = myEncoderParameter;
   multi->SaveAdd( page2, myEncoderParameters );
   
   // Save the third page (frame).
   myEncoderParameter = gcnew EncoderParameter( myEncoder,(__int64)EncoderValue::FrameDimensionPage );
   myEncoderParameters->Param[ 0 ] = myEncoderParameter;
   multi->SaveAdd( page3, myEncoderParameters );
   
   // Close the multiple-frame file.
   myEncoderParameter = gcnew EncoderParameter( myEncoder,(__int64)EncoderValue::Flush );
   myEncoderParameters->Param[ 0 ] = myEncoderParameter;
   multi->SaveAdd( myEncoderParameters );
}

static ImageCodecInfo^ GetEncoderInfo( String^ mimeType )
{
   int j;
   array<ImageCodecInfo^>^encoders;
   encoders = ImageCodecInfo::GetImageEncoders();
   for ( j = 0; j < encoders->Length; ++j )
   {
      if ( encoders[ j ]->MimeType == mimeType )
            return encoders[ j ];

   }
   return nullptr;
}

// </snippet4>
