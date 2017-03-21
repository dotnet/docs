   public class WebPage : Page
   {
      private MyForm myFormObj;
      private Label label1;
      private Label label2;
      private TextBox textBoxObj;
      private Button buttonObj;

      public WebPage()
      {
         Page.Init += new System.EventHandler(Page_Init);
      }

      private void Page_Load(object sender, System.EventArgs e)
      {
         // Comment the following line to maintain page view state.
         Page.EnableViewState = false;
         myFormObj.Method = "post";
         Controls.Add(myFormObj);
         textBoxObj.Text = "Welcome to .NET";

         label1.Text = "Enter a name";
         buttonObj.Text = "ClickMe";
         buttonObj.Click += new EventHandler(Button_Click);
         myFormObj.Controls.Add(label1);
         myFormObj.Controls.Add(textBoxObj);
         myFormObj.Controls.Add(buttonObj);
         myFormObj.Controls.Add(label2);
      }
      private void Button_Click(object sender, EventArgs e)
      {
         String temp = "<br>Name is " + textBoxObj.Text + "<br>";
         temp += "Saved content of previous page is " + ViewState["name"] as String;
         label2.Text = temp;
      }
      protected override void LoadViewState(object viewState)
      {
         if(viewState != null)
            base.LoadViewState(viewState);
      }
      protected override object SaveViewState()
      {
         ViewState["name"] = textBoxObj.Text;
         return base.SaveViewState();
      }
      private void Page_Init(object sender, EventArgs e)
      {
         this.Load += new System.EventHandler(this.Page_Load);

         myFormObj = new MyForm();
         label1 = new Label();
         label2 = new Label();
         textBoxObj = new TextBox();
         buttonObj = new Button();
      }
   };