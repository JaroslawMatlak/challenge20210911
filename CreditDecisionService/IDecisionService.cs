using System.ServiceModel;
using CreditDecisionLib;

namespace CreditDecisionService
{
    [ServiceContract]
    public interface IDecisionService
    {
        [OperationContract]
        CreditDecision GetDecision(DecisionParameters parameters);
    }
    //[DataContract]
    //public class DecisionParameters
    //{
    //    [DataMember]
    //    public int RequestedCredit { get; set; }
    //    [DataMember]
    //    public int PaymentInMonths { get; set; }
    //    [DataMember]
    //    public int ExistingDebt { get; set; }
    //}
}
