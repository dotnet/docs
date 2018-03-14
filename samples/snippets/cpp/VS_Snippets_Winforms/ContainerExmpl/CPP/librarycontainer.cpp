
#using <system.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::Collections;



   //<snippet1>
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
   ref class ISBNSite: public ISite
   {
   private:
      IComponent^ m_curComponent;
      IContainer^ m_curContainer;
      bool m_bDesignMode;
      String^ m_ISBNCmpName;

   public:
      ISBNSite( IContainer^ actvCntr, IComponent^ prntCmpnt )
      {
         m_curComponent = prntCmpnt;
         m_curContainer = actvCntr;
         m_bDesignMode = false;
         m_ISBNCmpName = nullptr;
      }


      property IComponent^ Component 
      {

         //Support the ISite interface.
         virtual IComponent^ get()
         {
            return m_curComponent;
         }

      }

      property IContainer^ Container 
      {
         virtual IContainer^ get()
         {
            return m_curContainer;
         }

      }

      property bool DesignMode 
      {
         virtual bool get()
         {
            return m_bDesignMode;
         }

      }

      property String^ Name 
      {
         virtual String^ get()
         {
            return m_ISBNCmpName;
         }

         virtual void set( String^ value )
         {
            m_ISBNCmpName = value;
         }

      }

      //Support the IServiceProvider interface.
      virtual Object^ GetService( Type^ serviceType )
      {
         
         //This example does not use any service object.
         return nullptr;
      }

   };


   // The BookComponent class represents the book component of the library container.
   // This class implements the IComponent interface.
   ref class BookComponent: public IComponent
   {
   private:
      ISite^ m_curISBNSite;
      String^ m_bookTitle;
      String^ m_bookAuthor;

   public:
      event virtual EventHandler^ Disposed;

	  BookComponent( String^ Title, String^ Author )
      {
         m_curISBNSite = nullptr;
         //Disp = false;
         m_bookTitle = Title;
         m_bookAuthor = Author;
      }


      property String^ Title 
      {
         String^ get()
         {
            return m_bookTitle;
         }

      }

      property String^ Author 
      {
         String^ get()
         {
            return m_bookAuthor;
         }

      }

      ~BookComponent()
      {

      }

      property ISite^ Site 
      {
         virtual ISite^ get()
         {
            return m_curISBNSite;
         }

         virtual void set( ISite^ value )
         {
            m_curISBNSite = value;
         }

      }
      virtual bool Equals( Object^ cmp ) override
      {
         BookComponent^ cmpObj = safe_cast<BookComponent^>(cmp);
         return (this->Title->Equals( cmpObj->Title ) && this->Author->Equals( cmpObj->Author ));
      }

      virtual int GetHashCode() override
      {
         return IComponent::GetHashCode();
      }

   };


   //</snippet1>
   //<snippet2>
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

//</snippet2>
