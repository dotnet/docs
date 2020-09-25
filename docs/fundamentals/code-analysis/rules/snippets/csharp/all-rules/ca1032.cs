using System;
using System.Runtime.Serialization;

namespace ca1032
{
    //<snippet1>
    // Violates rule ImplementStandardExceptionConstructors.
    public class BadException : Exception
    {
        public BadException()
        {
            // Add any type-specific logic, and supply the default message.
        }
    }

    [Serializable()]
    public class GoodException : Exception
    {
        public GoodException()
        {
            // Add any type-specific logic, and supply the default message.
        }

        public GoodException(string message) : base(message)
        {
            // Add any type-specific logic.
        }

        public GoodException(string message, Exception innerException) :
           base(message, innerException)
        {
            // Add any type-specific logic for inner exceptions.
        }

        protected GoodException(SerializationInfo info,
           StreamingContext context) : base(info, context)
        {
            // Implement type-specific serialization constructor logic.
        }
    }
    //</snippet1>
}
