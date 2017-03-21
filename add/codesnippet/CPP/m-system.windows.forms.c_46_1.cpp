private:
   void RemoveThirdBinding()
   {
      if ( textBox1->DataBindings->Count < 3 )
      {
         return;
      }
      textBox1->DataBindings->RemoveAt( 2 );
   }