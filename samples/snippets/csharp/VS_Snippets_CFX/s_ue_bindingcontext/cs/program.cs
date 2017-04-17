using System;
using System.Xml;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace Program
{
    class Snippets
    {
        void Snippet1()
        {
            // <Snippet1>
            CustomBinding binding = new CustomBinding();
            BindingParameterCollection bpCol = new BindingParameterCollection();
            BindingContext context = new BindingContext(binding, bpCol);
            // </Snippet1>
        }

        void Snippet2()
        {
            // <Snippet2>
            CustomBinding binding = new CustomBinding();
            BindingParameterCollection bpCol = new BindingParameterCollection();
            Uri baseAddress = new Uri("http://MyServer/Base");
            string relAddress = "MyService";
            BindingContext context = new BindingContext(binding, bpCol, baseAddress, relAddress, ListenUriMode.Explicit);
            // </Snippet2>
        }

        void Snippet3()
        {
            // <Snippet3>
            CustomBinding binding = new CustomBinding();
            BindingParameterCollection bpCol = new BindingParameterCollection();
            BindingContext context = new BindingContext(binding, bpCol);
            Binding binding2 = context.Binding;
            // </Snippet3>
        }

        void Snippet4()
        {
            // <Snippet4>
            CustomBinding binding = new CustomBinding();
            BindingParameterCollection bpCol = new BindingParameterCollection();
            BindingContext context = new BindingContext(binding, bpCol);
            BindingParameterCollection bindingParams = context.BindingParameters;
            // </Snippet4>
        }

        void Snippet5()
        {
            // <Snippet5>
            CustomBinding binding = new CustomBinding();
            BindingParameterCollection bpCol = new BindingParameterCollection();
            BindingContext context = new BindingContext(binding, bpCol);
            Uri baseAddress = context.ListenUriBaseAddress;
            // </Snippet5>
        }

        void Snippet6()
        {
            // <Snippet6>
            CustomBinding binding = new CustomBinding();
            BindingParameterCollection bpCol = new BindingParameterCollection();
            BindingContext context = new BindingContext(binding, bpCol);
            ListenUriMode mode = context.ListenUriMode;
            // </Snippet6>
        }

        void Snippet7()
        {
            // <Snippet7>
            CustomBinding binding = new CustomBinding();
            BindingParameterCollection bpCol = new BindingParameterCollection();
            BindingContext context = new BindingContext(binding, bpCol);
            string relAddress = context.ListenUriRelativeAddress;
            // </Snippet7>
        }

        void Snippet8()
        {
            // <Snippet8>
            CustomBinding binding = new CustomBinding();
            BindingParameterCollection bpCol = new BindingParameterCollection();
            BindingContext context = new BindingContext(binding, bpCol);
            BindingElementCollection bindingElements = context.RemainingBindingElements;
            // </Snippet8>
        }

        void Snippet9()
        {
            // <Snippet9>
            CustomBinding binding = new CustomBinding();
            BindingParameterCollection bpCol = new BindingParameterCollection();
            BindingContext context = new BindingContext(binding, bpCol);
            context.BuildInnerChannelFactory<IDuplexChannel>();
            // </Snippet9>
        }

        void Snippet10()
        {
            // <Snippet10>
            CustomBinding binding = new CustomBinding();
            BindingParameterCollection bpCol = new BindingParameterCollection();
            BindingContext context = new BindingContext(binding, bpCol);
            context.BuildInnerChannelListener<IDuplexChannel>();
            // </Snippet10>
        }

        void Snippet11()
        {
            // <Snippet11>
            CustomBinding binding = new CustomBinding();
            BindingParameterCollection bpCol = new BindingParameterCollection();
            BindingContext context = new BindingContext(binding, bpCol);
            context.CanBuildInnerChannelFactory<IDuplexChannel>();
            // </Snippet11>
        }

        void Snippet12()
        {
            // <Snippet12>
            CustomBinding binding = new CustomBinding();
            BindingParameterCollection bpCol = new BindingParameterCollection();
            BindingContext context = new BindingContext(binding, bpCol);
            context.CanBuildInnerChannelListener<IDuplexChannel>();
            // </Snippet12>
        }

        void Snippet13()
        {
            // <Snippet13>
            CustomBinding binding = new CustomBinding();
            BindingParameterCollection bpCol = new BindingParameterCollection();
            BindingContext context = new BindingContext(binding, bpCol);
            BindingContext clonedContext = context.Clone();
            // </Snippet13>
        }

        void Snippet14()
        {
            // <Snippet14>
            CustomBinding binding = new CustomBinding();
            BindingParameterCollection bpCol = new BindingParameterCollection();
            BindingContext context = new BindingContext(binding, bpCol);
            XmlDictionaryReaderQuotas quotas = context.GetInnerProperty<XmlDictionaryReaderQuotas>();
            // </Snippet14>
        }

    }
}
