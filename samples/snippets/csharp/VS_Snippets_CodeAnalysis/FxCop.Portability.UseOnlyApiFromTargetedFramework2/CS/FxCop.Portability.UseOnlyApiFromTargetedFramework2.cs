//<Snippet1>
using System;
namespace Samples
{
	public class LibraryBook
	{
		private readonly string _Title;
		private DateTime _CheckoutDate;
		public LibraryBook(string title)
		{
			_Title = title;
		}
		public string Title
		{
			get { return _Title; }
		}
		public DateTime CheckoutDate
		{
			get { return _CheckoutDate; }
			set { _CheckoutDate = value; }
		}
	}
}
//</Snippet1>
