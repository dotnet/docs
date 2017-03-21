   virtual void OnUploadDataCompleted( UploadDataCompletedEventArgs ^ e ) override
   {
      // Here you can perform any custom actions before the event is raised
      // and event handlers are called...
      WebClient::OnUploadDataCompleted( e );

      // Here you can perform any post event actions...
   }