// System.Windows.Forms.Control.Invoke(Delegate,Object[]);

/*
The following example demonstrates the 'Invoke(Delegate,Object[])'
method of 'Control' class.
A 'ListBox' and a 'Button' control are added to a form, containing a delegate
which encapsulates a method that adds items to the listbox.This function is executed
on the thread that owns the underlying handle of the form .When user clicks on button
the above delegate is executed using 'Invoke' method.
*/
// <Snippet1>
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

   public class MyFormControl : Form
   {
      public delegate void AddListItem(String myString);
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
         Text = " 'Control_Invoke' example ";
         myDelegate = new AddListItem(AddListItemMethod);
      }
      static void Main()
      {
         MyFormControl myForm = new MyFormControl();
         myForm.ShowDialog();
      }
      public void AddListItemMethod(String myString)
      {
            myListBox.Items.Add(myString);
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
   public class MyThreadClass
   {
      MyFormControl myFormControl1;
      public MyThreadClass(MyFormControl myForm)
      {
         myFormControl1 = myForm;
      }
      String myString;

      public void Run()
      {


         for (int i = 1; i <= 5; i++)
         {
            myString = "Step number " + i.ToString() + " executed";
            Thread.Sleep(400);
            // Execute the specified delegate on the thread that owns
            // 'myFormControl1' control's underlying window handle with
            // the specified list of arguments.
            myFormControl1.Invoke(myFormControl1.myDelegate,
                                   new Object[] {myString});
         }
      }
   }
   // </Snippet1>