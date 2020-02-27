#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::Security::Permissions;

public ref class BufferingExamples: public Form
{
private:
   BufferedGraphicsContext^ appDomainBufferedGraphicsContext;
   BufferedGraphics^ grafx;

public:
   [SecurityPermission(SecurityAction::Demand, Flags=SecurityPermissionFlag::UnmanagedCode)]
   BufferingExamples() : Form()
   {
      //<Snippet1>
      // Retrieves the BufferedGraphicsContext for the 
      // current application domain.
      BufferedGraphicsContext^ appDomainGraphicsContext =
         BufferedGraphicsManager::Current;
      //</Snippet1>

      appDomainGraphicsContext->MaximumBuffer = System::Drawing::Size( 400, 400 );
      appDomainBufferedGraphicsContext = BufferedGraphicsManager::Current;
      
      //<Snippet2>
      // Sets the maximum size for the graphics buffer 
      // of the buffered graphics context. Any allocation 
      // requests for a buffer larger than this will create 
      // a temporary buffered graphics context to host 
      // the graphics buffer.
      appDomainBufferedGraphicsContext->MaximumBuffer = System::Drawing::Size( 400, 400 );
      //</Snippet2>

      //<Snippet3>
      // Allocates a graphics buffer using the pixel format 
      // of the specified Graphics object.
      grafx = appDomainBufferedGraphicsContext->Allocate( this->CreateGraphics(),
         Rectangle( 0, 0, 400, 400 ) );
      //</Snippet3>

      //<Snippet4>
      // Allocates a graphics buffer using the pixel format 
      // of the specified handle to a device context.
      grafx = appDomainBufferedGraphicsContext->Allocate( this->Handle,
         Rectangle( 0, 0, 400, 400 ) );
      //</Snippet4>
   }

   //<Snippet5>
private:
   void RenderToGraphics( Graphics^ g )
   {
      grafx->Render( g );
   }
   //</Snippet5>

   //<Snippet6>
private:
   void RenderToDeviceContextHandle( IntPtr hDC )
   {
      grafx->Render( hDC );
   }
   //</Snippet6>
};

[STAThread]
int main()
{
   Application::Run( gcnew BufferingExamples );
}
