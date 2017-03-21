protected override void SetBoundsCore(int x, int y, 
   int width, int height, BoundsSpecified specified)
{
   // Set a fixed height and width for the control.
   base.SetBoundsCore(x, y, 150, 75, specified);
}