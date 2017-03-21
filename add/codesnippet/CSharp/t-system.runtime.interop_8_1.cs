   enum Bool
   {
      False = 0,
      True
   };
   [StructLayout(LayoutKind.Sequential)]
   public struct Point 
   {
      public int x;
      public int y;
   }   

   [StructLayout(LayoutKind.Explicit)]
   public struct Rect 
   {
      [FieldOffset(0)] public int left;
      [FieldOffset(4)] public int top;
      [FieldOffset(8)] public int right;
      [FieldOffset(12)] public int bottom;
   }   

   class LibWrapper
   {
      [DllImport("user32.dll", CallingConvention=CallingConvention.StdCall)]
      public static extern Bool PtInRect(ref Rect r, Point p);
   };

   class TestApplication
   {
      public static void Main()
      {
         try
         {
            Bool bPointInRect = 0;
            Rect myRect = new Rect();
            myRect.left = 10;
            myRect.right = 100;
            myRect.top = 10;
            myRect.bottom = 100;
            Point myPoint = new Point();
            myPoint.x = 50;
            myPoint.y = 50;
            bPointInRect = LibWrapper.PtInRect(ref myRect, myPoint);
            if(bPointInRect == Bool.True)
               Console.WriteLine("Point lies within the Rect");
            else
               Console.WriteLine("Point did not lie within the Rect");
         }
         catch(Exception e)
         {
            Console.WriteLine("Exception : " + e.Message);
         }
      }
   }