using System;
using System.Collections.Generic;

using System.Text;
using System.ServiceModel;
using System.ServiceModel.Persistence;
using System.ServiceModel.Channels;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace PersistenceProviderSample
{
    public class FilePersistenceProviderFactory : PersistenceProviderFactory
    {
        const string InstanceFormatString = "{0}.bin";
        const string SubDirectoryName = "FilePersistenceProvider";
        const string SubStateFormatString = "{0}-{1}.bin";

        BinaryFormatter formatter;

        public FilePersistenceProviderFactory()
        {
            formatter = new BinaryFormatter();
        }

        protected override TimeSpan DefaultCloseTimeout
        {
            get { return TimeSpan.FromSeconds(15); }
        }

        protected override TimeSpan DefaultOpenTimeout
        {
            get { return TimeSpan.FromSeconds(15); }
        }

        public override PersistenceProvider CreateProvider(Guid id)
        {
            return new FilePersistenceProvider(id, this);
        }

        protected override void OnAbort()
        {
        }

        protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
        {
            NoOpAsyncResult result = new NoOpAsyncResult(state);

            if (callback != null)
            {
                callback(result);
            }

            return result;
        }

        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            NoOpAsyncResult result = new NoOpAsyncResult(state);

            if (callback != null)
            {
                callback(result);
            }

            return result;
        }

        protected override void OnClose(TimeSpan timeout)
        {
        }

        protected override void OnEndClose(IAsyncResult result)
        {
        }

        protected override void OnEndOpen(IAsyncResult result)
        {
        }

        protected override void OnOpen(TimeSpan timeout)
        {
        }

        IAsyncResult BeginDelete(Guid id, TimeSpan timeout, AsyncCallback callback, object state)
        {
            Delete(id, timeout);

            NoOpAsyncResult result = new NoOpAsyncResult(state);

            if (callback != null)
            {
                callback(result);
            }

            return result;
        }

        IAsyncResult BeginLoad(Guid id, TimeSpan timeout, AsyncCallback callback, object state)
        {
            object toReturn = Load(id, timeout);

            NoOpAsyncResult result = new NoOpAsyncResult(state, toReturn);

            if (callback != null)
            {
                callback(result);
            }

            return result;
        }

        
        void Delete(Guid identifier, TimeSpan timeout)
        {
            string fName = GetFileName(identifier);

            string newFileName = Path.Combine(Path.GetDirectoryName(fName), "DELETED-" + Path.GetFileName(fName));

            File.Move(fName, newFileName);
        }

        void EndDelete(IAsyncResult result)
        {
        }

        object EndLoad(IAsyncResult result)
        {
            return ((NoOpAsyncResult)result).ToReturn;
        }

        void EndSave(IAsyncResult result)
        {
        }

        private string GetDirectory()
        {
            string dirName = Path.Combine(Path.GetTempPath(), SubDirectoryName);

            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }

            return dirName;
        }

        private string GetFileName(Guid identifier)
        {
            return Path.Combine(GetDirectory(), string.Format(InstanceFormatString, identifier));
        }

        private string GetFileName(Guid identifier, int subStateId)
        {
            return Path.Combine(GetDirectory(), string.Format(SubStateFormatString, identifier, subStateId));
        }

        object Load(Guid identifier, TimeSpan timeout)
        {
            string fName = GetFileName(identifier);

            using (FileStream inFile = new FileStream(fName, FileMode.Open))
            {
                return formatter.Deserialize(inFile);
            }
        }

        IAsyncResult BeginCreate(Guid id, object instance, TimeSpan timeout, AsyncCallback callback, object state)
        {
            Create(id, instance, timeout);

            NoOpAsyncResult result = new NoOpAsyncResult(state);

            if (callback != null)
            {
                callback(result);
            }

            return result;
        }

        IAsyncResult BeginUpdate(Guid id, object instance, TimeSpan timeout, AsyncCallback callback, object state)
        {
            Update(id, instance, timeout);

            NoOpAsyncResult result = new NoOpAsyncResult(state);

            if (callback != null)
            {
                callback(result);
            }

            return result;
        }
        void EndCreate(IAsyncResult result)
        {
        }
        void EndUpdate(IAsyncResult result)
        {
        }
        void Create(Guid identifier, object toSave, TimeSpan timeout)
        {
            string fName = GetFileName(identifier);

            using (FileStream outFile = new FileStream(fName, FileMode.Create))
            {
                formatter.Serialize(outFile, toSave);
            }
        }

        void Update(Guid identifier, object toSave, TimeSpan timeout)
        {
            string fName = GetFileName(identifier);

            using (FileStream outFile = new FileStream(fName, FileMode.Create))
            {
                formatter.Serialize(outFile, toSave);
            }
        }


        public void Container0()    //Container method for Id snippet
        {
            //<snippet10>
            FilePersistenceProviderFactory factory = new FilePersistenceProviderFactory();
            PersistenceProvider provider = factory.CreateProvider(new Guid());
            Guid providerId = provider.Id;
            //</snippet10>
        }
    
        class FilePersistenceProvider : PersistenceProvider
        {
            FilePersistenceProviderFactory factory;
            //<snippet0>
            public FilePersistenceProvider(Guid id, FilePersistenceProviderFactory factory)
                : base(id)
            {
                this.factory = factory;
            }
            //</snippet0>
            protected override TimeSpan DefaultCloseTimeout
            {
                get { return TimeSpan.FromSeconds(15); }
            }

            protected override TimeSpan DefaultOpenTimeout
            {
                get { return TimeSpan.FromSeconds(15); }
            }

            //<snippet6>
            public override IAsyncResult BeginDelete(object instance, TimeSpan timeout, AsyncCallback callback, object state)
            {
                base.ThrowIfDisposedOrNotOpen();
                return this.factory.BeginDelete(this.Id, timeout, callback, state);
            }
            //</snippet6>

            //<snippet7>
            public override IAsyncResult BeginLoad(TimeSpan timeout, AsyncCallback callback, object state)
            {
                base.ThrowIfDisposedOrNotOpen();
                return this.factory.BeginLoad(this.Id, timeout, callback, state);
            }
            //</snippet7>

            //<snippet11>
            public override IAsyncResult BeginLoadIfChanged(TimeSpan timeout, object instanceToken, AsyncCallback callback, object state)
            {
                base.ThrowIfDisposedOrNotOpen();
                return this.factory.BeginLoad(this.Id, timeout, callback, state);
            }
            //</snippet11>

            

            //<snippet9>
            public override void Delete(object instance, TimeSpan timeout)
            {
                base.ThrowIfDisposedOrNotOpen();
                this.factory.Delete(this.Id, timeout);
            }
            //</snippet9>
            //<snippet5>
            public override void EndDelete(IAsyncResult result)
            {
                base.ThrowIfDisposedOrNotOpen();
                this.factory.EndDelete(result);
            }
            //</snippet5>

            //<snippet1>
            public override object EndLoad(IAsyncResult result)
            {
                base.ThrowIfDisposedOrNotOpen();
                return this.factory.EndLoad(result);
            }
            //</snippet1>

            //<snippet12>
            public override bool EndLoadIfChanged(IAsyncResult result, out object instance)
            {
                base.ThrowIfDisposedOrNotOpen();
                instance = this.factory.EndLoad(result);
                return true;
            }
            //</snippet12>

            
            //<snippet3>
            public override object Load(TimeSpan timeout)
            {
                base.ThrowIfDisposedOrNotOpen();
                return this.factory.Load(this.Id, timeout);
            }
            //</snippet3>

            //<snippet13>
            public override bool LoadIfChanged(TimeSpan timeout, object instanceToken, out object instance)
            {
                base.ThrowIfDisposedOrNotOpen();
                instance = this.factory.Load(this.Id, timeout);
                return true;
            }
            //</snippet13>

            //<snippet14>
            public override IAsyncResult BeginCreate(object instance, TimeSpan timeout, AsyncCallback callback, object state)
            {
                base.ThrowIfDisposedOrNotOpen();
                return this.factory.BeginCreate(this.Id, instance, timeout, callback, state);
            }
            //</snippet14>

            //<snippet15>
            public override object Create(object instance, TimeSpan timeout)
            {
                base.ThrowIfDisposedOrNotOpen();
                this.factory.Create(this.Id, instance, timeout);
                return null;
            }
            //</snippet15>
            //<snippet16>
            public override object EndCreate(IAsyncResult result)
            {
                base.ThrowIfDisposedOrNotOpen();
                this.factory.EndCreate(result);
                return null;
            }
            //</snippet16>
            //<snippet17>
            public override IAsyncResult BeginUpdate(object instance, TimeSpan timeout, AsyncCallback callback, object state)
            {
                base.ThrowIfDisposedOrNotOpen();
                return this.factory.BeginUpdate(this.Id, instance, timeout, callback, state);
            }
            //</snippet17>
            //<snippet18>
            public override object Update(object instance, TimeSpan timeout)
            {
                base.ThrowIfDisposedOrNotOpen();
                this.factory.Update(this.Id, instance, timeout);
                return null;
            }
            //</snippet18>
            //<snippet19>
            public override object EndUpdate(IAsyncResult result)
            {
                base.ThrowIfDisposedOrNotOpen();
                this.factory.EndUpdate(result);
                return null;
            }
            //</snippet19>

            

            protected override void OnAbort()
            {
            }

            protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
            {
                return new NoOpAsyncResult(callback, state);
            }

            protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
            {
                return new NoOpAsyncResult(callback, state);
            }

            protected override void OnClose(TimeSpan timeout)
            {
            }

            protected override void OnEndClose(IAsyncResult result)
            {
            }

            protected override void OnEndOpen(IAsyncResult result)
            {
            }

            protected override void OnOpen(TimeSpan timeout)
            {
            }
        }

        class NoOpAsyncResult : IAsyncResult
        {
            ManualResetEvent mre;
            object state;
            object toReturn;

            public NoOpAsyncResult(object state)
                : this(state, null)
            {
            }

            public NoOpAsyncResult(object state, object toReturn)
            {
                this.state = state;
                this.mre = new ManualResetEvent(true);
                this.toReturn = toReturn;
            }

            public object AsyncState
            {
                get { return state; }
            }

            public WaitHandle AsyncWaitHandle
            {
                get { return mre; }
            }

            public bool CompletedSynchronously
            {
                get { return true; }
            }

            public bool IsCompleted
            {
                get { return true; }
            }

            public object ToReturn
            {
                get { return toReturn; }
            }
        }
}
}
