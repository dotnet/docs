// This is a custom TextBox control that overrides the OnClick method
// to allow one-click selection of the text in the text box.
public ref class SingleClickTextBox: public TextBox
{
protected:
   virtual void OnClick( EventArgs^ e ) override
   {
      this->SelectAll();
      TextBox::OnClick( e );
   }
};