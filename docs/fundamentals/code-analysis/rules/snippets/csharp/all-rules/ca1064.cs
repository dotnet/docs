using System;
using System.Runtime.Serialization;

namespace ca1064
{
    //<snippet1>
    // Violates this rule
    [Serializable]
    internal class FirstCustomException : Exception
    {
        internal FirstCustomException()
        {
        }

        internal FirstCustomException(string message)
            : base(message)
        {
        }

        internal FirstCustomException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected FirstCustomException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }

    // Does not violate this rule because
    // SecondCustomException is public
    [Serializable]
    public class SecondCustomException : Exception
    {
        public SecondCustomException()
        {
        }

        public SecondCustomException(string message)
            : base(message)
        {

        }

        public SecondCustomException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected SecondCustomException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }

    // Does not violate this rule because
    // ThirdCustomException it does not derive directly from
    // Exception, SystemException, or ApplicationException
    [Serializable]
    internal class ThirdCustomException : SecondCustomException
    {
        internal ThirdCustomException()
        {
        }

        internal ThirdCustomException(string message)
            : base(message)
        {
        }

        internal ThirdCustomException(string message, Exception innerException)
            : base(message, innerException)
        {
        }


        protected ThirdCustomException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
    //</snippet1>
}
