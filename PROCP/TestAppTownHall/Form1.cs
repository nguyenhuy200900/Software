using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace TestAppTownHall
{
    
    public partial class Form1 : Form
    {
        private CustomersList customers;
        private List<CircularPanel> circularPanels;
        private List<Panel> panels;
        private CountersList counters;
        private List<Label> countersLabels;
        private int waitingTime=0;
        private static int id = 0;
        
        public Form1()
        {
            InitializeComponent();
            //this.timerBlinking.Enabled = true;
            //this.timerStart.Start();
            //If this one triggered error, add pictures to .../bin/Debug/
            this.pbxDoor.Image = Image.FromFile("Doors.jpg");
            this.pbxChairs1.Image = Image.FromFile("chairs.jpg");
            this.pbxChairs2.Image = Image.FromFile("chairs.jpg");
            this.pbxChairs3.Image = Image.FromFile("chairs.jpg");
            this.pbxChairs4.Image = Image.FromFile("chairs.jpg");
            this.pbxChairs5.Image = Image.FromFile("chairs.jpg");
            this.pbxChairs6.Image = Image.FromFile("chairs.jpg");
            this.pbxChairs7.Image = Image.FromFile("chairs.jpg");
            this.pbxChairs8.Image = Image.FromFile("chairs.jpg");
            this.pbxChairs9.Image = Image.FromFile("chairs.jpg");
            this.pbxChairs10.Image = Image.FromFile("chairs.jpg");
            this.pbxChairs11.Image = Image.FromFile("chairs.jpg");
            this.pbxChairs12.Image = Image.FromFile("chairs.jpg");
            this.pbxAppointmentRoom.Image = Image.FromFile("appointmentRoom3.png");
            this.pbxAppointmentRoom.BackColor = Color.Transparent;

            //
            this.WindowState = FormWindowState.Maximized;
            this.comboBox1.Items.Add("TAX");
            this.comboBox1.Items.Add("DRIVERLICENCSE");
            this.comboBox1.Items.Add("PASSPORTANDID");
            this.comboBox1.Items.Add("ROOMRENTAL");

            this.cbxCountersTypes.Items.Add(CounterType.GENERAL);
            this.cbxCountersTypes.Items.Add(CounterType.TAXandROOMRENTAL);
            this.cbxCountersTypes.Items.Add(CounterType.DRIVERLICENSEandPASSPORTID);
            this.cbxCountersTypes.Items.Add(CounterType.DRIVERLICENSEandPASSPORTID);

            this.quantityBox.Maximum = 5;

            customers = new CustomersList();
            circularPanels = new List<CircularPanel>();
            panels = new List<Panel>();
            counters = new CountersList();
            countersLabels = new List<Label>();
            //this.timerStart.Interval = 16;
            //this.circularPanel1.Visible = false;

            this.numericQuantityTax.Maximum = 5;
            this.numericQuantityDL.Maximum = 5;
            this.numericQuantityPAndID.Maximum = 5;
            this.numericQuantityRoom.Maximum = 5;
            this.numericQuantityAll.Maximum = 5;

            this.btnSpawnAllTypes.Click += new EventHandler(this.btnSpawnTax_Click); this.Invalidate();
            this.btnSpawnAllTypes.Click += new EventHandler(this.btnSpawnDriverLicense_Click); this.Invalidate();
            this.btnSpawnAllTypes.Click += new EventHandler(this.btnSpawnPassID_Click); this.Invalidate();
            this.btnSpawnAllTypes.Click += new EventHandler(this.btnSpawnRental_Click); this.Invalidate();

          

            this.AddDefault();
            //taxCus = new List<SimulatingCustomer>();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //this.customers.PaintAllCustomers(e.Graphics);
            //this.counters.PaintAllCounters(e.Graphics);
            
        }

        private void button1_Click(object sender, EventArgs e) //testButton
        {
            //CustomerType cType;
            //SimulatingCustomer nwCus;
            //Panel nwPanel = new Panel();
            //nwPanel.BackColor = Color.BlueViolet;
            //nwPanel.Size = new Size(21, 21);
            //this.Controls.Add(nwPanel);
            //this.buttons.Add(nwPanel);
            

            //if (this.comboBox1.SelectedIndex == 0) { cType = CustomerType.TAX; }
            //else if (this.comboBox1.SelectedIndex == 1) { cType = CustomerType.DRIVERLICENCSE; }
            //else if (this.comboBox1.SelectedIndex == 2) { cType = CustomerType.PASSPORTANDID; }
            //else { cType = CustomerType.ROOMRENTAL; }

            //nwCus = new SimulatingCustomer(800, 300, 20, -30, 50, cType);
            //this.customers.AddCustomer(nwCus);
            //this.circularPanel1.Paint += new PaintEventHandler(circularPanel1_Paint);
            //this.circularPanel1.Refresh();
            //this.circularPanel1.Visible = true;
            //this.timerStart.Start();
            //this.Invalidate();
        }


        private void listBox2_Paint(object sender, PaintEventArgs e)
        {
            this.customers.PaintAllCustomers(e.Graphics);
           
        }

        private void panel1_PaddingChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //this.customers.PaintAllCustomers(e.Graphics);
        }

        private void circularPanel1_Paint(object sender, PaintEventArgs e)
        {
            //this.customers.PaintAllCustomers(e.Graphics);
        }

        private void btnSpawnTax_Click(object sender, EventArgs e) //real one
        {
            //this.timerStart.Stop();
          
            
            Random ran = new Random();
           
            if (this.numericQuantityTax.Value != 0)
            {
                
                for(int i=0; i < this.numericQuantityTax.Value; i++)
                {
                    int x = ran.Next(359, 400);
                    int y = ran.Next(352, 412);
                    SimulatingCustomer nwCus;
                    CircularPanel nwPan = new CircularPanel();
                    
                    nwCus = new SimulatingCustomer(800, 300, 20, -30, 50, CustomerType.TAX,nwPan,CustomerDirection.RIGHT);
                    this.SetBackColor(nwCus, nwPan);
                    nwPan.Location = new Point(x, y);

                    this.circularPanels.Add(nwPan);
                   
                   
                    this.customers.AddCustomer(nwCus);
                    this.Controls.Add(nwPan);
                    nwPan.BringToFront();
                    //this.circularPanel1.Paint += new PaintEventHandler(circularPanel1_Paint);
                    //this.circularPanel1.Refresh();
                    //this.circularPanel1.Visible = true;
                   
                }

            }
            //foreach(CircularPanel p in circularPanels)
            //{
            //    this.Controls.Add(p);
            //    p.BringToFront();
            //}

            // MessageBox.Show(customers.GetAllCustomers().Count().ToString());

            //this.Moving();
            this.Invalidate();
            this.timerStart.Start();
        }

        private void timerStart_Tick(object sender, EventArgs e)
        {
            this.Moving();
            waitingTime++;
           
            //this.timerStart.Stop();
            //this.customers.MoveAllCustomers();

        }

        private void btnSpawnDriverLicense_Click(object sender, EventArgs e)
        {
            
            Random ran = new Random();

            if (this.numericQuantityDL.Value != 0)
            {

                for (int i = 0; i < this.numericQuantityDL.Value; i++)
                {
                    int x = ran.Next(359, 400);
                    int y = ran.Next(352, 412);
                    SimulatingCustomer nwCus;
                    CircularPanel nwPan = new CircularPanel();
                    nwCus = new SimulatingCustomer(800, 300, 20, -30, 50, CustomerType.DRIVERLICENCSE,nwPan,CustomerDirection.RIGHT);
                    this.SetBackColor(nwCus, nwPan);
                    nwPan.Location = new Point(x, y);

                    this.circularPanels.Add(nwPan);
                    this.Controls.Add(nwPan);
                    nwPan.BringToFront();

                    this.customers.AddCustomer(nwCus);
                    //this.circularPanel1.Paint += new PaintEventHandler(circularPanel1_Paint);
                    //this.circularPanel1.Refresh();
                    //this.circularPanel1.Visible = true;
                   
                }
            }
            //foreach (CircularPanel p in circularPanels)
            //{
            //    this.Controls.Add(p);
            //    p.BringToFront();
            //}
            //MessageBox.Show(customers.GetAllCustomers().Count().ToString());
            //this.Moving();
            this.Invalidate();
            this.timerStart.Start();
        }

        private void btnSpawnPassID_Click(object sender, EventArgs e)
        {
            

            Random ran = new Random();

            if (this.numericQuantityPAndID.Value != 0)
            {

                for (int i = 0; i < this.numericQuantityPAndID.Value; i++)
                {
                    int x = ran.Next(359, 400);
                    int y = ran.Next(352, 412);
                    SimulatingCustomer nwCus;
                    CircularPanel nwPan = new CircularPanel();
                   
                    nwCus = new SimulatingCustomer(800, 300, 20, -30, 50, CustomerType.PASSPORTANDID,nwPan,CustomerDirection.RIGHT);
                    this.SetBackColor(nwCus, nwPan);
                    nwPan.Location = new Point(x, y);

                    this.circularPanels.Add(nwPan);
                    this.Controls.Add(nwPan);
                    nwPan.BringToFront();

                    this.customers.AddCustomer(nwCus);
                    //this.circularPanel1.Paint += new PaintEventHandler(circularPanel1_Paint);
                    //this.circularPanel1.Refresh();
                    //this.circularPanel1.Visible = true;
                   
                }
            }
            //foreach (CircularPanel p in circularPanels)
            //{
            //    this.Controls.Add(p);
            //    p.BringToFront();
            //}
            // MessageBox.Show(customers.GetAllCustomers().Count().ToString());
            //this.Moving();
            this.Invalidate();
            this.timerStart.Start();
        }

        private void btnSpawnRental_Click(object sender, EventArgs e)
        {
            

            Random ran = new Random();

            if (this.numericQuantityRoom.Value != 0)
            {

                for (int i = 0; i < this.numericQuantityRoom.Value; i++)
                {
                    int x = ran.Next(359, 400);
                    int y = ran.Next(352, 412);
                    SimulatingCustomer nwCus;
                    CircularPanel nwPan = new CircularPanel();

                    nwCus = new SimulatingCustomer(800, 300, 20, -30, 50, CustomerType.ROOMRENTAL,nwPan,CustomerDirection.RIGHT);
                    this.SetBackColor(nwCus, nwPan);
                    nwPan.Location = new Point(x, y);

                    this.circularPanels.Add(nwPan);
                    this.Controls.Add(nwPan);
                    nwPan.BringToFront();

                    this.customers.AddCustomer(nwCus);
                    //this.circularPanel1.Paint += new PaintEventHandler(circularPanel1_Paint);
                    //this.circularPanel1.Refresh();
                    //this.circularPanel1.Visible = true;
                    
                }
            }
            //foreach (CircularPanel p in circularPanels)
            //{
            //    this.Controls.Add(p);
            //    p.BringToFront();
            //}
            //MessageBox.Show(customers.GetAllCustomers().Count().ToString());
            // this.Moving();
            this.Invalidate();
            this.timerStart.Start();
        }

        private void btnSpawnAllTypes_Click(object sender, EventArgs e)
        {
            this.timerStart.Start();

            
            Random ran = new Random();

            if (this.numericQuantityAll.Value != 0)
            {
                this.numericQuantityTax.Value = this.numericQuantityAll.Value;
                this.numericQuantityDL.Value = this.numericQuantityAll.Value;
                this.numericQuantityPAndID.Value = this.numericQuantityAll.Value;
                this.numericQuantityRoom.Value = this.numericQuantityAll.Value;
                
            }
            

           // this.Moving();
                //    for (int i = 0; i < this.numericQuantityAll.Value; i++)
                //    {
                //        int x = ran.Next(359, 400);
                //        int y = ran.Next(352, 412);
                //        SimulatingCustomer nwCus1, nwCus2,nwCus3,nwCus4;
                //        CircularPanel nwPan1, nwPan2, nwPan3, nwPan4;
                //        nwPan1 = new CircularPanel();
                //        nwPan2 = new CircularPanel();
                //        nwPan3 = new CircularPanel();
                //        nwPan4 = new CircularPanel();

                //        nwCus1 = new SimulatingCustomer(800, 300, 20, -30, 50, CustomerType.TAX);
                //        nwCus2 = new SimulatingCustomer(800, 300, 20, -30, 50, CustomerType.DRIVERLICENCSE);
                //        nwCus3 = new SimulatingCustomer(800, 300, 20, -30, 50, CustomerType.PASSPORTANDID);
                //        nwCus4 = new SimulatingCustomer(800, 300, 20, -30, 50, CustomerType.ROOMRENTAL);



                //        nwPan1.Location = new Point(x, y);
                //        nwPan2.Location = new Point(x, y);
                //        nwPan3.Location = new Point(x, y);
                //        nwPan4.Location = new Point(x, y);

                //        nwPan1.BackColor = Color.BlueViolet;
                //        nwPan2.BackColor = Color.LightPink;
                //        nwPan3.BackColor = Color.LightGray;
                //        nwPan4.BackColor = Color.Maroon;

                //        this.circularPanels.Add(nwPan1);
                //        this.circularPanels.Add(nwPan2);
                //        this.circularPanels.Add(nwPan3);
                //        this.circularPanels.Add(nwPan4);


                //        this.customers.AddCustomer(nwCus1);
                //        this.customers.AddCustomer(nwCus2);
                //        this.customers.AddCustomer(nwCus3);
                //        this.customers.AddCustomer(nwCus4);
                //        //this.circularPanel1.Paint += new PaintEventHandler(circularPanel1_Paint);
                //        //this.circularPanel1.Refresh();
                //        //this.circularPanel1.Visible = true;
                //        this.Invalidate();
                //    }
                //}
                //foreach (CircularPanel p in circularPanels)
                //{
                //    this.Controls.Add(p);
                //    p.BringToFront();

                //}
                ////MessageBox.Show(customers.GetAllCustomers().Count().ToString());
              
        }

        private void openCounterBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void pbxCounter1_Click(object sender, EventArgs e)
        {

        }

        private void openTaxCounterBtn_Click(object sender, EventArgs e)
        {
            this.timerBlinking.Start();
            if (this.cbxCounterId.SelectedIndex >= 0)
            {
                int counterId = this.cbxCounterId.SelectedIndex + 1;
                if (counters.OpenCounter(counterId))
                {
                    MessageBox.Show("Successfully opened!");
                }
               else { MessageBox.Show("This counter is already opened!"); }
            }
            
            

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void createNewCounterBtn_Click(object sender, EventArgs e)
        {
            //CounterType type;
            //double processingTime = 0;
            //if (this.cbxCountersTypes.SelectedIndex >= 0)
            //{

            //    if (this.cbxCountersTypes.SelectedIndex == 0)
            //    {
            //        type = CounterType.GENERAL;
            //    }
            //    else if (this.cbxCountersTypes.SelectedIndex == 1)
            //    {
            //        type = CounterType.TAXandROOMRENTAL;
            //    }
            //    else { type = CounterType.DRIVERLICENSEandPASSPORTID; }

            //    if (tbProcessingTime.Text != "")
            //    {
            //        processingTime = Convert.ToDouble(this.tbProcessingTime.Text);
            //    }
            //    else MessageBox.Show("Please enter processing time!");
            //    if ((this.quantityBox.Value + this.counters.GetAllCounters().Count) <= 5)
            //    {
            //        for(int i=0; i< this.quantityBox.Value; i++)
            //        {
            //            id++;
            //            MovePanelToLeft();
            //            Label nwLbl = new Label();
            //            Counter nwCounter = new Counter(id,this.GetLastPanelX() + 208, 74, type, processingTime);
            //            Panel nwPanel = new Panel();
            //            nwPanel.Size = new Size(108, 50);
            //            nwPanel.Location = new Point(nwCounter.X, nwCounter.Y);
            //            this.SetCounterColor(nwCounter, nwPanel);
            //            nwLbl.Location = new Point(nwPanel.Location.X + 23, 51);
            //            nwLbl.Text = $"Counter {id}";
            //            //-Time: { processingTime}                     
            //            nwLbl.Font = new Font("Microsoft Sans Serif", 10);
            //            nwLbl.BackColor = Color.Pink;
            //            nwLbl.AutoSize = true;
                        
            //            //processing time

                        

            //            this.counters.AddCounter(nwCounter);
            //            this.Controls.Add(nwPanel);
            //            this.Controls.Add(nwLbl);
            //            this.panels.Add(nwPanel);
            //            this.countersLabels.Add(nwLbl);

            //            foreach (Panel p in panels)
            //            {
            //                p.BringToFront();
            //            }

            //            foreach(Label lbl in countersLabels)
            //            {
            //                lbl.BringToFront();
            //            }

            //            this.AddIdToCombobox();
            //            this.Invalidate();
            //        }
                   
            //    }
            //    else { MessageBox.Show("The maximum of counters is 5! You cannot create more!"); }
                

            //}
            //else { MessageBox.Show("Please select type of counter you want to create!"); }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void numericTaxUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void closeTaxCounterBtn_Click(object sender, EventArgs e)
        {
            this.timerBlinking.Start();
            if (this.cbxCounterId.SelectedIndex >= 0)
            {
                int counterId = this.cbxCounterId.SelectedIndex+1;
                if (counters.CloseCounter(counterId))
                {
                    panels[counterId - 1].BackColor = Color.DarkGray;
                    MessageBox.Show("Successfully closed!");
                }
                else { MessageBox.Show("This counter is already closed!"); }
            }
        }

        private void SetBackColor(SimulatingCustomer c, CircularPanel p)
        {
            if (c.Type == CustomerType.TAX)
            {
                p.BackColor = Color.BlueViolet;
            }
            else if (c.Type == CustomerType.DRIVERLICENCSE)
            {
                p.BackColor = Color.LightPink;
            }
            else if (c.Type == CustomerType.PASSPORTANDID)
            {
                p.BackColor = Color.LightGray;
            }
            else
            {
                p.BackColor = Color.Maroon;
            }
        }

        private int GetLastPanelX()
        {
            Panel lastPanel = panels[panels.Count - 1];
            
            return lastPanel.Location.X;
        }


        //process a new appointment
        private void GoIntoCounter(CustomersList steadyCustomers)
        {
            //if (this.timerProcessTax.Enabled)
            //{
                //timerProcessTax.Start();
                Counter selectedCounter;

                List<CustomerType> types = new List<CustomerType>();
            //List<SimulatingCustomer> movingTRCus = this.customers.GetCustomersPerType(CustomerType.TAX, CustomerType.ROOMRENTAL);
            //List<SimulatingCustomer> movingDPCus = this.customers.GetCustomersPerType(CustomerType.DRIVERLICENCSE, CustomerType.PASSPORTANDID);
            //List<SimulatingCustomer> movingGCus = this.customers.GetCustomersPerType(CustomerType.TAX, CustomerType.TAX);

                List<SimulatingCustomer> movingTRCus = steadyCustomers.GetCustomersPerType(CustomerType.TAX, CustomerType.ROOMRENTAL);
                List<SimulatingCustomer> movingDPCus = steadyCustomers.GetCustomersPerType(CustomerType.DRIVERLICENCSE, CustomerType.PASSPORTANDID);
                List<SimulatingCustomer> movingGCus = steadyCustomers.GetCustomersPerType(CustomerType.TAX, CustomerType.TAX);
            this.customers.MoveAllCustomers();


            //foreach (SimulatingCustomer cus in movingTRCus)
            //{
            //    selectedCounter = counters.GetCounter(counters.GetSmallestCounterIdInAType(CounterType.TAXandROOMRENTAL));

            //    foreach (CircularPanel c in circularPanels)
            //    {
            //        if (selectedCounter.IsOccupied == false)
            //        {
            //            cus.GoIntoTheCounter(selectedCounter);
            //        }
            //    }
            //    selectedCounter.IsOccupied = true;

            //}

            //foreach (SimulatingCustomer cus in movingDPCus)
            //{
            //    selectedCounter = counters.GetCounter(counters.GetSmallestCounterIdInAType(CounterType.DRIVERLICENSEandPASSPORTID));
            //    foreach (CircularPanel c in circularPanels)
            //    {
            //        if (selectedCounter.IsOccupied == false)
            //        {
            //            cus.GoIntoTheCounter(selectedCounter);

            //        }
            //    }
            //    selectedCounter.IsOccupied = true;
            //}
            //this.Invalidate();
        }


        

        private void Moving()
        {
            if (timerStart.Enabled)
            {
                this.timerStart.Start();

                Counter selectedCounter;
                

                int steadyPForTR = 0;
                int steadyPForDP = 0;
                int steadyPForG = 0;
                List<CustomerType> types = new List<CustomerType>();
                List<SimulatingCustomer> movingTRCus = this.customers.GetCustomersPerType(CustomerType.TAX, CustomerType.ROOMRENTAL);
                List<SimulatingCustomer> movingDPCus = this.customers.GetCustomersPerType(CustomerType.DRIVERLICENCSE, CustomerType.PASSPORTANDID);
                List<SimulatingCustomer> movingGCus = this.customers.GetCustomersPerType(CustomerType.TAX, CustomerType.TAX);
                //selectedCounter = counters.GetCounter(counters.GetSmallestCounterIdInAType(CounterType.TAXandROOMRENTAL));
                //selectedCounter2 = counters.GetCounter(counters.GetSmallestCounterIdInAType(CounterType.DRIVERLICENSEandPASSPORTID));


                //List<SimulatingCustomer> steadyCustomers = new List<SimulatingCustomer>();
                //CustomersList steadyCustomers = new CustomersList();
                this.customers.MoveAllCustomers();


                foreach (SimulatingCustomer cus in movingTRCus)
                {
                    selectedCounter = counters.GetCounter(counters.GetSmallestCounterIdInAType(CounterType.TAXandROOMRENTAL));
                    steadyPForTR += 30;


                    foreach (CircularPanel c in circularPanels)
                    {
                        if (movingTRCus.IndexOf(cus) == 0)
                        {
                            cus.DirectCustomer(selectedCounter, 0, 0); //                           
                            cus.GoIntoTheCounter(selectedCounter, 0, 0);
                        }
                        else
                        {
                            cus.DirectCustomer(selectedCounter, steadyPForTR, 30);
                            cus.GoIntoTheCounter(selectedCounter, steadyPForTR, 30);
                        }
                        if (cus.CPanel.Location.X == 305 && cus.CPanel.Location.Y == selectedCounter.Y + 380)
                        {
                            cus.CPanel.SendToBack();
                            customers.GetAllCustomers().Remove(cus);
                        }


                    }
                    //steadyCustomers.AddCustomer(cus);
                    //if(selectedCounter.IsOccupied==false && steadyCustomers != null)
                    //{
                    //    foreach (SimulatingCustomer steadycus in steadyCustomers.GetAllCustomers())
                    //    {
                    //        foreach (CircularPanel c in circularPanels)
                    //        {
                    //            steadycus.GoIntoTheCounter(selectedCounter);
                    //        }
                    //    }
                    //    selectedCounter.IsOccupied = true;
                    //}
                }
            //for(int i = 0; i<movingTRCus.Count - 1;i++)
            //{
            //    if(movingTRCus[i].StandingInTheQueue == true)
            //    {
            //        if (movingTRCus[i + 1] != null)
            //        {
            //            movingTRCus[i + 1].GoLeft();
            //        }
            //    }
            //}


            foreach (SimulatingCustomer cus in movingDPCus)
                {
                    selectedCounter = counters.GetCounter(counters.GetSmallestCounterIdInAType(CounterType.DRIVERLICENSEandPASSPORTID));

                    steadyPForDP += 30;
                    foreach (CircularPanel c in circularPanels)
                    {
                        if (movingDPCus.IndexOf(cus) == 0)
                        {
                            cus.DirectCustomer(selectedCounter, 0,0);
                            cus.GoIntoTheCounter(selectedCounter,0,0);
                        }
                        if (cus.CPanel.Location.X == 305 && cus.CPanel.Location.Y == selectedCounter.Y + 380)
                        {
                            cus.CPanel.SendToBack();
                            customers.GetAllCustomers().Remove(cus);

                        }
                        else
                        {
                            cus.DirectCustomer(selectedCounter, steadyPForDP,30);
                            cus.GoIntoTheCounter(selectedCounter,steadyPForDP,30);
                        }

                    }
                    //steadyCustomers.AddCustomer(cus);
                }
                this.customers.SocialDistancingForDriverLicenseQueue();

                //this.GoIntoCounter(steadyCustomers);
                this.Invalidate();
            }
        }

        //public void ProcessingAppointment(Counter selectedCounter, CustomerType t1, CustomerType t2)
        //{
        //    List<SimulatingCustomer> cusPerType = this.customers.GetCustomersPerType(t1, t2);
        //    foreach (SimulatingCustomer cus in cusPerType)
        //    {
        //        int currentPosition = cus.Y;
        //        if (cusPerType.IndexOf(cus)<cusPerType.Count()-1)
        //        {
        //            SimulatingCustomer nextCus = cusPerType[cusPerType.IndexOf(cus) + 1];

        //            foreach (CircularPanel c in circularPanels)
        //            {
        //                if (selectedCounter.IsOccupied == false)
        //                {
        //                    cus.Dir = CustomerDirection.UP;
        //                    if (c.Location.Y == selectedCounter.Y + 30)
        //                    {
        //                        cus.Dir = CustomerDirection.STEADY;
        //                        nextCus.Dir = CustomerDirection.UP;
        //                        if (nextCus.Y == currentPosition)
        //                        {
        //                            nextCus.Dir = CustomerDirection.STEADY;
        //                        }
        //                    }
        //                    selectedCounter.IsOccupied = true;
        //                }                        
        //            }
        //        }
        //        else
        //        {

        //            foreach (CircularPanel c in circularPanels)
        //            {
        //                if (selectedCounter.IsOccupied == false)
        //                {
        //                    cus.Dir = CustomerDirection.UP;
        //                    if (c.Location.Y == selectedCounter.Y + 30)
        //                    {
        //                        cus.Dir = CustomerDirection.STEADY;
        //                    }
        //                    selectedCounter.IsOccupied = true;
        //                }
        //            }
        //        }
                
        //    }
        //}




        private void AddDefault()
            {
            //counter 1
            id++;
            Counter c1 = new Counter(id,336, 74, CounterType.GENERAL, 20);
            Panel p1 = new Panel();
            p1.Location = new Point(c1.X, c1.Y);
            p1.Size = new Size(108, 50);
            Label lblC1 = new Label();
            lblC1.Location = new Point(p1.Location.X+23, 51);
            lblC1.Text = $"Counter {id}";
            lblC1.Font = new Font("Microsoft Sans Serif", 10);
            lblC1.BackColor = Color.Pink;
            lblC1.AutoSize = true;
            
            //counter 2
            id++;
            Counter c2 = new Counter(id,500, 74, CounterType.TAXandROOMRENTAL, 20);
            Panel p2 = new Panel();
            p2.Location = new Point(c2.X, c2.Y);
            p2.Size = new Size(108, 50);
            Label lblC2 = new Label();
            lblC2.Location = new Point(p2.Location.X+23, 51);
            lblC2.Text = $"Counter {id}";
            lblC2.Font = new Font("Microsoft Sans Serif", 10);
            lblC2.BackColor = Color.Pink;
            lblC2.AutoSize = true;

            //counter 3
            id++;
            Counter c3 = new Counter(id,664, 74, CounterType.DRIVERLICENSEandPASSPORTID, 20);
            Panel p3 = new Panel();
            p3.Location = new Point(c3.X, c3.Y);
            p3.Size = new Size(108, 50);
            Label lblC3 = new Label();
            lblC3.Location = new Point(p3.Location.X+23, 51);
            lblC3.Text = $"Counter {id}";
            lblC3.Font = new Font("Microsoft Sans Serif", 10);
            lblC3.BackColor = Color.Pink;
            lblC3.AutoSize = true;

            //counter 4
            id++;
            Counter c4 = new Counter(id, 828, 74, CounterType.DRIVERLICENSEandPASSPORTID, 20);
            Panel p4 = new Panel();
            p4.Location = new Point(c4.X, c4.Y);
            p4.Size = new Size(108, 50);
            Label lblC4 = new Label();
            lblC4.Location = new Point(p4.Location.X + 23, 51);
            lblC4.Text = $"Counter {id}";
            lblC4.Font = new Font("Microsoft Sans Serif", 10);
            lblC4.BackColor = Color.Pink;
            lblC4.AutoSize = true;
            
            //counter 5
            id++;
            Counter c5 = new Counter(id, 992, 74, CounterType.DRIVERLICENSEandPASSPORTID, 20);
            Panel p5 = new Panel();
            p5.Location = new Point(c5.X, c5.Y);
            p5.Size = new Size(108, 50);
            Label lblC5 = new Label();
            lblC5.Location = new Point(p5.Location.X + 23, 51);
            lblC5.Text = $"Counter {id}";
            lblC5.Font = new Font("Microsoft Sans Serif", 10);
            lblC5.BackColor = Color.Pink;
            lblC5.AutoSize = true;

            //counter 6
            id++;
            Counter c6 = new Counter(id, 1156, 74, CounterType.DRIVERLICENSEandPASSPORTID, 20);
            Panel p6 = new Panel();
            p6.Location = new Point(c6.X, c6.Y);
            p6.Size = new Size(108, 50);
            Label lblC6 = new Label();
            lblC6.Location = new Point(p6.Location.X + 23, 51);
            lblC6.Text = $"Counter {id}";
            lblC6.Font = new Font("Microsoft Sans Serif", 10);
            lblC6.BackColor = Color.Pink;
            lblC6.AutoSize = true;


            //set sounter color
            this.SetCounterColor(c1,p1);
            this.SetCounterColor(c2,p2);
            this.SetCounterColor(c3,p3);
            this.SetCounterColor(c4, p4);
            this.SetCounterColor(c5, p5);
            this.SetCounterColor(c6, p6);

            this.counters.AddCounter(c1);
            this.counters.AddCounter(c2);
            this.counters.AddCounter(c3);
            this.counters.AddCounter(c4);
            this.counters.AddCounter(c5);
            this.counters.AddCounter(c6);

            this.panels.Add(p1);
            this.panels.Add(p2);
            this.panels.Add(p3);
            this.panels.Add(p4);
            this.panels.Add(p5);
            this.panels.Add(p6);

            this.countersLabels.Add(lblC1);
            this.countersLabels.Add(lblC2);
            this.countersLabels.Add(lblC3);
            this.countersLabels.Add(lblC4);
            this.countersLabels.Add(lblC5);
            this.countersLabels.Add(lblC6);

            foreach (Panel p in panels)
            {
                this.Controls.Add(p);
                p.BringToFront();
            }

            foreach(Label l in countersLabels)
            {
                this.Controls.Add(l);
                l.BringToFront();
            }
            this.AddIdToCombobox();
            this.Invalidate();

        }

        private void SetCounterColor(Counter c, Panel p)
        {
            if (c.CounterType == CounterType.GENERAL)
            {
                p.BackColor = Color.FromArgb(0, 204, 255);
            }
            else if (c.CounterType == CounterType.DRIVERLICENSEandPASSPORTID)
            {
                p.BackColor = Color.FromArgb(255, 51, 153);
            }
            else
            {
                p.BackColor = Color.FromArgb(255, 153, 51);
            }
        }

        private void MovePanelToLeft()
        {
            int firstCounterX = panels[0].Location.X;
            panels[0].Location = new Point(firstCounterX - 54, 74);

            countersLabels[0].Location = new Point(panels[0].Location.X + 15, 51);
            for (int i = 1; i < panels.Count; i++) 
            {
                for (int n = 1; n < countersLabels.Count; n++)
                {
                    panels[i].Location = new Point(panels[i - 1].Location.X + 108 + 110, 74);
                    countersLabels[n].Location = new Point(countersLabels[n-1].Location.X+218, 51);
                }
                
            }
            this.Invalidate();
        }

        private int GetNrOfCounters()
        {
            return this.counters.GetAllCounters().Count;
        }

        private void AddIdToCombobox()
        {
            this.cbxCounterId.Items.Clear();
            foreach (Counter c in counters.GetAllCounters())
            {
                this.cbxCounterId.Items.Add($"{c.Id}-Type:{c.CounterType}");
            }
        }

        private void timerBlinking_Tick(object sender, EventArgs e)
        {

            Random r = new Random();

            int a = r.Next(144, 245);
            int b = r.Next(192, 238);
            int c = r.Next(144, 203);
            int d = r.Next(0, 0);

           foreach(Counter counter in counters.GetAllCounters())
            {
                if (counter.IsOpened == true)
                {
                    countersLabels[counter.Id-1].BackColor = Color.FromArgb(a, b, c, d);

                }
                else
                {
                    countersLabels[counter.Id-1].BackColor = Color.Pink;

                }
            }



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult dialog = MessageBox.Show("Do you really want to end the simulation?", "Exit", MessageBoxButtons.YesNo);
            //MessageBox.Show("Do you really want to end the simulation?", "Exit", MessageBoxButtons.YesNo);
            
            if(dialog == DialogResult.No)
            { 

                e.Cancel = true;
            }
        }

        private void changeProcessingTimeBtn_Click(object sender, EventArgs e)
        {
            
            
        }

        private void cbxCounterId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbxCounterId.SelectedIndex >= 0)
            {
                string s = "";
                int counterId = this.cbxCounterId.SelectedIndex + 1;
                s += counters.GetCounter(counterId).ProcessingTime;
                processTimeTb.Text = s;
                
                
            }
        }

        private void changeProcessingTimeBtn_Click_1(object sender, EventArgs e)
        {
            double processingTime = Convert.ToDouble(changedProcessingTimeTb.Text);
            CounterType type;
            if (this.changedTimeForTypeCb.SelectedIndex == 0)
            {
                type = CounterType.GENERAL;
            }
            else if (this.changedTimeForTypeCb.SelectedIndex == 1)
            {
                type = CounterType.TAXandROOMRENTAL;
            }
            else { type = CounterType.DRIVERLICENSEandPASSPORTID; }


            if (changedProcessingTimeTb.Text != string.Empty)
            {
            counters.SetProcessingTime(processingTime, type);    
            MessageBox.Show("Processing time changed to " + processingTime);
            }
            else
            {
                MessageBox.Show("Please input the processcing time");
            }

        }

        private void taskCmb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void changedProcessingTimeTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private bool IsTimerStarted()
        {
            if (this.timerStart.Enabled == true)
            {
                return true;
            }
            else { return false; }
        }

        private void timerWait_Tick(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timerProcessTax_Tick(object sender, EventArgs e)
        {

            //this.GoIntoCounter();
        }


        //processing appointments



    }
}
