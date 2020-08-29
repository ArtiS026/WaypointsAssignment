using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WebApplication1;

namespace JSONTest
{
    [TestClass]
    public class WaypointsTest
    {

        [TestMethod]
        public void CalculateSpeedDistanceAndTime()
        {
            //Arrange
            double expecteddistance = 133;
            DateTime dttimestamp = Convert.ToDateTime("2016-06-21T12:00:10.000Z");
            double speed = 11.1;

            InsuranceCalculation.JsonReader();

            //Act
            InsuranceCalculation.Categories(speed, dttimestamp);

            //Assert
            double actualdistance = 133.23;
            //Assert.AreEqual(expecteddistance, actualdistance, "Actual distance speeding");
            Assert.AreEqual(expecteddistance, actualdistance);

        }

        [TestMethod]
        public void CalculateSpeedDistanceAndTime_Throwsexception()
        {
            //Arrange
            double expecteddistance = 133.2, expectedtotalduration = 12.02;
            DateTime dttimestamp = DateTime.Today;
            double speed = 11.1;

            InsuranceCalculation.JsonReader();

            //Act
            InsuranceCalculation.Categories(speed, dttimestamp);

            //Assert
            double actualdistance = 125.1, actualtotalduration = 11.01;
            Assert.AreEqual(expecteddistance, actualdistance, "Incorrect distance speeding");
            Assert.AreEqual(expectedtotalduration, actualtotalduration, "Incorrect total duration");

        }

    }
}
