using Insurance.Model;
using Insurance.Repository;

namespace Insurance.App
{
    internal class Main
    {
        IPolicyService policyService = new PolicyService();

        internal void Run()
        {
            bool loop = true;
            while(loop)
            {
                
                //Object Creation For Repositories
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("WELCOME ..! Choose From The Options");
                Console.WriteLine("1 . Create Policy");
                Console.WriteLine("2 . Get Policy");
                Console.WriteLine("3 . Get All Policy");
                Console.WriteLine("4 . UpdatePolicy");
                Console.WriteLine("5 . DeletePolicy");
                Console.WriteLine("6 . Exit");

                //Getting Input Option From The User

                Console.WriteLine("Enter Your Choice :: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CreatePolicy(policyService);
                        break;
                    case 2:
                        GetPolicy(policyService);
                        break;
                    case 3:
                        GetAllPolicy(policyService);
                        break;
                    case 4:
                        UpdatePolicy(policyService);
                        break;
                    case 5:
                        DeletePolicy(policyService);
                        break;
                    case 6:
                        loop = false;
                        break;
                    default:
                        break;
                }
            }
        }

        //1.Create Policy
        private void CreatePolicy(IPolicyService policyService)
        {
            Console.WriteLine("Enter the Policy Name to Add ::");
            string policyName = Console.ReadLine();
            bool policy = policyService.CreatePolicy(policyName);
            if(policy == true)
            {
                Console.WriteLine("Added Successfully");
            }
            else
            {
                Console.WriteLine("Policy Creation Failed");
            }
        }

        //2.Get Policy
        private void GetPolicy(IPolicyService policyService)
        {
            Console.WriteLine("Enter the PolicyId :: ");
            int policyId = int.Parse(Console.ReadLine());
            Policy policy = policyService.GetPolicy(policyId);
            if(policy != null)
            {
                Console.WriteLine($"The PolicyName Correspoding to the policy ID {policyId} is {policy.policyName}");
            }
        }

        //Get All Policy
        private void GetAllPolicy(IPolicyService policyService)
        {
            List<Policy> policy = policyService.GetAllPolicy();
            foreach( Policy policyItem in policy )
            {
                Console.WriteLine($"Policy ID = {policyItem.policyId}  \t Policy Name {policyItem.policyName}");
            }
        }

        //Update policy
        private void UpdatePolicy(IPolicyService policyService)
        {
            Console.WriteLine("Enter the policyId :: ");
            int policyId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the PolicyName :: ");
            string policyName = Console.ReadLine();
            bool policy = policyService.UpdatePolicy(policyName,policyId);
            if (policy == true)
            {
                Console.WriteLine("Updated Successfully");
            }
            else
            {
                Console.WriteLine("Updation Failed");
            }
        }

        //Delete policy
        private void DeletePolicy(IPolicyService policyService)
        {
            Console.WriteLine("Enter the Policy ID ::");
            int policyID = int.Parse(Console.ReadLine());
            bool policy = policyService.DeletePolicy(policyID);
            if (policy == true)
            {
                Console.WriteLine("Deleted Successfully");
            }
            else
            {
                Console.WriteLine("Policy Deletion Failed");
            }
        }
    }
}
