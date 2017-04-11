using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace StylingIntroSample
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
}
