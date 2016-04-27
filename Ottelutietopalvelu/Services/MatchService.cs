using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Ottelutietopalvelu.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ottelutietopalvelu.Services
{
  public class MatchService
  {
    #region Properties

    /// <summary>
    /// All MatchList property 
    /// (Used to avoid to read same json data multiple times)
    /// </summary>
    private List<Match> AllMatchList { get; set; }

    /// <summary>
    /// MatchList property
    /// (property used by caller)
    /// </summary>
    public List<Match> MatchList { get; set; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Constructor
    /// </summary>
    public MatchService()
    {
      readJsonMatches();
    }

    #endregion Constructors

    /// <summary>
    /// Reads all matched from Json-file into MatchList property
    /// </summary>
    public void readJsonMatches()
    {
      //Note! Json file path exists in Web.config:
      //<appSettings>
      //  <add key="JsonFilePath" value="C:\temp\matches.json" />
      //</appSettings>

      try
      {
        string jsonFile = System.Configuration.ConfigurationManager.AppSettings["JsonFilePath"];
        if (string.IsNullOrEmpty(jsonFile)) // Just in case!
        {
          jsonFile = @"C:\temp\matches.json";
        }
        string jsonData = System.IO.File.ReadAllText(jsonFile);
        AllMatchList = JsonConvert.DeserializeObject<List<Match>>(jsonData, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-ddTHH:mm:ssZ" });
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    /// <summary>
    /// Get all matches list into MatchList property ordered by MatchDate desc
    /// </summary>
    public void ReadAllMatches()
    {
      try
      {
        if (AllMatchList == null || AllMatchList.Count == 0) readJsonMatches(); // Just in case!

        MatchList = AllMatchList
          .OrderByDescending(m => m.MatchDate)
          .ToList();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    /// <summary>
    /// Get matched list within period into MatchList property ordered by MatchDate desc
    /// </summary>
    public void MatchesByPeriod(DateTime startDate, DateTime endDate)
    {
      try
      {
        if (AllMatchList == null || AllMatchList.Count == 0) readJsonMatches(); // Just in case!

        MatchList = AllMatchList
          .Where(m => m.MatchDate >= startDate && m.MatchDate < endDate.AddDays(1))
          .OrderByDescending(m => m.MatchDate)
          .ToList();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

  }
}