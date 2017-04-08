using System;
using System.Data;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Service
{
    class Snippets
    {
        void Snippet1()
        {
            // <Snippet1>
            Uri baseAddress = new Uri("http://localhost:8001/Simple");
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            serviceHost.AddServiceEndpoint(
                typeof(ICalculator),
                new WSHttpBinding(),
                "CalculatorServiceObject");

            serviceHost.Open();
            
            IChannelListener icl = serviceHost.ChannelDispatchers[0].Listener;
            ChannelDispatcher dispatcher = new ChannelDispatcher(icl);
            // </Snippet1>
        }

        void Snippet2()
        {
            // <Snippet2>
            Uri baseAddress = new Uri("http://localhost:8001/Simple");
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            serviceHost.AddServiceEndpoint(
                typeof(ICalculator),
                new WSHttpBinding(),
                "CalculatorServiceObject");

            serviceHost.Open();

            IChannelListener icl = serviceHost.ChannelDispatchers[0].Listener;
            ChannelDispatcher dispatcher = new ChannelDispatcher(icl, "MyTestBinding");
            // </Snippet2>
        }

        void Snippet3()
        {
            // <Snippet3>
            Uri baseAddress = new Uri("http://localhost:8001/Simple");
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);
            WSHttpBinding binding = new WSHttpBinding();

            serviceHost.AddServiceEndpoint(
                typeof(ICalculator),
                binding,
                "CalculatorServiceObject");

            serviceHost.Open();

            IChannelListener icl = serviceHost.ChannelDispatchers[0].Listener;
            ChannelDispatcher dispatcher = new ChannelDispatcher(icl, "MyTestBinding", binding);
            // </Snippet3>
        }

        void Snippet4()
        {
            // <Snippet4>
            Uri baseAddress = new Uri("http://localhost:8001/Simple");
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            serviceHost.AddServiceEndpoint(
                typeof(ICalculator),
                new WSHttpBinding(),
                "CalculatorServiceObject");

            serviceHost.Open();

            ChannelDispatcher dispatcher = (ChannelDispatcher) serviceHost.ChannelDispatchers[0];
            string bindingName = dispatcher.BindingName;
            // </Snippet4>
        }

        void Snippet5()
        {
            // <Snippet5>
            Uri baseAddress = new Uri("http://localhost:8001/Simple");
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            serviceHost.AddServiceEndpoint(
                typeof(ICalculator),
                new WSHttpBinding(),
                "CalculatorServiceObject");

            serviceHost.Open();

            ChannelDispatcher dispatcher = (ChannelDispatcher) serviceHost.ChannelDispatchers[0];
            SynchronizedCollection<IChannelInitializer> col = dispatcher.ChannelInitializers;
            // </Snippet5>
        }

        void Snippet6()
        {
            // <Snippet6>
            Uri baseAddress = new Uri("http://localhost:8001/Simple");
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            serviceHost.AddServiceEndpoint(
                typeof(ICalculator),
                new WSHttpBinding(),
                "CalculatorServiceObject");

            serviceHost.Open();

            ChannelDispatcher dispatcher = (ChannelDispatcher)serviceHost.ChannelDispatchers[0];
            SynchronizedCollection<EndpointDispatcher> col = dispatcher.Endpoints;
            // </Snippet6>
        }

        void Snippet7()
        {
            // <Snippet7>
            Uri baseAddress = new Uri("http://localhost:8001/Simple");
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            serviceHost.AddServiceEndpoint(
                typeof(ICalculator),
                new WSHttpBinding(),
                "CalculatorServiceObject");

            serviceHost.Open();

            ChannelDispatcher dispatcher = (ChannelDispatcher)serviceHost.ChannelDispatchers[0];
            Collection<IErrorHandler> col = dispatcher.ErrorHandlers;
            // </Snippet7>
        }

        void Snippet8()
        {
            // <Snippet8>
            Uri baseAddress = new Uri("http://localhost:8001/Simple");
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            serviceHost.AddServiceEndpoint(
                typeof(ICalculator),
                new WSHttpBinding(),
                "CalculatorServiceObject");

            serviceHost.Open();

            ChannelDispatcher dispatcher = (ChannelDispatcher)serviceHost.ChannelDispatchers[0];
            ServiceHostBase hostBase = dispatcher.Host;
            // </Snippet8>
        }

        void Snippet9()
        {
            // <Snippet9>
            Uri baseAddress = new Uri("http://localhost:8001/Simple");
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            serviceHost.AddServiceEndpoint(
                typeof(ICalculator),
                new WSHttpBinding(),
                "CalculatorServiceObject");

            serviceHost.Open();

            ChannelDispatcher dispatcher = (ChannelDispatcher)serviceHost.ChannelDispatchers[0];
            bool isTransactedAccept = dispatcher.IsTransactedAccept;
            // </Snippet9>
        }

        void Snippet10()
        {
            // <Snippet10>
            Uri baseAddress = new Uri("http://localhost:8001/Simple");
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            serviceHost.AddServiceEndpoint(
                typeof(ICalculator),
                new WSHttpBinding(),
                "CalculatorServiceObject");

            serviceHost.Open();

            IChannelListener icl = serviceHost.ChannelDispatchers[0].Listener;
            ChannelDispatcher dispatcher = new ChannelDispatcher(icl);
            bool isTransactedReceive = dispatcher.IsTransactedReceive;
            // </Snippet10>
        }

        void Snippet11()
        {
            // <Snippet11>
            Uri baseAddress = new Uri("http://localhost:8001/Simple");
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            serviceHost.AddServiceEndpoint(
                typeof(ICalculator),
                new WSHttpBinding(),
                "CalculatorServiceObject");

            serviceHost.Open();

            ChannelDispatcher dispatcher = (ChannelDispatcher)serviceHost.ChannelDispatchers[0];
            IChannelListener listener = dispatcher.Listener;
            // </Snippet11>
        }

        void Snippet12()
        {
            // <Snippet12>
            Uri baseAddress = new Uri("http://localhost:8001/Simple");
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            serviceHost.AddServiceEndpoint(
                typeof(ICalculator),
                new WSHttpBinding(),
                "CalculatorServiceObject");

            serviceHost.Open();

            IChannelListener icl = serviceHost.ChannelDispatchers[0].Listener;
            ChannelDispatcher dispatcher = new ChannelDispatcher(icl);

            bool isManualAddressing = dispatcher.ManualAddressing;
            // </Snippet12>
        }

        void Snippet13()
        {
            // <Snippet13>
            Uri baseAddress = new Uri("http://localhost:8001/Simple");
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            serviceHost.AddServiceEndpoint(
                typeof(ICalculator),
                new WSHttpBinding(), 
                "CalculatorServiceObject");

            serviceHost.Open();

            IChannelListener icl = serviceHost.ChannelDispatchers[0].Listener;
            ChannelDispatcher dispatcher = new ChannelDispatcher(icl);

            dispatcher.MaxTransactedBatchSize = 10;
            // </Snippet13>
        }

        void Snippet14()
        {
            // <Snippet14>
            Uri baseAddress = new Uri("http://localhost:8001/Simple");
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            serviceHost.AddServiceEndpoint(
                typeof(ICalculator),
                new WSHttpBinding(),
                "CalculatorServiceObject");

            serviceHost.Open();

            IChannelListener icl = serviceHost.ChannelDispatchers[0].Listener;
            ChannelDispatcher dispatcher = new ChannelDispatcher(icl);
            bool receiveSynchronously = dispatcher.ReceiveSynchronously;
            // </Snippet14>
        }

        void Snippet15()
        {
            // <Snippet15>
            Uri baseAddress = new Uri("http://localhost:8001/Simple");
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            serviceHost.AddServiceEndpoint(
                typeof(ICalculator),
                new WSHttpBinding(),
                "CalculatorServiceObject");

            serviceHost.Open();

            IChannelListener icl = serviceHost.ChannelDispatchers[0].Listener;
            ChannelDispatcher dispatcher = new ChannelDispatcher(icl);
            ServiceThrottle throttle = dispatcher.ServiceThrottle;
            // </Snippet15>
        }

        void Snippet16()
        {
            // <Snippet16>
            Uri baseAddress = new Uri("http://localhost:8001/Simple");
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            serviceHost.AddServiceEndpoint(
                typeof(ICalculator),
                new WSHttpBinding(),
                "CalculatorServiceObject");

            serviceHost.Open();

            IChannelListener icl = serviceHost.ChannelDispatchers[0].Listener;
            ChannelDispatcher dispatcher = new ChannelDispatcher(icl);
            dispatcher.TransactionIsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;            
            // </Snippet16>
        }

        void Snippet17()
        {
            // <Snippet17>
            Uri baseAddress = new Uri("http://localhost:8001/Simple");
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            serviceHost.AddServiceEndpoint(
                typeof(ICalculator),
                new WSHttpBinding(),
                "CalculatorServiceObject");

            serviceHost.Open();

            IChannelListener icl = serviceHost.ChannelDispatchers[0].Listener;
            ChannelDispatcher dispatcher = new ChannelDispatcher(icl);
            dispatcher.TransactionTimeout = new TimeSpan(100);
            // </Snippet17>
        }

        void Snippet18()
        {
            // <Snippet18>
            Uri baseAddress = new Uri("http://localhost:8001/Simple");
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            serviceHost.AddServiceEndpoint(
                typeof(ICalculator),
                new WSHttpBinding(),
                "CalculatorServiceObject");

            serviceHost.Open();

            IChannelListener icl = serviceHost.ChannelDispatchers[0].Listener;
            ChannelDispatcher dispatcher = new ChannelDispatcher(icl);
            dispatcher.CloseInput();
            // </Snippet18>
        }

        void Snippet19()
        {
            // <Snippet19>
            Uri baseAddress = new Uri("http://localhost:8001/Simple");
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            serviceHost.AddServiceEndpoint(
                typeof(ICalculator),
                new WSHttpBinding(),
                "CalculatorServiceObject");

            serviceHost.Open();

            IChannelListener icl = serviceHost.ChannelDispatchers[0].Listener;
            ChannelDispatcher dispatcher = new ChannelDispatcher(icl);
            dispatcher.IncludeExceptionDetailInFaults = true;
            // </Snippet19>
        }

        void Snippet20()
        {
            // <Snippet20>
            Uri baseAddress = new Uri("http://localhost:8001/Simple");
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            serviceHost.AddServiceEndpoint(
                typeof(ICalculator),
                new WSHttpBinding(),
                "CalculatorServiceObject");

            serviceHost.Open();

            IChannelListener icl = serviceHost.ChannelDispatchers[0].Listener;
            ChannelDispatcher dispatcher = new ChannelDispatcher(icl);
            dispatcher.MessageVersion = MessageVersion.Default;
            // </Snippet20>
        }
    }
}
