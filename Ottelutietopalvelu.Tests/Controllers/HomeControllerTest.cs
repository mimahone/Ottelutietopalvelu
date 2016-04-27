using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ottelutietopalvelu.Controllers;
using Ottelutietopalvelu.Models;

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
    public void Index_Post()
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
  }
}
