using System;
using System.Collections.Generic;

namespace InsuranceDashboard
{
    // Custom delegate to encapsulate policy approval logic
    public delegate bool ApprovalDelegate(InsurancePolicy policy);

    public class PolicyService
    {
        private List<InsurancePolicy> policies;

        // Initialize with some sample policies
        public PolicyService()
        {
            policies = new List<InsurancePolicy>
            {
                new InsurancePolicy(1, "Life Insurance",  true,  1200.00),
                new InsurancePolicy(2, "Car Insurance",   false,  800.00),
                new InsurancePolicy(3, "Home Insurance",  true,  1500.00),
                new InsurancePolicy(4, "Health Insurance",true,  2000.00)
            };
        }

        // Get all policies
        public List<InsurancePolicy> GetAllPolicies()
        {
            return policies;
        }

        // Filter policies using a Predicate<InsurancePolicy>
        // Predicate<T> represents a method that returns true/false:contentReference[oaicite:6]{index=6}.
        public List<InsurancePolicy> GetActivePolicies(Predicate<InsurancePolicy> filter)
        {
            return policies.FindAll(filter);
        }

        // Approve policies using a custom ApprovalDelegate for logic injection
        public void ApprovePolicies(IEnumerable<InsurancePolicy> list, ApprovalDelegate approver)
        {
            foreach (var policy in list)
            {
                bool approved = approver(policy);
                string status = approved ? "APPROVED" : "DENIED";
                Console.WriteLine($"Policy {policy.Id} ({policy.PolicyName}): {status}");
            }
        }
    }
}
