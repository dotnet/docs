// <snippet100>
// <snippet1>
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Windows.Forms;
// </snippet1>

namespace CancellationWinForms
{
   public partial class Form1 : Form
   {
      // <snippet2>
      // A placeholder type that performs work.
      class WorkItem
      {
         // Performs work for the provided number of milliseconds.
         public void DoWork(int milliseconds)
         {
            // For demonstration, suspend the current thread.
            Thread.Sleep(milliseconds);
         }
      }
      // </snippet2>

      // <snippet3>
      // Enables the user interface to signal cancellation.
      CancellationTokenSource cancellationSource;

      // The first node in the dataflow pipeline.
      TransformBlock<WorkItem, WorkItem> startWork;

      // The second, and final, node in the dataflow pipeline.
      ActionBlock<WorkItem> completeWork;

      // Increments the value of the provided progress bar.
      ActionBlock<ToolStripProgressBar> incrementProgress;

      // Decrements the value of the provided progress bar.
      ActionBlock<ToolStripProgressBar> decrementProgress;

      // Enables progress bar actions to run on the UI thread.
      TaskScheduler uiTaskScheduler;
      // </snippet3>

      public Form1()
      {
         InitializeComponent();

         // Create the UI task scheduler from the current synchronization
         // context.
         uiTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
      }

      // <snippet4>
      // Creates the blocks that participate in the dataflow pipeline.
      private void CreatePipeline()
      {
         // Create the cancellation source.
         cancellationSource = new CancellationTokenSource();

         // Create the first node in the pipeline.
         startWork = new TransformBlock<WorkItem, WorkItem>(workItem =>
         {
            // Perform some work.
            workItem.DoWork(250);

            // Decrement the progress bar that tracks the count of
            // active work items in this stage of the pipeline.
            decrementProgress.Post(toolStripProgressBar1);

            // Increment the progress bar that tracks the count of
            // active work items in the next stage of the pipeline.
            incrementProgress.Post(toolStripProgressBar2);

            // Send the work item to the next stage of the pipeline.
            return workItem;
         },
         new ExecutionDataflowBlockOptions
         {
            CancellationToken = cancellationSource.Token
         });

         // Create the second, and final, node in the pipeline.
         completeWork = new ActionBlock<WorkItem>(workItem =>
         {
            // Perform some work.
            workItem.DoWork(1000);

            // Decrement the progress bar that tracks the count of
            // active work items in this stage of the pipeline.
            decrementProgress.Post(toolStripProgressBar2);

            // Increment the progress bar that tracks the overall
            // count of completed work items.
            incrementProgress.Post(toolStripProgressBar3);
         },
         new ExecutionDataflowBlockOptions
         {
            CancellationToken = cancellationSource.Token,
            MaxDegreeOfParallelism = 2
         });

         // Connect the two nodes of the pipeline. When the first node completes,
         // set the second node also to the completed state.
         startWork.LinkTo(
            completeWork, new DataflowLinkOptions { PropagateCompletion = true });

         // Create the dataflow action blocks that increment and decrement
         // progress bars.
         // These blocks use the task scheduler that is associated with
         // the UI thread.

         incrementProgress = new ActionBlock<ToolStripProgressBar>(
            progressBar => progressBar.Value++,
            new ExecutionDataflowBlockOptions
            {
               CancellationToken = cancellationSource.Token,
               TaskScheduler = uiTaskScheduler
            });

         decrementProgress = new ActionBlock<ToolStripProgressBar>(
            progressBar => progressBar.Value--,
            new ExecutionDataflowBlockOptions
            {
               CancellationToken = cancellationSource.Token,
               TaskScheduler = uiTaskScheduler
            });
      }
      // </snippet4>

      // <snippet5>
      // Event handler for the Add Work Items button.
      private void toolStripButton1_Click(object sender, EventArgs e)
      {
         // The Cancel button is disabled when the pipeline is not active.
         // Therefore, create the pipeline and enable the Cancel button
         // if the Cancel button is disabled.
         if (!toolStripButton2.Enabled)
         {
            CreatePipeline();

            // Enable the Cancel button.
            toolStripButton2.Enabled = true;
         }

         // Post several work items to the head of the pipeline.
         for (int i = 0; i < 5; i++)
         {
            toolStripProgressBar1.Value++;
            startWork.Post(new WorkItem());
         }
      }
      // </snippet5>

      // <snippet6>
      // Event handler for the Cancel button.
      private async void toolStripButton2_Click(object sender, EventArgs e)
      {
         // Disable both buttons.
         toolStripButton1.Enabled = false;
         toolStripButton2.Enabled = false;

         // Trigger cancellation.
         cancellationSource.Cancel();

         try
         {
            // Asynchronously wait for the pipeline to complete processing and for
            // the progress bars to update.
            await Task.WhenAll(
               completeWork.Completion,
               incrementProgress.Completion,
               decrementProgress.Completion);
         }
         catch (OperationCanceledException)
         {
         }

         // Increment the progress bar that tracks the number of cancelled
         // work items by the number of active work items.
         toolStripProgressBar4.Value += toolStripProgressBar1.Value;
         toolStripProgressBar4.Value += toolStripProgressBar2.Value;

         // Reset the progress bars that track the number of active work items.
         toolStripProgressBar1.Value = 0;
         toolStripProgressBar2.Value = 0;

         // Enable the Add Work Items button.
         toolStripButton1.Enabled = true;
      }
      // </snippet6>

      ~Form1()
      {
         cancellationSource.Dispose();
      }
   }
}
// </snippet100>
