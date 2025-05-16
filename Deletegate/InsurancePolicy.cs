using System;

namespace InsuranceDashboard
{
    // Model class for an insurance policy
    public class InsurancePolicy
    {
        public int Id { get; set; }
        public string PolicyName { get; set; }
        public bool IsActive { get; set; }
        public double Premium { get; set; }

        public InsurancePolicy(int id, string name, bool isActive, double premium)
        {
            Id = id;
            PolicyName = name;
            IsActive = isActive;
            Premium = premium;
        }

        // Override ToString() to print policy details
        public override string ToString()
        {
            return $"ID: {Id}, Name: {PolicyName}, Active: {IsActive}, Premium: {Premium:C}";
        }
    }
}
