      // Create a private function that obtains
      // information stored in Session state
      // in the application's Global.asax file.
      // When this method is called and a key name
      // that is stored in Session state is passed
      // as the paramter, the key is obtained and
      // converted to a string.
      String GetStyle(String key) {
        return Session[key].ToString();       
      }