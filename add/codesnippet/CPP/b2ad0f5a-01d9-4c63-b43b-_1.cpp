   virtual void OnDownloadFileCompleted( System::ComponentModel::AsyncCompletedEventArgs ^ e ) override
   {
      // Here you can perform any custom actions before the event is raised
      // and event handlers are called...
      WebClient::OnDownloadFileCompleted( e );

      // Here you can perform any post event actions...
   }