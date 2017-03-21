   virtual void OnUploadStringCompleted( UploadStringCompletedEventArgs ^ e ) override
   {
      // Here you can perform any custom actions before the event is raised
      // and event handlers are called...
      WebClient::OnUploadStringCompleted( e );

      // Here you can perform any post event actions...
   }