using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Reflection;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace DelayStateMachine3
{
	partial class DelayWorkflow
	{
		#region Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		[System.Diagnostics.DebuggerNonUserCode]
		[System.CodeDom.Compiler.GeneratedCode("", "")]
		private void InitializeComponent()
		{
			this.CanModifyActivities = true;
			this.codeActivity3 = new System.Workflow.Activities.CodeActivity();
			this.setStateActivity4 = new System.Workflow.Activities.SetStateActivity();
			this.delayActivity4 = new System.Workflow.Activities.DelayActivity();
			this.codeActivity2 = new System.Workflow.Activities.CodeActivity();
			this.setStateActivity3 = new System.Workflow.Activities.SetStateActivity();
			this.delayActivity3 = new System.Workflow.Activities.DelayActivity();
			this.codeActivity4 = new System.Workflow.Activities.CodeActivity();
			this.setStateActivity5 = new System.Workflow.Activities.SetStateActivity();
			this.delayActivity6 = new System.Workflow.Activities.DelayActivity();
			this.codeActivity5 = new System.Workflow.Activities.CodeActivity();
			this.setStateActivity6 = new System.Workflow.Activities.SetStateActivity();
			this.delayActivity5 = new System.Workflow.Activities.DelayActivity();
			this.codeActivity1 = new System.Workflow.Activities.CodeActivity();
			this.setStateActivity2 = new System.Workflow.Activities.SetStateActivity();
			this.delayActivity2 = new System.Workflow.Activities.DelayActivity();
			this.setStateActivity1 = new System.Workflow.Activities.SetStateActivity();
			this.delayActivity1 = new System.Workflow.Activities.DelayActivity();
			this.stateInitializationActivity3 = new System.Workflow.Activities.StateInitializationActivity();
			this.eventDrivenActivity4 = new System.Workflow.Activities.EventDrivenActivity();
			this.stateInitializationActivity2 = new System.Workflow.Activities.StateInitializationActivity();
			this.eventDrivenActivity3 = new System.Workflow.Activities.EventDrivenActivity();
			this.stateInitializationActivity4 = new System.Workflow.Activities.StateInitializationActivity();
			this.eventDrivenActivity5 = new System.Workflow.Activities.EventDrivenActivity();
			this.stateInitializationActivity5 = new System.Workflow.Activities.StateInitializationActivity();
			this.eventDrivenActivity7 = new System.Workflow.Activities.EventDrivenActivity();
			this.stateInitializationActivity1 = new System.Workflow.Activities.StateInitializationActivity();
			this.eventDrivenActivity2 = new System.Workflow.Activities.EventDrivenActivity();
			this.eventDrivenActivity1 = new System.Workflow.Activities.EventDrivenActivity();
			this.stateActivity4 = new System.Workflow.Activities.StateActivity();
			this.stateActivity3 = new System.Workflow.Activities.StateActivity();
			this.stateActivity5 = new System.Workflow.Activities.StateActivity();
			this.stateActivity2 = new System.Workflow.Activities.StateActivity();
			this.stateActivity1 = new System.Workflow.Activities.StateActivity();
			this.Workflow1InitialState = new System.Workflow.Activities.StateActivity();
			// 
			// codeActivity3
			// 
			this.codeActivity3.Name = "codeActivity3";
			this.codeActivity3.ExecuteCode += new System.EventHandler(this.codeActivity3_ExecuteCode);
			// 
			// setStateActivity4
			// 
			this.setStateActivity4.Name = "setStateActivity4";
			this.setStateActivity4.TargetStateName = "stateActivity5";
			// 
			// delayActivity4
			// 
			this.delayActivity4.Name = "delayActivity4";
			this.delayActivity4.TimeoutDuration = System.TimeSpan.Parse("00:00:02");
			// 
			// codeActivity2
			// 
			this.codeActivity2.Name = "codeActivity2";
			this.codeActivity2.ExecuteCode += new System.EventHandler(this.codeActivity2_ExecuteCode);
			// 
			// setStateActivity3
			// 
			this.setStateActivity3.Name = "setStateActivity3";
			this.setStateActivity3.TargetStateName = "stateActivity4";
			// 
			// delayActivity3
			// 
			this.delayActivity3.Name = "delayActivity3";
			this.delayActivity3.TimeoutDuration = System.TimeSpan.Parse("00:00:02");
			// 
			// codeActivity4
			// 
			this.codeActivity4.Name = "codeActivity4";
			this.codeActivity4.ExecuteCode += new System.EventHandler(this.codeActivity4_ExecuteCode);
			// 
			// setStateActivity5
			// 
			this.setStateActivity5.Name = "setStateActivity5";
			this.setStateActivity5.TargetStateName = "stateActivity1";
			// 
			// delayActivity6
			// 
			this.delayActivity6.Name = "delayActivity6";
			this.delayActivity6.TimeoutDuration = System.TimeSpan.Parse("00:00:02");
			// 
			// codeActivity5
			// 
			this.codeActivity5.Name = "codeActivity5";
			this.codeActivity5.ExecuteCode += new System.EventHandler(this.codeActivity5_ExecuteCode);
			// 
			// setStateActivity6
			// 
			this.setStateActivity6.Name = "setStateActivity6";
			this.setStateActivity6.TargetStateName = "stateActivity2";
			// 
			// delayActivity5
			// 
			this.delayActivity5.Name = "delayActivity5";
			this.delayActivity5.TimeoutDuration = System.TimeSpan.Parse("00:00:02");
			// 
			// codeActivity1
			// 
			this.codeActivity1.Name = "codeActivity1";
			this.codeActivity1.ExecuteCode += new System.EventHandler(this.codeActivity1_ExecuteCode);
			// 
			// setStateActivity2
			// 
			this.setStateActivity2.Name = "setStateActivity2";
			this.setStateActivity2.TargetStateName = "stateActivity4";
			// 
			// delayActivity2
			// 
			this.delayActivity2.Name = "delayActivity2";
			this.delayActivity2.TimeoutDuration = System.TimeSpan.Parse("00:00:02");
			// 
			// setStateActivity1
			// 
			this.setStateActivity1.Name = "setStateActivity1";
			this.setStateActivity1.TargetStateName = "stateActivity3";
			// 
			// delayActivity1
			// 
			this.delayActivity1.Name = "delayActivity1";
			this.delayActivity1.TimeoutDuration = System.TimeSpan.Parse("00:00:01");
			// 
			// stateInitializationActivity3
			// 
			this.stateInitializationActivity3.Activities.Add(this.codeActivity3);
			this.stateInitializationActivity3.Name = "stateInitializationActivity3";
			// 
			// eventDrivenActivity4
			// 
			this.eventDrivenActivity4.Activities.Add(this.delayActivity4);
			this.eventDrivenActivity4.Activities.Add(this.setStateActivity4);
			this.eventDrivenActivity4.Name = "eventDrivenActivity4";
			// 
			// stateInitializationActivity2
			// 
			this.stateInitializationActivity2.Activities.Add(this.codeActivity2);
			this.stateInitializationActivity2.Name = "stateInitializationActivity2";
			// 
			// eventDrivenActivity3
			// 
			this.eventDrivenActivity3.Activities.Add(this.delayActivity3);
			this.eventDrivenActivity3.Activities.Add(this.setStateActivity3);
			this.eventDrivenActivity3.Name = "eventDrivenActivity3";
			// 
			// stateInitializationActivity4
			// 
			this.stateInitializationActivity4.Activities.Add(this.codeActivity4);
			this.stateInitializationActivity4.Name = "stateInitializationActivity4";
			// 
			// eventDrivenActivity5
			// 
			this.eventDrivenActivity5.Activities.Add(this.delayActivity6);
			this.eventDrivenActivity5.Activities.Add(this.setStateActivity5);
			this.eventDrivenActivity5.Name = "eventDrivenActivity5";
			// 
			// stateInitializationActivity5
			// 
			this.stateInitializationActivity5.Activities.Add(this.codeActivity5);
			this.stateInitializationActivity5.Name = "stateInitializationActivity5";
			// 
			// eventDrivenActivity7
			// 
			this.eventDrivenActivity7.Activities.Add(this.delayActivity5);
			this.eventDrivenActivity7.Activities.Add(this.setStateActivity6);
			this.eventDrivenActivity7.Name = "eventDrivenActivity7";
			// 
			// stateInitializationActivity1
			// 
			this.stateInitializationActivity1.Activities.Add(this.codeActivity1);
			this.stateInitializationActivity1.Name = "stateInitializationActivity1";
			// 
			// eventDrivenActivity2
			// 
			this.eventDrivenActivity2.Activities.Add(this.delayActivity2);
			this.eventDrivenActivity2.Activities.Add(this.setStateActivity2);
			this.eventDrivenActivity2.Name = "eventDrivenActivity2";
			// 
			// eventDrivenActivity1
			// 
			this.eventDrivenActivity1.Activities.Add(this.delayActivity1);
			this.eventDrivenActivity1.Activities.Add(this.setStateActivity1);
			this.eventDrivenActivity1.Name = "eventDrivenActivity1";
			// 
			// stateActivity4
			// 
			this.stateActivity4.Activities.Add(this.eventDrivenActivity4);
			this.stateActivity4.Activities.Add(this.stateInitializationActivity3);
			this.stateActivity4.Name = "stateActivity4";
			// 
			// stateActivity3
			// 
			this.stateActivity3.Activities.Add(this.eventDrivenActivity3);
			this.stateActivity3.Activities.Add(this.stateInitializationActivity2);
			this.stateActivity3.Name = "stateActivity3";
			// 
			// stateActivity5
			// 
			this.stateActivity5.Activities.Add(this.eventDrivenActivity5);
			this.stateActivity5.Activities.Add(this.stateInitializationActivity4);
			this.stateActivity5.Name = "stateActivity5";
			// 
			// stateActivity2
			// 
			this.stateActivity2.Name = "stateActivity2";
			// 
			// stateActivity1
			// 
			this.stateActivity1.Activities.Add(this.eventDrivenActivity7);
			this.stateActivity1.Activities.Add(this.stateInitializationActivity5);
			this.stateActivity1.Name = "stateActivity1";
			// 
			// Workflow1InitialState
			// 
			this.Workflow1InitialState.Activities.Add(this.eventDrivenActivity1);
			this.Workflow1InitialState.Activities.Add(this.eventDrivenActivity2);
			this.Workflow1InitialState.Activities.Add(this.stateInitializationActivity1);
			this.Workflow1InitialState.Name = "Workflow1InitialState";
			// 
			// DelayWorkflow
			// 
			this.Activities.Add(this.Workflow1InitialState);
			this.Activities.Add(this.stateActivity1);
			this.Activities.Add(this.stateActivity2);
			this.Activities.Add(this.stateActivity5);
			this.Activities.Add(this.stateActivity3);
			this.Activities.Add(this.stateActivity4);
			this.CompletedStateName = "stateActivity2";
			this.DynamicUpdateCondition = null;
			this.InitialStateName = "Workflow1InitialState";
			this.Name = "DelayWorkflow";
			this.CanModifyActivities = false;

		}

		#endregion

		private SetStateActivity setStateActivity4;

		private SetStateActivity setStateActivity3;

		private SetStateActivity setStateActivity6;

		private EventDrivenActivity eventDrivenActivity4;

		private EventDrivenActivity eventDrivenActivity3;

		private SetStateActivity setStateActivity2;

		private SetStateActivity setStateActivity1;

		private DelayActivity delayActivity1;

		private EventDrivenActivity eventDrivenActivity7;

		private StateActivity stateActivity4;

		private StateActivity stateActivity3;

		private EventDrivenActivity eventDrivenActivity2;

		private EventDrivenActivity eventDrivenActivity1;

		private StateActivity stateActivity5;

		private StateActivity stateActivity2;

		private StateActivity stateActivity1;

		private DelayActivity delayActivity2;

		private DelayActivity delayActivity3;

		private DelayActivity delayActivity4;

		private DelayActivity delayActivity5;

		private StateInitializationActivity stateInitializationActivity3;

		private StateInitializationActivity stateInitializationActivity2;

		private CodeActivity codeActivity1;

		private StateInitializationActivity stateInitializationActivity4;

		private StateInitializationActivity stateInitializationActivity1;

		private CodeActivity codeActivity2;

		private CodeActivity codeActivity3;

		private CodeActivity codeActivity4;

		private SetStateActivity setStateActivity5;

		private DelayActivity delayActivity6;

		private CodeActivity codeActivity5;

		private EventDrivenActivity eventDrivenActivity5;

		private StateInitializationActivity stateInitializationActivity5;

		private StateActivity Workflow1InitialState;


















	}
}
