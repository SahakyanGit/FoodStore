using System;
using System.Collections.Generic;
using FoodStore.Domain.Abstract;
using FoodStore.Domain.Entities;
using FoodStore.WebUI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using FoodStore.WebUI.HtmlHelpers;
using FoodStore.WebUI.Models;
using Microsoft.CSharp;


namespace FoodStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            // Arrange - define an HTML helper - we need to do this
            // in order to apply the extension method
            HtmlHelper myHelper = null;
            // Arrange - create PagingInfo data
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };
            // Arrange - set up the delegate using a lambda expression
            Func<int, string> pageUrlDelegate = i => "Page" + i;
            // Act
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            // Assert
            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
                            + @"<a class=""btn btn-default btn btn-default selected"" href=""Page2"">2</a>"
                            + @"<a class=""btn btn-default"" href=""Page3"">3</a>",
                result.ToString());
        }
    }
}
