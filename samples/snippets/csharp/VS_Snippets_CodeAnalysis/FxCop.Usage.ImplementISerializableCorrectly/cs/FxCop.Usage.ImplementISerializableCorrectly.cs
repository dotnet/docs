//<Snippet1>
using System;
using System.Security.Permissions;
using System.Runtime.Serialization;

namespace Samples1
{
    // Violates this rule
    [Serializable]
    public class Book : ISerializable
    {
        private readonly string _Text;

        public Book(string text)
        {
            if (text == null)
                throw new ArgumentNullException("text");

            _Text = text;
        }

        protected Book(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");

            _Text = info.GetString("Text");
        }

        public string Text
        {
            get { return _Text; }
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");

            info.AddValue("Text", _Text);
        }
    }

    // Violates this rule
    [Serializable]
    public class LibraryBook : Book
    {
        private readonly DateTime _CheckedOut;

        public LibraryBook(string text, DateTime checkedOut)
            : base(text)
        {
            _CheckedOut = checkedOut;
        }

        public DateTime CheckedOut
        {
            get { return _CheckedOut; }
        }
    }
}
//</Snippet1>