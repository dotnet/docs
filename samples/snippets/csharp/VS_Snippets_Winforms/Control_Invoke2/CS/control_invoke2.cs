// System.Windows.Forms.Control.Invoke(Delegate);

// <Snippet1>
/*
The following example demonstrates the 'Invoke(Delegate)' method of 'Control class.
A 'ListBox' and a 'Button' control are added to a form, containing a delegate
which encapsulates a method that adds items to the listbox.This function is executed
on the thread that owns the underlying handle of the form. When user clicks on button
the above delegate is executed using 'Invoke' method.


*/

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

   public class MyFormControl : Form
   {
      public delegate void AddListItem();
      public AddListItem myDelegate;
      private Button myButton;
      private Thread myThread;
      private ListBox myListBox;
      public MyFormControl()
      {
         myButton = new Button();
         myListBox = new ListBox();
         myButton.Location = new Point(72, 160);
         myButton.Size = new Size(152, 32);
         myButton.TabIndex = 1;
         myButton.Text = "Add items in list box";
         myButton.Click += new EventHandler(Button_Click);
         myListBox.Location = new Point(48, 32);
         myListBox.Name = "myListBox";
         myListBox.Size = new Size(200, 95);
         myListBox.TabIndex = 2;
         ClientSize = new Size(292, 273);
         Controls.AddRange(new Control[] {myListBox,myButton});
         Text = " 'Control_Invoke' example";
         myDelegate = new AddListItem(AddListItemMethod);
      }
      static void Main()
      {
         MyFormControl myForm = new MyFormControl();
         myForm.ShowDialog();
      }
      public void AddListItemMethod()
      {
         String myItem;
         for(int i=1;i<6;i++)
         {
            myItem = "MyListItem" + i.ToString();
            myListBox.Items.Add(myItem);
            myListBox.Update();
            Thread.Sleep(300);
         }
      }
      private void Button_Click(object sender, EventArgs e)
      {
         myThread = new Thread(new ThreadStart(ThreadFunction));
         myThread.Start();
      }
      private void ThreadFunction()
      {
         MyThreadClass myThreadClassObject  = new MyThreadClass(this);
         myThreadClassObject.Run();
      }
   }

// The following code assumes a 'ListBox' and a 'Button' control are added to a form, 
// containing a delegate which encapsulates a method that adds items to the listbox.

   public class MyThreadClass
   {
      MyFormControl myFormControl1;
      public MyThreadClass(MyFormControl myForm)
      {
         myFormControl1 = myForm;
      }

      public void Run()
      {
         // Execute the specified delegate on the thread that owns
         // 'myFormControl1' control's underlying window handle.
         myFormControl1.Invoke(myFormControl1.myDelegate);
      }
   }
   // </Snippet1>