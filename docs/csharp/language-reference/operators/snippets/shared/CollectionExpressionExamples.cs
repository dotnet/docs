﻿using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using System.Collections;


// <BuilderAttribute>
[CollectionBuilder(typeof(LineBufferBuilder), "Create")]
// </BuilderAttribute>
// <BufferDeclaration>
public class LineBuffer : IEnumerable<char>
{
    private readonly char[] _buffer;
    private readonly int _count;

    public LineBuffer(ReadOnlySpan<char> buffer)
    {
        _buffer = new char[buffer.Length];
        _count = buffer.Length;
        for (int i = 0; i < _count; i++)
        {
            _buffer[i] = buffer[i];
        }
    }

    public int Count => _count;
    
    public char this[int index]
    {
        get
        {
            if (index >= _count)
                throw new IndexOutOfRangeException();
            return _buffer[index];
        }
    }

    public IEnumerator<char> GetEnumerator()
    {
        for (int i = 0; i < _count; i++)
        {
            yield return _buffer[i];
        }
    }
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    // etc
}
// </BufferDeclaration>

// <BuilderClass>
internal static class LineBufferBuilder
{
    internal static LineBuffer Create(ReadOnlySpan<char> values) => new LineBuffer(values);
}
// </BuilderClass>

public class CollectionExpressionExamples
{
    internal static void Examples()
    {
        // <CustomBuilderUsage>
        LineBuffer line = ['H', 'e', 'l', 'l', 'o', ' ', 'W', 'o', 'r', 'l', 'd', '!'];
        // </CustomBuilderUsage>
        IEnumerator<char> iter = line.GetEnumerator();
        while (iter.MoveNext())
        {
            Console.Write(iter.Current);
        }
        Console.WriteLine();

        // <FirstCollectionExpression>
        Span<string> weekDays = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];
        foreach (var day in weekDays)
        {
            Console.WriteLine(day);
        }
        // </FirstCollectionExpression>

        // <UseVariables>
        string hydrogen = "H";
        string helium = "He";
        string lithium = "Li";
        string beryllium = "Be";
        string boron = "B";
        string carbon = "C";
        string nitrogen = "N";
        string oxygen = "O";
        string fluorine = "F";
        string neon = "Ne";
        string[] elements = [hydrogen, helium, lithium, beryllium, boron, carbon, nitrogen, oxygen, fluorine, neon];
        foreach (var element in elements)
        {
            Console.WriteLine(element);
        }
        // </UseVariables>

        // <SpreadOperator>
        string[] vowels = ["a", "e", "i", "o", "u"];
        string[] consonants = ["b", "c", "d", "f", "g", "h", "j", "k", "l", "m",
                               "n", "p", "q", "r", "s", "t", "v", "w", "x", "z"];
        string[] alphabet = [.. vowels, .. consonants, "y"];
        // </SpreadOperator>
    }


    public class Container
    {
        // <CompileTimeExpressions>
        // Initialize private field:
        private static readonly ImmutableArray<string> _months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];

        // property with expression body:
        public IEnumerable<int> MaxDays =>
            [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];

        public int Sum(IEnumerable<int> values) =>
            values.Sum();

        public void Example()
        {
            // As a parameter:
            int sum = Sum([1, 2, 3, 4, 5]);
        }
        // </CompileTimeExpressions>
    }
}

