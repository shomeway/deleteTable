using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using MySql.Data.MySqlClient;

namespace deleteTable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            bgwWorker.DoWork += new DoWorkEventHandler(bgwWorker_DoWork);
            bgwWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgwWorker_RunWorkerCompleted);
            bgwWorker.ProgressChanged += new ProgressChangedEventHandler(bgwWorker_ProgressChanged);
            bgwWorker.WorkerReportsProgress = true;
            bgwWorker.WorkerSupportsCancellation = true;
        }

        private bool flag = true;
        private MySqlConnection mConn;
        private MySqlCommand mCommand;
        private MySqlDataReader mReader;
        private List<string> result_List;
        BackgroundWorker bgwWorker = new BackgroundWorker();

        private void button_Ask_Click(object sender, EventArgs e)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            //string sql = "SELECT CONCAT( 'DROP TABLE ', GROUP_CONCAT(table_name) , ';' ) AS statement FROM information_schema.tables WHERE table_schema = 'netflow' AND table_name LIKE '{0}'";
            string sql = "SHOW TABLES FROM netflow LIKE '{0}'";
            try
            {
                int x = Convert.ToInt32(textBox_From.Text);
                this.textBox_Log.Text = "Start Connection";
                Connection();
                result_List = new List<string>();
                //combine query string
                sqlBuilder = new StringBuilder();
                string query = this.textBox_IP.Text.ToString().Replace('.', '_');
                query += "_" + x.ToString() + "%";
                sqlBuilder = sqlBuilder.AppendFormat(sql, query);
                //execute query
                mCommand = new MySqlCommand(sqlBuilder.ToString() + ";", mConn);
                mCommand.CommandTimeout = 120;
                mReader = mCommand.ExecuteReader();
                this.textBox_Log.AppendText("\r\nStart show table : " + query);

                while (mReader.Read())
                {
                    result_List.Add(mReader.GetString(0));
                }

                foreach (string s in result_List)
                {
                    this.textBox_Log.AppendText("\r\n" + s);
                }
                CloseConnection();
                Thread.Sleep(1000);
                this.textBox_Log.Text += "\r\nDone";
            }
            catch (Exception ex)
            {
                this.textBox_Log.Text += ex.Message;
            }
        }

        private void button_Drop_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                this.button_Drop.Text = "Stop";
                flag = false;
                this.textBox_Log.Text = "Start!";
                bgwWorker.RunWorkerAsync();
                this.textBox_Log.AppendText("\r\nComputing...");
            }
            else
            {
                this.button_Drop.Text = "Drop";
                bgwWorker.CancelAsync();
                this.textBox_Log.AppendText("\r\nCanceled!");
                flag = true;
            }
        }

        public void Connection()
        {
            try
            {
                //configs
                string ConnStr = "Database=;Server=127.0.0.1;UserID=;Password=;Port="+textBox_Port.Text.ToString()+";CHARSET=utf8";
                mConn = new MySqlConnection(ConnStr);
                mConn.Open();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void CloseConnection()
        {
            if (mConn != null)
                this.mConn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(this.textBox_Port.Text);

            for (int i = 0; i < count; i++)
            {
                button_Ask.PerformClick();
                Thread.Sleep(3000);
                button_Drop.PerformClick();
            }
        }

        private void bgwWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            
            StringBuilder sqlBuilder = new StringBuilder();
            string sql = "SHOW TABLES FROM netflow LIKE '{0}'";
            string sql2 = "DROP TABLE {0};";
            float current_progress = 0;
            try
            {
                int start_count = Convert.ToInt32(textBox_From.Text);
                for (int i = start_count; i < 1000; i++)
                {
                    if (bgwWorker.CancellationPending)
                    {
                        break;//stop thread
                    }
                    //int opreation always return an int, must convert one of them to float to get a float return
                    current_progress = (i - start_count) / (float)(1000 - start_count) * 100;
                    Connection();//連線
                    result_List = new List<string>();
                    sqlBuilder = new StringBuilder();
                    //combine query string
                    string query = this.textBox_IP.Text.ToString().Replace('.', '_');
                    query += "_" + i.ToString() + "%";
                    sqlBuilder = sqlBuilder.AppendFormat(sql, query);
                    //exceute query
                    mCommand = new MySqlCommand(sqlBuilder.ToString() + ";", mConn);
                    mCommand.CommandTimeout = 180;//wait timeout
                    mReader = mCommand.ExecuteReader();

                    bgwWorker.ReportProgress((int)current_progress,"Start show table : "+query);
                    string result = "";

                    while (mReader.Read())
                    {
                        result = mReader.GetString(0);
                        result_List.Add(mReader.GetString(0));
                    }
                    CloseConnection();
                    Thread.Sleep(1000);

                    //DROP===================================================
                    bgwWorker.ReportProgress((int)current_progress,"Start dropping @ " + query);
                    Connection();
                    sqlBuilder = new StringBuilder();
                    int return_value = 0;
                    query = "";
                    int count = result_List.Count();
                    if (count > 0)
                    {
                        foreach (string s in result_List)
                        {
                            if (count > 1)
                                query += s + ',';
                            else
                                query += s;
                            count--;
                        }

                        sqlBuilder = sqlBuilder.AppendFormat(sql2, query);
                        mCommand = new MySqlCommand(sqlBuilder.ToString(), mConn);
                        mCommand.CommandTimeout = 120;
                        return_value = mCommand.ExecuteNonQuery();
                    }
                    CloseConnection();
                    bgwWorker.ReportProgress((int)current_progress,"Drop done @ " + query);
                    
                }
            }
            catch (Exception ex)
            {
                bgwWorker.ReportProgress((int)current_progress,ex.Message);
            }
        }

        private void bgwWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            
            this.textBox_Log.AppendText("\r\n"+e.UserState.ToString());
        }

        private void bgwWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.textBox_Log.AppendText("\r\nDone");
            if (flag == false)
            {
                this.button_Drop.Text = "Drop";
                flag = true;
            }
        }

        private void progressBar1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(this.progressBar1.Value.ToString(),progressBar1);
        }
    }
}
