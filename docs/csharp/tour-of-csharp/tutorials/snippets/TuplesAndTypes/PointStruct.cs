namespace MoreStruct;

// <RecordStruct>
public record struct Point(int X, int Y)
{
    public double Slope() => (double) Y / (double) X;
}
// </RecordStruct>
