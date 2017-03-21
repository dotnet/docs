private:
   void ClearAllBindings()
   {
      for each ( Control^ c in groupBox1->Controls )
      {
         c->DataBindings->Clear();
      }
   }