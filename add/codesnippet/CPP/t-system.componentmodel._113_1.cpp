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

