using System;
using System.Collections.Generic;
using System.Linq;

namespace InsuranceDashboard
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Insurance Dashboard ===\n");

            // Initialize services
            var policyService = new PolicyService();
            var notificationService = new NotificationService();

            // 1. View all policies
            Console.WriteLine("All Policies:");
            List<InsurancePolicy> allPolicies = policyService.GetAllPolicies();
            foreach (var p in allPolicies)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();

            // 2. Filter active policies (using Predicate<InsurancePolicy>)
            // Define a predicate for active policies
            Predicate<InsurancePolicy> isActive = policy => policy.IsActive;
            List<InsurancePolicy> activePolicies = policyService.GetActivePolicies(isActive);
            Console.WriteLine("Active Policies (filtered with Predicate):");
            foreach (var p in activePolicies)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine();

            // 3. Calculate premium (using Func<InsurancePolicy, double>)
            // Func represents a method that returns a value:contentReference[oaicite:11]{index=11}
            Func<InsurancePolicy, double> calculatePremium = policy => policy.Premium * 1.10; // e.g., add 10% tax
            Console.WriteLine("Calculated Premiums (using Func):");
            foreach (var p in allPolicies)
            {
                double newPremium = calculatePremium(p);
                Console.WriteLine($"Policy {p.Id}: Original = {p.Premium:C}, After 10% = {newPremium:C}");
            }
            Console.WriteLine();

            // 4. Notify via Email/SMS (using Action<InsurancePolicy>)
            Console.WriteLine("Notifications (using Action delegates):");
            // Use the EmailNotifier and SMSNotifier actions
            InsurancePolicy samplePolicy = allPolicies.First();
            notificationService.EmailNotifier(samplePolicy);
            notificationService.SMSNotifier(samplePolicy);
            // Combine actions to multicast notifications
            Action<InsurancePolicy> notifyAll = notificationService.EmailNotifier + notificationService.SMSNotifier;
            Console.WriteLine("Combined Notification (both Email and SMS):");
            notifyAll(samplePolicy);
            Console.WriteLine();

            // 5. Approve policies (using delegate for custom logic)
            Console.WriteLine("Policy Approvals (using custom delegate logic):");
            // Define custom approval logic: approve if Premium < 1500 AND policy is active
            ApprovalDelegate approvalLogic = policy => policy.IsActive && policy.Premium < 1500;
            policyService.ApprovePolicies(allPolicies, approvalLogic);
        }
    }
}
