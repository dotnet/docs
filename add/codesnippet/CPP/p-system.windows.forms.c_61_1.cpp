// To use this example create a new form and paste this class 
// forming the same file, after the form class in the same file.  
// Add a button of type FunButton to the form. 
public ref class FunButton: public Button
{
protected:
   virtual void OnMouseHover( System::EventArgs^ e ) override
   {
      
      // Get the font size in Points, add one to the
      // size, and reset the button's font to the larger
      // size.
      float fontSize = Font->SizeInPoints;
      fontSize += 1;
      System::Drawing::Size buttonSize = Size;
      this->Font = gcnew System::Drawing::Font( Font->FontFamily,fontSize,Font->Style );
      
      // Increase the size width and height of the button 
      // by 5 points each.
      Size = System::Drawing::Size( Size.Width + 5, Size.Height + 5 );
      
      // Call myBase.OnMouseHover to activate the delegate.
      Button::OnMouseHover( e );
   }

   virtual void OnMouseMove( MouseEventArgs^ e ) override
   {
      
      // Make the cursor the Hand cursor when the mouse moves 
      // over the button.
      Cursor = Cursors::Hand;
      
      // Call MyBase.OnMouseMove to activate the delegate.
      Button::OnMouseMove( e );
   }