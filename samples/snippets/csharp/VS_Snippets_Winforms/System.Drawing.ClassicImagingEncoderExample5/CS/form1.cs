 // Snippet for: F:System.Drawing.Imaging.Encoder.Transformation
        // <snippet5>
using System;
using System.Drawing;
using System.Drawing.Imaging;
class Example_RotateJPEG
{
    public static void Main()
    {
        Bitmap myBitmap;
        ImageCodecInfo myImageCodecInfo;
        Encoder myEncoder;
        EncoderParameter myEncoderParameter;
        EncoderParameters myEncoderParameters;
                     
        // Create a Bitmap object based on a JPEG file.
        myBitmap = new Bitmap("Shapes.jpg");
                     
        // Get an ImageCodecInfo object that represents the JPEG codec.
        myImageCodecInfo = GetEncoderInfo("image/jpeg");
                     
        // Create an Encoder object based on the GUID
        // for the Transformation parameter category.
        myEncoder = Encoder.Transformation;
                     
        // Create an EncoderParameters object.
        // An EncoderParameters object has an array of EncoderParameter
        // objects. In this case, there is only one
        // EncoderParameter object in the array.
        myEncoderParameters = new EncoderParameters(1);
                     
        // Rotate the image 90 degrees, and save it as a separate JPEG file.
        myEncoderParameter = new EncoderParameter(
            myEncoder,
            (long)EncoderValue.TransformRotate90);
        myEncoderParameters.Param[0] = myEncoderParameter;
        myBitmap.Save("ShapesR90.jpg", myImageCodecInfo, myEncoderParameters);
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
        // </snippet5>