

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

// This example demonstrates using the following members: 
// Form.BackColor, Control.RectangleToScreen, Control.PointToScreen,
// ControlPaint.DrawReversibleFrame, and Rectangle.Intersects.
using namespace System::Windows::Forms;
using namespace System::Drawing;
public ref class Form1: public System::Windows::Forms::Form
{
public:
   Form1()
      : Form()
   {
      
      // This call is required by the Windows Form Designer.
      InitializeComponent();
      isDrag = false;
      theRectangle = Rectangle(Point(0,0),System::Drawing::Size( 0, 0 ));
      this->Button1->Click += gcnew System::EventHandler( this, &Form1::Button1_Click );
   }


internal:
   System::Windows::Forms::Button^ Button1;
   System::Windows::Forms::Button^ Button2;
   System::Windows::Forms::Label ^ Label1;

private:
   void InitializeComponent()
   {
      this->Button1 = gcnew System::Windows::Forms::Button;
      this->Button2 = gcnew System::Windows::Forms::Button;
      this->Label1 = gcnew System::Windows::Forms::Label;
      this->SuspendLayout();
      this->Button1->Location = System::Drawing::Point( 40, 64 );
      this->Button1->Name = "Button1";
      this->Button1->Size = System::Drawing::Size( 80, 50 );
      this->Button1->TabIndex = 0;
      this->Button1->Text = "Click for a bigger form.";
      this->Button2->Location = System::Drawing::Point( 144, 64 );
      this->Button2->Name = "Button2";
      this->Button2->Size = System::Drawing::Size( 72, 48 );
      this->Button2->TabIndex = 1;
      this->Button2->Text = "Click me and nothing happens.";
      this->Label1->Location = System::Drawing::Point( 72, 168 );
      this->Label1->Name = "Label1";
      this->Label1->Size = System::Drawing::Size( 152, 32 );
      this->Label1->TabIndex = 2;
      this->Label1->Text = "Click and drag on screen to see a frame drawn.";
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Controls->Add( this->Label1 );
      this->Controls->Add( this->Button2 );
      this->Controls->Add( this->Button1 );
      this->Name = "Form1";
      this->Text = "Form1";
      
      // Explicitly set the form's BackColor property.
      this->BackColor = Color::Cornsilk;
      this->ResumeLayout( false );
      
      // Associate the event-handling methods with the appropriate
      // event.
      this->MouseDown += gcnew MouseEventHandler( this, &Form1::Form1_MouseDown );
      this->MouseMove += gcnew MouseEventHandler( this, &Form1::Form1_MouseMove );
      this->MouseUp += gcnew MouseEventHandler( this, &Form1::Form1_MouseUp );
   }

   // <snippet1>
private:
   // This method retrieves the form's client rectangle, inflates it,
   // and forces layout of the form by resetting the bounds.  
   void Button1_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      Rectangle clientRectangle = this->ClientRectangle;
      clientRectangle.Inflate( 50, 50 );
      
      // Convert the rectangle coordinates to screen coordinates.
      this->Bounds = this->RectangleToScreen( clientRectangle );
   }
   //</snippet1>

   //<snippet2>
private:
   // The following three methods will draw a rectangle and allow 
   // the user to use the mouse to resize the rectangle.  If the 
   // rectangle intersects a control's client rectangle, the 
   // control's color will change.
   bool isDrag;
   Rectangle theRectangle;
   Point startPoint;
   void Form1_MouseDown( Object^ sender, System::Windows::Forms::MouseEventArgs^ e )
   {
      
      // Set the isDrag variable to true and get the starting point 
      // by using the PointToScreen method to convert form 
      // coordinates to screen coordinates.
      if ( e->Button == ::MouseButtons::Left )
      {
         isDrag = true;
      }

      Control^ control = dynamic_cast<Control^>(sender);
      
      // Calculate the startPoint by using the PointToScreen 
      // method.
      startPoint = control->PointToScreen( Point(e->X,e->Y) );
   }

   void Form1_MouseMove( Object^ /*sender*/, System::Windows::Forms::MouseEventArgs^ e )
   {
      
      // If the mouse is being dragged, 
      // undraw and redraw the rectangle as the mouse moves.
      if ( isDrag )
      {
         ControlPaint::DrawReversibleFrame( theRectangle, this->BackColor, FrameStyle::Dashed );
         
         // Calculate the endpoint and dimensions for the new 
         // rectangle, again using the PointToScreen method.
         Point endPoint = this->PointToScreen( Point(e->X,e->Y) );
         int width = endPoint.X - startPoint.X;
         int height = endPoint.Y - startPoint.Y;
         theRectangle = Rectangle(startPoint.X,startPoint.Y,width,height);
         
         // Draw the new rectangle by calling DrawReversibleFrame
         // again.  
         ControlPaint::DrawReversibleFrame( theRectangle, this->BackColor, FrameStyle::Dashed );
      }
   }

   void Form1_MouseUp( Object^ /*sender*/, System::Windows::Forms::MouseEventArgs^ /*e*/ )
   {
      
      // If the MouseUp event occurs, the user is not dragging.
      isDrag = false;
      
      // Draw the rectangle to be evaluated. Set a dashed frame style 
      // using the FrameStyle enumeration.
      ControlPaint::DrawReversibleFrame( theRectangle, this->BackColor, FrameStyle::Dashed );
      
      // Find out which controls intersect the rectangle and 
      // change their color. The method uses the RectangleToScreen  
      // method to convert the Control's client coordinates 
      // to screen coordinates.
      Rectangle controlRectangle;
      for ( int i = 0; i < Controls->Count; i++ )
      {
         controlRectangle = Controls[ i ]->RectangleToScreen( Controls[ i ]->ClientRectangle );
         if ( controlRectangle.IntersectsWith( theRectangle ) )
         {
            Controls[ i ]->BackColor = Color::BurlyWood;
         }

      }
      
      // Reset the rectangle.
      theRectangle = Rectangle(0,0,0,0);
   }
   // </snippet2>
};

[System::STAThreadAttribute]
int main()
{
   Application::Run( gcnew Form1 );
}
