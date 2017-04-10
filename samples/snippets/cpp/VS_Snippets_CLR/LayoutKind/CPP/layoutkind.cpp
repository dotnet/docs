
using namespace System;
using namespace System::Runtime::InteropServices;

// <Snippet1>
// <Snippet2>
enum class Bool
{
   False = 0,
   True
};


[StructLayout(LayoutKind::Sequential)]
value struct Point
{
public:
   int x;
   int y;
};


[StructLayout(LayoutKind::Explicit)]
value struct Rect
{
public:

   [FieldOffset(0)]
   int left;

   [FieldOffset(4)]
   int top;

   [FieldOffset(8)]
   int right;

   [FieldOffset(12)]
   int bottom;
};

ref class LibWrapper
{
public:

   [DllImport("user32.dll",CallingConvention=CallingConvention::StdCall)]
   static Bool PtInRect( Rect * r, Point p );
};

int main()
{
   try
   {
      Bool bPointInRect = (Bool)0;
      Rect myRect = Rect(  );
      myRect.left = 10;
      myRect.right = 100;
      myRect.top = 10;
      myRect.bottom = 100;
      Point myPoint = Point(  );
      myPoint.x = 50;
      myPoint.y = 50;
      bPointInRect = LibWrapper::PtInRect(  &myRect, myPoint );
      if ( bPointInRect == Bool::True )
            Console::WriteLine( "Point lies within the Rect" );
      else
            Console::WriteLine( "Point did not lie within the Rect" );
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception : {0}", e->Message );
   }

}

// </Snippet2>
// </Snippet1>
