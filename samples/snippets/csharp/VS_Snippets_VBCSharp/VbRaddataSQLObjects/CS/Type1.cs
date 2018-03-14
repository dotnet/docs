//-----------------------------------------------------------------------------
//<Snippet5>
using System;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

[Serializable()]
[SqlUserDefinedType(Format.Native)]
public struct Point : INullable
{
    private Int32 m_x;
    private Int32 m_y;
    private bool is_Null;


    public Int32 X
    {
        get
        {
            return (this.m_x);
        }
        set
        {
            m_x = value;
        }
    }


    public Int32 Y
    {
        get
        {
            return (this.m_y);
        }
        set
        {
            m_y = value;
        }
    }


    public bool IsNull
    {
        get
        {
            return is_Null;
        }
    }


    public static Point Null
    {
        get
        {
            Point pt = new Point();
            pt.is_Null = true;
            return (pt);
        }
    }


    public override string ToString()
    {
        if (this.IsNull)
        {
            return "NULL";
        }
        else
        {
            return this.m_x + ":" + this.m_y;
        }
    }


    public static Point Parse(SqlString s)
    {
        if (s.IsNull)
        {
            return Null;
        }

        // Parse input string here to separate out coordinates
        string str = Convert.ToString(s);
        string[] xy = str.Split(':');

        Point pt = new Point();
        pt.X = Convert.ToInt32(xy[0]);
        pt.Y = Convert.ToInt32(xy[1]);
        return (pt);
    }


    public SqlString Quadrant()
    {
        if (m_x == 0 && m_y == 0)
        {
            return "centered";
        } 

        SqlString stringReturn = "";

        if (m_x == 0)
        {
            stringReturn = "center";
        }
        else if (m_x > 0)
        {
            stringReturn = "right";
        } 
        else if (m_x < 0)
        {
            stringReturn = "left";
        }

        if (m_y == 0) 
        {
            stringReturn = stringReturn + " center";
        }
        else if (m_y > 0)
        {
            stringReturn = stringReturn + " top";
        }
        else if (m_y < 0)
        {
            stringReturn = stringReturn + " bottom";
        }

        return stringReturn;
    }
}
//</Snippet5>


//-----------------------------------------------------------------------------
//<Snippet12>
[SqlUserDefinedType(Format.Native, MaxByteSize=8000)]
public class SampleType
{
   //...
}
//</Snippet12>
