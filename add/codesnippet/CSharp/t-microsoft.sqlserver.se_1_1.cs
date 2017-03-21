// Distance from Point to the specified x and y values method.
[SqlMethod(OnNullCall = false, IsMutator=false, InvokeIfReceiverIsNull=false)]
public Double DistanceFromXY(Int32 iX, Int32 iY)
{
   return Math.Sqrt(Math.Pow(iX - _x, 2.0) + Math.Pow(iY - _y, 2.0));
}