using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppTownHall
{
    class Queue
    {
        private CustomersList customersList;
        private int nrOfPeopleInTheQueue=5;

        public Queue()
        {
            this.customersList = new CustomersList();
        }

        public bool CanAddGuest()
        {
            return customersList.GetCustomersInTRQueue().Count <= nrOfPeopleInTheQueue;
        }

        public SimulatingCustomer GetFirstInQueue()
        {
            if(customersList.GetCustomersInTRQueue().Count==0)
            {
                return null;
            }
            else
            {
                
                SimulatingCustomer customer = customersList.GetCustomersInTRQueue()[0];
                customersList.GetCustomersInTRQueue().RemoveAt(0);
                return customer;
            }

        }

        private void RelocateCustomers()
        {
            //for(int i=0; i < customersList.GetCustomersInTRQueue().Count; i++)
            //{
            //    customersList.GetCustomersInTRQueue()[i].
            //}
        }



    }
}
