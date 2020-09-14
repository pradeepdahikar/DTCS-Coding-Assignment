using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Patient.Model.LocationModule;
using Patient.Service.Interfaces;
using Patient_Registration.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatientRegistration.Test
{
    [TestClass]
    public class LocationServiceUnitTest
    {
        ILocationService _locationService;

        public LocationServiceUnitTest()
        {
            SetUpMocks();
        }

        private void SetUpMocks()
        {
            var mockRepo = new Mock<ILocationService>();

            IList<StateModel> stateList = new List<StateModel>()
            {
            new StateModel {
                Id=1,
                Name="MH"
            }
            };

            IList<CityModel> cityList = new List<CityModel>()
            {
            new CityModel {
                Id=1,
                Name="Pune",
            }
            };


            mockRepo
                .Setup(repo => repo.GetStateListAsync())
                .ReturnsAsync(stateList.ToList());

            mockRepo
                .Setup(repo => repo.GetCityListByStateIdAsync(1))
                .ReturnsAsync(cityList.ToList());

            mockRepo.SetupAllProperties();

            _locationService = mockRepo.Object;
        }

        [TestMethod]
        public void GetStateList()
        {
            //Arrange the resources
            var controlller = new LocationController(_locationService);

            //Act on functionality
            var stateList = controlller.GetStates().Result;
            var okResult = stateList as OkObjectResult;
            var actualStateList = (List<StateModel>)okResult.Value;

            //Assert The result against expected
            Assert.IsTrue(actualStateList[0].Name != string.Empty);
        }

        [TestMethod]
        public void GetCityListByStateId()
        {
            //Arrange the resources
            var controlller = new LocationController(_locationService);

            //Act on functionality
            var cityList = controlller.GetCityById(1).Result;
            var okResult = cityList as OkObjectResult;
            var actualCityList = (List<CityModel>)okResult.Value;

            //Assert The result against expected
            Assert.IsTrue(actualCityList[0].Name != string.Empty);
        }
    }
}
