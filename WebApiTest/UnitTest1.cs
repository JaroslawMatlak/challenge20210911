using System;
using System.Net.Http;
using CreditDecisionLib;
using CreditDecisionWebApi.Controllers;
using NUnit.Framework;

namespace WebApiTest
{
    //TODO: More controller tests
    public class CreditDecisionControllerTest
    {
        [Test]
        public void GetMethodFromCreditDecisionController_ReturnsCreditDecisionType()
        {
            var controller = new CreditDecisionController();
            var result = controller.Get(0, 0, 0);
            Type expectedType = typeof(CreditDecision);

            Assert.IsInstanceOf(expectedType, result);
        }
    }
}