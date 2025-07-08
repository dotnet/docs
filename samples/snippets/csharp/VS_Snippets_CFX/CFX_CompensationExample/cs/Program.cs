using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;
using System.IO;
using System.Xaml;
using System.Diagnostics;
using System.Threading;

namespace CompensationExample
{
    // Used in Compensation Overview

    // 1 - SuccessfulFlight
    // 2 - Implicit Compensation
    // 3 - Explicit Compensation
    // 4 - FlightConfirmation
    // 5 - Cancellation

    // 100 - Hosting Code
    class Program
    {
        static void Main(string[] args)
        {
            //SuccessfulFlight();
            //ImplicitCompensation();
            //ExplicitCompensation();
            //FlightConfirmation();
            ImplicitCancellation();
        }

        static void FlightConfirmation()
        {
            //<snippet4>
            Variable<CompensationToken> token1 = new Variable<CompensationToken>
            {
                Name = "token1",
            };

            Activity wf = new Sequence()
            {
                Variables =
                {
                    token1
                },
                Activities =
                {
                    new CompensableActivity
                    {
                        Body = new ReserveFlight(),
                        CompensationHandler = new CancelFlight(),
                        ConfirmationHandler = new ConfirmFlight(),
                        Result = token1
                    },
                    new ManagerApproval(),
                    new PurchaseFlight(),
                    new TakeFlight(),
                    new Confirm()
                    {
                        Target = token1
                    }
                }
            };
            //</snippet4>

            /*
            wf.Invoke();
            /*/
            RunWF(wf);
            //*/

            GetXaml(wf, "FlightConfirmation1.xaml");
        }

        static void ExplicitCompensation()
        {
            //<snippet3>
            Variable<CompensationToken> token1 = new Variable<CompensationToken>
            {
                Name = "token1",
            };

            Activity wf = new TryCatch()
            {
                Variables =
                {
                    token1
                },
                Try = new Sequence
                {
                    Activities =
                    {
                        new CompensableActivity
                        {
                            Body = new ReserveFlight(),
                            CompensationHandler = new CancelFlight(),
                            ConfirmationHandler = new ConfirmFlight(),
                            Result = token1
                        },
                        new SimulatedErrorCondition(),
                        new ManagerApproval(),
                        new PurchaseFlight()
                    }
                },
                Catches =
                {
                    new Catch<ApplicationException>()
                    {
                        Action = new ActivityAction<ApplicationException>()
                        {
                            Handler = new Compensate()
                            {
                                Target = token1
                            }
                        }
                    }
                }
            };
            //</snippet3>

            /*
            wf.Invoke();
            /*/
            RunWF(wf);
            //*/

            GetXaml(wf, "ExplicitConfirmation1.xaml");
        }

        static void ImplicitCompensation()
        {
            //<snippet2>
            Activity wf = new Sequence()
            {
                Activities =
                {
                    new CompensableActivity
                    {
                        Body = new ReserveFlight(),
                        CompensationHandler = new CancelFlight()
                    },
                    new SimulatedErrorCondition(),
                    new ManagerApproval(),
                    new PurchaseFlight()
                }
            };
            //</snippet2>

            /*
            wf.Invoke();
            /*/
            RunWF(wf);
            //*/

            GetXaml(wf, "ImplicitCompensation1.xaml");
        }

        static void ImplicitCancellation()
        {
            //<snippet5>
            Activity wf = new Sequence()
            {
                Activities =
                {
                    new CompensableActivity
                    {
                        Body = new Sequence
                        {
                            Activities =
                            {
                                new ReserveFlight(),
                                new SimulatedErrorCondition()
                            }
                        },
                        CompensationHandler = new CancelFlight(),
                        CancellationHandler = new CancelFlight()
                    },
                    new ManagerApproval(),
                    new PurchaseFlight()
                }
            };
            //</snippet5>

            /*
            wf.Invoke();
            /*/
            RunWF(wf);
            //*/

            GetXaml(wf, "ImplicitCancellation.xaml");
        }

        static void SuccessfulFlight()
        {
            //<snippet1>
            Activity wf = new Sequence()
            {
                Activities =
                {
                    new CompensableActivity
                    {
                        Body = new ReserveFlight(),
                        CompensationHandler = new CancelFlight()
                    },
                    new ManagerApproval(),
                    new PurchaseFlight()
                }
            };
            //</snippet1>

            /*
            wf.Invoke();
            /*/
            RunWF(wf);
            //*/

            GetXaml(wf, "SuccessfulFlight1.xaml");
        }

        static void GetXaml(Activity wf, string outXaml)
        {
            string inFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pre" + outXaml);
            string outFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, outXaml);

            // Delete the old one if it exists
            File.Delete(outXaml);

            // Create the Xaml for the first file
            StreamWriter sw = File.CreateText(inFile);

            XamlServices.Save(sw, wf);
            sw.Close();

            // Format it
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = @"C:\tools\formatxml\FormatXml.exe";
            //psi.Arguments = "\"" + inFile + "\" \"" + outFile + "\""; ;
            psi.Arguments = inFile + " " + outFile;
            Console.WriteLine(psi.Arguments);
            psi.CreateNoWindow = true;
            Process.Start(psi);
            //Process.Start("FormatXml.exe", "pre" + outXaml + " " + outXaml);

            Thread.Sleep(1500); // Cheesy :)

            psi = new ProcessStartInfo();
            psi.FileName = "Notepad.exe";
            psi.Arguments = outXaml;
            psi.CreateNoWindow = true;
            // Display it in Notepad
            Process.Start(psi);
        }

        static void RunWF(Activity wf)
        {
            //<snippet100>
            AutoResetEvent syncEvent = new AutoResetEvent(false);
            WorkflowApplication wfApp = new WorkflowApplication(wf);

            wfApp.Completed = delegate(WorkflowApplicationCompletedEventArgs e)
            {
                if (e.TerminationException != null)
                {
                    Console.WriteLine($"""
                    Workflow terminated with exception:
                    {e.TerminationException.GetType().FullName}: {e.TerminationException.Message}
                    """);
                }
                else
                {
                    Console.WriteLine($"Workflow completed successfully with status: {e.CompletionState}.");
                }

                syncEvent.Set();
            };

            wfApp.OnUnhandledException = delegate(WorkflowApplicationUnhandledExceptionEventArgs e)
            {
                Console.WriteLine($"""
                Workflow Unhandled Exception:
                {e.UnhandledException.GetType().FullName}: {e.UnhandledException.Message}
                """);

                return UnhandledExceptionAction.Cancel;
            };

            wfApp.Run();
            syncEvent.WaitOne();
            //</snippet100>
        }
    } // End class program

    // Flight Activities
    public sealed class ReserveFlight : CodeActivity
    {
        protected override void Execute(CodeActivityContext context)
        {
            Console.WriteLine("ReserveFlight: Ticket is reserved.");
        }
    }

    public sealed class CancelFlight : CodeActivity
    {
        protected override void Execute(CodeActivityContext context)
        {
            Console.WriteLine("CancelFlight: Ticket is canceled.");
        }
    }

    public sealed class PurchaseFlight : CodeActivity
    {
        protected override void Execute(CodeActivityContext context)
        {
            Console.WriteLine("PurchaseFlight: Ticket is purchased.");
        }
    }

    public sealed class ManagerApproval : CodeActivity
    {
        protected override void Execute(CodeActivityContext context)
        {
            Console.WriteLine("ManagerApproval: Manager approval received.");
        }
    }

    public sealed class TakeFlight : CodeActivity
    {
        protected override void Execute(CodeActivityContext context)
        {
            Console.WriteLine("TakeFlight: Flight is completed.");
        }
    }

    public sealed class SimulatedErrorCondition : CodeActivity
    {
        protected override void Execute(CodeActivityContext context)
        {
            Console.WriteLine("SimulatedErrorCondition: Throwing an ApplicationException.");
            throw new ApplicationException("Simulated error condition in the workflow.");
        }
    }

    public sealed class ConfirmFlight : CodeActivity
    {
        protected override void Execute(CodeActivityContext context)
        {
            Console.WriteLine("ConfirmFlight: Flight has been taken, no compensation possible.");
        }
    }

    public sealed class CompleteTrip : CodeActivity
    {
        protected override void Execute(CodeActivityContext context)
        {
            Console.WriteLine("CompleteTrip: Conclude trip business.");
        }
    }
}
