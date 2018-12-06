using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_in_Csharp
{
    public partial class Simulation : Form
    {
        public Simulation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Blue;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (button3.BackColor == Color.Red)
            {
                button3.BackColor = Color.LightGray;
                button2.BackColor = Color.Green;
            }
            textBox1.Text = network[0].Name;
            network[0].StartDevice();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            if (button2.BackColor == Color.Green)
            {
                button3.BackColor = Color.Red;
                button2.BackColor = Color.LightGray;
            }
            network[0].ShutDown();
            textBox1.Clear();
        }
        
        //SEARCH BUTTON////////////////////////////////////////////////////////
        private void button4_Click(object sender, EventArgs e)
        {
         foreach(Computer comp in network)
            {
                ListBox.Items.Add(comp.Name +"                              "+comp.Ipaddress);
                ListBox.DrawItem += new DrawItemEventHandler(listBox1_DrawItem);
            }
        }
        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox lb = (ListBox)sender;
            e.DrawBackground();
            Brush brush;

            if (e.Index == lb.Items.Count - 6)
                brush = Brushes.Red; //El último elemento
            else if (e.Index == lb.Items.Count - 5)
                brush = Brushes.Red;
            else if (e.Index == lb.Items.Count - 4)
                brush = Brushes.Red;
            else brush = Brushes.Black;

            e.Graphics.DrawString(lb.Items[e.Index].ToString(), e.Font, brush, e.Bounds);
        }
        ////////////////////////////////////////////////////////////////////////

        private void button5_Click(object sender, EventArgs e)
        {
            if (button6.BackColor == Color.Red)
            {
                button6.BackColor = Color.LightGray;
                button5.BackColor = Color.Green;
            }
            textBox2.Text = network[1].Name;
            network[1].StartDevice();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button5.BackColor == Color.Green)
            {
                button6.BackColor = Color.Red;
                button5.BackColor = Color.LightGray;
            }
            network[1].ShutDown();
            textBox2.Clear();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button8.BackColor == Color.Red)
            {
                button8.BackColor = Color.LightGray;
                button7.BackColor = Color.Green;
            }
            textBox3.Text = network[2].Name;
            network[2].StartDevice();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (button7.BackColor == Color.Green)
            {
                button8.BackColor = Color.Red;
                button7.BackColor = Color.LightGray;
            }
            network[2].ShutDown();
            textBox3.Clear();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (button14.BackColor == Color.Red)
            {
                button14.BackColor = Color.LightGray;
                button13.BackColor = Color.Green;
            }
            textBox4.Text = network[3].Name;
            network[3].StartDevice();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (button13.BackColor == Color.Green)
            {
                button14.BackColor = Color.Red;
                button13.BackColor = Color.LightGray;
            }
            network[3].ShutDown();
            textBox4.Clear();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (button12.BackColor == Color.Red)
            {
                button12.BackColor = Color.LightGray;
                button11.BackColor = Color.Green;
            }
            textBox5.Text = network[4].Name;
            network[4].StartDevice();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (button11.BackColor == Color.Green)
            {
                button12.BackColor = Color.Red;
                button11.BackColor = Color.LightGray;
            }
            network[4].ShutDown();
            textBox5.Clear();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (button10.BackColor == Color.Red)
            {
                button10.BackColor = Color.LightGray;
                button9.BackColor = Color.Green;
            }
            textBox6.Text = network[5].Name;
            network[5].StartDevice();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (button9.BackColor == Color.Green)
            {
                button10.BackColor = Color.Red;
                button9.BackColor = Color.LightGray;
            }
            network[5].ShutDown();
            textBox6.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void Console_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        
        //list of Arrays
        List<Computer> network = new List<Computer>();

        private void Simulation_Load(object sender, EventArgs e)
        {
   
            //Creating the object
            Server servidor = new Server("servidor_1", "Dell", "Windows", false, "WEB Server", "10.0.0.1");
            Server servidor2 = new Server("servidor_2", "Mac", "Linux", false, "WEB Server", "10.0.0.2");
            Server servidor3 = new Server("servidor_3", "Acer", "Windows", false, "WEB Server", "10.0.0.3");
            Computer myFirstComp = new Computer("myFirstComp", "Lenovo", "Linux", false);
            Computer mySecondComp = new Computer("mySecondComp", "Toshiba", "Windows", false);
            Computer myThirdComp = new Computer("myThirdComp", "Asus", "Linux", false);

            //Add the computer to the Array
            network.Add(servidor);
            network.Add(servidor2);
            network.Add(servidor3);
            network.Add(myFirstComp);
            network.Add(mySecondComp);
            network.Add(myThirdComp);
        }

        private void Computer_1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Computer_2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Computer_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
