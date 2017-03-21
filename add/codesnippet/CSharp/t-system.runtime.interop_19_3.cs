   decimal _money;   
   
   public decimal Money 
   {
      [return: MarshalAs(UnmanagedType.Currency)]
      get { return this._money; }
      [param: MarshalAs(UnmanagedType.Currency)]
      set { this._money = value; }
   }