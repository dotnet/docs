using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Globalization;

namespace AltnerationIndexSnippets
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            //MessageBox.Show((-10 % 7).ToString());

        }
    }

    #region GroupStyle data
    public class Place
    {
        private string name;

        private string state;

        public string CityName
        {
            get { return name; }
            set { name = value; }
        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public Place()
        {
            this.name = "";
            this.state = "";
        }

        public Place(string name, string state)
        {
            this.name = name;
            this.state = state;
        }
    }

    public class Places : ObservableCollection<Place>
    {
        public Places()
        {
            Add(new Place("Seattle", "WA"));
            Add(new Place("Redmond", "WA"));
            Add(new Place("Bellevue", "WA"));
            Add(new Place("Kirkland", "WA"));
            Add(new Place("Portland", "OR"));
            Add(new Place("San Francisco", "CA"));
            Add(new Place("Los Angeles", "CA"));
            Add(new Place("San Diego", "CA"));
            Add(new Place("San Jose", "CA"));
            Add(new Place("Santa Ana", "CA"));
            Add(new Place("Bellingham", "WA"));
            Add(new Place("Tacoma", "WA"));
            Add(new Place("Albany", "OR"));
        }
    }
    #endregion

    #region TreeView Data
    public class League
    {
        public League(string name)
        {
            _name = name;
            _divisions = new List<Division>();
        }


        string _name;

        public string Name { get { return _name; } }

        List<Division> _divisions;
        public List<Division> Divisions { get { return _divisions; } }

    }
    public class Division
    {
        public Division(string name)
        {
            _name = name;
            _teams = new List<Team>();

        }

        string _name;

        public string Name { get { return _name; } }

        List<Team> _teams;

        public List<Team> Teams { get { return _teams; } }

    }

    public class Team
    {
        public Team(string name)
        {
            _name = name;
        }

        string _name;

        public string Name { get { return _name; } }
    }

    public class ListLeagueList : List<League>
    {
        public ListLeagueList()
        {
            League l;
            Division d;

            Add(l = new League("League A"));
            l.Divisions.Add((d = new Division("Division A")));
            d.Teams.Add(new Team("Team I"));
            d.Teams.Add(new Team("Team II"));
            d.Teams.Add(new Team("Team III"));
            d.Teams.Add(new Team("Team IV"));
            d.Teams.Add(new Team("Team V"));
            l.Divisions.Add((d = new Division("Division B")));
            d.Teams.Add(new Team("Team Blue"));
            d.Teams.Add(new Team("Team Red"));
            d.Teams.Add(new Team("Team Yellow"));
            d.Teams.Add(new Team("Team Green"));
            d.Teams.Add(new Team("Team Orange"));
            l.Divisions.Add((d = new Division("Division C")));
            d.Teams.Add(new Team("Team East"));
            d.Teams.Add(new Team("Team West"));
            d.Teams.Add(new Team("Team North"));
            d.Teams.Add(new Team("Team South"));
            Add(l = new League("League B"));
            l.Divisions.Add((d = new Division("Division A")));
            d.Teams.Add(new Team("Team 1"));
            d.Teams.Add(new Team("Team 2"));
            d.Teams.Add(new Team("Team 3"));
            d.Teams.Add(new Team("Team 4"));
            d.Teams.Add(new Team("Team 5"));
            l.Divisions.Add((d = new Division("Division B")));
            d.Teams.Add(new Team("Team Diamond"));
            d.Teams.Add(new Team("Team Heart"));
            d.Teams.Add(new Team("Team Club"));
            d.Teams.Add(new Team("Team Spade"));
            l.Divisions.Add((d = new Division("Division C")));
            d.Teams.Add(new Team("Team Alpha"));
            d.Teams.Add(new Team("Team Beta"));
            d.Teams.Add(new Team("Team Gamma"));
            d.Teams.Add(new Team("Team Delta"));
            d.Teams.Add(new Team("Team Epsilon"));
        }

    }

    #endregion

    public class ListBoxData : ObservableCollection<string>
    {
        public ListBoxData()
        {
            Add("item 1");
            Add("item 2");
            Add("item 3");
            Add("item 4");
            Add("item 5");
        }

    }

}
