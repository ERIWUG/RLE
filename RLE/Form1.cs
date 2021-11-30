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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public int min(int a,int b)
        {
            return a < b ? a : b;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                string k = textBox1.Text;
                string res = "";
                string pr = k.Substring(0, 1);
                int kol = 1;
                int prev_kol = 0;
                for (int i = 1; i < k.Length; i++)
                {
                    if (k.Substring(i, 1) == pr) { kol += 1; }
                    else
                    {
                        if (prev_kol == 1) { res += pr; }
                        else { res += Convert.ToString(kol) + pr; }
                        pr = k.Substring(i, 1);
                        prev_kol = kol;
                        kol = 1;
                    }
                }
                if (prev_kol == 1) { res += pr; }
                else { res += Convert.ToString(kol) + pr; }
                textBox2.Text = res;
                
            }
            else if(radioButton1.Checked)
            {
                string k = textBox1.Text;
                string s = "↑";
                string res = "";
                string pr = k.Substring(0, 1);
                int kol = 1;
                
                for (int i = 1; i < k.Length; i++)
                {
                    textBox2.Text = textBox1.Text + "\r\n" + s+"\r\n"+res;
                    
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
                    await Task.Delay(Convert.ToInt32(numericUpDown1.Value*100));
                }

                while (kol > 0)
                {
                    res += Convert.ToString(min(kol, 9)) + pr;
                    kol -= min(kol, 9);
                }
                textBox2.Text = res;
            }
            else
            {
                string k = "↑";
                
                for(int i = 0; i <textBox1.Text.Length; i++)
                {
                    textBox2.Text = textBox1.Text + "\r\n" + k;
                    k = "  " + k.Substring(0);
                    await Task.Delay(300);
                }
             
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
    
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked)
            {
                string k = textBox1.Text;
                string s = "↑";
                string res="";
                for (int i = 0; i < k.Length-1; i+=2)
                {
                    for(int j = Convert.ToInt32(k.Substring(i, 1)); j > 0; j--)
                    {
                        s= "  " + s.Substring(0);
                        res += k.Substring(i + 1, 1);
                    }
                    textBox2.Text = k + "\r\n" + s + "\r\n" + res;
                    await Task.Delay(Convert.ToInt32(numericUpDown1.Value * 100));
                }
                textBox2.Text = res;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
