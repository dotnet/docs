public bool DoubleBufferingEnabled()
{
   // Get the value of the double-buffering style bits.
   return this.GetStyle(ControlStyles.DoubleBuffer | 
      ControlStyles.UserPaint | 
      ControlStyles.AllPaintingInWmPaint);
}