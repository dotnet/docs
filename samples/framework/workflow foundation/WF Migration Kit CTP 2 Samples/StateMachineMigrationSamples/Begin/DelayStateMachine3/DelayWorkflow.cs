using System;
using System.Workflow.Activities;

namespace DelayStateMachine3
{
	public sealed partial class DelayWorkflow : StateMachineWorkflowActivity
	{
		public DelayWorkflow()
		{
			InitializeComponent();
		}

		private void codeActivity1_ExecuteCode(object sender, EventArgs e)
		{
			Console.WriteLine("initial state");
		}

		private void codeActivity2_ExecuteCode(object sender, EventArgs e)
		{
			Console.WriteLine("state 3");
		}

		private void codeActivity3_ExecuteCode(object sender, EventArgs e)
		{
			Console.WriteLine("state 4");
		}

		private void codeActivity4_ExecuteCode(object sender, EventArgs e)
		{
			Console.WriteLine("state 5");
		}

		private void codeActivity5_ExecuteCode(object sender, EventArgs e)
		{
			Console.WriteLine("state 1");
		}
	}

}
