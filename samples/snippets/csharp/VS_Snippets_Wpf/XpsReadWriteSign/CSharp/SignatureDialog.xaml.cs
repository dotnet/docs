using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Input;
using System.Windows.Xps.Packaging;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;


namespace SDKSample
{
    /// <summary>
    /// Dialog for displaying Signatures and Signature Definitions associated
    /// with an XpsDocument
    /// </summary>

    public partial class SignatureDialog : Window
    {
        #region Constructor
        public SignatureDialog(XpsDocument document)
            : base()
        {
            _xpsDocument = document;
            InitializeComponent();
            SignatureDef.Click += new RoutedEventHandler(SignatureDefinitionCommandHandler);
            Sign.Click += new RoutedEventHandler(SignCommandHandler);
            Done.Click += new RoutedEventHandler(DoneCommandHandler);
            _signatureUtilities = new SignatureUtilites();
            InitializeSignatureDisplay();

        }
        #endregion
        #region Public Methods
        public SignatureDisplayItem AddSignatureItem(XpsSignatureDefinition signatureDefintion)
        {
            SignatureDisplayItem item = new SignatureDisplayItem();
            if (signatureDefintion != null)
            {
                item.Request = signatureDefintion.RequestedSigner;
                item.Intent = signatureDefintion.Intent;
                item.SignBy = signatureDefintion.SignBy.ToString();
                item.Location = signatureDefintion.SigningLocale;
                item.SigId = signatureDefintion.SpotId;
            }
            this.SignatureList.Items.Add(item);
            return item;
        }
        #endregion
        #region Private Methods
        private void InitializeSignatureDisplay()
        {
            this.SignatureList.Items.Clear();
            this.SignatureList.Items.Add(SignatureHeader);
            _signatureUtilities.IterateSignatureDefinitions(this, _xpsDocument);
            _signatureUtilities.IterateSignatures(this, _xpsDocument);
        }

        private void SignCommandHandler(object sender, RoutedEventArgs e)
        {
            SignatureDisplayItem item = SignatureList.SelectedItem as SignatureDisplayItem;
            if ( item != null && item.IsSigned )
            {
                System.Windows.MessageBox.Show("This definition is already signed.");
                return;
            }
            X509Certificate cert = PromptForSignature();
            if (cert != null)
            {
                Guid? spotID = null;
                if (item != null)
                {
                    spotID = item.SigId;
                }
                _signatureUtilities.SignXps(_xpsDocument, cert, spotID);
                InitializeSignatureDisplay();
            }

        }

        //<SnippetSignatureDefinitionCommandHandler>

        private void SignatureDefinitionCommandHandler(object sender, RoutedEventArgs e)
        {
            SignatureDefinition sigDefDialog = new SignatureDefinition();
            if (sigDefDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                XpsSignatureDefinition signatureDefinition = new XpsSignatureDefinition();
                signatureDefinition.RequestedSigner = sigDefDialog.RequestedSigner.Text;
                signatureDefinition.Intent = sigDefDialog.Intent.Text;
                signatureDefinition.SigningLocale = sigDefDialog.SigningLocale.Text;
                try
                {
                    signatureDefinition.SignBy = DateTime.Parse(sigDefDialog.SignBy.Text);
                }
                catch (FormatException)
                {
                }
                signatureDefinition.SpotId = Guid.NewGuid();
                IXpsFixedDocumentSequenceReader docSeq = _xpsDocument.FixedDocumentSequenceReader; //_xpsDocument is type System.Windows.Xps.Packaging.XpsDocument
                IXpsFixedDocumentReader doc = docSeq.FixedDocuments[0];
                doc.AddSignatureDefinition(signatureDefinition);
                doc.CommitSignatureDefinition();
                InitializeSignatureDisplay();
            }
        }

        //</SnippetSignatureDefinitionCommandHandler>

        private void DoneCommandHandler(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private static X509Certificate PromptForSignature()
        {
            X509Certificate2 x509cert = null;

            // look for appropriate certificates
            X509Store store = new X509Store(StoreLocation.CurrentUser);
            X509Certificate2Collection collection = null;

            store.Open(OpenFlags.OpenExistingOnly | OpenFlags.ReadOnly);
            collection = (X509Certificate2Collection)store.Certificates;

            // narrow down the choices
            // timevalid
            collection = collection.Find(X509FindType.FindByTimeValid, DateTime.Now, true /*validOnly*/);

            // intended for signing (or no intent specified)
            collection = collection.Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature, false /*validOnly*/);

            // remove certs that don't have private key
            // work backward so we don't disturb the enumeration
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                if (!collection[i].HasPrivateKey)
                {
                    collection.RemoveAt(i);
                }
            }

            // any suitable certificates available?
            if (collection.Count > 0)
            {
                // ask user to select
                collection = X509Certificate2UI.SelectFromCollection(collection, "Select Certificate",
                                                "Select Certificate",
                                                X509SelectionFlag.SingleSelection
                                              );
                if (collection.Count > 0)
                {
                    x509cert = collection[0];   // return the first one
                }
            }
            return x509cert;
        }
        #endregion Private Methods
        #region Private Members
        private SignatureUtilites _signatureUtilities;
        private XpsDocument _xpsDocument;
        #endregion

    }
    /// <summary>
    /// A control that diplays information on a Signature Definition and associated signature
    /// </summary>
    public class SignatureDisplayItem : StackPanel
    {

        #region Constructor
        public SignatureDisplayItem()
            :base()
        {
            this.Orientation = System.Windows.Controls.Orientation.Horizontal;
            RequestBlock = new TextBlock();
            RequestBlock.Width = 100;
            this.Children.Add(RequestBlock);

            SignerBlock = new TextBlock();
            SignerBlock.Width = 100;
            this.Children.Add(SignerBlock);

            IntentBlock = new TextBlock();
            IntentBlock.Width = 100;
            this.Children.Add(IntentBlock);

            LocationBlock = new TextBlock();
            LocationBlock.Width = 100;
            this.Children.Add(LocationBlock);

            SignByBlock = new TextBlock();
            SignByBlock.Width = 50;
            this.Children.Add(SignByBlock);
        }
        #endregion
        #region Public Properties
        public string Request
        {
            get { return RequestBlock.Text; }
            set { RequestBlock.Text = value; }
        }

        public string Signer
        {
            get { return SignerBlock.Text; }
            set { SignerBlock.Text = value; }
        }

        public string Intent
        {
            get { return IntentBlock.Text; }
            set { IntentBlock.Text = value; }
        }

        public string Location
        {
            get { return LocationBlock.Text; }
            set { LocationBlock.Text = value; }
        }
        public string SignBy
        {
            get { return SignByBlock.Text; }
            set { SignByBlock.Text = value; }
        }

        public Guid? SigId
        {
            get { return sigId; }
            set { sigId = value; }
        }

        public bool IsSigned
        {
            get { return isSigned; }
            set { isSigned = value; }
        }

        #endregion Public Properties
        #region Private Members
        private Guid? sigId;
        private TextBlock RequestBlock;
        private TextBlock SignerBlock;
        private TextBlock IntentBlock;
        private TextBlock LocationBlock;
        private TextBlock SignByBlock;
        private bool isSigned;
        #endregion PrivateMembers
    }

}