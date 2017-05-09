// Snippet for: F:System.Drawing.Imaging.Encoder.Compression
// <snippet2>
using System;
using System.Drawing;
using System.Drawing.Imaging;
class Example_SetTIFFCompression
{
    public static void Main()
    {
        Bitmap myBitmap;
        ImageCodecInfo myImageCodecInfo;
        Encoder myEncoder;
        EncoderParameter myEncoderParameter;
        EncoderParameters myEncoderParameters;
                     
        // Create a Bitmap object based on a BMP file.
        myBitmap = new Bitmap("Shapes.bmp");
                     
        // Get an ImageCodecInfo object that represents the TIFF codec.
        myImageCodecInfo = GetEncoderInfo("image/tiff");
                     
        // Create an Encoder object based on the GUID
        // for the Compression parameter category.
        myEncoder = Encoder.Compression;
                     
        // Create an EncoderParameters object.
        // An EncoderParameters object has an array of EncoderParameter
        // objects. In this case, there is only one
        // EncoderParameter object in the array.
        myEncoderParameters = new EncoderParameters(1);
                     
        // Save the bitmap as a TIFF file with LZW compression.
        myEncoderParameter = new EncoderParameter(
            myEncoder,
            (long)EncoderValue.CompressionLZW);
        myEncoderParameters.Param[0] = myEncoderParameter;
        myBitmap.Save("ShapesLZW.tif", myImageCodecInfo, myEncoderParameters);
    }
    private static ImageCodecInfo GetEncoderInfo(String mimeType)
    {
        int j;
        ImageCodecInfo[] encoders;
        encoders = ImageCodecInfo.GetImageEncoders();
        for(j = 0; j < encoders.Length; ++j)
        {
            if(encoders[j].MimeType == mimeType)
                return encoders[j];
        }
        return null;
    }
}
// </snippet2>
