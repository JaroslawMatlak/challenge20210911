namespace CreditDecisionLib
{
    public class DecisionCalculator : IDecisionCalculator
    {
        public CreditDecision CalculateDecision(DecisionParameters parameters)
        {
            if (parameters is null)
                return new CreditDecision();

            var result = new CreditDecision()
            {
                Decision = Decide(parameters.RequestedCredit),
                InterestRatePercent = CalculateRateOfInterest(parameters.RequestedCredit, parameters.ExistingDebt)
            };

            return result;
        }

        //Note: As the AC does not specify the decision for value equal 2000, I've assumed that this decision is 'true'
        //In case this assumption was wrong, please report BUG and provide more detailed instructions. 
        private bool Decide(int requestedCredit)
        {
            return requestedCredit >= 2000 && requestedCredit <= 69000;
        }

        //Note: As the AC does not specify, what to do with values in ranges 39K-40K and 59K-60K,
        //I've made assumption that these lie in the direct lower defined ranges.
        //In case this assumption was wrong, please report BUG and provide more detailed instructions. 
        private int CalculateRateOfInterest(int requestedCredit, int existingCredit)
        {
            //I'm not sure, if this is how 'future debt' is being understood by business
            //In case my understanding is wrong, please provide more detailed instructions
            var futureDebt = requestedCredit + existingCredit;
            var result = 0;
            //TODO: These ifs looks awful - do something with this!
            if (futureDebt < 20000)
            {
                result = 3;
            }
            else if (futureDebt < 40000)
            {
                result = 4;
            }
            else if (futureDebt < 60000)
            {
                result = 5;
            }
            else if (futureDebt >= 60000)
            {
                result = 6;
            }

            return result;
        }
    }
}
