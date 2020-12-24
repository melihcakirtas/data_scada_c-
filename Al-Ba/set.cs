using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyModbus;
using System.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MySql.Data.MySqlClient;
namespace Al_Ba
{
    public partial class set : UserControl
    {
        private ModbusClient modbusClient;
        private bool check = false;
        public set()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            List<listitems> listitems = new List<listitems>();
            try
            {
                listitems.Add(new Al_Ba.listitems
                {
                    status = false,
                    address = Convert.ToInt32(address.Text),
                    type = comboBox1.Text,
                    definition = definition.Text
                });
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                goto end;
            }

            foreach (var item in listitems)
            {
                if (Check(item.address.ToString(), item.type))
                    dataGridView1.Rows.Add(item.address, item.type, item.status, item.definition);
            }
            string sampleJson = null;
            sampleJson += "{\"datagrid\":[";
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if (i > 0)
                    sampleJson += ",";
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    switch (j)
                    {
                        case 0:
                            sampleJson += "{\"address\":\"" + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\",";
                            break;
                        case 1:
                            sampleJson += "\"type\":\"" + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\",";
                            break;
                        case 2:
                            sampleJson += "\"status\":\"" + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\",";
                            break;
                        case 3:
                            sampleJson += "\"definition\":\"" + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\"}";
                            break;
                    }
                }
            }
            sampleJson += "]}";
            Properties.Settings.Default.Setting = sampleJson;
            Properties.Settings.Default.Save();
        end:
            if (true) { }
        }
        private bool Check(string add, string type)
        {
            bool response = true;
            if (dataGridView1.Rows.Count > 1)
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() == add && dataGridView1.Rows[i].Cells[1].Value.ToString() == type)
                    {
                        response = false;
                        MessageBox.Show("Address is already added to list", "info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            return response;
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                modbusClient = new ModbusClient(IP.Text, Convert.ToInt32(port.Text));
                modbusClient.Connect();
                MessageBox.Show("connection successful!!!", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                check = true;
                modbusClient.Disconnect();
                socket.Ip = IP.Text;
                socket.port = Convert.ToInt32(port.Text);
                Properties.Settings.Default.ip = IP.Text;
                Properties.Settings.Default.port = Convert.ToInt32(port.Text);
                Properties.Settings.Default.Save();
                button2.BackColor = Color.Green;
            }
            catch (Exception err)
            {
                button2.BackColor = Color.Orange;
                MessageBox.Show("please check your Ip or Port settings\n" + err.Message, "connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Set_Load(object sender, EventArgs e)
        {
            sıfırlama.gündüz_saat = textBox1.Text;
            sıfırlama.gündüz_dak = textBox8.Text;
            sıfırlama.mesai_saat = textBox3.Text;
            sıfırlama.mesai_dak = textBox9.Text;
            sıfırlama.gece_saat = textBox6.Text;
            sıfırlama.gece_dak = textBox11.Text;
            textBox2.Visible = false;
            timer1.Start();
            user.Text = Properties.Settings.Default.username;
            password.Text = Properties.Settings.Default.password;
            server_name.Text = Properties.Settings.Default.servername;
            dbname.Text = Properties.Settings.Default.dbname;
            tbname.Text = Properties.Settings.Default.tbname;
            port.Text = Properties.Settings.Default.port.ToString();
            IP.Text = Properties.Settings.Default.ip;
            mailbox.Text = Properties.Settings.Default.mail;
            mailnotification.Checked = Properties.Settings.Default.mailnotification;
            if (Properties.Settings.Default.Setting != "")
            {
                JObject results = JObject.Parse(Properties.Settings.Default.Setting);
                foreach (var result in results["datagrid"])
                {
                    string address = (string)result["address"];
                    JToken type = result["type"];
                    JToken status = result["status"];
                    JToken definition = result["definition"];
                    dataGridView1.Rows.Add(address, type, status, definition);
                }
            }
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            string connectionString;
            connectionString = "Server = " + server_name.Text + "; Port = " + sql_port.Text + "; Database = " + dbname.Text + "; Uid = " +
            user.Text + "; Pwd = " + password.Text + ";";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM " + tbname.Text + ";";
                    MySqlCommand insertCommand = new MySqlCommand(query, connection);
                    MessageBox.Show("My-Sql connection successful!!!");
                    Properties.Settings.Default.username = user.Text;
                    Properties.Settings.Default.password = password.Text;
                    Properties.Settings.Default.servername = server_name.Text;
                    Properties.Settings.Default.tbname = tbname.Text;
                    Properties.Settings.Default.dbname = dbname.Text;
                    Properties.Settings.Default.sql_port = sql_port.Text;
                    Properties.Settings.Default.Save();
                    server.username = user.Text;
                    server.password = password.Text;
                    server.servername = server_name.Text;
                    server.dbname = dbname.Text;
                    server.tbname = tbname.Text;
                    server.sql_port = sql_port.Text;
                    button3.BackColor = Color.Green;
                }
                catch (Exception ex)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show(ex.Message);
                        button3.BackColor = Color.Orange;
                    });
                }
            }
        }
        private void DataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                dataGridView1.Rows.RemoveAt(e.RowIndex);
                string sampleJson = null;
                sampleJson += "{\"datagrid\":[";
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (i > 0)
                        sampleJson += ",";
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        switch (j)
                        {
                            case 0:
                                sampleJson += "{\"address\":\"" + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\",";
                                break;
                            case 1:
                                sampleJson += "\"type\":\"" + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\",";
                                break;
                            case 2:
                                sampleJson += "\"status\":\"" + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\",";
                                break;
                            case 3:
                                sampleJson += "\"definition\":\"" + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\"}";
                                break;
                        }
                    }
                }
                sampleJson += "]}";
                Properties.Settings.Default.Setting = sampleJson;
                Properties.Settings.Default.Save();
            }
        }
        string IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return "true";
            }
            catch (Exception err)
            {
                return err.Message;
            }
        }
        private void Mailbox_Leave(object sender, EventArgs e)
        {
            Properties.Settings.Default.mail = mailbox.Text;
            if (mailbox.Text != "")
            {
                string resp = IsValidEmail(Properties.Settings.Default.mail);
                if (resp == "true")
                {
                    Properties.Settings.Default.Save();
                }
                else
                    MessageBox.Show(resp);
            }
            else
                Properties.Settings.Default.Save();
        }
        private void Mailnotification_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.mailnotification = mailnotification.Checked;
            Properties.Settings.Default.Save();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            reset reset = new reset();
            reset.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sıfırlama.gündüz_saat = textBox1.Text;
            sıfırlama.gündüz_dak = textBox8.Text;
            try
            {
                modbusClient.Connect();
                modbusClient.WriteSingleRegister(300, Convert.ToInt32(textBox1.Text));
                modbusClient.WriteSingleRegister(301, Convert.ToInt32(textBox8.Text));
                button5.BackColor = Color.Blue;
                MessageBox.Show("Succesful", "function succes!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                modbusClient.Disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            sıfırlama.mesai_saat = textBox3.Text;
            sıfırlama.mesai_dak = textBox9.Text;
            try
            {
                modbusClient.Connect();
                modbusClient.WriteSingleRegister(304, Convert.ToInt32(textBox3.Text));
                modbusClient.WriteSingleRegister(305, Convert.ToInt32(textBox9.Text));
                button6.BackColor = Color.Blue;
                MessageBox.Show("Succesful", "function succes!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                modbusClient.Disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            sıfırlama.gece_saat = textBox6.Text;
            sıfırlama.gece_dak = textBox11.Text;
            try
            {
                modbusClient.Connect();
                modbusClient.WriteSingleRegister(308, Convert.ToInt32(textBox6.Text));
                modbusClient.WriteSingleRegister(309, Convert.ToInt32(textBox11.Text));
                button7.BackColor = Color.Blue;
                MessageBox.Show("Succesful", "function succes!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                modbusClient.Disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label17.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

    }
}