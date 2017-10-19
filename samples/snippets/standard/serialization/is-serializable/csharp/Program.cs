// <Snippet1>
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Libraries;

namespace test_serialization
{
    class Program
    {
        static void Main()
        {
            var value = ValueTuple.Create("03244562", DateTime.Now, 13452.50m);
		    if (UtilityLibrary.IsSerializable(value))
			{
				// Serialize the value tuple.
            var formatter = new BinaryFormatter();
				var stream = new FileStream("data.bin", FileMode.Create, 
				                            FileAccess.Write, FileShare.None);
				formatter.Serialize(stream, value);
				stream.Close();
            // Deserialize the value tuple.
            var readStream = new FileStream("data.bin", FileMode.Open);
            var restoredValue = formatter.Deserialize(readStream);
            Console.WriteLine($"{restoredValue.GetType().Name}: {restoredValue}");
			}
			else
			{
				Console.WriteLine($"{nameof(value)} is not serializable");
			}
        }
    }
}
// The example displays output like the following:
//    ValueTuple`3: (03244562, 10/18/2017 5:25:22 PM, 13452.50)
// </Snippet1>

// <Snippet2>
namespace Libraries
{
    using System;
    
    public class UtilityLibrary
    {
        public static bool IsSerializable(object obj)
        {
            if (obj == null) 
                return false;

            Type t = obj.GetType();
            return t.IsSerializable;
        }
    }
}
// </Snippet2>
