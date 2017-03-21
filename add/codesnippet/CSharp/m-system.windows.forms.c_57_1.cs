protected override void SetClientSizeCore(int x, int y)
{
   // Keep the client size square.
   if(x > y)
   {
      base.SetClientSizeCore(x, x);
   }
   else
   {
      base.SetClientSizeCore(y, y);
   }
}