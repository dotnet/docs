

// Snippet for: F:System.Drawing.Imaging.Encoder.Compression
// <snippet2>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Drawing::Imaging;
static ImageCodecInfo^ GetEncoderInfo( String^ mimeType );
int main()
{
   Bitmap^ myBitmap;
   ImageCodecInfo^ myImageCodecInfo;
   Encoder^ myEncoder;
   EncoderParameter^ myEncoderParameter;
   EncoderParameters^ myEncoderParameters;
   
   // Create a Bitmap object based on a BMP file.
   myBitmap = gcnew Bitmap( "Shapes.bmp" );
   
   // Get an ImageCodecInfo object that represents the TIFF codec.
   myImageCodecInfo = GetEncoderInfo( "image/tiff" );
   
   // Create an Encoder object based on the GUID
   // for the Compression parameter category.
   myEncoder = Encoder::Compression;
   
   // Create an EncoderParameters object.
   // An EncoderParameters object has an array of EncoderParameter
   // objects. In this case, there is only one
   // EncoderParameter object in the array.
   myEncoderParameters = gcnew EncoderParameters( 1 );
   
   // Save the bitmap as a TIFF file with LZW compression.
   myEncoderParameter = gcnew EncoderParameter( myEncoder,(__int64)EncoderValue::CompressionLZW );
   myEncoderParameters->Param[ 0 ] = myEncoderParameter;
   myBitmap->Save( "ShapesLZW.tif", myImageCodecInfo, myEncoderParameters );
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

// </snippet2>
