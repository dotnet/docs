SessionStateItemCollection items = new SessionStateItemCollection();

items["LastName"] = "Wilson";
items["FirstName"] = "Dan";

foreach (string s in items.Keys)
  Response.Write("items[\"" + s + "\"] = " + items[s].ToString() + "<br />");