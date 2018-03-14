//-----------------------------------------------------------------------------
//<Snippet6>
using System.Reflection;
using Word = Microsoft.Office.Interop.Word;

namespace WordSpell
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;

        public Form1()  //constructor
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Word.Application app = new Word.Application();

            int errors = 0;
            if (textBox1.Text.Length > 0)
            {
                app.Visible = false;

                // Setting these variables is comparable to passing null to the function.
                // This is necessary because the C# null cannot be passed by reference.
                object template = Missing.Value;
                object newTemplate = Missing.Value;
                object documentType = Missing.Value;
                object visible = true;

                Word._Document doc1 = app.Documents.Add(ref template, ref newTemplate, ref documentType, ref visible);
                doc1.Words.First.InsertBefore(textBox1.Text);
                Word.ProofreadingErrors spellErrorsColl = doc1.SpellingErrors;
                errors = spellErrorsColl.Count;

                object optional = Missing.Value;

                doc1.CheckSpelling(
                    ref optional, ref optional, ref optional, ref optional, ref optional, ref optional,
                    ref optional, ref optional, ref optional, ref optional, ref optional, ref optional);

                label1.Text = errors + " errors corrected ";
                object first = 0;
                object last = doc1.Characters.Count - 1;
                textBox1.Text = doc1.Range(ref first, ref last).Text;
            }

            object saveChanges = false;
            object originalFormat = Missing.Value;
            object routeDocument = Missing.Value;

            app.Quit(ref saveChanges, ref originalFormat, ref routeDocument);
        }
    }
}
//</Snippet6>


//-----------------------------------------------------------------------------
// Form1.Desgner.cs
//-----------------------------------------------------------------------------
namespace Microsoft.Office.Interop
{
  namespace Word
  {

    //-------------------------------------------------------------------------
    class Application
    {
        private bool _Visible;
        public bool Visible
        {
            get{return _Visible;}
            set{_Visible = value;}
        }

        private Documents _Documents = new Documents();
        public Documents Documents
        {
            get{return _Documents;}
        }
        
        public void Quit(ref object SaveChanges, ref object OriginalFormat, ref object RouteDocument)
        {
        }
    }


    //-------------------------------------------------------------------------
    class Documents
    {
        public Document Add(ref object a, ref object b, ref object c, ref object d)
        {
            return new Document();
        }
    }


    //-------------------------------------------------------------------------
    public interface _Document
    {
        Words Words {get;}
        ProofreadingErrors SpellingErrors {get;}
        void CheckSpelling(ref object CustomDictionary, ref object IgnoreUppercase, ref object AlwaysSuggest, ref object CustomDictionary2, ref object CustomDictionary3, ref object CustomDictionary4, ref object CustomDictionary5, ref object CustomDictionary6, ref object CustomDictionary7, ref object CustomDictionary8, ref object CustomDictionary9, ref object CustomDictionary10);
        Characters Characters {get;}
        Range Range(ref object first, ref object last);
    }


    //-------------------------------------------------------------------------
    class Document : _Document
    {
        Words _Words = (Words) new object();
        public Words Words
        {
            get{ return _Words; }
        }

        ProofreadingErrors _SpellingErrors = (ProofreadingErrors) new object();
        public ProofreadingErrors SpellingErrors
        {
            get{ return _SpellingErrors; }
        }
        
        public void CheckSpelling(ref object CustomDictionary, ref object IgnoreUppercase, ref object AlwaysSuggest, ref object CustomDictionary2, ref object CustomDictionary3, ref object CustomDictionary4, ref object CustomDictionary5, ref object CustomDictionary6, ref object CustomDictionary7, ref object CustomDictionary8, ref object CustomDictionary9, ref object CustomDictionary10)
        {
        }

        Characters _Characters = (Characters) new object();
        public Characters Characters
        {
            get{ return _Characters; }
        }

        public Range Range(ref object first, ref object last)
        {
            return (Range)new object();
        }
    }


    //-------------------------------------------------------------------------
    public interface Range
    {
        void InsertBefore(string Text);
        string Text { set; get; }
    }


    //-------------------------------------------------------------------------
    public interface ProofreadingErrors
    {
        int Count { get; }
    }


    //-------------------------------------------------------------------------
    public interface Words
    {
        Range First {get;}
    }


    //-------------------------------------------------------------------------
    public interface Characters
    {
        int Count {get;}
    }
  }
}


//-----------------------------------------------------------------------------
namespace WordSpell
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components=null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing&&(components!=null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components=new System.ComponentModel.Container();
            this.AutoScaleMode=System.Windows.Forms.AutoScaleMode.Font;
            this.Text="Form1";

            //<Snippet7>
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(40, 40);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(344, 136);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(392, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Check Spelling";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(40, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(336, 16);
            this.label1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5, 13);
            this.ClientSize = new System.Drawing.Size(496, 205);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "SpellCheckDemo";
            this.ResumeLayout(false);
            //</Snippet7>
        }
    }
}
