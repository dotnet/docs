   //This code segment implements the IContainer interface.  The code segment
   //containing the implementation of ISite and IComponent can be found in the documentation
   //for those interfaces.
   //Implement the LibraryContainer using the IContainer interface.
   ref class LibraryContainer: public IContainer
   {
   private:
      ArrayList^ m_bookList;

   public:
      LibraryContainer()
      {
         m_bookList = gcnew ArrayList;
      }

      virtual void Add( IComponent^ book )
      {
         
         //The book will be added without creation of the ISite object.
         m_bookList->Add( book );
      }

      virtual void Add( IComponent^ book, String^ ISNDNNum )
      {
         for ( int i = 0; i < m_bookList->Count; ++i )
         {
            IComponent^ curObj = static_cast<IComponent^>(m_bookList->default[ i ]);
            if ( curObj->Site != nullptr )
            {
               if ( curObj->Site->Name->Equals( ISNDNNum ) )
                              throw gcnew SystemException( "The ISBN number already exists in the container" );
            }

         }
         ISBNSite^ data = gcnew ISBNSite( this,book );
         data->Name = ISNDNNum;
         book->Site = data;
         m_bookList->Add( book );
      }

      virtual void Remove( IComponent^ book )
      {
         for ( int i = 0; i < m_bookList->Count; ++i )
         {
            if ( book->Equals( m_bookList->default[ i ] ) )
            {
               m_bookList->RemoveAt( i );
               break;
            }

         }
      }


      property ComponentCollection^ Components 
      {
         virtual ComponentCollection^ get() 
         {
            array<IComponent^>^datalist = gcnew array<BookComponent^>(m_bookList->Count);
            m_bookList->CopyTo( datalist );
            return gcnew ComponentCollection( datalist );
         }

      }

      ~LibraryContainer()
      {
         for ( int i = 0; i < m_bookList->Count; ++i )
         {
            IComponent^ curObj = static_cast<IComponent^>(m_bookList->default[ i ]);
            delete curObj;

         }
         m_bookList->Clear();
      }



   };



   [STAThreadAttribute]
   int main()
      {
         LibraryContainer^ cntrExmpl = gcnew LibraryContainer;
         try
         {
            BookComponent^ book1 = gcnew BookComponent( "Wizard's First Rule","Terry Gooodkind" );
            cntrExmpl->Add( book1, "0812548051" );
            BookComponent^ book2 = gcnew BookComponent( "Stone of Tears","Terry Gooodkind" );
            cntrExmpl->Add( book2, "0812548094" );
            BookComponent^ book3 = gcnew BookComponent( "Blood of the Fold","Terry Gooodkind" );
            cntrExmpl->Add( book3, "0812551478" );
            BookComponent^ book4 = gcnew BookComponent( "The Soul of the Fire","Terry Gooodkind" );
            
            //This will generate exception because the ISBN already exists in the container.
            cntrExmpl->Add( book4, "0812551478" );
         }
         catch ( SystemException^ e ) 
         {
            Console::WriteLine(  "Error description: {0}", e->Message );
         }

         ComponentCollection^ datalist = cntrExmpl->Components;
         IEnumerator^ denum = datalist->GetEnumerator();
         while ( denum->MoveNext() )
         {
            BookComponent^ cmp = static_cast<BookComponent^>(denum->Current);
            Console::WriteLine( "Book Title: {0}", cmp->Title );
            Console::WriteLine(  "Book Author: {0}", cmp->Author );
            Console::WriteLine(  "Book ISBN: {0}", cmp->Site->Name );
         }

	 return 0;
      }
