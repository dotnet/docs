//<SnippetData>
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace IEditableCollectionViewAddItemExample
{
    // LibraryItem implements INotifyPropertyChanged so that the 
    // application is notified when a property changes.  It 
    // implements IEditableObject so that pending changes can be discarded.
    public class LibraryItem : INotifyPropertyChanged, IEditableObject
    {
        struct ItemData
        {
            internal string Title;
            internal string CallNumber;
            internal DateTime DueDate;
        }

        ItemData copyData;
        ItemData currentData;

        public LibraryItem(string title, string callNum, DateTime dueDate)
        {
            Title = title;
            CallNumber = callNum;
            DueDate = dueDate;
        }

        public override string ToString()
        {
            return String.Format("{0}, {1:c}, {2:D}", Title, CallNumber, DueDate);
        }

        public string Title
        {
            get { return currentData.Title; }
            set
            {
                if (currentData.Title != value)
                {
                    currentData.Title = value;
                    NotifyPropertyChanged("Title");
                }
            }
        }

        public string CallNumber
        {
            get { return currentData.CallNumber; }
            set
            {
                if (currentData.CallNumber != value)
                {
                    currentData.CallNumber = value;
                    NotifyPropertyChanged("CallNumber");
                }
            }
        }

        public DateTime DueDate
        {
            get { return currentData.DueDate; }
            set
            {
                if (value != currentData.DueDate)
                {
                    currentData.DueDate = value;
                    NotifyPropertyChanged("DueDate");
                }
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        #endregion

        #region IEditableObject Members

        public virtual void BeginEdit()
        {
            copyData = currentData;
        }

        public virtual void CancelEdit()
        {
            currentData = copyData;
            NotifyPropertyChanged("");

        }

        public virtual void EndEdit()
        {
            copyData = new ItemData();

        }

        #endregion

    }


    public class MusicCD : LibraryItem
    {
        private struct MusicData
        {
            internal int SongNumber;
            internal string Artist;

        }

        MusicData copyData;
        MusicData currentData;

        public MusicCD(string title, string artist, int songNum, string callNum, DateTime dueDate)
            : base(title, callNum, dueDate)
        {
            currentData.SongNumber = songNum;
            currentData.Artist = artist;
        }

        public string Artist
        {
            get { return currentData.Artist; }
            set
            {
                if (value != currentData.Artist)
                {
                    currentData.Artist = value;
                    NotifyPropertyChanged("Artist");
                }
            }
        }

        public int NumberOfTracks
        {
            get { return currentData.SongNumber; }
            set
            {
                if (value != currentData.SongNumber)
                {
                    currentData.SongNumber = value;
                    NotifyPropertyChanged("NumberOfTracks");
                }
            }
        }

        public override void BeginEdit()
        {
            base.BeginEdit();
            copyData = currentData;
        }

        public override void CancelEdit()
        {
            base.CancelEdit();
            currentData = copyData;
        }

        public override void EndEdit()
        {
            base.EndEdit();
            copyData = new MusicData();
        }

        public override string ToString()
        {
            return string.Format(
                "Album: {0}\nArtist: {1}\nTracks: {2}\nDue Date: {3:d}\nCall Number: {4}",
                this.Title, this.Artist, this.NumberOfTracks, this.DueDate, this.CallNumber);
        }
    }

    public class Book : LibraryItem
    {
        private struct BookData
        {
            internal string Author;
            internal string Genre;
        }

        BookData currentData;
        BookData copyData;

        public Book(string title, string author, string genre, string callnum, DateTime dueDate)
            : base (title, callnum, dueDate)
        {
            this.Author = author;
            this.Genre = genre;
        }

        public string Author
        {
            get { return currentData.Author; }
            set
            {
                if (value != currentData.Author)
                {
                    currentData.Author = value;
                    NotifyPropertyChanged("Author");
                }
            }
        }

        public string Genre
        {
            get { return currentData.Genre; }
            set
            {
                if (value != currentData.Genre)
                {
                    currentData.Genre = value;
                    NotifyPropertyChanged("Genre");
                }
            }
        }

        public override void BeginEdit()
        {
            base.BeginEdit();
            copyData = currentData;
        }

        public override void CancelEdit()
        {
            base.CancelEdit();
            currentData = copyData;
        }

        public override void EndEdit()
        {
            base.EndEdit();
            copyData = new BookData();
        }

        public override string ToString()
        {
            return String.Format(
                "Title: {0}\nAuthor: {1}\nGenre: {2}\nDue Date: {3:d}\nCall Number: {4}",
                this.Title, this.Author, this.Genre, this.DueDate, this.CallNumber);
        }
    }

    public class MovieDVD : LibraryItem
    {
        private struct MovieData
        {
            internal TimeSpan Length;
            internal string Director;
            internal string Genre;
        }

        private MovieData currentData;
        private MovieData copyData;


        public MovieDVD(string title, string director, string genre, TimeSpan length, string callnum, DateTime dueDate)
            : base(title, callnum, dueDate)
        {
            this.Director = director;
            this.Length = length;
            this.Genre = genre;
        }

        public TimeSpan Length
        {
            get { return currentData.Length; }
            set
            {
                if (value != currentData.Length)
                {
                    currentData.Length = value;
                    NotifyPropertyChanged("Length");
                }
            }
        }

        public string Director
        {
            get { return currentData.Director; }
            set
            {
                if (value != currentData.Director)
                {
                    currentData.Director = value;
                    NotifyPropertyChanged("Director");
                }
            }
        }

        public string Genre
        {
            get { return currentData.Genre; }
            set
            {
                if (value != currentData.Genre)
                {
                    currentData.Genre = value;
                    NotifyPropertyChanged("Genre");
                }
            }
        }

        public override void BeginEdit()
        {
            base.BeginEdit();
            copyData = currentData;
        }

        public override void CancelEdit()
        {
            base.CancelEdit();
            currentData = copyData;
        }

        public override void EndEdit()
        {
            base.EndEdit();
            copyData = new MovieData();
        }

        public override string  ToString()
        {
            return String.Format("Title: {0}\nDirector: {1}\nGenre: {2}\nLength: {3}\nDue Date: {4:d}\nCall Number: {5}",
                this.Title, this.Director, this.Genre, this.Length, this.DueDate, this.CallNumber);
        }
    }

    public class LibraryCatalog : ObservableCollection<LibraryItem>
    {
        public LibraryCatalog()
        {
            Add(new MusicCD("A Programmers Plight", "Jon Orton", 
                12, "CD.OrtPro", new DateTime(2010, 3, 24)));
    
            Add(new Book("Cooking with Thyme", "Eliot J. Graff",
                "Home Economics", "HE.GraThy", new DateTime(2010, 2, 26)));
            
            Add(new MovieDVD("Terror of the Testers", "Molly Dempsey", 
                "Horror", new TimeSpan(1, 27, 19), "DVD.DemTer",
                new DateTime(2010, 2, 1)));
            
            Add(new MusicCD("The Best of Jim Hance", "Jim Hance", 
                15, "CD.HanBes", new DateTime(2010, 1, 31)));
            
            Add(new Book("Victor and the VB Vehicle", "Tommy Hortono", 
                "YA Fiction", "YA.HorVic", new DateTime(2010, 3, 1)));

        }
    }
}
//</SnippetData>
