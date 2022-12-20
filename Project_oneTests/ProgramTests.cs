using Microsoft.VisualStudio.TestTools.UnitTesting;

using Project_one.Models;

using System;
using System.Collections.Generic;

using Assert = NUnit.Framework.Assert;

namespace Project_one.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void SetWeatherTest()
        {
            List<Models.WeatherForecast> pList = new List<WeatherForecast>();

            Project_one.Program.SetWeather(Enums.Weekday.Friday, 25, "Hot", DateTime.Now, pList: pList);

            Assert.AreEqual(1, pList.Count);
        }

        [TestMethod()]
        public void SetWeatherTestFail()
        {
            List<Models.WeatherForecast> pList = new List<WeatherForecast>();

            Project_one.Program.SetWeather(Enums.Weekday.Friday, 25, "Hot", DateTime.Now, pList: pList);

            Assert.Fail();
        }
    }
}