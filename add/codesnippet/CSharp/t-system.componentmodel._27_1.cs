	public class CustomersList :  CollectionBase, IBindingList
	{
    
		private ListChangedEventArgs resetEvent = new ListChangedEventArgs(ListChangedType.Reset, -1);
		private ListChangedEventHandler onListChanged;

		public void LoadCustomers() 
		{
			IList l = (IList)this;
			l.Add(ReadCustomer1());
			l.Add(ReadCustomer2());
			OnListChanged(resetEvent);
		}

		public Customer this[int index] 
		{
			get 
			{
				return (Customer)(List[index]);
			}
			set 
			{
				List[index] = value;
			}
		}

		public int Add (Customer value) 
		{
			return List.Add(value);
		}

		public Customer AddNew() 
		{
			return (Customer)((IBindingList)this).AddNew();
		}

		public void Remove (Customer value) 
		{
			List.Remove(value);
		}

        
		protected virtual void OnListChanged(ListChangedEventArgs ev) 
		{
			if (onListChanged != null) 
			{
				onListChanged(this, ev);
			}
		}
        

		protected override void OnClear() 
		{
			foreach (Customer c in List) 
			{
				c.Parent = null;
			}
		}

		protected override void OnClearComplete() 
		{
			OnListChanged(resetEvent);
		}

		protected override void OnInsertComplete(int index, object value) 
		{
			Customer c = (Customer)value;
			c.Parent = this;
			OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, index));
		}

		protected override void OnRemoveComplete(int index, object value) 
		{
			Customer c = (Customer)value;
			c.Parent = this;
			OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, index));
		}

		protected override void OnSetComplete(int index, object oldValue, object newValue) 
		{
			if (oldValue != newValue) 
			{

				Customer oldcust = (Customer)oldValue;
				Customer newcust = (Customer)newValue;
                
				oldcust.Parent = null;
				newcust.Parent = this;
                
				
				OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, index));
			}
		}
        
		// Called by Customer when it changes.
		internal void CustomerChanged(Customer cust) 
		{
			
			int index = List.IndexOf(cust);
            
			OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, index));
		}
        

		// Implements IBindingList.
		bool IBindingList.AllowEdit 
		{ 
			get { return true ; }
		}

		bool IBindingList.AllowNew 
		{ 
			get { return true ; }
		}

		bool IBindingList.AllowRemove 
		{ 
			get { return true ; }
		}

		bool IBindingList.SupportsChangeNotification 
		{ 
			get { return true ; }
		}
        
		bool IBindingList.SupportsSearching 
		{ 
			get { return false ; }
		}

		bool IBindingList.SupportsSorting 
		{ 
			get { return false ; }
		}


		// Events.
		public event ListChangedEventHandler ListChanged 
		{
			add 
			{
				onListChanged += value;
			}
			remove 
			{
				onListChanged -= value;
			}
		}

		// Methods.
		object IBindingList.AddNew() 
		{
			Customer c = new Customer(this.Count.ToString());
			List.Add(c);
			return c;
		}


		// Unsupported properties.
		bool IBindingList.IsSorted 
		{ 
			get { throw new NotSupportedException(); }
		}

		ListSortDirection IBindingList.SortDirection 
		{ 
			get { throw new NotSupportedException(); }
		}


		PropertyDescriptor IBindingList.SortProperty 
		{ 
			get { throw new NotSupportedException(); }
		}


		// Unsupported Methods.
		void IBindingList.AddIndex(PropertyDescriptor property) 
		{
			throw new NotSupportedException(); 
		}

		void IBindingList.ApplySort(PropertyDescriptor property, ListSortDirection direction) 
		{
			throw new NotSupportedException(); 
		}

		int IBindingList.Find(PropertyDescriptor property, object key) 
		{
			throw new NotSupportedException(); 
		}

		void IBindingList.RemoveIndex(PropertyDescriptor property) 
		{
			throw new NotSupportedException(); 
		}

		void IBindingList.RemoveSort() 
		{
			throw new NotSupportedException(); 
		}

		// Worker functions to populate the list with data.
		private static Customer ReadCustomer1() 
		{
			Customer cust = new Customer("536-45-1245");
			cust.FirstName = "Jo";
			cust.LastName = "Brown";
			return cust;
		}
        
		private static Customer ReadCustomer2() 
		{
			Customer cust = new Customer("246-12-5645");
			cust.FirstName = "Robert";
			cust.LastName = "Brown";
			return cust;
		}
	}
