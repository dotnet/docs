using System;
using System.ComponentModel;
using System.Collections;

namespace InterfaceSample
{
	//<snippet1>
	/// <summary>
	/// The following example demonstrates the implementation of 
	/// ISite, IComponent, and IContainer for use in a simple library container.
	///
	/// This example uses the System, System.ComponentModel, and System.Collections
	/// namespaces.
	/// </summary>

	//This code segment implements the ISite and IComponent interfaces.
	//The implementation of the IContainer interface can be seen in the documentation 
	//of IContainer.

	//Implement the ISite interface.

	// The ISBNSite class represents the ISBN name of the book component
	class ISBNSite : ISite
	{
		private IComponent m_curComponent;
		private IContainer m_curContainer;
		private bool m_bDesignMode;
		private string m_ISBNCmpName;

		public ISBNSite(IContainer actvCntr, IComponent prntCmpnt)
		{
			m_curComponent = prntCmpnt;
			m_curContainer = actvCntr;
			m_bDesignMode = false;
			m_ISBNCmpName = null;
		}

		//Support the ISite interface.
		public virtual IComponent Component
		{
			get
			{
				return m_curComponent;
			}
		}

		public virtual IContainer Container
		{
			get
			{
				return m_curContainer;
			}
		}
		
		public virtual bool DesignMode
		{
			get
			{
				return m_bDesignMode;
			}
		}

		public virtual string Name
		{
			get
			{
				return m_ISBNCmpName;
			}

			set
			{
				m_ISBNCmpName = value;
			}
		}

		//Support the IServiceProvider interface.
		public virtual object GetService(Type serviceType)
		{
			//This example does not use any service object.
			return null;
		}

	}

	// The BookComponent class represents the book component of the library container.
	
	// This class implements the IComponent interface.
	
	class BookComponent : IComponent
	{
		public event EventHandler Disposed;
		private ISite m_curISBNSite;
		private string m_bookTitle;
		private string m_bookAuthor;

		public BookComponent(string Title, string Author)
		{
			m_curISBNSite = null;
			Disposed = null;
			m_bookTitle = Title;
			m_bookAuthor = Author;
		}

		public string Title
		{
			get
			{
				return m_bookTitle;
			}
		}

		public string Author
		{
			get
			{
				return m_bookAuthor;
			}
		}

		public virtual void Dispose()
		{	
			//There is nothing to clean.
			if(Disposed != null)
				Disposed(this,EventArgs.Empty);
		}

		public virtual ISite Site
		{
			get
			{
				return m_curISBNSite;
			}
			set
			{
				m_curISBNSite = value;
			}
		}

		public override bool Equals(object cmp)
		{
			BookComponent cmpObj = (BookComponent)cmp;
			if(this.Title.Equals(cmpObj.Title) && this.Author.Equals(cmpObj.Author))
				return true;

			return false;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
	//</snippet1>
	//<snippet2> 
	//This code segment implements the IContainer interface.  The code segment 
	//containing the implementation of ISite and IComponent can be found in the documentation
	//for those interfaces.
	
	//Implement the LibraryContainer using the IContainer interface.
	
	class LibraryContainer : IContainer
	{
		private ArrayList m_bookList;

		public LibraryContainer()
		{
			m_bookList = new ArrayList();
		}

		public virtual void Add(IComponent book)
		{
			//The book will be added without creation of the ISite object.
			m_bookList.Add(book);
		}

		public virtual void Add(IComponent book, string ISNDNNum)
		{
			for(int i =0; i < m_bookList.Count; ++i)
			{
				IComponent curObj = (IComponent)m_bookList[i];
				if(curObj.Site != null)
				{
					if(curObj.Site.Name.Equals(ISNDNNum))
						throw new SystemException("The ISBN number already exists in the container"); 
				}
			}

			ISBNSite data = new ISBNSite(this, book);
			data.Name = ISNDNNum;
			book.Site = data;
			m_bookList.Add(book);
		}

		public virtual void Remove(IComponent book)
		{
			for(int i =0; i < m_bookList.Count; ++i)
			{				
				if(book.Equals(m_bookList[i]))
				{
					m_bookList.RemoveAt(i);
						break;
				}
			}
		}

		public ComponentCollection Components
		{
			get
			{
				IComponent[] datalist = new BookComponent[m_bookList.Count];
				m_bookList.CopyTo(datalist);
				return new ComponentCollection(datalist);
			}
		}

		public virtual void Dispose()
		{	
			for(int i =0; i < m_bookList.Count; ++i)
			{
				IComponent curObj = (IComponent)m_bookList[i];
				curObj.Dispose();
			}
			
			m_bookList.Clear();
		}

		static void Main(string[] args)
		{
			LibraryContainer cntrExmpl = new LibraryContainer();

			try
			{
				BookComponent book1 = new BookComponent("Wizard's First Rule", "Terry Gooodkind");
				cntrExmpl.Add(book1, "0812548051");
				BookComponent book2 = new BookComponent("Stone of Tears", "Terry Gooodkind");
				cntrExmpl.Add(book2, "0812548094");
				BookComponent book3 = new BookComponent("Blood of the Fold", "Terry Gooodkind");
				cntrExmpl.Add(book3, "0812551478");
				BookComponent book4 = new BookComponent("The Soul of the Fire", "Terry Gooodkind");
				//This will generate exception because the ISBN already exists in the container.
				cntrExmpl.Add(book4, "0812551478");
			}
			catch(SystemException e)
			{
				Console.WriteLine("Error description: " + e.Message);
			}

			ComponentCollection datalist =cntrExmpl.Components;
			IEnumerator denum = datalist.GetEnumerator();

			while(denum.MoveNext())
			{
				BookComponent cmp = (BookComponent)denum.Current;
				Console.WriteLine("Book Title: " + cmp.Title);
				Console.WriteLine("Book Author: " + cmp.Author);
				Console.WriteLine("Book ISBN: " + cmp.Site.Name);
			}
		}
	}
	//</snippet2>
}

