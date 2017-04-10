// <Snippet1>
using System;
using System.Collections;
using System.Collections.Generic;

class Program
{

    static void Main(string[] args)
    {

        BoxCollection bxList = new BoxCollection();

        bxList.Add(new Box(10, 4, 6));
        bxList.Add(new Box(4, 6, 10));
        bxList.Add(new Box(6, 10, 4));
        bxList.Add(new Box(12, 8, 10));

        // Same dimensions. Cannot be added:
        bxList.Add(new Box(10, 4, 6));

        // Test the Remove method.
        Display(bxList);
        Console.WriteLine("Removing 6x10x4");
        bxList.Remove(new Box(6, 10, 4));
        Display(bxList);

        // Test the Contains method.
        Box BoxCheck = new Box(8, 12, 10);
        Console.WriteLine("Contains {0}x{1}x{2} by dimensions: {3}", 
            BoxCheck.Height.ToString(), BoxCheck.Length.ToString(), 
            BoxCheck.Width.ToString(), bxList.Contains(BoxCheck).ToString());

        // Test the Contains method overload with a specified equality comparer.
        Console.WriteLine("Contains {0}x{1}x{2} by volume: {3}", 
            BoxCheck.Height.ToString(), BoxCheck.Length.ToString(), 
            BoxCheck.Width.ToString(), bxList.Contains(BoxCheck, 
            new BoxSameVol()).ToString());

    }
    // <Snippet2>
    public static void Display(BoxCollection bxList)
    {
        Console.WriteLine("\nHeight\tLength\tWidth\tHash Code");
        foreach (Box bx in bxList)
        {
            Console.WriteLine("{0}\t{1}\t{2}\t{3}",
                bx.Height.ToString(), bx.Length.ToString(), 
                bx.Width.ToString(), bx.GetHashCode().ToString());
        }

        // Results by manipulating the enumerator directly:

        //IEnumerator enumerator = bxList.GetEnumerator();
        //Console.WriteLine("\nHeight\tLength\tWidth\tHash Code");
        //while (enumerator.MoveNext())
        //{
        //    Box b = (Box)enumerator.Current;
        //    Console.WriteLine("{0}\t{1}\t{2}\t{3}",
        //    b.Height.ToString(), b.Length.ToString(), 
        //    b.Width.ToString(), b.GetHashCode().ToString());
        //}

        Console.WriteLine();
    }

    // </Snippet2>   
}

public class Box : IEquatable<Box>
{

    public Box(int h, int l, int w)
    {
        this.Height = h;
        this.Length = l;
        this.Width = w;
    }
    public int Height { get; set; }
    public int Length { get; set; }
    public int Width { get; set; }

    // Defines equality using the
    // BoxSameDimensions equality comparer.
    public bool Equals(Box other)
    {
        if (new BoxSameDimensions().Equals(this, other))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

public class BoxCollection : ICollection<Box>
{
    // The generic enumerator obtained from IEnumerator<Box>
    // by GetEnumerator can also be used with the non-generic IEnumerator.
    // To avoid a naming conflict, the non-generic IEnumerable method
    // is explicitly implemented.

    public IEnumerator<Box> GetEnumerator()
    {
        return new BoxEnumerator(this);
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return new BoxEnumerator(this);
    }

    // The inner collection to store objects.
    private List<Box> innerCol;

    public BoxCollection()
    {
        innerCol = new List<Box>();
    }

    // Adds an index to the collection.
    public Box this[int index]
    {
        get { return (Box)innerCol[index]; }
        set { innerCol[index] = value; }
    }

    // Determines if an item is in the collection
    // by using the BoxSameDimensions equality comparer.
    public bool Contains(Box item)
    {
        bool found = false;

        foreach (Box bx in innerCol)
        {
            // Equality defined by the Box
            // class's implmentation of IEquitable<T>.
            if (bx.Equals(item))
            {
                found = true;
            }
        }

        return found;
    }

    // Determines if an item is in the 
    // collection by using a specified equality comparer.
    public bool Contains(Box item, EqualityComparer<Box> comp)
    {
        bool found = false;

        foreach (Box bx in innerCol)
        {
            if (comp.Equals(bx, item))
            {
                found = true;
            }
        }

        return found;
    }

    // Adds an item if it is not already in the collection
    // as determined by calling the Contains method.
    public void Add(Box item)
    {

        if (!Contains(item))
        {
            innerCol.Add(item);
        }
        else
        {
            Console.WriteLine("A box with {0}x{1}x{2} dimensions was already added to the collection.",
                item.Height.ToString(), item.Length.ToString(), item.Width.ToString());
        }
    }

    public void Clear()
    {
        innerCol.Clear();
    }

    public void CopyTo(Box[] array, int arrayIndex)
    {
        if (array == null)
           throw new ArgumentNullException("The array cannot be null.");
        if (arrayIndex < 0)
           throw new ArgumentOutOfRangeException("The starting array index cannot be negative.");
        if (Count > array.Length - arrayIndex + 1)
           throw new ArgumentException("The destination array has fewer elements than the collection.");
           
        for (int i = 0; i < innerCol.Count; i++) {
            array[i + arrayIndex] = innerCol[i];
        }
    }

    public int Count
    {
        get
        {
            return innerCol.Count;
        }
    }

    public bool IsReadOnly
    {
        get { return false; }
    }

    public bool Remove(Box item)
    {
        bool result = false;

        // Iterate the inner collection to 
        // find the box to be removed.
        for (int i = 0; i < innerCol.Count; i++)
        {

            Box curBox = (Box)innerCol[i];

            if (new BoxSameDimensions().Equals(curBox, item))
            {
                innerCol.RemoveAt(i);
                result = true;
                break;
            }
        }
        return result;
    }
}

//<Snippet3>

// Defines the enumerator for the Boxes collection.
// (Some prefer this class nested in the collection class.)
public class BoxEnumerator : IEnumerator<Box>
{
    private BoxCollection _collection;
    private int curIndex;
    private Box curBox;


    public BoxEnumerator(BoxCollection collection)
    {
        _collection = collection;
        curIndex = -1;
        curBox = default(Box);

    }

    public bool MoveNext()
    {
        //Avoids going beyond the end of the collection.
        if (++curIndex >= _collection.Count)
        {
            return false;
        }
        else
        {
            // Set current box to next item in collection.
            curBox = _collection[curIndex];
        }
        return true;
    }

    public void Reset() { curIndex = -1; }

    void IDisposable.Dispose() { }

    public Box Current
    {
        get { return curBox; }
    }


    object IEnumerator.Current
    {
        get { return Current; }
    }

}
// </Snippet3>

// Defines two boxes as equal if they have the same dimensions.
public class BoxSameDimensions : EqualityComparer<Box>
{

    public override bool Equals(Box b1, Box b2)
    {
        if (b1.Height == b2.Height && b1.Length == b2.Length
                            && b1.Width == b2.Width)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public override int GetHashCode(Box bx)
    {
        int hCode = bx.Height ^ bx.Length ^ bx.Width;
        return hCode.GetHashCode();
    }

}

// Defines two boxes as equal if they have the same volume.
public class BoxSameVol : EqualityComparer<Box>
{

    public override bool Equals(Box b1, Box b2)
    {
        if ((b1.Height * b1.Length * b1.Width) ==
                (b2.Height * b2.Length * b2.Width))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public override int GetHashCode(Box bx)
    {
        int hCode = bx.Height ^ bx.Length ^ bx.Width;
        Console.WriteLine("HC: {0}", hCode.GetHashCode());
        return hCode.GetHashCode();
    }
}


/* 
This code example displays the following output:
================================================

A box with 10x4x6 dimensions was already added to the collection.

Height  Length  Width   Hash Code
10      4       6       46104728
4       6       10      12289376
6       10      4       43495525
12      8       10      55915408

Removing 6x10x4

Height  Length  Width   Hash Code
10      4       6       46104728
4       6       10      12289376
12      8       10      55915408

Contains 8x12x10 by dimensions: False
Contains 8x12x10 by volume: True 
 */

// </Snippet1>

