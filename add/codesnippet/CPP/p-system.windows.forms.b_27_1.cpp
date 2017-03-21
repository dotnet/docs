private:
   void GetDataSource()
   {
      DataSet^ ds = dynamic_cast<DataSet^>(text1->DataBindings[nullptr]->DataSource);
      Console::WriteLine( ds->Tables[ 0 ]->TableName );
   }
