    // This is a simple page that demonstrates how to place a value
    // in the cache from a page, and one way to retrieve the value.
    // Declare two constants, myInt1 and myInt2 and set their values
    // and declare a string variable, myValue.
    const int myInt1 = 35;
    const int myInt2 = 77;
    string myValue;

    // When the page is loaded, the sum of the constants
    // is placed in the cache and assigned a key, key1.
    void Page_Load(Object sender,  EventArgs arg) {
      Cache["key1"] = myInt1 + myInt2;

    }

    // When a user clicks a button, the sum associated
    // with key1 is retrieved from the Cache using the
    // Cache.Get method. It is converted to a string
    // and displayed in a Label Web server control.
    void CacheBtn_Click(object sender, EventArgs e) {
       if (Cache["key1"] == null) {
          myLabel.Text = "That object is not cached.";
       }
       else {
          myValue = Cache.Get("key1").ToString();
          myLabel.Text = myValue;
       }
    }