using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PhotoStore
{
    public class Photo
    {
        public Photo(string path)
        {
            _source = path;
        }

        public override string ToString()
        {
            return Source;
        }

        private string _source;
        public string Source { get { return _source; } }

    }

    public class PhotoList : ObservableCollection<Photo>
    {
        public PhotoList() { }

        public PhotoList(string path) : this(new DirectoryInfo(path)) { }

        public PhotoList(DirectoryInfo directory)
        {
            _directory = directory;
            Update();
        }

        public string Path
        {
            set
            {
                _directory = new DirectoryInfo(value);
                Update();
            }
            get { return _directory.FullName; }
        }

        public DirectoryInfo Directory
        {
            set
            {
                _directory = value;
                Update();
            }
            get { return _directory; }
        }
        private void Update()
        {
            foreach (FileInfo f in _directory.GetFiles("*.jpg"))
            {
                Add(new Photo(f.FullName));
            }
        }

        DirectoryInfo _directory;
    }

    public class PrintType
    {
        public PrintType(string description, double cost)
        {
            _description = description;
            _cost = cost;
        }

        public override string ToString()
        {
            return _description;
        }

        private string _description;
        public String Description { get { return _description; } }

        private double _cost;
        public double Cost { get { return _cost; } }
    }

    public class PrintTypeList : ObservableCollection<PrintType>
    {
        public PrintTypeList()
        {
            Add(new PrintType("4x6 Print", 0.19));
            Add(new PrintType("5x7 Print", 0.99));
            Add(new PrintType("8x10 Print", 2.99));
            Add(new PrintType("Framed Print", 7.99));
            Add(new PrintType("T-Shirt", 12.99));
        }
    }

    public class Print : INotifyPropertyChanged
    {
        public Print(Photo photo, PrintType printtype, int quantity)
        {
            Photo = photo;
            PrintType = printtype;
            Quantity = quantity;
        }

        private Photo _photo;
        public Photo Photo
        {
            set { _photo = value; OnPropertyChanged("Photo"); }
            get { return _photo; }
        }

        private PrintType _PrintType;
        public PrintType PrintType
        {
            set { _PrintType = value; OnPropertyChanged("PrintType"); }
            get { return _PrintType; }
        }

        private int _quantity;
        public int Quantity
        {
            set { _quantity = value; OnPropertyChanged("Quantity"); }
            get { return _quantity; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }

        public override string ToString()
        {
            return Quantity + " " + PrintType + " " + Photo;
        }
    }

    public class PrintList : ObservableCollection<Print> { }

}
