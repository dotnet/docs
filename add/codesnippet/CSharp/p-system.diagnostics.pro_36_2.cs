      private MyButton button1;
      private void button1_Click(object sender, System.EventArgs e)
      {
         Process myProcess = new Process();
         ProcessStartInfo myProcessStartInfo= new ProcessStartInfo("mspaint");
         myProcess.StartInfo = myProcessStartInfo;
         myProcess.Start();
         myProcess.Exited += new EventHandler(MyProcessExited);
         // Set 'EnableRaisingEvents' to true, to raise 'Exited' event when process is terminated.
         myProcess.EnableRaisingEvents = true;
         // Set method handling the exited event to be called  ;
         // on the same thread on which MyButton was created.
         myProcess.SynchronizingObject = button1;
         MessageBox.Show("Waiting for the process 'mspaint' to exit....");
         myProcess.WaitForExit();
         myProcess.Close();
      }
      private void MyProcessExited(Object source, EventArgs e)
      {
         MessageBox.Show("The process has exited.");
      }
   }

   public class MyButton:Button
   {

   }