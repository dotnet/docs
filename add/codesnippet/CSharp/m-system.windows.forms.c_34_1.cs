   public delegate void MyDelegate(Label myControl, string myArg2);

   private void Button_Click(object sender, EventArgs e)
   {
      object[] myArray = new object[2];

      myArray[0] = new Label();
      myArray[1] = "Enter a Value";
      myTextBox.BeginInvoke(new MyDelegate(DelegateMethod), myArray);
   }

   public void DelegateMethod(Label myControl, string myCaption)
   {
      myControl.Location = new Point(16,16);
      myControl.Size = new Size(80, 25);
      myControl.Text = myCaption;
      this.Controls.Add(myControl);
   }