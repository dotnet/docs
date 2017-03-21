   virtual void OnDownloadDataCompleted( DownloadDataCompletedEventArgs ^ e ) override
   {
      // Here you can perform any custom actions before the event is raised
      // and event handlers are called...
      WebClient::OnDownloadDataCompleted( e );

      // Here you can perform any post event actions...
   }