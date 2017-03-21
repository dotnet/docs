 public virtual bool LoadPostData(string postDataKey,
    NameValueCollection postCollection) {

    String presentValue = Text;
    String postedValue = postCollection[postDataKey];

    if (presentValue == null || !presentValue.Equals(postedValue)){
       Text = postedValue;
       return true;
    }
    return false;
 }
   