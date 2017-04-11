//<snippet0>
using System;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using System.Security.Permissions;

namespace StreamingContextExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SerializeAndDeserialize();
            }
            catch (System.Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            finally
            {
                Console.WriteLine("Press <Enter> to exit....");
                Console.ReadLine();
            }
        }
        static void SerializeAndDeserialize()
        {
            object myObject = DateTime.Now;
            // Create a StreamingContext that includes a
            // a DateTime. 
            StreamingContext sc = new StreamingContext(
                StreamingContextStates.CrossProcess, myObject);
            BinaryFormatter bf = new BinaryFormatter(null, sc);
            MemoryStream ms = new MemoryStream(new byte[2048]);
            bf.Serialize(ms, new MyClass());
            ms.Seek(0, SeekOrigin.Begin);
            MyClass f = (MyClass)bf.Deserialize(ms);
            Console.WriteLine("\t MinValue: {0} \n\t MaxValue: {1}", 
                f.MinValue , f.MaxValue);
            Console.WriteLine("StreamingContext.State: {0}", 
                sc.State);

            DateTime myDateTime = (DateTime)sc.Context;
            Console.WriteLine("StreamingContext.Context: {0}",
                myDateTime.ToLongTimeString());
        }
    }

    [Serializable]
    [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
    class MyClass : ISerializable
    {
        private int minValue_value;
        private int maxValue_value;

        public MyClass()
        {
            minValue_value = int.MinValue;
            maxValue_value = int.MaxValue;
        }

        public int MinValue
        {
            get { return minValue_value; }
            set { minValue_value = value;}
        }

        public int MaxValue
        {
            get { return maxValue_value; }
            set { maxValue_value = value; }
        }

        void ISerializable.GetObjectData(SerializationInfo si, StreamingContext context)
        {
            si.AddValue("minValue", minValue_value);
            si.AddValue("maxValue", maxValue_value);
        }

        protected MyClass(SerializationInfo si, StreamingContext context)
        {
            minValue_value = (int)si.GetValue("minValue", typeof(int));
            maxValue_value = (int)si.GetValue("maxValue", typeof(int));            
        }
    }
}
//</snippet0>
