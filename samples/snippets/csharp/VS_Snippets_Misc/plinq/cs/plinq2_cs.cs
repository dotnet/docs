using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

class Example
{
    public static void Main()
    {
        IntroTopic_OptInModel();
        IntroTopic_OptIntoOrdering();
        ForAllOperator();
        CustomPartitioners();
    }

    static void IntroTopic_OptInModel()
    {
        // <snippet1>
        var source = Enumerable.Range(1, 10000);

        // Opt in to PLINQ with AsParallel.
        var evenNums = from num in source.AsParallel()
                       where num % 2 == 0
                       select num;
        Console.WriteLine($"{evenNums.Count()} even numbers out of {source.Count()} total");
        // The example displays the following output:
        //       5000 even numbers out of 10000 total
        // </snippet1>
    }

    static int Compute(int i)
    {
        return 1;
    }

    static void IntroTopic_OptIntoOrdering()
    {
        var numbers = Enumerable.Range(0, 1000);
        // <snippet3>
        var evenNums =
            from num in numbers.AsParallel().AsOrdered()
            where num % 2 == 0
            select num;
        // </snippet3>
    }

    static void ForAllOperator()
    {
        var concurrentBag = new ConcurrentBag<int>();

        // <snippet4>
        var nums = Enumerable.Range(10, 10000);
        var query =
            from num in nums.AsParallel()
            where num % 10 == 0
            select num;

        // Process the results as each thread completes
        // and add them to a System.Collections.Concurrent.ConcurrentBag(Of Int)
        // which can safely accept concurrent add operations
        query.ForAll(e => concurrentBag.Add(Compute(e)));
        // </snippet4>
    }

    static void CustomPartitioners()
    {
        // <Snippet2>
        int[] arr = new int[9999];
        Partitioner<int> partitioner = new MyArrayPartitioner<int>(arr);
        var query = partitioner.AsParallel().Select(SomeFunction);
        // </Snippet2>
    }

    public static int SomeFunction(int x)
    {
        return x * x;
    }
}

class MyArrayPartitioner<T> : Partitioner<T>
{
    private readonly List<T> _list = new();

    public MyArrayPartitioner(T[] arr)
    {
        foreach (var element in arr)
        {
            _list.Add(element);
        }
    }

    public override IList<IEnumerator<T>> GetPartitions(int partitionCount)
    {
        List<IEnumerator<T>> enumList = new();
        enumList.Add(_list.GetEnumerator());
        return enumList;
    }
}
