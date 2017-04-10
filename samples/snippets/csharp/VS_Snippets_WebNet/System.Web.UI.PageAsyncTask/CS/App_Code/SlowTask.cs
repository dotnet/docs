// <Snippet2> 
using System;
using System.Web;
using System.Web.UI;
using System.Threading;

namespace Samples.AspNet.CS.Controls
{
    public class SlowTask
    {
        private String _taskprogress;
        private AsyncTaskDelegate _dlgt;

        // Create delegate.
        protected delegate void AsyncTaskDelegate();

        public String GetAsyncTaskProgress()
        {
            return _taskprogress;
        }
        public void ExecuteAsyncTask()
        {
            // Introduce an artificial delay to simulate a delayed 
            // asynchronous task.
            Thread.Sleep(TimeSpan.FromSeconds(5.0));
        }

        // Define the method that will get called to
        // start the asynchronous task.
        public IAsyncResult OnBegin(object sender, EventArgs e,
            AsyncCallback cb, object extraData)
        {
            _taskprogress = "AsyncTask started at: " + DateTime.Now + ". ";

            _dlgt = new AsyncTaskDelegate(ExecuteAsyncTask);
            IAsyncResult result = _dlgt.BeginInvoke(cb, extraData);

            return result;
        }

        // Define the method that will get called when
        // the asynchronous task is ended.
        public void OnEnd(IAsyncResult ar)
        {
            _taskprogress += "AsyncTask completed at: " + DateTime.Now;
            _dlgt.EndInvoke(ar);
        }

        // Define the method that will get called if the task
        // is not completed within the asynchronous timeout interval.
        public void OnTimeout(IAsyncResult ar)
        {
            _taskprogress += "AsyncTask failed to complete " +
                "because it exceeded the AsyncTimeout parameter.";
        }
    }
}
// </Snippet2> 

