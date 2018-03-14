using System;
using System.Data;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Text;


[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.Native,
     IsByteOrdered=true,  
     Name="Point",ValidationMethodName = "ValidatePoint")]
public struct Point : INullable
{

    private bool is_Null;
    private Int32 _x;
    private Int32 _y;

// <Snippet1>
// Distance from Point to the specified x and y values method.
[SqlMethod(OnNullCall = false, IsMutator=false, InvokeIfReceiverIsNull=false)]
public Double DistanceFromXY(Int32 iX, Int32 iY)
{
   return Math.Sqrt(Math.Pow(iX - _x, 2.0) + Math.Pow(iY - _y, 2.0));
}
//</Snippet1>

    public bool IsNull
    {
        get
        {
            return (is_Null);
        }
    }

    public static Point Null
    {
        get
        {
            Point pt = new Point();
            pt.is_Null = true;
            return pt;
        }
    }

    // Use StringBuilder to provide string representation of UDT.
    public override string ToString()
    {
        // Since InvokeIfReceiverIsNull defaults to 'true'
        // this test is unneccesary if Point is only being called
        // from SQL.
        if (this.IsNull)
            return "NULL";
        else
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(_x);
            builder.Append(",");
            builder.Append(_y);
            return builder.ToString();
        }
    }

    [SqlMethod(OnNullCall = false)]
    public static Point Parse(SqlString s)
    {
        // With OnNullCall=false, this check is unnecessary if 
        // Point only called from SQL.
        if (s.IsNull)
            return Null;

        // Parse input string to separate out points.
        Point pt = new Point();
        string[] xy = s.Value.Split(",".ToCharArray());
        pt.X = Int32.Parse(xy[0]);
        pt.Y = Int32.Parse(xy[1]);

        // Call ValidatePoint to enforce validation
        // for string conversions.
        if (!pt.ValidatePoint()) 
            throw new ArgumentException("Invalid XY coordinate values.");
        return pt;
    }

    // X and Y coordinates exposed as properties.
    public Int32 X
    {
        get
        {
            return this._x;
        }
        // Call ValidatePoint to ensure valid range of Point values.
        set 
        {
            Int32 temp = _x;
            _x = value;
            if (!ValidatePoint())
            {
                _x = temp;
                throw new ArgumentException("Invalid X coordinate value.");
            }
        }
    }

    public Int32 Y
    {
        get
        {
            return this._y;
        }
        set
        {
            Int32 temp = _y;
            _y = value;
            if (!ValidatePoint())
            {
                _y = temp;
                throw new ArgumentException("Invalid Y coordinate value.");
            }
        }
    }

    // Validation method to enforce valid X and Y values.
    private bool ValidatePoint()
    {
        return true;
    }

    
}
