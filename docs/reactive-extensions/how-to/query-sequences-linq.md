---
title: Query Observable sequences using LINQ operators
description: Learn how to query Observable sequences using various LINQ operators with Reactive Extensions in .NET.
author: IEvangelist
ms.date: 11/03/2020
ms.author: dapine
ms.topic: how-to
---

# Query Observable sequences using LINQ operators

In this topic, we will look at the first-class nature of observable sequences as <xref:System.IObservable%601> objects, in which generic LINQ operators are supplied by the Rx assemblies to manipulate these objects. Most operators take an observable sequence and perform some logic on it and output another observable sequence. In addition, as you can see from our code samples, you can even chain multiple operators on a source sequence to tweak the resulting sequence to your exact requirement.

## Operators

We have already used the Create and Generate operators in previous topics to create and return simple sequences. We have also used the FromEventPattern operator to convert existing .NET events into observable sequences. In this topic, we will use other static LINQ operators of the Observable type so that you can filter, group and transform data. Such operators take observable sequence(s) as input, and produce observable sequence(s) as output.

### Combine sequences

In this section, we will examine some of the operators that combine various observable sequences into a single observable sequence. Notice that data are not transformed when we combine sequences.

In the following sample, we use the Concat operator to combine two sequences into a single sequence and subscribe to it. For illustration purpose, we will use the very simple Range(x, y) operator to create a sequence of integers that starts with x and produces y sequential numbers afterwards.

```csharp
var source1 = Observable.Range(1, 3);
var source2 = Observable.Range(1, 3);
source1.Concat(source2)
        .Subscribe(Console.WriteLine);
Console.ReadLine();
```

Notice that the resultant sequence is `1,2,3,1,2,3`. This is because when you use the Concat operator, the 2nd sequence (source2) will not be active until after the 1st sequence (`source1`) has finished pushing all its values. It is only after `source1` has completed, then `source2` will start to push values to the resultant sequence. The subscriber will then get all the values from the resultant sequence.

Compare this with the Merge operator. If you run the following sample code, you will get `1,1,2,2,3,3`. This is because the two sequences are active at the same time and values are pushed out as they occur in the sources. The resultant sequence only completes when the last source sequence has finished pushing values.

Notice that for Merge to work, all the source observable sequences need to be of the same type of <xref:System.IObservable%601>. The resultant sequence will be of the type <xref:System.IObservable%601>. If `source1` produces an OnError in the middle of the sequence, then the resultant sequence will complete immediately.

```csharp
var source1 = Observable.Range(1, 3);
var source2 = Observable.Range(1, 3);
source1.Merge(source2)
        .Subscribe(Console.WriteLine);
Console.ReadLine();
```

Another comparison can be done with the Catch operator. In this case, if `source1` completes without any error, then `source2` will not start. Therefore, if you run the following sample code, you will get `1,2,3` only since `source2` (which produces `4,5,6`) is ignored.

```csharp
var source1 = Observable.Range(1, 3);
var source2 = Observable.Range(4, 3);
source1.Catch(source2)
        .Subscribe(Console.WriteLine);
Console.ReadLine();
```

Finally, let's look at OnErrorResumeNext. This operator will move on to `source2` even if `source1` cannot be completed due to an error. In the following example, even though `source1` represents a sequence that terminates with an exception (by using the Throw operator), the subscriber will receive values (`1,2,3`) published by `source2`. Therefore, if you expect either source sequence to produce any error, it is a safer bet to use OnErrorResumeNext to guarantee that the subscriber will still receive some values.

```csharp
var source1 = Observable.Throw<int>(new Exception("An error has occurred."));
var source2 = Observable.Range(4, 3);
source1.OnErrorResumeNext(source2)
        .Subscribe(Console.WriteLine);
Console.ReadLine();
```

Notice that for all these combination operators to work, all the observable sequences need to be of the same type of T.

### Projection

The Select operator can translate each element of an observable sequence into another form.

In the following example, we project a sequence of integers into strings of length n respectively.

```csharp
var seqNum = Observable.Range(1, 5);
var seqString = from n in seqNum
                select new string('*', (int)n);
seqString.Subscribe(str => { Console.WriteLine(str); });
Console.ReadKey();
```

In the following sample, which is an extension of the .NET event conversion example we saw in the [Bridging with Existing .NET Events](hh242978(v=vs.103).md) topic, we use the Select operator to project the IEventPattern<MouseEventArgs> data type into a [Point](https://msdn.microsoft.com/en-us/library/bk9hwzbw) type. In this way, we are transforming a mouse move event sequence into a data type that can be parsed and manipulated further, as can be seen in the next "Filtering" section.

```csharp
var frm = new Form();
IObservable<EventPattern<MouseEventArgs>> move = Observable.FromEventPattern<MouseEventArgs>(frm, "MouseMove");
IObservable<System.Drawing.Point> points = from evt in move
                                            select evt.EventArgs.Location;
points.Subscribe(pos => Console.WriteLine("mouse at " + pos));
Application.Run(frm);
```

Finally, let's look at the SelectMany operator. The SelectMany operator has many overloads, one of which takes a selector function argument. This selector function is invoked on every value pushed out by the source observable. For each of these values, the selector projects it into a mini observable sequence. At the end, the SelectMany operator flattens all of these mini sequences into a single resultant sequence, which is then pushed to the subscriber.

The observable returned from SelectMany publishes OnCompleted after the source sequence and all mini observable sequences produced by the selector have completed. It fires OnError when an error has occurred in the source stream, when an exception was thrown by the selector function, or when an error occurred in any of the mini observable sequences.

In the following example, we first create a source sequence which produces an integer every 5 seconds, and decide to just take the first 2 values produced (by using the Take operator). We then use `SelectMany` to project each of these integers using another sequence of `{100, 101, 102}`. By doing so, two mini observable sequences are produced, `{100, 101, 102}` and `{100, 101, 102}`. These are finally flattened into a single stream of integers of `{100, 101, 102, 100, 101, 102}` and pushed to the observer.

```csharp
var source1 = Observable.Interval(TimeSpan.FromSeconds(5)).Take(2);
var proj = Observable.Range(100, 3);
var resultSeq = source1.SelectMany(proj);

var sub = resultSeq.Subscribe(x => Console.WriteLine("OnNext : {0}", x.ToString()),
                                ex => Console.WriteLine("Error : {0}", ex.ToString()),
                                () => Console.WriteLine("Completed"));
Console.ReadKey();
```csharp

### Filtering

In the following example, we use the Generate operator to create a simple observable sequence of numbers. The Generate operator has several overloads. In our example, it takes an initial state (0 in our example), a conditional function to terminate (fewer than 10 times), an iterator (+1), a result selector (a square function of the current value). , and print out only those smaller than 15 using the Where and Select operators.

```csharp
IObservable<int> seq = Observable.Generate(0, i => i < 10, i => i + 1, i => i * i);
IObservable<int> source = from n in seq
                          where n < 5
                          select n;
source.Subscribe(x => {Console.WriteLine(x);});   // output is 0, 1, 4, 9
Console.ReadKey();
```

The following example is an extension of the projection example you have seen earlier in this topic. In that sample, we have used the Select operator to project the IEventPattern<MouseEventArgs> data type into a **Point** type. In the following example, we use the Where and Select operator to pick only those mouse movement that we are interested. In this case, we filter the mouse moves to those over the first bisector (where the x and y coordinates are equal).

```csharp
var frm = new Form(); 
IObservable<EventPattern<MouseEventArgs>> move = Observable.FromEventPattern<MouseEventArgs>(frm, "MouseMove");
IObservable<System.Drawing.Point> points = from evt in move
                                            select evt.EventArgs.Location;
var overfirstbisector = from pos in points
                        where pos.X == pos.Y 
                        select pos;
var movesub = overfirstbisector.Subscribe(pos => Console.WriteLine("mouse at " + pos));
Application.Run(frm);
```

### Time-based operation

You can use the Buffer operators to perform time-based operations.

Buffering an observable sequence means that an observable sequence's values are put into a buffer based on either a specified timespan or by a count threshold. This is especially helpful in situations when you expect a tremendous amount of data to be pushed out by the sequence, and the subscriber does not have the resource to process these values. By buffering the results based on time or count, and only returning a sequence of values when the criteria is exceeded (or when the source sequence has completed), the subscriber can process OnNext calls at its own pace.

In the following example, we first create a simple sequence of integers for every second. We then use the Buffer operator and specify that each buffer will hold 5 items from the sequence. OnNext is called when the buffer is full. We then tally the sum of the buffer using the Sum operator. The buffer is automatically flushed and another cycle begins. The printout will be `10, 35, 60…` in which 10=0+1+2+3+4, 35=5+6+7+8+9, and so on.

```csharp
var seq = Observable.Interval(TimeSpan.FromSeconds(1));
var bufSeq = seq.Buffer(5);
bufSeq.Subscribe(values => Console.WriteLine(values.Sum()));
Console.ReadKey();
```

We can also create a buffer with a specified timespan. In the following example, the buffer will hold items that have accumulated for 3 seconds. The printout will be 3, 12, 21… in which 3=0+1+2, 12=3+4+5, and so on.

```csharp
var seq = Observable.Interval(TimeSpan.FromSeconds(1));
var bufSeq = seq.Buffer(TimeSpan.FromSeconds(3));
bufSeq.Subscribe(value => Console.WriteLine(value.Sum()));  
Console.ReadKey();
```

Note that if you are using Buffer or Window, you have to make sure that the sequence is not empty before filtering on it.

### LINQ operators by Categories

The [LINQ Operators by Categories](hh242961(v=vs.103).md) topic lists of all major LINQ operators implemented by the [Observable](hh244252(v=vs.103).md) type by their categories; specifically: creation, conversion, combine, functional, mathematical, time, exceptions, miscellaneous, selection and primitives.

## See Also

#### Reference

[Observable](hh244252(v=vs.103).md)  

#### Concepts

[LINQ Operators by Categories](hh242961(v=vs.103).md)
