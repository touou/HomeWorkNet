using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HW6Giraffe;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW6Tests
{
    [TestClass]
    public class CalculatorTests
    {
        private WebApplicationFactory<Startup> factory;
        private HttpClient client;

        [TestInitialize]
        public void SetFactory()
        {
            factory = new WebApplicationFactory<Startup>();
            client = factory.CreateClient();
        }

        private async Task<decimal> Action(decimal v1, decimal v2, string operation)
        {
            var response = await client.GetAsync($"http://localhost:5000/calc?v1={v1}&v2={v2}&op={operation}");

            var strNumber = await response.Content.ReadAsStringAsync();
            decimal parsed;
            try
            {
                parsed = decimal.Parse(strNumber, CultureInfo.InvariantCulture);
            }
            catch
            {
                throw new Exception($"cant parse, the number is {strNumber}");
            }

            return parsed;
        }

        private async Task<decimal> Sum(decimal v1, decimal v2) => await Action(v1, v2, "sum");
        private async Task<decimal> Minus(decimal v1, decimal v2) => await Action(v1, v2, "minus");
        private async Task<decimal> Mult(decimal v1, decimal v2) => await Action(v1, v2, "mult");
        private async Task<decimal> Div(decimal v1, decimal v2) => await Action(v1, v2, "div");

        private static void IsEqual(decimal v1, decimal v2) => Assert.IsTrue(Math.Round(v1 - v2) < 0.0001m);

        [TestMethod]
        public async Task IsSumEqual()
        {
            IsEqual(3m, await Sum(1, 2));
            IsEqual(6m, await Sum(4, 2));
            IsEqual(123m, await Sum(101, 22));
            IsEqual(4835m, await Sum(1252, 3583));
        }

        [TestMethod]
        public async Task IsMinusEqual()
        {
            IsEqual(-1m, await Minus(1, 2));
            IsEqual(2m, await Minus(4, 2));
            IsEqual(79m, await Minus(101, 22));
            IsEqual(-2331m, await Minus(1252, 3583));
        }

        [TestMethod]
        public async Task IsMultEqual()
        {
            IsEqual(2m, await Mult(1, 2));
            IsEqual(8m, await Mult(4, 2));
            IsEqual(2222m, await Mult(101, 22));
            IsEqual(4485916m, await Mult(1252, 3583));
        }

        [TestMethod]
        public async Task IsDivEqual()
        {
            IsEqual(0.5m, await Div(1, 2));
            IsEqual(2m, await Div(4, 2));
            IsEqual(4.590909090909091m, await Div(101, 22));
            IsEqual(0.3494278537538376m, await Div(1252, 3583));
        }

        [TestMethod]
        public async Task ExceptionHandling()
        {
            var response = await client.GetAsync("http://localhost:5000/calc?v1=1");
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            response = await client.GetAsync("http://localhost:5000/calc?v1=1&v2=2&op=qwe");
            Assert.AreEqual((HttpStatusCode) 450, response.StatusCode);
            Assert.AreEqual($"\"{FSLibraryHW5.ParserHW5.notOperation}\"",
                await response.Content.ReadAsStringAsync());

            response = await client.GetAsync("http://localhost:5000/calc?v1=1&v2=0&op=div");
            Assert.AreEqual($"\"{FSLibraryHW5.CalculatorHW5.devByZero}\"",
                await response.Content.ReadAsStringAsync());
        }
    }
}