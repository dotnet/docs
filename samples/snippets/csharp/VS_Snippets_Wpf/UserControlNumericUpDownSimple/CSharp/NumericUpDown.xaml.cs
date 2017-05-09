//<!--<SnippetCodeBehind>-->
using System;
using System.Windows;
using System.Windows.Controls;

namespace MyUserControl
{
    public partial class NumericUpDown : System.Windows.Controls.UserControl
    {
        /// <summary>
        /// Initializes a new instance of the NumericUpDownControl.
        /// </summary>
        public NumericUpDown()
        {
            InitializeComponent();

            UpdateTextBlock();
        }

        /// <summary>
        /// Gets or sets the value assigned to the control.
        /// </summary>
        public decimal Value
        {
            get { return _value; }
            set
            {
                if (value != _value)
                {
                    if (MinValue <= value && value <= MaxValue)
                    {
                        _value = value;
                        UpdateTextBlock();
                        OnValueChanged(EventArgs.Empty);
                    }
                }
            }
        }


        private decimal _value = MinValue;


        /// <summary>
        /// Occurs when the Value property changes.
        /// </summary>
        public event EventHandler<EventArgs> ValueChanged;


        /// <summary>
        /// Raises the ValueChanged event.
        /// </summary>
        /// <param name="args">An EventArgs that contains the event data.</param>
        protected virtual void OnValueChanged(EventArgs args)
        {
            EventHandler<EventArgs> handler = ValueChanged;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        //<SnippetEventHandlerCode>
        private void upButton_Click(object sender, EventArgs e)
        {
                Value++;
        }

        private void downButton_Click(object sender, EventArgs e)
        {
                Value--;
        }
        //</SnippetEventHandlerCode>

        //<SnippetUIRefCode>
        private void UpdateTextBlock()
        {
            valueText.Text = Value.ToString();
        }
        //</SnippetUIRefCode>

        private const decimal MinValue = 0, MaxValue = 100;
    }
}
//<!--</SnippetCodeBehind>-->