using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ottelutietopalvelu.Controllers;
using Ottelutietopalvelu.Models;
using Ottelutietopalvelu.Objects;
using System.Collections.Generic;

namespace Ottelutietopalvelu.Tests.Controllers
{
  /// <summary>
  /// Test class for HomeController tests
  /// </summary>
  [TestClass]
  public class HomeControllerTest
  {
    /// <summary>
    /// Test for Home/Index default method
    /// </summary>
    [TestMethod]
    public void Index()
    {
      // Arrange
      HomeController controller = new HomeController();

      // Act
      ViewResult result = controller.Index() as ViewResult;

      // Assert
      Assert.IsNotNull(result);
      var model = (MatchesModel)result.Model;
      Assert.IsTrue(model.Matches.Count > 100);
      Assert.IsNull(model.StartDate);
      Assert.IsNull(model.EndDate);
    }

    /// <summary>
    /// Test for Home/Index post method
    /// </summary>
    [TestMethod]
    public void Index_Post_WithPeriod()
    {
      // Arrange
      HomeController controller = new HomeController();
      DateTime startDate = new DateTime(2015, 9, 15);
      DateTime endDate = new DateTime(2015, 10, 15);

      // Act
      ViewResult result = controller.Index(startDate, endDate) as ViewResult;

      // Assert
      Assert.IsNotNull(result);
      var model = (MatchesModel)result.Model;
      Assert.IsTrue(model.Matches.Count > 10);
      Assert.AreEqual(startDate, model.StartDate);
      Assert.AreEqual(endDate, model.EndDate);
    }

    /// <summary>
    /// Test for Home/Index post method
    /// </summary>
    [TestMethod]
    public void Index_Post_WithoutPeriod()
    {
      // Arrange
      HomeController controller = new HomeController();

      // Act
      ViewResult result = controller.Index(null, null) as ViewResult;

      // Assert
      Assert.IsNotNull(result);
      var model = (MatchesModel)result.Model;
      Assert.IsTrue(model.Matches.Count > 10);
      Assert.AreEqual(null, model.StartDate);
      Assert.AreEqual(null, model.EndDate);
    }

    /// <summary>
    /// Test for Home/GetMatches(startDate, endDate) get method
    /// </summary>
    [TestMethod]
    public void GetMatches_WithPeriod()
    {
      // Arrange
      HomeController controller = new HomeController();
      DateTime startDate = new DateTime(2015, 9, 15);
      DateTime endDate = new DateTime(2015, 10, 15);

      // Act
      JsonResult result = controller.GetMatches(startDate, endDate);
      List<Match> matches = (List<Match>)result.Data;

      // Assert  
      Assert.IsTrue(matches.Count < 30);
    }

    /// <summary>
    /// Test for Home/GetMatches(startDate, endDate) get method
    /// </summary>
    [TestMethod]
    public void GetMatches_WithoutPeriod()
    {
      // Arrange
      HomeController controller = new HomeController();

      // Act
      JsonResult result = controller.GetMatches(null, null);
      List<Match> matches = (List<Match>)result.Data;

      // Assert  
      Assert.IsTrue(matches.Count > 190);
    }

  }
}
