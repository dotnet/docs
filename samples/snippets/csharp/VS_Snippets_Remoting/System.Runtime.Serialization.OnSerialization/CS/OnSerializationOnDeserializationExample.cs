namespace Serialization
{
    // <snippet1>
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;

    public class Test
    {
        public static void Main()
        {
            // Create a new TestSimpleObject object.
            TestSimpleObject obj = new TestSimpleObject();

            Console.WriteLine("\n Before serialization the object contains: ");
            obj.Print();

            // Open a file and serialize the object into binary format.
            Stream stream = File.Open("DataFile.dat", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();

            try
            {
                formatter.Serialize(stream, obj);

                // Print the object again to see the effect of the 
                //OnSerializedAttribute.
                Console.WriteLine("\n After serialization the object contains: ");
                obj.Print();

                // Set the original variable to null.
                obj = null;
                stream.Close();

                // Open the file "DataFile.dat" and deserialize the object from it.
                stream = File.Open("DataFile.dat", FileMode.Open);

                // Deserialize the object from the data file.
                obj = (TestSimpleObject)formatter.Deserialize(stream);

                Console.WriteLine("\n After deserialization the object contains: ");
                obj.Print();
                Console.ReadLine();
            }
            catch (SerializationException se)
            {
                Console.WriteLine("Failed to serialize. Reason: " + se.Message);
                throw;
            }
            catch (Exception exc)
            {
                Console.WriteLine("An exception occurred. Reason: " + exc.Message);
                throw;
            }
            finally
            {
                stream.Close();
                obj = null;
                formatter = null;
            }

        }
    }


    // This is the object that will be serialized and deserialized.
    [Serializable()]
    public class TestSimpleObject
    {
        // This member is serialized and deserialized with no change.
        public int member1;

        // The value of this field is set and reset during and 
        // after serialization.
        private string member2;

        // This field is not serialized. The OnDeserializedAttribute 
        // is used to set the member value after serialization.
        [NonSerialized()]
        public string member3;

        // This field is set to null, but populated after deserialization.
        private string member4;

        // Constructor for the class.
        public TestSimpleObject()
        {
            member1 = 11;
            member2 = "Hello World!";
            member3 = "This is a nonserialized value";
            member4 = null;
        }

        public void Print()
        {
            Console.WriteLine("member1 = '{0}'", member1);
            Console.WriteLine("member2 = '{0}'", member2);
            Console.WriteLine("member3 = '{0}'", member3);
            Console.WriteLine("member4 = '{0}'", member4);
        }

        [OnSerializing()]
        internal void OnSerializingMethod(StreamingContext context)
        {
            member2 = "This value went into the data file during serialization.";
        }

        [OnSerialized()]
        internal void OnSerializedMethod(StreamingContext context)
        {
            member2 = "This value was reset after serialization.";
        }

        [OnDeserializing()]
        internal void OnDeserializingMethod(StreamingContext context)
        {
            member3 = "This value was set during deserialization";
        }

        [OnDeserialized()]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            member4 = "This value was set after deserialization.";
        }
    }

    // Output:
    //  Before serialization the object contains: 
    // member1 = '11'
    // member2 = 'Hello World!'
    // member3 = 'This is a nonserialized value'
    // member4 = ''
    //
    //  After serialization the object contains: 
    // member1 = '11'
    // member2 = 'This value was reset after serialization.'
    // member3 = 'This is a nonserialized value'
    // member4 = ''
    //
    //  After deserialization the object contains: 
    // member1 = '11'
    // member2 = 'This value went into the data file during serialization.'
    // member3 = 'This value was set during deserialization'
    // member4 = 'This value was set after deserialization.'
    // </snippet1>


    public class ExampleCode
    {

        private ExampleCode()
        {
            // Empty constructor to get around security checks.
        }


        // <snippet2>
        [OnSerializing]
        private void SetValuesOnSerializing(StreamingContext context)
        {
            // Code not shown.
        }
        // </snippet2>


        // <snippet3>
        [OnSerialized]
        private void SetValuesOnSerialized(StreamingContext context)
        {
            // Code not shown.
        }
        // </snippet3>

        // <snippet4>
        [OnDeserializing]
        private void SetValuesOnDeserializing(StreamingContext context)
        {
            // Code not shown.
        }
        // </snippet4>

        //<snippet5>
        [OnDeserialized]
        private void SetValuesOnDeserialized(StreamingContext context)
        {
            // Code not shown.
        }
        // </snippet5>
    }
}