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