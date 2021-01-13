using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TestAppTownHall
{
    public enum CustomerType
    {
        TAX,
        DRIVERLICENCSE,
        PASSPORTANDID, ROOMRENTAL
    }

    public enum CustomerDirection
    {
        UP, DOWN, LEFT, RIGHT, STEADY
    }
     class SimulatingCustomer
    {
        private int x, y, dx, dy, diameter;
        private CustomerType type;
        private CountersList counters = new CountersList();
        private CustomerDirection dir;

        private CircularPanel firstPosition2 = new CircularPanel();

        private List<CircularPanel> fixedPositions = new List<CircularPanel>();

       
       

        public bool FinishHandlingAppoitment { get; set; }
        public bool StandingInTheQueue { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public int GetX()
        {
            return x;
        }
        public void SetX(int newX)
        {
            this.X = newX;
        }
        public int GetY()
        {
            return y;
        }

        public void SetY(int newY)
        {
            this.Y = newY;
        }
        public CustomerType Type
        {
            get { return type; }
        }

        public CircularPanel CPanel
        {
            get;set;
        }

        public CustomerDirection Dir
        {
            get;set;
        }


        public SimulatingCustomer(int x, int y, int dx, int dy, int diameter, CustomerType type, CircularPanel p, CustomerDirection dir)
        {
            this.x = x;
            this.y = y;
            this.dx = dx;
            this.dy = dy;
            this.diameter = diameter;
            this.type = type;
            this.CPanel = p;
            this.dir = dir;
            this.FinishHandlingAppoitment = false;
            this.StandingInTheQueue = false;
        }

        public void Move()
        {
            this.x += this.dx;
            this.y -= this.dy;
            this.dx += 1;
        }

        public void MovePanel()
        {
            if (this.dir == CustomerDirection.LEFT)
            {
                CPanel.Location = new Point(CPanel.Location.X - 1, CPanel.Location.Y);
            }
            else if (this.dir == CustomerDirection.RIGHT)
            {
                CPanel.Location = new Point(CPanel.Location.X + 1, CPanel.Location.Y);
            }
            else if (this.dir == CustomerDirection.UP)
            {
                CPanel.Location = new Point(CPanel.Location.X, CPanel.Location.Y - 1);
            }
            else if (this.dir == CustomerDirection.DOWN)
            {
                CPanel.Location = new Point(CPanel.Location.X, CPanel.Location.Y + 1);

            }
            else
            {
                CPanel.Location = new Point(CPanel.Location.X, CPanel.Location.Y);
            }
            //DirectCustomer(selectedCounter);
        }


        //first customer in queue
        public void DirectCustomer(Counter selectedCounter, int steadyP1, int steadyP2)
        {

            if (this.FinishHandlingAppoitment == false && CPanel.Location.X >= 359
                && CPanel.Location.X <= selectedCounter.X + 48 && this.StandingInTheQueue == false)
            {
                //CPanel.Location = new Point(CPanel.Location.X + 1, CPanel.Location.Y);
                this.dir = CustomerDirection.RIGHT;
            }
            else if (this.FinishHandlingAppoitment == false &&
               CPanel.Location.Y == selectedCounter.Y + 65 + Math.Abs(steadyP2 - steadyP1) &&
                 this.StandingInTheQueue == false)
            {
               
                    this.dir = CustomerDirection.STEADY;
                    this.StandingInTheQueue = true;              
            }

             else if (this.FinishHandlingAppoitment == false 
                && CPanel.Location.X >selectedCounter.X + 48 && this.dir!=CustomerDirection.STEADY
                && StandingInTheQueue == false && CPanel.Location.Y >= selectedCounter.Y + 65 + Math.Abs(steadyP2 - steadyP1))
            {
                this.dir = CustomerDirection.UP;   
            }
            
            


        }

        //method: make the customer move into the counter
        public void GoIntoTheCounter(Counter selectedCounter, int steadyP1, int steadyP2)
        {
            //if (this.standingInTheQueue == true && this.FinishHandlingAppoitment == false && selectedCounter.IsOccupied == false 
            //    && CPanel.Location.Y < selectedCounter.Y + 65)
            //{
            //    this.dir = CustomerDirection.UP;
            //}
            //if (this.FinishHandlingAppoitment == false && selectedCounter.IsOccupied == true
            //    && CPanel.Location.Y < selectedCounter.Y + 65 + steadyP)
            //{
            //    this.dir = CustomerDirection.STEADY;

            //}
            if (CPanel.Location.Y == selectedCounter.Y + 30 && CPanel.Location.X != selectedCounter.X - 20)
            {
                //this.dir = CustomerDirection.STEADY;
                selectedCounter.IsOccupied = true;
                this.dir = CustomerDirection.LEFT;
                this.FinishHandlingAppoitment = true;   
                this.StandingInTheQueue = false;

            }
            if (this.FinishHandlingAppoitment == true && CPanel.Location.Y == selectedCounter.Y + 30
                && CPanel.Location.X == selectedCounter.X - 20)
            {
                selectedCounter.IsOccupied = false;
                this.dir = CustomerDirection.DOWN;
            }
            if (this.StandingInTheQueue == true && !selectedCounter.IsOccupied
                && CPanel.Location.Y < selectedCounter.Y + 100 + Math.Abs(steadyP2-steadyP1) && !FinishHandlingAppoitment)
            {
                    this.dir = CustomerDirection.UP;
                    selectedCounter.IsOccupied = true;
                //if (selectedCounter.IsOccupied)
                //{
                //    if (CPanel.Location.Y < selectedCounter.Y + 100 + Math.Abs(steadyP2 - steadyP1))
                //        this.dir = CustomerDirection.UP;
                //    else if (CPanel.Location.Y == selectedCounter.Y + 100 + Math.Abs(steadyP2 - steadyP1))
                //        this.dir = CustomerDirection.STEADY;
                //}


            }


            if (this.FinishHandlingAppoitment && CPanel.Location.Y == selectedCounter.Y + 380
                && CPanel.Location.X == selectedCounter.X - 20)
            {
                this.dir = CustomerDirection.LEFT;

            }
        }

        public void SetSteadyPoint(int steadyP)
        {
            if (CPanel.Location.Y == steadyP)
            {
                this.dir = CustomerDirection.STEADY;
            }

        }

        public void PaintCustomer(Graphics gr)
        {
           // gr.FillRectangle(new SolidBrush(Color.FromArgb(0, Color.Black)),4F);
            
            Point[] points = new Point[4];

            points[0] = new Point(0, 0);
            points[1] = new Point(0, x-diameter/2);
            points[2] = new Point(y-diameter/2, x-diameter/2);
            points[3] = new Point(y-diameter/2, 0);

            Brush brush;

            if (this.type == CustomerType.TAX)
            {
               brush = new SolidBrush(Color.BlueViolet);
            }
            else if (this.type == CustomerType.DRIVERLICENCSE)
            {
                brush = new SolidBrush(Color.LightPink);
            }
            else if (this.type == CustomerType.PASSPORTANDID)
            {
                brush = new SolidBrush(Color.LightGray);
            }
            else
            {
                brush = new SolidBrush(Color.Maroon);
            }
            gr.FillPolygon(brush, points);
        }

    public List<CircularPanel> GetFixedPositions(Counter selectedCounter)
    {


            //------------------------------------------------//
            firstPosition2.Location = new Point(selectedCounter.X + 48, selectedCounter.Y + 65);
            this.fixedPositions.Add(firstPosition2);
            CircularPanel nwPanel = new CircularPanel();
            nwPanel.BackColor = Color.GreenYellow;

            for (int i = 1; i < 5; i++)
            {
                nwPanel.Location = new Point(fixedPositions[i - 1].Location.X, fixedPositions[i - 1].Location.Y + 30);
                fixedPositions.Add(nwPanel);
            }
            return fixedPositions;
        }


}
}
