using System;

namespace Exceptions
{
    // <DefineExceptionClass>
    [Serializable]
    public class InvalidDepartmentException : Exception
    {
        public InvalidDepartmentException() : base() { }
        public InvalidDepartmentException(string message) : base(message) { }
        public InvalidDepartmentException(string message, Exception inner) : base(message, inner) { }
    }
    // </DefineExceptionClass>
}
