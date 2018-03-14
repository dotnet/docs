// <Snippet1>
using System;
using System.Messaging;

namespace MyProject
{
	/// <summary>
	/// Provides a container class for the example.
	/// </summary>
	public class MyNewQueue
	{

		//**************************************************
		// Provides an entry point into the application.
		//		 
		// This example demonstrates several ways to set
		// a queue's path.
		//**************************************************

		public static void Main()
		{
			// Create a new instance of the class.
			MyNewQueue myNewQueue = new MyNewQueue();

			myNewQueue.SendPublic();
			myNewQueue.SendPrivate();
			myNewQueue.SendByLabel();
			myNewQueue.SendByFormatName();
			myNewQueue.MonitorComputerJournal();
			myNewQueue.MonitorQueueJournal();
			myNewQueue.MonitorDeadLetter();
			myNewQueue.MonitorTransactionalDeadLetter();

			return;
		}
		
		// References public queues.
		public void SendPublic()
		{
			MessageQueue myQueue = new MessageQueue(".\\myQueue");
			myQueue.Send("Public queue by path name.");

			return;
		}

		// References private queues.
		public void SendPrivate()
		{
			MessageQueue myQueue = new 
				MessageQueue(".\\Private$\\myQueue");
			myQueue.Send("Private queue by path name.");

			return;
		}

		// References queues by label.
		public void SendByLabel()
		{
			MessageQueue myQueue = new MessageQueue("Label:TheLabel");
			myQueue.Send("Queue by label.");

			return;
		}

		// References queues by format name.
		public void SendByFormatName()
		{
			MessageQueue myQueue = new 
				MessageQueue("FormatName:Public=5A5F7535-AE9A-41d4" + 
				"-935C-845C2AFF7112");
			myQueue.Send("Queue by format name.");

			return;
		}

		// References computer journal queues.
		public void MonitorComputerJournal()
		{
			MessageQueue computerJournal = new 
				MessageQueue(".\\Journal$");
			while(true)
			{
				Message journalMessage = computerJournal.Receive();
				// Process the journal message.
			}
		}

		// References queue journal queues.
		public void MonitorQueueJournal()
		{
			MessageQueue queueJournal = new 
				MessageQueue(".\\myQueue\\Journal$");
			while(true)
			{
				Message journalMessage = queueJournal.Receive();
				// Process the journal message.
			}
		}
		
		// References dead-letter queues.
		public void MonitorDeadLetter()
		{
			MessageQueue deadLetter = new 
				MessageQueue(".\\DeadLetter$");
			while(true)
			{
				Message deadMessage = deadLetter.Receive();
				// Process the dead-letter message.
			}
		}

		// References transactional dead-letter queues.
		public void MonitorTransactionalDeadLetter()
		{
			MessageQueue TxDeadLetter = new 
				MessageQueue(".\\XactDeadLetter$");
			while(true)
			{
				Message txDeadLetter = TxDeadLetter.Receive();
				// Process the transactional dead-letter message.
			}
		}

	}
}
// </Snippet1>