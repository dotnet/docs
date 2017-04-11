using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace IBindingList_Doc
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{

		}


	}

	// sample for IEditableObject
	//<snippet1>
	public class Customer : IEditableObject 
	{
       
		struct CustomerData 
		{
			internal string id ;
			internal string firstName ;
			internal string lastName ;
		}
        
		private CustomersList parent;
		private CustomerData custData; 
		private CustomerData backupData; 
		private bool inTxn = false;

		// Implements IEditableObject
		void IEditableObject.BeginEdit() 
		{
			Console.WriteLine("Start BeginEdit");
			if (!inTxn) 
			{
				this.backupData = custData;
				inTxn = true;
				Console.WriteLine("BeginEdit - " + this.backupData.lastName);
			}
			Console.WriteLine("End BeginEdit");
		}

		void IEditableObject.CancelEdit() 
		{
			Console.WriteLine("Start CancelEdit");
			if (inTxn) 
			{
				this.custData = backupData;
				inTxn = false;
				Console.WriteLine("CancelEdit - " + this.custData.lastName);
			}
			Console.WriteLine("End CancelEdit");
		}

		void IEditableObject.EndEdit() 
		{
			Console.WriteLine("Start EndEdit" + this.custData.id + this.custData.lastName);
			if (inTxn) 
			{
				backupData = new CustomerData();
				inTxn = false;
				Console.WriteLine("Done EndEdit - " + this.custData.id + this.custData.lastName);
			}
			Console.WriteLine("End EndEdit");
		}

		public Customer(string ID) : base() 
		{
			this.custData = new CustomerData();
			this.custData.id = ID;
			this.custData.firstName = "";
			this.custData.lastName = "";
		}

		public string ID 
		{
			get 
			{
				return this.custData.id;
			}
		}
        
		public string FirstName 
		{
			get 
			{
				return this.custData.firstName;
			}
			set 
			{
				this.custData.firstName = value;
                this.OnCustomerChanged();
			}
		}
             
		public string LastName 
		{
			get 
			{
				return this.custData.lastName;
			}
			set 
			{
				this.custData.lastName = value;
                this.OnCustomerChanged();
			}
		}
       
		internal CustomersList Parent 
		{
			get 
			{
				return parent;
			}
			set 
			{
				parent = value ;
			}
		}

		private void OnCustomerChanged() 
		{
			if (!inTxn && Parent != null) 
			{
				Parent.CustomerChanged(this);
			}
		}
		
		public override string ToString() 
		{
			StringWriter sb = new StringWriter();
			sb.Write(this.FirstName);
			sb.Write(" ");
			sb.Write(this.LastName);
			return sb.ToString();
		}   
	}
	//</snippet1>
	// end of Customer class - sample for IEditableObject

	// sample for IBindingList
	//<snippet2>
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

     //</snippet2>
}
