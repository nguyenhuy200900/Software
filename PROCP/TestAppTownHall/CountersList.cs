using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TestAppTownHall
{
    class CountersList
    {
        private List<Counter> counters;

        public CountersList()
        {
            this.counters = new List<Counter>();
        }

        public void PaintAllCounters(Graphics gr)
        {
            foreach (Counter c in counters)
            {
                c.PaintCounter(gr);
            }
        }

        public List<Counter> GetAllCounters()
        {
            return this.counters;
        }

        public void AddCounter(Counter c)
        {
            this.counters.Add(c);
        }

        public Counter GetCounter(int id)
        {
            foreach(Counter c in counters)
            {
                if (c.Id == id)
                {
                    return c;
                }
            }
            return null;
        }

        public bool OpenCounter(int id)
        {
            if (this.GetCounter(id) != null)
            {
                Counter selected = this.GetCounter(id);
                if (selected.IsOpened == false)
                {
                    selected.IsOpened = true;
                    return true;
                }
                else return false;
            }
            return false;
        }

        public bool CloseCounter(int id)
        {
            if (this.GetCounter(id) != null)
            {
                if (this.GetCounter(id).IsOpened == true)
                {
                    this.GetCounter(id).IsOpened = false;
                    return true;
                }
            }
            return false;
        }


        public void SetProcessingTime(double processingTime, CounterType counterType)
        {
            foreach(Counter c in this.GetAllCounters())
            {
                if (c != null)
                {
                    if (c.CounterType == counterType)
                    {
                        c.ProcessingTime = processingTime;
                    }
                }
               
            }

        }

        public List<Counter> GetCounterByType(CounterType type)
        {
            List<Counter> temp = new List<Counter>();

            foreach(Counter c in counters)
            {
                if (c.CounterType == type)
                {
                    temp.Add(c);
                }
            }
            return temp;
        }
      
        public int GetSmallestCounterIdInAType(CounterType type)
        {
            List<Counter> temp = this.GetCounterByType(type);
            int min = 9999;
            for(int i=0; i < temp.Count; i++)
            {
                if (temp[i].Id < min)
                {
                    min = temp[i].Id;
                }
            }
            return min;
        }
        

        //distance between 2 people

    }
}
