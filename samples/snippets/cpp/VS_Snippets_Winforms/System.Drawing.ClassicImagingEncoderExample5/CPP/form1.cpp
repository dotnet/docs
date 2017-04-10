

// Snippet for: F:System.Drawing.Imaging.Encoder.Transformation
// <snippet5>
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
   
   // Create a Bitmap object based on a JPEG file.
   myBitmap = gcnew Bitmap( "Shapes.jpg" );
   
   // Get an ImageCodecInfo object that represents the JPEG codec.
   myImageCodecInfo = GetEncoderInfo( "image/jpeg" );
   
   // Create an Encoder object based on the GUID
   // for the Transformation parameter category.
   myEncoder = Encoder::Transformation;
   
   // Create an EncoderParameters object.
   // An EncoderParameters object has an array of EncoderParameter
   // objects. In this case, there is only one
   // EncoderParameter object in the array.
   myEncoderParameters = gcnew EncoderParameters( 1 );
   
   // Rotate the image 90 degrees, and save it as a separate JPEG file.
   myEncoderParameter = gcnew EncoderParameter( myEncoder,(__int64)EncoderValue::TransformRotate90 );
   myEncoderParameters->Param[ 0 ] = myEncoderParameter;
   myBitmap->Save( "ShapesR90.jpg", myImageCodecInfo, myEncoderParameters );
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

// </snippet5>
