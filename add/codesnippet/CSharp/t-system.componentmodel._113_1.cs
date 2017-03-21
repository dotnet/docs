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