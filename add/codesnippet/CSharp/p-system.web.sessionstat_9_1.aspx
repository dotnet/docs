foreach (System.Collections.DictionaryEntry de in Session.StaticObjects)
  Response.Write(de.Key + " is of type " + de.Value.GetType().ToString() + "<br />");