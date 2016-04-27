using Ottelutietopalvelu.Models;
using Ottelutietopalvelu.Services;
using System;
using System.Web.Mvc;

namespace Ottelutietopalvelu.Controllers
{
  public class HomeController : Controller
  {
    /// <summary>
    /// Default method: Get all matches list
    /// </summary>
    /// <returns>View</returns>
    public ActionResult Index()
    {
      MatchesModel model = new MatchesModel();
      model.StartDate = null;
      model.EndDate = null;

      MatchService service = new MatchService();
      service.ReadAllMatches();
      model.Matches = service.MatchList;

      return View(model);
    }

    /// <summary>
    /// Get matches list within period
    /// </summary>
    /// <param name="startDate">Start Date of Search Period</param>
    /// <param name="endDate">End Date of Search Period</param>
    /// <returns>View</returns>
    [HttpPost]
    public ActionResult Index(DateTime? startDate, DateTime? endDate)
    {
      MatchesModel model = new MatchesModel();
      model.StartDate = startDate;
      model.EndDate = endDate;

      MatchService service = new MatchService();

      if (startDate.HasValue && endDate.HasValue)
      {
        service.MatchesByPeriod(startDate.Value, endDate.Value);
      }
      else
      {
        service.ReadAllMatches();
      }

      model.Matches = service.MatchList;

      return View(model);
    }

  }
}