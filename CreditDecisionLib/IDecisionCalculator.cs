namespace CreditDecisionLib
{
    public interface IDecisionCalculator
    {
        CreditDecision CalculateDecision(DecisionParameters parameters);
    }
}