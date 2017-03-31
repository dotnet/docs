using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BufferingExample 
{
[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")]

    public class BufferingExamples : Form
    {
        private BufferedGraphicsContext appDomainBufferedGraphicsContext;
        private BufferedGraphics grafx;	

        public BufferingExamples() : base()
        {
            //<Snippet1>
            // Retrieves the BufferedGraphicsContext for the 
            // current application domain.
            BufferedGraphicsContext appDomainGraphicsContext = 
                 BufferedGraphicsManager.Current;
            //</Snippet1>

            appDomainGraphicsContext.MaximumBuffer = new Size(400, 400);
            appDomainBufferedGraphicsContext = BufferedGraphicsManager.Current;

            //<Snippet2>
            // Sets the maximum size for the graphics buffer 
            // of the buffered graphics context. Any allocation 
            // requests for a buffer larger than this will create 
            // a temporary buffered graphics context to host 
            // the graphics buffer.
            appDomainBufferedGraphicsContext.MaximumBuffer = new Size(400, 400);
            //</Snippet2>

            //<Snippet3>
            // Allocates a graphics buffer using the pixel format 
            // of the specified Graphics object.
            grafx = appDomainBufferedGraphicsContext.Allocate(this.CreateGraphics(), 
                 new Rectangle( 0, 0, 400, 400 ));
            //</Snippet3>

            //<Snippet4>
            // Allocates a graphics buffer using the pixel format 
            // of the specified handle to a device context.
            grafx = appDomainBufferedGraphicsContext.Allocate(this.Handle, 
                 new Rectangle( 0, 0, 400, 400 ));            
            //</Snippet4>
        }

        //<Snippet5>
        private void RenderToGraphics(Graphics g)
        {
            grafx.Render( g );
        }
        //</Snippet5>

        //<Snippet6>
        private void RenderToDeviceContextHandle(IntPtr hDC)
        {
            grafx.Render( hDC );
        }
        //</Snippet6>

        [STAThread]
        public static void Main(string[] args)
        {
	    Application.Run(new BufferingExamples());
        }
    }
}