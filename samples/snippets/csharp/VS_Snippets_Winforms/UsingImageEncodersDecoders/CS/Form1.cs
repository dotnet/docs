using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace GDIPlusPort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        //<snippet1>
        private void GetImageEncodersExample(PaintEventArgs e)
        {
            // Get an array of available encoders.
            ImageCodecInfo[] myCodecs;
            myCodecs = ImageCodecInfo.GetImageEncoders();
            int numCodecs = myCodecs.GetLength(0);

            // Set up display variables.
            Color foreColor = Color.Black;
            Font font = new Font("Arial", 8);
            int i = 0;

            // Check to determine whether any codecs were found.
            if (numCodecs > 0)
            {
                // Set up an array to hold codec information. There are 9
                // information elements plus 1 space for each codec, so 10 times
                // the number of codecs found is allocated.
                string[] myCodecInfo = new string[numCodecs * 10];

                // Write all the codec information to the array.
                for (i = 0; i < numCodecs; i++)
                {
                    myCodecInfo[i * 10] = "Codec Name = " + myCodecs[i].CodecName;
                    myCodecInfo[(i * 10) + 1] = "Class ID = " +
                        myCodecs[i].Clsid.ToString();
                    myCodecInfo[(i * 10) + 2] = "DLL Name = " + myCodecs[i].DllName;
                    myCodecInfo[(i * 10) + 3] = "Filename Ext. = " +
                        myCodecs[i].FilenameExtension;
                    myCodecInfo[(i * 10) + 4] = "Flags = " +
                        myCodecs[i].Flags.ToString();
                    myCodecInfo[(i * 10) + 5] = "Format Descrip. = " +
                        myCodecs[i].FormatDescription;
                    myCodecInfo[(i * 10) + 6] = "Format ID = " +
                        myCodecs[i].FormatID.ToString();
                    myCodecInfo[(i * 10) + 7] = "MimeType = " + myCodecs[i].MimeType;
                    myCodecInfo[(i * 10) + 8] = "Version = " +
                        myCodecs[i].Version.ToString();
                    myCodecInfo[(i * 10) + 9] = " ";
                }
                int numMyCodecInfo = myCodecInfo.GetLength(0);

                // Render all of the information to the screen.
                int j = 20;
                for (i = 0; i < numMyCodecInfo; i++)
                {
                    e.Graphics.DrawString(myCodecInfo[i],
                        font,
                        new SolidBrush(foreColor),
                        20,
                        j);
                    j += 12;
                }
            }
            else
                e.Graphics.DrawString("No Codecs Found",
                    font,
                    new SolidBrush(foreColor),
                    20,
                    20);
        }

        //</snippet1>

        //<snippet2>
        private void GetImageDecodersExample(PaintEventArgs e)
        {
            // Get an array of available decoders.
            ImageCodecInfo[] myCodecs;
            myCodecs = ImageCodecInfo.GetImageDecoders();
            int numCodecs = myCodecs.GetLength(0);

            // Set up display variables.
            Color foreColor = Color.Black;
            Font font = new Font("Arial", 8);
            int i = 0;

            // Check to determine whether any codecs were found.
            if (numCodecs > 0)
            {
                // Set up an array to hold codec information. There are 9
                // information elements plus 1 space for each codec, so 10 times
                // the number of codecs found is allocated.
                string[] myCodecInfo = new string[numCodecs * 10];

                // Write all the codec information to the array.
                for (i = 0; i < numCodecs; i++)
                {
                    myCodecInfo[i * 10] = "Codec Name = " + myCodecs[i].CodecName;
                    myCodecInfo[(i * 10) + 1] = "Class ID = " +
                        myCodecs[i].Clsid.ToString();
                    myCodecInfo[(i * 10) + 2] = "DLL Name = " + myCodecs[i].DllName;
                    myCodecInfo[(i * 10) + 3] = "Filename Ext. = " +
                        myCodecs[i].FilenameExtension;
                    myCodecInfo[(i * 10) + 4] = "Flags = " +
                        myCodecs[i].Flags.ToString();
                    myCodecInfo[(i * 10) + 5] = "Format Descrip. = " +
                        myCodecs[i].FormatDescription;
                    myCodecInfo[(i * 10) + 6] = "Format ID = " +
                        myCodecs[i].FormatID.ToString();
                    myCodecInfo[(i * 10) + 7] = "MimeType = " + myCodecs[i].MimeType;
                    myCodecInfo[(i * 10) + 8] = "Version = " +
                        myCodecs[i].Version.ToString();
                    myCodecInfo[(i * 10) + 9] = " ";
                }
                int numMyCodecInfo = myCodecInfo.GetLength(0);

                // Render all of the information to the screen.
                int j = 20;
                for (i = 0; i < numMyCodecInfo; i++)
                {
                    e.Graphics.DrawString(myCodecInfo[i],
                        font,
                        new SolidBrush(foreColor),
                        20,
                        j);
                    j += 12;
                }
            }
            else
                e.Graphics.DrawString("No Codecs Found",
                    font,
                    new SolidBrush(foreColor),
                    20,
                    20);
        }
        //</snippet2>


        //<snippet3>
        private void GetSupportedParameters(PaintEventArgs e)
        {
            Bitmap bitmap1 = new Bitmap(1, 1);
            ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
            EncoderParameters paramList = bitmap1.GetEncoderParameterList(jpgEncoder.Clsid);
            EncoderParameter[] encParams = paramList.Param;
            StringBuilder paramInfo = new StringBuilder();

            for (int i = 0; i < encParams.Length; i++)
            {
                paramInfo.Append("Param " + i + " holds " + encParams[i].NumberOfValues +
                    " items of type " +
                    encParams[i].ValueType + "\r\n" + "Guid category: " + encParams[i].Encoder.Guid + "\r\n");

            }
            e.Graphics.DrawString(paramInfo.ToString(), this.Font, Brushes.Red, 10.0F, 10.0F);
        }
        
        //<snippet6>
        private ImageCodecInfo GetEncoder(ImageFormat format)
        {

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
        //</snippet6>
        //</snippet3>

        //<snippet4>
        private void SaveBmpAsPNG()
        {
            Bitmap bmp1 = new Bitmap(typeof(Button), "Button.bmp");
            bmp1.Save(@"c:\button.png", ImageFormat.Png);
        }
        //</snippet4>

        //<snippet8>
        private void VaryQualityLevel()
        {
            // Get a bitmap.
            Bitmap bmp1 = new Bitmap(@"c:\TestPhoto.jpg");
            ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);

            // Create an Encoder object based on the GUID
            // for the Quality parameter category.
            System.Drawing.Imaging.Encoder myEncoder =
                System.Drawing.Imaging.Encoder.Quality;

            // Create an EncoderParameters object.
            // An EncoderParameters object has an array of EncoderParameter
            // objects. In this case, there is only one
            // EncoderParameter object in the array.
            EncoderParameters myEncoderParameters = new EncoderParameters(1);

            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 50L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            bmp1.Save(@"c:\TestPhotoQualityFifty.jpg", jpgEncoder, myEncoderParameters);

            myEncoderParameter = new EncoderParameter(myEncoder, 100L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            bmp1.Save(@"c:\TestPhotoQualityHundred.jpg", jpgEncoder, myEncoderParameters);

            // Save the bitmap as a JPG file with zero quality level compression.
            myEncoderParameter = new EncoderParameter(myEncoder, 0L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            bmp1.Save(@"c:\TestPhotoQualityZero.jpg", jpgEncoder, myEncoderParameters);

        }
        //</snippet8>
       
        private void Form1_Load(object sender, EventArgs e)
        {
            //SaveBmpAsPng();
        }

        private void Form1_Paint(object sender, PaintEventArgs e) 
        {
            GetSupportedParameters(e);
            SaveBmpAsPNG();
            VaryQualityLevel();
           // GetImageDecodersExample(e);
        }

    }
}