using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Collections.ObjectModel;

namespace SDKSample
{
  //<Snippet2>
  public class Team
  {
    string _name;

    public Team(string name)
    {
      _name = name;
    }
      public string Name { get { return _name; } }

      public override string ToString()
      {
          return _name.ToString();
      }
  }

  public class TeamList : ObservableCollection<Team>
  {
    public TeamList() : base()
    {
    }
  }

  public class Division
  {
    string _name;
    TeamList _teams;

    public Division(string name)
    {
    	_name = name;
    	_teams = new TeamList();
    }

    public string Name { get { return _name; } }

      public override string ToString()
      {
          return _name.ToString();
      }

    public TeamList Teams { get { return _teams; } }
  }

  public class DivisionList : ObservableCollection<Division>
  {
    public DivisionList() : base()
    {
    }
  }

  public class League
  {
    string _name;
    DivisionList _divisions;

    public League(string name)
    {
    	_name = name;
    	_divisions = new DivisionList();
    }

    public string Name { get { return _name; } }

      public override string ToString()
      {
          return _name.ToString();
      }

    public DivisionList Divisions { get { return _divisions; } }
  }

  public class LeagueList : ObservableCollection<League>
  {
    public LeagueList() : base()
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
  //</Snippet2>
}
