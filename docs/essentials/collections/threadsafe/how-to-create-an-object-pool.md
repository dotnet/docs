# How to: Create an Object Pool by Using a ConcurrentBag

This example shows how to use a concurrent bag to implement an object pool. Object pools can improve application performance in situations where you require multiple instances of a class and the class is expensive to create or destroy. When a client program requests a new object, the object pool first attempts to provide one that has already been created and returned to the pool. If none is available, only then is a new object created. 

[ConcurrentBag&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Concurrent.ConcurrentBag%601.html) is used to store the objects because it supports fast insertion and removal, especially when the same thread is both adding and removing items. This example could be further augmented to be built around a [IProducerConsumerCollection&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Concurrent.IProducerConsumerCollection%601.html), which the bag data structure implements, as do [ConcurrentQueue&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Concurrent.ConcurrentQueue%601.html) and [ConcurrentStack&lt;T&gt;](http://dotnet.github.io/api/System.Collections.Concurrent.ConcurrentStack%601.html).

## Example

```csharp
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;


namespace ObjectPoolExample
{
    public class ObjectPool<T>
    {
        private ConcurrentBag<T> _objects;
        private Func<T> _objectGenerator;

        public ObjectPool(Func<T> objectGenerator)
        {
            if (objectGenerator == null) throw new ArgumentNullException("objectGenerator");
            {
                _objects = new ConcurrentBag<T>();
                _objectGenerator = objectGenerator;
            }
        }

        public T GetObject()
        {
            T item;
            if (_objects.TryTake(out item)) return item;
            {
                return _objectGenerator();
            }
        }

        public void PutObject(T item)
        {
            _objects.Add(item);
        }
    }

    class Program
    {
       static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            // Create an opportunity for the user to cancel.
            Task.Run(() =>
                {
                    if (Console.ReadKey().KeyChar == 'c' || Console.ReadKey().KeyChar == 'C')
                        cts.Cancel();
                });

            ObjectPool<MyClass> pool = new ObjectPool<MyClass> (() => new MyClass());            

            // Create a high demand for MyClass objects.
            Parallel.For(0, 1000000, (i, loopState) =>
                {
                    MyClass mc = pool.GetObject();
                    Console.CursorLeft = 0;
                    // This is the bottleneck in our application. All threads in this loop
                    // must serialize their access to the static Console class.
                    Console.WriteLine("{0:####.####}", mc.GetValue(i));                 

                    pool.PutObject(mc);
                    if (cts.Token.IsCancellationRequested)
                        loopState.Stop();                 
                });
            Console.WriteLine("Press the Enter key to exit.");
            Console.ReadLine();
            cts.Dispose();
        }
    }

    // A toy class that requires some resources to create.
    // You can experiment here to measure the performance of the
    // object pool vs. ordinary instantiation.
    class MyClass
    {
        public int[] Nums {get; set;}
        public double GetValue(long i)
        {
            return Math.Sqrt(Nums[i]);
        }
        public MyClass()
        {
            Nums = new int[1000000];
            Random rand = new Random();
            for (int i = 0; i < Nums.Length; i++)
                Nums[i] = rand.Next();
        }
    }   
}
```

## See Also

[System.Collections.Concurrent](http://dotnet.github.io/api/System.Collections.Concurrent.html)

[Thread-Safe Collections](../thread-safe-collections.md)


