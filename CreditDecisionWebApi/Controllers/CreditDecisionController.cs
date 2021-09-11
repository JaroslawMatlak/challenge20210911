using CreditDecisionLib;
using Microsoft.AspNetCore.Mvc;

namespace CreditDecisionWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreditDecisionController : Controller
    {
        //.../CreditDecision?requested=10000&months=5&existing=90000
        [HttpGet]
        public CreditDecision Get(int requested, int months, int existing)
        {
            var parameters = new DecisionParameters()
                {ExistingDebt = existing, PaymentInMonths = months, RequestedCredit = requested};
            var calculator = new DecisionCalculator();
            var result = calculator.CalculateDecision(parameters);
            return result;
        }
    }
}