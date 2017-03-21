      ' Create a private function that obtains
      ' information stored in session state
      ' in the application's Global.asax file.
      ' When this method is called and a key name
      ' that is stored in session state is passed
      ' as the parameter, the key is obtained and
      ' converted to a string.
      Function GetStyle(Key As String) As String
        Return Session(Key).ToString()
      End Function