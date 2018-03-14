//<Snippet1>
using System;
namespace Samples
{
	public class LibraryBook
	{
		private readonly string _Title;
		private DateTimeOffset _CheckoutDate;   // Violates this rule
		public LibraryBook(string title)
		{
			_Title = title;
		}
		public string Title
		{
		get { return _Title; }
		}
		public DateTimeOffset CheckoutDate      // Violates this rule
		{
			get { return _CheckoutDate; }
			set { _CheckoutDate = value; }
		}
	}
}
//</Snippet1>