// <snippet0>
using System;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Controls;
using System.Windows.Media;

namespace MyControls
{
    // <snippet21>
    public partial class MyControl1 : Grid
    // </snippet21>
    {
        // <snippet11>
        public delegate void MyControlEventHandler(object sender, MyControlEventArgs args);
        public event MyControlEventHandler OnButtonClick;
        private FontWeight _fontWeight;
        private double _fontSize;
        private FontFamily _fontFamily;
        private FontStyle _fontStyle;
        private SolidColorBrush _foreground;
        private SolidColorBrush _background;

        private void Init(object sender, EventArgs e)
        {
            //They all have the same style, so use nameLabel to set initial values.
            _fontWeight = nameLabel.FontWeight;
            _fontSize = nameLabel.FontSize;
            _fontFamily = nameLabel.FontFamily;
            _fontStyle = nameLabel.FontStyle;
            _foreground = (SolidColorBrush)nameLabel.Foreground;
            _background = (SolidColorBrush)rootElement.Background;
        }
        // </snippet11>

        // <snippet12>
        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            MyControlEventArgs retvals = new MyControlEventArgs(true,
                                                                txtName.Text,
                                                                txtAddress.Text,
                                                                txtCity.Text,
                                                                txtState.Text,
                                                                txtZip.Text);
            if (sender == btnCancel)
            {
                retvals.IsOK = false;
            }
            if (OnButtonClick != null)
                OnButtonClick(this, retvals);
        }
        // </snippet12>

        // <snippet13>
        public FontWeight MyControl_FontWeight
        {
            get { return _fontWeight; }
            set
            {
                _fontWeight = value;
                nameLabel.FontWeight = value;
                addressLabel.FontWeight = value;
                cityLabel.FontWeight = value;
                stateLabel.FontWeight = value;
                zipLabel.FontWeight = value;
            }
        }
        public double MyControl_FontSize
        {
            get { return _fontSize; }
            set
            {
                _fontSize = value;
                nameLabel.FontSize = value;
                addressLabel.FontSize = value;
                cityLabel.FontSize = value;
                stateLabel.FontSize = value;
                zipLabel.FontSize = value;
            }
        }
        public FontStyle MyControl_FontStyle
        {
            get { return _fontStyle; }
            set
            {
                _fontStyle = value;
                nameLabel.FontStyle = value;
                addressLabel.FontStyle = value;
                cityLabel.FontStyle = value;
                stateLabel.FontStyle = value;
                zipLabel.FontStyle = value;
            }
        }
        public FontFamily MyControl_FontFamily
        {
            get { return _fontFamily; }
            set
            {
                _fontFamily = value;
                nameLabel.FontFamily = value;
                addressLabel.FontFamily = value;
                cityLabel.FontFamily = value;
                stateLabel.FontFamily = value;
                zipLabel.FontFamily = value;
            }
        }

        public SolidColorBrush MyControl_Background
        {
            get { return _background; }
            set
            {
                _background = value;
                rootElement.Background = value;
            }
        }
        public SolidColorBrush MyControl_Foreground
        {
            get { return _foreground; }
            set
            {
                _foreground = value;
                nameLabel.Foreground = value;
                addressLabel.Foreground = value;
                cityLabel.Foreground = value;
                stateLabel.Foreground = value;
                zipLabel.Foreground = value;
            }
        }
        // </snippet13>
    }

    // <snippet14>
    public class MyControlEventArgs : EventArgs
    {
        private string _Name;
        private string _StreetAddress;
        private string _City;
        private string _State;
        private string _Zip;
        private bool _IsOK;

        public MyControlEventArgs(bool result,
                                  string name,
                                  string address,
                                  string city,
                                  string state,
                                  string zip)
        {
            _IsOK = result;
            _Name = name;
            _StreetAddress = address;
            _City = city;
            _State = state;
            _Zip = zip;
        }

        public string MyName
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string MyStreetAddress
        {
            get { return _StreetAddress; }
            set { _StreetAddress = value; }
        }
        public string MyCity
        {
            get { return _City; }
            set { _City = value; }
        }
        public string MyState
        {
            get { return _State; }
            set { _State = value; }
        }
        public string MyZip
        {
            get { return _Zip; }
            set { _Zip = value; }
        }
        public bool IsOK
        {
            get { return _IsOK; }
            set { _IsOK = value; }
        }
    }
    // </snippet14>
}
// </snippet0>