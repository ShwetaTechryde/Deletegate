using System;


namespace DelegateInsideClassExample
{
    class InsuranceManager
    {
        // 🔸 Step 1: Declare delegate inside class
        public delegate void NotifyDelegate(string message);

        // 🔸 Step 2: Methods matching delegate signature
        public void SendEmail(string message)
        {
            Console.WriteLine("Email Sent: " + message);
        }

        public void SendSMS(string message)
        {
            Console.WriteLine("SMS Sent: " + message);
        }

        // 🔸 Step 3: Method to trigger notification using delegate
        public void NotifyCustomer(NotifyDelegate notifyMethod)
        {
            // Imagine policy created successfully
            notifyMethod("Your insurance policy is now active!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            InsuranceManager manager = new InsuranceManager();

            // 🔸 Step 4: Create delegate instance & call
            InsuranceManager.NotifyDelegate emailDelegate = manager.SendEmail;
            InsuranceManager.NotifyDelegate smsDelegate = manager.SendSMS;

            // 🔸 Step 5: Pass delegate to NotifyCustomer method
            manager.NotifyCustomer(emailDelegate);  // Output: Email Sent: ...
            manager.NotifyCustomer(smsDelegate);    // Output: SMS Sent: ...
        }
    }
}
    