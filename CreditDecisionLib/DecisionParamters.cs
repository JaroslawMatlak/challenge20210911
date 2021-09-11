namespace CreditDecisionLib
{
    public class DecisionParameters
    {
        public int RequestedCredit { get; set; }
        public int PaymentInMonths { get; set; }
        public int ExistingDebt { get; set; }
    }
}