public:
   virtual IPermission^ Copy() override
   {
      String^ name = m_Name;
      return gcnew NameIdPermission( name );
   }