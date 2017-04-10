//<snippet1>

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

// for Marshal.Copy
using System.Runtime.InteropServices; 

public class Form1 : Form
{
    private Metafile metafile1;
    private Graphics.EnumerateMetafileProc metafileDelegate;
    private Point destPoint;
    public Form1()
    {
        metafile1 = new Metafile(@"C:\Test.wmf");
        metafileDelegate = new Graphics.EnumerateMetafileProc(MetafileCallback);
        destPoint = new Point(20, 10);
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.EnumerateMetafile(metafile1, destPoint, metafileDelegate);
    }
    private bool MetafileCallback(
       EmfPlusRecordType recordType,
       int flags,
       int dataSize,
       IntPtr data,
       PlayRecordCallback callbackData)
    {
        byte[] dataArray = null;
        if (data != IntPtr.Zero)
        {
            // Copy the unmanaged record to a managed byte buffer 
            // that can be used by PlayRecord.
            dataArray = new byte[dataSize];
            Marshal.Copy(data, dataArray, 0, dataSize);
        }

        metafile1.PlayRecord(recordType, flags, dataSize, dataArray);

        return true;
    }

    static void Main()
    {
        Application.Run(new Form1());
    }
}
//</snippet1>