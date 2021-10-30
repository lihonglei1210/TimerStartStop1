using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;


namespace 定时启动关闭应用程序
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            button1_Click(null,null);
        }
       
        static int jishi;
        static Process proc;
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "启动")
            {
                try
                {
                    proc_Start();
                    
                    button1.Text = "停止";
                    notifyIcon1_MouseDoubleClick(null, null);
                }
                catch (ArgumentException ex)
                {
                    
                    MessageBox.Show(ex.Message);
                }
                
            }
            else
            {
                timer1.Enabled = false;
                try
                {
                    proc.Kill();
                    
                }
                catch (Exception)
                {

                   
                }
                jishi = 0;
                label1.Text = jishi.ToString();
                button1.Text = "启动";
            }

           
        }
        void proc_AutoStart(object sender, EventArgs e)
        {
            Thread.Sleep(5000);
            proc.EnableRaisingEvents = false;
            proc_Start();
        }

        private void proc_Start()
        {
            proc = new Process();
            proc.StartInfo.FileName = textBox1.Text;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            proc.Start();

            //proc.
            timer1.Enabled = true;
            timer1.Start();
            
        }
      
        private void timer1_Tick(object sender, EventArgs e)
        {
              jishi = jishi+1;
              label1.Text = jishi.ToString();
              if (textBox2.Text!="")
              switch (comboBox1.Text)
              {
                  case "秒":
                    int a= Convert.ToInt32(textBox2.Text);
                      if (jishi > a+1 || jishi == a+1)
                      {
                            
                            jishi = 0;
                            label1.Text = jishi.ToString();
                            timer1.Enabled = false;
                            try
                            {
                                proc.Kill();
                            }
                            catch (Exception)
                            { 

                                
                            }
                           
                            proc_AutoStart(null, null);
                            
                        }
                          break;
                  case "分":
                      int b = Convert.ToInt32(textBox2.Text);
                      b = b * 60;
                      if (jishi > b+1 || jishi == b+1)
                      {
                            
                            jishi = 0;
                            label1.Text = jishi.ToString();
                            timer1.Enabled = false;
                            try
                            {
                                proc.Kill();
                            }
                            catch (Exception)
                            {

                                
                            }

                            proc_AutoStart(null, null);

                      }
                      break;

                  case "时":
                      int c = Convert.ToInt32(textBox2.Text);
                      c = c*60*60;
                      if (jishi > c+1 || jishi == c+1)
                      {
                          
                            jishi = 0;
                            label1.Text = jishi.ToString();
                            timer1.Enabled = false;
                            try
                            {
                                proc.Kill();
                            }
                            catch (Exception)
                            {

                               
                            }

                            proc_AutoStart(null, null);
                      }
                      break;
              }
            if (button2.BackColor == Color.Green)
            {
                button2.BackColor = Color.Red;
            }
            else
            {
                button2.BackColor = Color.Green;
            }
         
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.Visible)
            {
                this.Hide();
            }
            else
            {
                this.Show();
            }

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            notifyIcon1_MouseDoubleClick(null,null);
        }
    }
}
