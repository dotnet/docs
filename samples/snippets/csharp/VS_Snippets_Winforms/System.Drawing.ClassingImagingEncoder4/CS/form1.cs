// Snippet for: F:System.Drawing.Imaging.Encoder.SaveFlag
        // <snippet4>
using System;
using System.Drawing;
using System.Drawing.Imaging;
class Example_MultiFrame
{
    public static void Main()
    {
        Bitmap multi;
        Bitmap page2;
        Bitmap page3;
        ImageCodecInfo myImageCodecInfo;
        Encoder myEncoder;
        EncoderParameter myEncoderParameter;
        EncoderParameters myEncoderParameters;
                     
        // Create three Bitmap objects.
        multi = new Bitmap("Shapes.bmp");
        page2 = new Bitmap("Iron.jpg");
        page3 = new Bitmap("House.png");
                     
        // Get an ImageCodecInfo object that represents the TIFF codec.
        myImageCodecInfo = GetEncoderInfo("image/tiff");
                     
        // Create an Encoder object based on the GUID
        // for the SaveFlag parameter category.
        myEncoder = Encoder.SaveFlag;
                     
        // Create an EncoderParameters object.
        // An EncoderParameters object has an array of EncoderParameter
        // objects. In this case, there is only one
        // EncoderParameter object in the array.
        myEncoderParameters = new EncoderParameters(1);
                     
        // Save the first page (frame).
        myEncoderParameter = new EncoderParameter(
            myEncoder,
            (long)EncoderValue.MultiFrame);
        myEncoderParameters.Param[0] = myEncoderParameter;
        multi.Save("Multiframe.tiff", myImageCodecInfo, myEncoderParameters);
                     
        // Save the second page (frame).
        myEncoderParameter = new EncoderParameter(
            myEncoder,
            (long)EncoderValue.FrameDimensionPage);
        myEncoderParameters.Param[0] = myEncoderParameter;
        multi.SaveAdd(page2, myEncoderParameters);
                     
        // Save the third page (frame).
        myEncoderParameter = new EncoderParameter(
            myEncoder,
            (long)EncoderValue.FrameDimensionPage);
        myEncoderParameters.Param[0] = myEncoderParameter;
        multi.SaveAdd(page3, myEncoderParameters);
                     
        // Close the multiple-frame file.
        myEncoderParameter = new EncoderParameter(
            myEncoder,
            (long)EncoderValue.Flush);
        myEncoderParameters.Param[0] = myEncoderParameter;
        multi.SaveAdd(myEncoderParameters);
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
        // </snippet4>

