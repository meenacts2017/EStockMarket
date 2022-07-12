using EStockMarket.Business.Interface;
using EStockMarket.Controllers;
using EStockMarket.Model;
using Moq;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EStockMarketAPITest
{
    public class StockControllerTest
    {
        private Mock<IStocksProcessor> _stocksProcessor;
        private StockController stockController;

        [SetUp]
        public void Setup()
        {
            _stocksProcessor = new Mock<IStocksProcessor>();
            stockController = new StockController(_stocksProcessor.Object);
        }

        [Test]
        public void AddStock_WithValidInput_ReturnsOkResultAsync()
        {
            //Arrange
            var stock = new Stocks()
            { 
                StockPrice = 10
            };
            _stocksProcessor.Setup(x => x.AddStockAsync(It.IsAny<Stocks>())).Returns(Task.CompletedTask);

            //Act
            var actualResult = stockController.Post(stock, "CompanyCode");

            //Assert
            Assert.IsNotNull(actualResult);
            OkResult OkResult = actualResult.Result as OkResult;
            Assert.AreEqual(200, OkResult.StatusCode);
        }

        [Test]
        public void GetStock_WithValidCode_ReturnStock()
        {
            var listStocks = new List<Stocks>()
            { new Stocks()
            {
                StockPrice = 20,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            },
            new Stocks()
            {
                StockPrice = 20,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            }
            };
            _stocksProcessor.Setup(x => x.GetStocksByIdAndDate(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .Returns(Task.FromResult(listStocks));
            //Act
            var actualResult = stockController.GetStocks("CompanyCode", DateTime.Now, DateTime.Now);

            //Assert
            Assert.IsNotNull(actualResult);
            OkObjectResult OkResult = actualResult.Result as OkObjectResult;
            Assert.AreEqual(200, OkResult.StatusCode);
        }

        [Test]
        public void GetStockAvg_WithValidCode_ReturnStockAvg()
        {
            var listStocks = new List<Stocks>()
            { new Stocks()
            {
                StockPrice = 20,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            },
            new Stocks()
            {
                StockPrice = 20,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            }
            };
            _stocksProcessor.Setup(x => x.GetStocksByIdAndDate(It.IsAny<string>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .Returns(Task.FromResult(listStocks));
            //Act
            var actualResult = stockController.GetStocksAug("CompanyCode", DateTime.Now, DateTime.Now);

            //Assert
            Assert.IsNotNull(actualResult);
            OkObjectResult OkResult = actualResult.Result as OkObjectResult;
            Assert.AreEqual(200, OkResult.StatusCode);
        }
    }
}
