using Ottelutietopalvelu.Objects;
using System;
using System.Collections.Generic;

namespace Ottelutietopalvelu.Models
{
  public class MatchesModel
  {
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public IList<Match> Matches { get; set; }
  }
}