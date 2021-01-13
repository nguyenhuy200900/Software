using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TestAppTownHall
{
    class CustomersList
    {
        private List<SimulatingCustomer> customers;
        //private List<SimulatingCustomer> customersInTRQueue;
        public List<CircularPanel> circularPanels;
        public CustomersList()
        {
            customers = new List<SimulatingCustomer>();
            circularPanels = new List<CircularPanel>();
        }

        public void PaintAllCustomers(Graphics gr)
        {
            foreach (SimulatingCustomer sm in customers)
            {
                sm.PaintCustomer(gr);
            }
        }

        public void MoveAllCustomers()
        {
            foreach (SimulatingCustomer sm in this.customers)
            {
                sm.MovePanel();
            }
        }

        public void AddCustomer(SimulatingCustomer cus)
        {
            this.customers.Add(cus);
        }

        public List<SimulatingCustomer> GetAllCustomers()
        {
            return this.customers;
        }

       
        //get list of people coming to the tax and room rental counter
        public List<SimulatingCustomer> GetCustomersInTRQueue()
        {
            List<SimulatingCustomer> returnList = new List<SimulatingCustomer>();

            foreach (SimulatingCustomer c in this.customers)
            {
                if(c.Dir==CustomerDirection.STEADY && c.Type==CustomerType.TAX && c.Type == CustomerType.ROOMRENTAL)
                {
                    returnList.Add(c);
                }
            }
            return returnList;
        }

        //get list of people coming to the driver license
        public List<SimulatingCustomer> GetCustomersInDriverLicenseQueue()
        {
            List<SimulatingCustomer> returnList = new List<SimulatingCustomer>();

            foreach (SimulatingCustomer c in this.customers)
            {
                if (c.Type == CustomerType.DRIVERLICENCSE)
                {
                    returnList.Add(c);
                }
            }
            return returnList;
        }


        public List<SimulatingCustomer> GetCustomersPerType(CustomerType t1, CustomerType t2)
        {
            List<SimulatingCustomer> cusWithType = new List<SimulatingCustomer>();
            foreach(SimulatingCustomer c in this.customers)
            {
                if (c.Type == t1 ||c.Type==t2 )
                {
                    cusWithType.Add(c);
                }
            }
            return cusWithType;
        }

        private int index = 0;


        //public void SetCustomersInQueue(int steadyPoint)
        //{
        //     for(int i=0; i < this.customers.Count; i++)
        //     {
        //         if (i==0)
        //         {
        //             if(customers[0].CPanel.Location.Y == steadyPoint)
        //             customers[0].Dir = CustomerDirection.STEADY;

        //         }
        //         else
        //         {
        //             if (customers[i].CPanel.Location.Y == customers[i - 1].CPanel.Location.Y + 40)
        //             {
        //                 customers[i].Dir = CustomerDirection.STEADY;
        //             }
        //         }
        //     }
        // }

        //processing appointment
        public void ProcessingAppointment(Counter selectedCounter, CustomerType t1, CustomerType t2)
        {
            foreach (SimulatingCustomer cus in this.GetCustomersPerType(t1, t2))
            {
                SimulatingCustomer nextCus = customers[customers.IndexOf(cus) + 1];
                int currentPosition = cus.Y;

                foreach (CircularPanel c in circularPanels)
                {
                    if (cus.Dir == CustomerDirection.STEADY && selectedCounter.IsOccupied == false)
                    {
                        cus.Dir = CustomerDirection.UP;
                        selectedCounter.IsOccupied = true;
                    }
                    else if (cus.Dir == CustomerDirection.UP && c.Location.Y == selectedCounter.Y + 30)
                    {
                        cus.Dir = CustomerDirection.STEADY;
                        nextCus.Dir = CustomerDirection.UP;

                        if (nextCus.Y == currentPosition)
                        {
                            nextCus.Dir = CustomerDirection.STEADY;
                        }
                    }
                }
            }
        }

        //2 visitors have a distance between them
        public void SocialDistancingForTRQueue()
        {
            for(int i =0; i < this.GetCustomersInTRQueue().Count-1; i++)
            {
                this.GetCustomersInTRQueue()[i].Y = this.GetCustomersInTRQueue()[i + 1].Y + 65;
            }
        }

        public void SocialDistancingForDriverLicenseQueue()
        {
            for (int i = 0; i < this.GetCustomersInDriverLicenseQueue().Count - 1; i++)
            {
                this.GetCustomersInDriverLicenseQueue()[i].Y = this.GetCustomersInDriverLicenseQueue()[i + 1].Y + 65;
            }
        }

     

        
    }
}
