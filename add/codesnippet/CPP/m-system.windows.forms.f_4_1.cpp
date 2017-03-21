public ref class myForm: public Form
{
protected:
   virtual void OnClosed( EventArgs^ e ) override
   {
      MessageBox::Show( "The form is now closing.", "Close Warning", MessageBoxButtons::OK, MessageBoxIcon::Warning );
      Form::OnClosed( e );
   }

public:
   myForm()
      : Form()
   {}

};