
using System;

namespace CreditDecisionLib
{
    public class CreditDecision
    {
        public bool Decision { get; set; }
        public int InterestRatePercent { get; set; }

        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                CreditDecision d = (CreditDecision)obj;
                return (Decision == d.Decision) && (InterestRatePercent == d.InterestRatePercent);
            }
        }
    }
}
