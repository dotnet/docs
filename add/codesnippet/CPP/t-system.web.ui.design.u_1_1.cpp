public:
   property String^ URL 
   {

	   [EditorAttribute(UrlEditor::typeid,UITypeEditor::typeid)]
      String^ get()
      {
         return http_url;
      }

      [EditorAttribute(UrlEditor::typeid,UITypeEditor::typeid)]
      void set( String^ value )
      {
         http_url = value;
      }
   }

private:
   String^ http_url;