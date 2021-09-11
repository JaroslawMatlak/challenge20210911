using System;
using CreditDecisionLib;

namespace CreditDecisionService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class DecisionService : IDecisionService
    {
        public CreditDecision GetDecision(DecisionParameters parameters)
        {
            var calculator = new DecisionCalculator();
            var result = calculator.CalculateDecision(parameters);
            return result;
        }
        public CreditDecision GetDecisionAsync(DecisionParameters parameters)
        {
            var calculator = new DecisionCalculator();
            var result = calculator.CalculateDecision(parameters);
            return result;
        }
    }
}
