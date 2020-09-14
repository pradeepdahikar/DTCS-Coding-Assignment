using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Patient.Model;
using Patient.Service.Interfaces;
using Patient.Service.Services;
using Patient_Registration.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PatientRegistration.Test
{
    [TestClass]
    public class PatientServiceUnitTest
    {
        IPatientService _patientService;

        public PatientServiceUnitTest()
        {
            SetUpMocks();
        }

        private void SetUpMocks()
        {
            var mockRepo = new Mock<IPatientService>();

            IList<PatientModel> patientDetails = new List<PatientModel>()
            {
            new PatientModel {
                Name="Venkat",
                SurName="Swami",
                CityId=1,
                DOB=DateTime.Now,
                Gender="M"
            }
            };

            mockRepo
                .Setup(repo => repo.GetPatientListAsync())
                .ReturnsAsync(patientDetails.ToList());

            mockRepo.SetupAllProperties();

            _patientService = mockRepo.Object;
        }

        [TestMethod]
        public void GetPatientsDetails_AllPatients()
        {
            //Arrange the resources
            var controlller = new PatientController(_patientService);

            //Act on functionality
            var patientsList = controlller.Get().Result;
            var okResult = patientsList as OkObjectResult;
            var actualPatientList = (List<PatientModel>)okResult.Value;

            //Assert The result against expected
            Assert.IsTrue(actualPatientList[0].Name!=string.Empty);
        }

        [TestMethod]
        public void RegisterPatient()
        {
            var controller = new PatientController(_patientService);

            var patientsList = controller.Get().Result;
            var okResult = patientsList as OkObjectResult;
            var actualPatientList = (List<PatientModel>)okResult.Value;

            var result = controller.Post(actualPatientList[0]).Result;
            var resultFromPOST = (bool)((OkObjectResult)result).Value;
          

            Assert.IsTrue(resultFromPOST);
        }

    }
}
