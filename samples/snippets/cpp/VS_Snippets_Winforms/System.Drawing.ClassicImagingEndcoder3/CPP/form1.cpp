

// Snippet for: F:System.Drawing.Imaging.Encoder.Quality
// <snippet3>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Drawing::Imaging;
static ImageCodecInfo^ GetEncoderInfo( ImageFormat^ format );
int main()
{
   Bitmap^ myBitmap;
   ImageCodecInfo^ myImageCodecInfo;
   Encoder^ myEncoder;
   EncoderParameter^ myEncoderParameter;
   EncoderParameters^ myEncoderParameters;
   
   // Create a Bitmap object based on a BMP file.
   myBitmap = gcnew Bitmap( "Shapes.bmp" );
   
   // Get an ImageCodecInfo object that represents the JPEG codec.
   myImageCodecInfo = GetEncoderInfo( ImageFormat->Jpeg );
   
   // Create an Encoder object based on the GUID
   // for the Quality parameter category.
   myEncoder = Encoder::Quality;
   
   // Create an EncoderParameters object.
   // An EncoderParameters object has an array of EncoderParameter
   // objects. In this case, there is only one
   // EncoderParameter object in the array.
   myEncoderParameters = gcnew EncoderParameters( 1 );
   
   // Save the bitmap as a JPEG file with quality level 25.
   myEncoderParameter = gcnew EncoderParameter( myEncoder,__int64(25) );
   myEncoderParameters->Param[ 0 ] = myEncoderParameter;
   myBitmap->Save( "Shapes025.jpg", myImageCodecInfo, myEncoderParameters );
   
   // Save the bitmap as a JPEG file with quality level 50.
   myEncoderParameter = gcnew EncoderParameter( myEncoder,__int64(50) );
   myEncoderParameters->Param[ 0 ] = myEncoderParameter;
   myBitmap->Save( "Shapes050.jpg", myImageCodecInfo, myEncoderParameters );
   
   // Save the bitmap as a JPEG file with quality level 75.
   myEncoderParameter = gcnew EncoderParameter( myEncoder,__int64(75) );
   myEncoderParameters->Param[ 0 ] = myEncoderParameter;
   myBitmap->Save( "Shapes075.jpg", myImageCodecInfo, myEncoderParameters );
}

static ImageCodecInfo^ GetEncoderInfo( ImageFormat^ format )
{
   int j;
   array<ImageCodecInfo^>^encoders;
   encoders = ImageCodecInfo::GetImageEncoders();
   for ( j = 0; j < encoders->Length; ++j )
   {
      if ( encoders[ j ]->FormatID == format->Guid)
            return encoders[ j ];

   }
   return nullptr;
}

// </snippet3>
