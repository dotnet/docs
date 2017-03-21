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