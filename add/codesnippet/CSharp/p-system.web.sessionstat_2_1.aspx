SessionStateItemCollection sessionItems = new SessionStateItemCollection();

sessionItems["ZipCode"] = "98072";
sessionItems["Email"] = "someone@example.com";

for (int i = 0; i < items.Count; i++)
  Response.Write("sessionItems[" + i + "] = " + sessionItems[i].ToString() + "<br />");