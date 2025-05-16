using System;

namespace InsuranceDashboard
{
    public class NotificationService
    {
        // Action to simulate sending an Email for a policy
        public Action<InsurancePolicy> EmailNotifier { get; set; }

        // Action to simulate sending an SMS for a policy
        public Action<InsurancePolicy> SMSNotifier { get; set; }

        public NotificationService()
        {
            // Define actions using lambda expressions
            EmailNotifier = policy =>
                Console.WriteLine($"[Email] Notification sent for policy '{policy.PolicyName}' (ID {policy.Id}).");
            SMSNotifier = policy =>
                Console.WriteLine($"[SMS] Notification sent for policy '{policy.PolicyName}' (ID {policy.Id}).");
        }
    }
}
