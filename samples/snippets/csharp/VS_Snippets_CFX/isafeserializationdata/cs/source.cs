//<snippet1>
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Security;

// [assembly: SecurityCritical(SecurityCriticalScope.Everything)] 
// Using the SecurityCriticalAttribute prohibits usage of the 
// ISafeSerializationData interface.
[assembly: AllowPartiallyTrustedCallers]
namespace ISafeSerializationDataExample
{
    class Test
    {
        public static void Main()
        {
            try
            {
                // This code forces a division by 0 and catches the 
                // resulting exception.
                try
                {
                    int zero = 0;
                    int ecks = 1 / zero;
                }
                catch (Exception ex)
                {
                    // Create a new exception to throw.
                    NewException newExcept = new NewException("Divided by", 0);

                    // This FileStream is used for the serialization.
                    FileStream fs =
                        new FileStream("NewException.dat",
                            FileMode.Create);

                    try
                    {
                        // Serialize the exception.
                        BinaryFormatter formatter = new BinaryFormatter();
                        formatter.Serialize(fs, newExcept);

                        // Rewind the stream and deserialize the exception.
                        fs.Position = 0;
                        NewException deserExcept =
                            (NewException)formatter.Deserialize(fs);
                        Console.WriteLine(
                        "Forced a division by 0, caught the resulting exception, \n" +
                        "and created a derived exception with custom data. \n" +
                        "Serialized the exception and deserialized it:\n");
                        Console.WriteLine("StringData: {0}", deserExcept.StringData);
                        Console.WriteLine("intData:   {0}", deserExcept.IntData);
                    }
                    catch (SerializationException se)
                    {
                        Console.WriteLine("Failed to serialize: {0}",
                            se.ToString());
                    }
                    finally
                    {
                        fs.Close();
                        Console.ReadLine();
                    }
                }
            }
            catch (NewException ex)
            {
                Console.WriteLine("StringData: {0}", ex.StringData);
                Console.WriteLine("IntData:   {0}", ex.IntData);
            }
        }
    }

    [Serializable]
    public class NewException : Exception
    {
        // Because we don't want the exception state to be serialized normally, 
        // we take care of that in the constructor.
        [NonSerialized]
        private NewExceptionState m_state = new NewExceptionState();

        public NewException(string stringData, int intData)
        {
            // Instance data is stored directly in the exception state object.
            m_state.StringData = stringData;
            m_state.IntData = intData;

            // In response to SerializeObjectState, we need to provide 
            // any state to serialize with the exception.  In this 
            // case, since our state is already stored in an
            // ISafeSerializationData implementation, we can 
            // just provide that.

            SerializeObjectState += delegate(object exception,
                SafeSerializationEventArgs eventArgs)
            {
                eventArgs.AddSerializedState(m_state);
            };
            // An alternate implementation would be to store the state 
            // as local member variables, and in response to this 
            // method create a new instance of an ISafeSerializationData
            // object and populate it with the local state here before 
            // passing it through to AddSerializedState.        

        }
        // There is no need to supply a deserialization constructor 
        // (with SerializationInfo and StreamingContext parameters), 
        // and no need to supply a GetObjectData implementation.


        // Data access is through the state object (m_State).
        public string StringData
        {
            get { return m_state.StringData; }
        }

        public int IntData
        {
            get { return m_state.IntData; }
        }

        // Implement the ISafeSerializationData interface 
        // to contain custom  exception data in a partially trusted 
       // assembly. Use this interface to replace the 
       // Exception.GetObjectData method, 
        // which is now marked with the SecurityCriticalAttribute.
        [Serializable]
        private struct NewExceptionState : ISafeSerializationData
        {
            private string m_stringData;
            private int m_intData;

            public string StringData
            {
                get { return m_stringData; }
                set { m_stringData = value; }
            }

            public int IntData
            {
                get { return m_intData; }
                set { m_intData = value; }
            }

            //<snippet2>
            // This method is called when deserialization of the 
            // exception is complete.
            void ISafeSerializationData.CompleteDeserialization
                (object obj)
            {
                // Since the exception simply contains an instance of 
                // the exception state object, we can repopulate it 
                // here by just setting its instance field to be equal 
                // to this deserialized state instance.
                NewException exception = obj as NewException;
                exception.m_state = this;
            }
            //</snippet2>
        }
    }
}
//</snippet1>