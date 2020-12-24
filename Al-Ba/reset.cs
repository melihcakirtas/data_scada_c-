using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyModbus;
namespace Al_Ba
{
    public partial class reset : Form
    {
        ModbusClient modbusClient;
        public reset()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                modbusClient = new ModbusClient(IP.Text, Convert.ToInt32(port.Text));
                modbusClient.Connect();
                MessageBox.Show("connection successful!!!", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                modbusClient.Disconnect();
                button2.BackColor = Color.Green;
            }
            catch (Exception err)
            {
                button2.BackColor = Color.Orange;
                MessageBox.Show("please check your Ip or Port settings\n" + err.Message, "connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                modbusClient.Connect();
                modbusClient.WriteSingleRegister(Convert.ToInt32(textBox1.Text), 0);
                MessageBox.Show("Succesful" , "function succes!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                modbusClient.Disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("please check your Ip or Port settings\n" + ex.Message, "connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reset_Load(object sender, EventArgs e)
        {

        }
    }
}
