    [Serializable()]
    public class InvalidDepartmentException : System.Exception
    {
        public InvalidDepartmentException() : base() { }
        public InvalidDepartmentException(string message) : base(message) { }
        public InvalidDepartmentException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client. 
        protected InvalidDepartmentException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) { }
    }