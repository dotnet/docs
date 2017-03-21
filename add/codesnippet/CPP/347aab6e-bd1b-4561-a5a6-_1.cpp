   virtual void OnDownloadProgressChanged( DownloadProgressChangedEventArgs ^ e ) override
   {
      // Here you can perform any custom actions before the event is raised
      // and event handlers are called...
      WebClient::OnDownloadProgressChanged( e );

      // Here you can perform any post event actions...
   }