    public class TcpChunkingBinding : Binding, IBindingRuntimePreferences
    {
        TcpTransportBindingElement tcpbe;
        ChunkingBindingElement be;
        public TcpChunkingBinding()
            : base()
        {
            Initialize();

        }
        public TcpChunkingBinding(string name, string ns)
            : base(name, ns)
        {
            Initialize();
        }
        public override BindingElementCollection CreateBindingElements()
        {
            BindingElementCollection col = new BindingElementCollection();
            col.Add(be);
            col.Add(tcpbe);
            return col;
        }

        public override string Scheme
        {
            get { return tcpbe.Scheme;  }
        }
        public int MaxBufferedChunks
        {
            get { return this.be.MaxBufferedChunks; }
            set { this.be.MaxBufferedChunks = value; }
        }

        void Initialize()
        {
             be = new ChunkingBindingElement();
             tcpbe = new TcpTransportBindingElement();
            tcpbe.TransferMode=TransferMode.Buffered; //no transport streaming
            tcpbe.MaxReceivedMessageSize = ChunkingUtils.ChunkSize + 100 * 1024; //add 100KB for headers
             this.SendTimeout = new TimeSpan(0, 5, 0);
             this.ReceiveTimeout = this.SendTimeout;

        }

        #region IBindingRuntimePreferences Members
        public bool ReceiveSynchronously
        {
            get { return true; }
        }
        #endregion
    }