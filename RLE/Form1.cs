using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;





namespace RLE
{
    
    public partial class Form1 : Form
    {


        public string k;

        public Form1()
        {
            InitializeComponent();
        }

       
        public int min(int a,int b)
        {
            return a < b ? a : b;
        }
        
        private async void button1_Click(object sender, EventArgs e)
        {
            string k = textBox1.Text;
            string s = "↑";
            string res = "";
            string pr = k.Substring(0, 1);
            int kol = 1;

            for (int i = 1; i < k.Length; i++)
            {
                textBox2.Text = textBox1.Text + "\r\n" + s + "\r\n" + res;

                s = "  " + s.Substring(0);
                if (k.Substring(i, 1) == pr) { kol += 1; }
                else
                {
                    while (kol > 0)
                    {
                        res += Convert.ToString(min(kol, 9)) + pr;
                        kol -= min(kol, 9);
                    }

                    pr = k.Substring(i, 1);

                    kol = 1;
                }
                await Task.Delay(Convert.ToInt32(numericUpDown1.Value * 100));
            }

            while (kol > 0)
            {
                res += Convert.ToString(min(kol, 9)) + pr;
                kol -= min(kol, 9);
            }
            textBox2.Text = res;

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string k = textBox1.Text;
            string s = "↑";
            string res = "";


            for (int i = 0; i < k.Length - 1; i += 2)
            {
                for (int j = Convert.ToInt32(k.Substring(i, 1)); j > 0; j--)
                {
                    s = "  " + s.Substring(0);
                    res += k.Substring(i + 1, 1);
                }
                textBox2.Text = k + "\r\n" + s + "\r\n" + res;
                await Task.Delay(Convert.ToInt32(numericUpDown1.Value * 100));
            }
            textBox2.Text = res;

        }


        private async void textBox1_MouseHover(object sender, EventArgs e)
        {
            string k = "Впишите сюда исходную строку";
            Label l1 = new Label();
            l1.AutoSize = true;
            l1.Location = new System.Drawing.Point(79, 8);
            l1.Name = "l1";
            l1.Size = new System.Drawing.Size(211, 17);
            l1.TabIndex = 11;
            Controls.Add(l1);
            for (int i = 0; i < k.Length; i++)
            {
                l1.Text += k[i];
                await Task.Delay(50);
            }
            

        }
        private async void textBox1_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                Label l1 = Controls.Find("l1", true)[0] as Label;
                int k = l1.Text.Length;
                for (int i = k; i > 1; i--)
                {
                    l1.Text = l1.Text.Substring(0, i - 1);
                    await Task.Delay(50);
                }

                Controls.Remove(Controls.Find("l1", true)[0]);
            }
            catch { };
        }

        private async void textBox2_MouseHover(object sender, EventArgs e)
        {
            Label l2 = new Label();
            l2.AutoSize = true;
            l2.Location = new System.Drawing.Point(366, 5);
            l2.Name = "l2";
            l2.Size = new System.Drawing.Size(24, 17);
            string k = "Тут будет происходить нужное вам действие";
            l2.TabIndex = 11;
            Controls.Add(l2);
            for (int i = 0; i < k.Length; i++)
            {
                l2.Text += k[i];
                await Task.Delay(50);
            }
        }

        private async void textBox2_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                Label l2 = Controls.Find("l2", true)[0] as Label;
                int k = l2.Text.Length;
                for (int i = k; i > 1; i--)
                {
                    l2.Text = l2.Text.Substring(0, i - 1);
                    await Task.Delay(50);
                }
                Controls.Remove(Controls.Find("l2", true)[0]);
            }
            catch { };
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form f = new Form();
            f.AutoSize = true;
            WebBrowser wb1 = new WebBrowser();
            wb1.Location = new System.Drawing.Point(10, 10);
            wb1.MinimumSize = new System.Drawing.Size(20, 20);
            wb1.Name = "webBrowser1";
            wb1.Size = new System.Drawing.Size(456, 288);
            wb1.TabIndex = 12;
            wb1.Url = new System.Uri("file:///C:/Users/ebely/Desktop/KURSACH/RLE/RLE/info.html", System.UriKind.Absolute);
            f.Controls.Add(wb1);
            f.Show();
        }

        
    }
}
