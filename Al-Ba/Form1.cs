using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using EasyModbus;
using System.Net.Mail;
using System.Net;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
namespace Al_Ba
{

    public partial class Form1 : Form
    {
        Color col = Color.FromArgb(106, 47, 44);
        private static ModbusClient modbusClient = null;
        private bool runsystem = false;

        public Form1()
        {
            InitializeComponent();
            dmon.BackColor = col;
            dmon1.BringToFront();
        }
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Set_Click(object sender, EventArgs e)
        {
            set.BackColor = col;
            dmon.BackColor = Color.Maroon;
            log.BackColor = Color.Maroon;
            help.BackColor = Color.Maroon;
            set1.BringToFront();
        }
        private void Dmon_Click(object sender, EventArgs e)
        {
            dmon.BackColor = col;
            set.BackColor = Color.Maroon;
            log.BackColor = Color.Maroon;
            help.BackColor = Color.Maroon;
            dmon1.BringToFront();
        }
        private void Log_Click(object sender, EventArgs e)
        {
            log.BackColor = col;
            dmon.BackColor = Color.Maroon;
            set.BackColor = Color.Maroon;
            help.BackColor = Color.Maroon;
            log1.BringToFront();
        }
        private void Help_Click(object sender, EventArgs e)
        {
            help.BackColor = col;
            dmon.BackColor = Color.Maroon;
            set.BackColor = Color.Maroon;
            log.BackColor = Color.Maroon;
            help1.BringToFront();
        }
        bool SQLerror = false;

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                modbusClient = new ModbusClient(socket.Ip, socket.port);
                modbusClient.Connect();
                modbusClient.WriteSingleRegister(312, Convert.ToInt32(time_hour));
                modbusClient.WriteSingleRegister(313, Convert.ToInt32(time_min));
                this.Invoke((MethodInvoker)delegate
              {
                  log1.listView1.Items.Add(new ListViewItem(new[] { DateTime.Now.ToString(), "connected to Ip=" + socket.Ip + "port=" + socket.Ip }));
              });
                modbusClient.Disconnect();
            }
            catch (Exception err)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    //log1.textBox1.AppendText(DateTime.Now + ":\t please check your Ip or Port settings");
                    log1.listView1.Items.Add(new ListViewItem(new[] { DateTime.Now.ToString(), "please check your Ip or Port settings " + err.Message }));
                });
                goto out_s;
            }

            while (runsystem)
            {
                bool datawritten = false;
            wait:
                try
                {
                    modbusClient = new ModbusClient(socket.Ip, socket.port);
                    modbusClient.Connect();
                }
                catch (Exception err)
                {
                    if (!datawritten)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            //log1.textBox1.AppendText(DateTime.Now + ":\t please check your Ip or Port settings");
                            log1.listView1.Items.Add(new ListViewItem(new[] { DateTime.Now.ToString(), "please check your Ip or Port settings" + err.Message }));
                        });
                        sendmail("Plc bağlantısı kesildi");
                        datawritten = true;
                    }
                    System.Threading.Thread.Sleep(1000);
                    goto wait;
                }
                List<sqlpost> post = new List<sqlpost>();
                for (int i = 0; i < set1.dataGridView1.Rows.Count - 1; i++)
                {

                    if (set1.dataGridView1.Rows[i].Cells[1].Value != null)
                    {

                        //
                        //************************************ LW **************************//
                        //
                        #region -----LW------
                        if (set1.dataGridView1.Rows[i].Cells[1].Value.ToString() == "D")
                        {

                            int[] readHoldingRegisters;
                            try
                            {
                                readHoldingRegisters = modbusClient.ReadInputRegisters(
                                Convert.ToUInt16(set1.dataGridView1.Rows[i].Cells[0].Value), 1);
                                modbusClient.WriteSingleRegister(312, Convert.ToInt32(time_hour));
                                modbusClient.WriteSingleRegister(313, Convert.ToInt32(time_min));
                            }
                            catch (Exception err)
                            {
                                this.Invoke((MethodInvoker)delegate
                                {
                                    log1.listView1.Items.Add(new ListViewItem(new[] { DateTime.Now.ToString(), "please check your Ethernet connection" + err.Message }));
                                });
                                goto wait;
                            }
                            if (readHoldingRegisters[0].ToString() != set1.dataGridView1.Rows[i].Cells[2].Value.ToString())
                            {
                                post.Add(new sqlpost { definition = set1.dataGridView1.Rows[i].Cells[3].Value.ToString(), address = set1.dataGridView1.Rows[i].Cells[0].Value.ToString(), value = readHoldingRegisters[0].ToString(), });
                                set1.dataGridView1.Rows[i].Cells[2].Value = readHoldingRegisters[0].ToString();
                            }
                        }
                        #endregion
                        //
                        //*!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! LW !!!!!!!!!!!!!!!!!!!!!!!!!*//
                        //

                        //
                        //************************************ RW **************************//
                        //
                        #region -----RW------
                        if (set1.dataGridView1.Rows[i].Cells[1].Value.ToString() == "RW")
                        {

                            int[] readHoldingRegisters;
                            try
                            {
                                readHoldingRegisters = modbusClient.ReadInputRegisters(
                                Convert.ToInt32(set1.dataGridView1.Rows[i].Cells[0].Value) + 10000 - 1, 1);
                            }
                            catch (Exception err)
                            {
                                this.Invoke((MethodInvoker)delegate
                                {
                                    log1.listView1.Items.Add(new ListViewItem(new[] { DateTime.Now.ToString(), "please check your Ethernet connection" + err.Message }));
                                });
                                goto wait;
                            }
                            if (readHoldingRegisters[0].ToString() != set1.dataGridView1.Rows[i].Cells[2].Value.ToString())
                            {
                                post.Add(new sqlpost { definition = set1.dataGridView1.Rows[i].Cells[3].Value.ToString(), address = set1.dataGridView1.Rows[i].Cells[0].Value.ToString(), value = readHoldingRegisters[0].ToString(), });
                                set1.dataGridView1.Rows[i].Cells[2].Value = readHoldingRegisters[0].ToString();
                            }
                        }
                        #endregion
                        //
                        //*!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! RW !!!!!!!!!!!!!!!!!!!!!!!!!*//
                        //
                    }
                }
                DateTime dateTime = DateTime.Now;
                string date = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                if (post != null)
                    if (post != null)
                    {
                        string lastitem = null;
                        string connectionString;
                        connectionString = "Server = " + server.servername + "; Port = " + server.sql_port + "; Database = " + server.dbname + "; Uid = " +
                        server.username + "; Pwd = " + server.password + ";";
                        using (MySqlConnection connection = new MySqlConnection(connectionString))
                        {
                            try
                            {
                                connection.Open();
                                foreach (var item in post)
                                {
                                    if (item != null)
                                    {
                                        lastitem = item.definition + "\t" + item.address + "\t" + DateTime.Now.ToString();
                                        MySqlCommand insertCommand = new MySqlCommand("INSERT INTO " + server.tbname + "(deviceID, value, datetime)VALUES(@0, @1, @2)", connection);
                                        insertCommand.Parameters.Add("@0", MySqlDbType.VarChar).Value = item.address;
                                        insertCommand.Parameters.Add("@1", MySqlDbType.Int16).Value = item.value;
                                        insertCommand.Parameters.AddWithValue("@2", date);
                                        insertCommand.ExecuteNonQuery();
                                        SQLerror = false;
                                        this.Invoke((MethodInvoker)delegate
                                        {
                                            log1.listView1.Items.Add(new ListViewItem(new[] { DateTime.Now.ToString(), "Data has added to SQL " }));
                                            dmon1.listView1.Items.Add(new ListViewItem(new[] { item.definition, item.address, item.value, DateTime.Now.ToString() }, "written"));
                                        });
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                if (SQLerror == false)
                                {
                                    this.Invoke((MethodInvoker)delegate
                                    {
                                        log1.listView1.Items.Add(new ListViewItem(new[] { DateTime.Now.ToString(), "sql error:  " + ex.Message }));
                                        sendmail("SQL bağlantı sorunu \n veri =" + lastitem + "\nyazılmadı");
                                    });
                                    SQLerror = true;
                                }
                            }
                        }
                    }
            }
        out_s:
            System.Threading.Thread.Sleep(50);
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Green;
            set1.button1.Enabled = false;
            set1.button1.Enabled = false;
            button1.Text = "Stop System";
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
                runsystem = true;
            }
            else
            {
                backgroundWorker1.Dispose();
                runsystem = false;
            }
        }


        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                button1.Text = "Start System";
                set1.button1.Enabled = true;
                set1.button1.Enabled = true;
            });
            button1.BackColor = Color.Orange;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        private void PictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private Point MouseDownLocation;
        private void Panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }
        private void Panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Left = e.X + this.Left - MouseDownLocation.X;
                this.Top = e.Y + this.Top - MouseDownLocation.Y;
            }
        }
        private void sendmail(string mess)
        {
            if (set1.mailnotification.Checked)
            {
                try
                {
                    //gmail >> smtp server : smtp.gmail.com, port : 587 , ssl required
                    //yahoo >> smtp server : smtp.mail.yahoo.com, port : 587 , ssl required
                    SmtpClient clientDetails = new SmtpClient();
                    clientDetails.Port = Convert.ToInt32(587);
                    clientDetails.Host = "smtp.gmail.com".Trim();
                    clientDetails.EnableSsl = true;
                    clientDetails.DeliveryMethod = SmtpDeliveryMethod.Network;
                    clientDetails.UseDefaultCredentials = false;
                    clientDetails.Credentials = new NetworkCredential("albaelektronikdestek@gmail.com".Trim(), "15Temmuz2016".Trim());
                    MailMessage mailDetails = new MailMessage();
                    mailDetails.From = new MailAddress("albaelektronikdestek@gmail.com".Trim());
                    mailDetails.To.Add(Properties.Settings.Default.mail);
                    //mailDetails.To.Add("another recipient email address");
                    //mailDetails.Bcc.Add("bcc email address")
                    mailDetails.Subject = "Al-Ba Elektronik".Trim();
                    mailDetails.IsBodyHtml = false;
                    mailDetails.Body = mess.Trim();
                    clientDetails.Send(mailDetails);
                }
                catch (Exception)
                {
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void PictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://albaelektronik.com/");
        }
        private void PictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Width = pictureBox2.Width - 20;
            pictureBox2.Height = pictureBox2.Height - 20;
            this.pictureBox2.Location = new Point(this.pictureBox2.Location.X + 10, this.pictureBox2.Location.Y + 10);
        }
        private void PictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Width = pictureBox2.Width + 20;
            pictureBox2.Height = pictureBox2.Height + 20;
            this.pictureBox2.Location = new Point(this.pictureBox2.Location.X - 10, this.pictureBox2.Location.Y - 10);
        }
        string time;
        string time_hour;
        string time_min;
        private void timer1_Tick(object sender, EventArgs e)
        {
            time = DateTime.Now.ToLongTimeString();
            time_hour = time.Substring(0, 2);
            time_min = time.Substring(3, 2);
        }

    }
}