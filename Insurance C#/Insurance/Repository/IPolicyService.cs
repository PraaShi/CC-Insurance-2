using Insurance.Model;

namespace Insurance.Repository
{
    internal interface IPolicyService
    {
        bool CreatePolicy(object policyName);
        bool DeletePolicy(int policyID);
        List<Policy> GetAllPolicy();
        Policy GetPolicy(int policyId);
        bool UpdatePolicy(string? policyName, int policyId);
    }
}
