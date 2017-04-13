//<Snippet1>
using System;
using System.Security.Permissions;
using System.Runtime.Serialization;

namespace Samples2
{
    [Serializable]
    public class Book : ISerializable
    {
        private readonly string _Title;

        public Book(string title)
        {
            if (title == null)
                throw new ArgumentNullException("title");

            _Title = title;
        }

        protected Book(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");

            _Title = info.GetString("Title");
        }

        public string Title
        {
            get { return _Title; }
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Title", _Title);
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");

            GetObjectData(info, context);
        }
    }

    [Serializable]
    public class LibraryBook : Book
    {
        private readonly DateTime _CheckedOut;

        public LibraryBook(string title, DateTime checkedOut)
            : base(title)
        {
            _CheckedOut = checkedOut;
        }

        protected LibraryBook(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            _CheckedOut = info.GetDateTime("CheckedOut");
        }

        public DateTime CheckedOut
        {
            get { return _CheckedOut; }
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue("CheckedOut", _CheckedOut);
        }
    }
}
//</Snippet1>
