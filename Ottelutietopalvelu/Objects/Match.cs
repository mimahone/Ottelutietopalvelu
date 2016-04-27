using System;
using System.Collections.Generic;

namespace Ottelutietopalvelu.Objects
{
  /// <summary>
  /// Class for Match object
  /// (These properties were generated using http://json2csharp.com/ service)
  /// </summary>
  public class Match
  {
    public int Id { get; set; }
    public object Round { get; set; }
    public int RoundNumber { get; set; }
    public DateTime? MatchDate { get; set; } // string changed manually to DateTime?
    public HomeTeam HomeTeam { get; set; }
    public AwayTeam AwayTeam { get; set; }
    public int HomeGoals { get; set; }
    public int AwayGoals { get; set; }
    public int Status { get; set; }
    public int PlayedMinutes { get; set; }
    public object SecondHalfStarted { get; set; }
    public DateTime? GameStarted { get; set; } // string changed manually to DateTime?
    public List<object> MatchEvents { get; set; }
    public List<object> PeriodResults { get; set; }
    public bool OnlyResultAvailable { get; set; }
    public int Season { get; set; }
    public string Country { get; set; }
    public string League { get; set; }
  }
}