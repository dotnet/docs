    For Each de As System.Collections.DictionaryEntry In Session.StaticObjects
      Response.Write(String.Format("{0} is of type {1}<br />", de.Key, de.Value.GetType()))
    Next