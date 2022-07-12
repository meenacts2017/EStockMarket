using EStockMarket.Business.Interface;
using EStockMarket.Controllers;
using EStockMarket.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EStockMarketAPITest
{
    public class CompanyControllerTest
    {
        private Mock<ICompanyProcessor> _companyProcessor;
        private CompanyController _companyController;
        [SetUp]
        public void Setup()
        {
            _companyProcessor = new Mock<ICompanyProcessor>();
            _companyController = new CompanyController(_companyProcessor.Object);
        }

        [Test]
        public void RegisterCompany_WithValidInput_ReturnsOkResultAsync()
        {
            //Arrange
            var companyData = new Company()
            {
                Id = "FirstData",
                Code = "CompanyCode",
                Name = "CompanyName",
                StockExchange = "BSE",
                CEO = "CompanyCEO",
                WebSite = "CompanySite",
                TurnOver = 100
            };
            _companyProcessor.Setup(x => x.AddCompanyAsync(It.IsAny<Company>())).Returns(Task.CompletedTask);

            //Act
            var actualResult =  _companyController.Post(companyData);

            //Assert
            Assert.IsNotNull(actualResult);
            OkResult OkResult = actualResult.Result as OkResult;
            Assert.AreEqual(200, OkResult.StatusCode);
           
        }

        [Test]
        public void GetAllCompany_ReturnsOkResult()
        {
            //Arrange
            var listCompany = new List<Company>()
            {
                new Company()
            {
                Id = "FirstData",
                Code = "CompanyCode",
                Name = "CompanyName",
                StockExchange = "BSE",
                CEO = "CompanyCEO",
                WebSite = "CompanySite",
                TurnOver = 100
            },
            new Company()
            {
                Id = "FirstData1",
                Code = "CompanyCode1",
                Name = "CompanyName1",
                StockExchange = "BSE1",
                CEO = "CompanyCEO1",
                WebSite = "CompanySite1",
                TurnOver = 100
            }
            };
          
            _companyProcessor.Setup(x => x.GetAllCompanyAsync()).Returns(Task.FromResult(listCompany));

            //Act
            var actualResult = _companyController.GetAll();

            //Assert
            Assert.IsNotNull(actualResult);
            OkObjectResult OkResult = actualResult.Result as OkObjectResult;
            Assert.AreEqual(200, OkResult.StatusCode);
        }

        [Test]
        public void GetCompanyByCode_ReturnsOkResult()
        {
            //Arrange
            var company = new Company()
            {
                Id = "FirstData",
                Code = "CompanyCode",
                Name = "CompanyName",
                StockExchange = "BSE",
                CEO = "CompanyCEO",
                WebSite = "CompanySite",
                TurnOver = 100
            };

            _companyProcessor.Setup(x => x.GetCompanyByIdAsync("CompanyCode")).Returns(Task.FromResult(company));

            //Act
            var actualResult = _companyController.GetCompany("CompanyCode");

            //Assert
            Assert.IsNotNull(actualResult);
            OkObjectResult OkResult = actualResult.Result as OkObjectResult;
            Assert.AreEqual(200, OkResult.StatusCode);
          
        }
        [Test]
        public void DeleteCompany_WithValidInput_ReturnsOkResultAsync()
        {
            //Arrange           
            _companyProcessor.Setup(x => x.DeleteCompanyAsync(It.IsAny<string>())).Returns(Task.CompletedTask);

            //Act
            var actualResult = _companyController.Delete("CompanyCode");

            //Assert
            Assert.IsNotNull(actualResult);
            OkResult OkResult = actualResult.Result as OkResult;
            Assert.AreEqual(200, OkResult.StatusCode);

        }
    }
}