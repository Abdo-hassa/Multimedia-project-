using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace multiMedisa
{
    public partial class Form1 : Form
    {
        public string s,s_out="";
        string output = "";
        string output1 = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void open_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd=new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                 s = File.ReadAllText(ofd.FileName);
                txt_data.Text = s;
            }
        }

        private void convert_Click(object sender, EventArgs e)
        {
            int c = 1;
            
            for (int i = 0; i < s.Length; i++)
            {
                if (i < s.Length - 1)
                {
                    if (s[i] == s[i + 1])
                        c++;
                    else
                    {
                        s_out += c;
                        s_out += s[i];
                        c = 1;
                    }

                }
                else
                {
                    s_out += c;
                    s_out += s[i];
                }   
                
            }
            File.WriteAllText(@"D:\RLC.txt",s_out);
            out_put.Text = s_out;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> dic = new List<string>();
            List<int> code = new List<int>();
            dic.Add("a");
            dic.Add("b");
            dic.Add("c");
            code.Add(1);
            code.Add(2);
            code.Add(3);
            int count = 4;
            string c ="";
            string next = "";
            
            c = s[0].ToString();
                              
            for (int i = 0; i < s.Length ; i++) {
                if (i < s.Length - 1)
                {
                    next = s[i + 1].ToString();
                    if (!dic.Contains(c + next))
                    {
                        dic.Add(c + next);
                        code.Add(count++);
                        output += code.ElementAt(dic.IndexOf(c));
                        c = next;
                    }
                    else
                    {
                        c = c + next;
                    }
                }
                else
                {
                    output += code.ElementAt(dic.IndexOf(c));
                }

            }
            File.WriteAllText(@"D:\Dictionary.txt", output);
            out_put.Text = output;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           char[]s1=s.ToArray();
           Array.Sort(s1);
           string s2="";
           s2 = string.Join("", s1.Distinct());
           List<string> vls = new List<string>();
           List<string> vls1 = new List<string>();
           List<int> vlc = new List<int>();
           int c=1;
           for (int i = 0; i < s.Length; i++)
           {
               if (i < s.Length - 1)
               {
                   if (s1[i] == s1[i + 1])
                       c++;
                   else
                   {
                       vls.Add(s1[i].ToString());

                       vlc.Add(c);
                       c = 1;
                   }

               }
               else
               {
                   vls.Add(s1[i].ToString());
                   vlc.Add(c); 
               }
           }
           for (int i = 0; i < vlc.Count; i++)
           {
               int m= vlc.Max();
               m = vlc.IndexOf(m);
               vls1.Add(vls[m]);
               vlc[m] = 0;
           }
           vls.Clear();
           string str = "0";
           string str2 = "";
            for (int i = 0; i < vls1.Count; i++)
           {
               if (vls1.Count > i+1)
               {
                   vls.Add (str);
                   str += "1";
                   str2 += "1";
               }
               else
               {
                   vls.Add(str2);
               }
           }

           for (int i = 0; i < s.Length; i++) {
               int m=vls1.IndexOf(s[i].ToString());
               output1 += vls[m];
           }
           File.WriteAllText(@"D:\VLC.txt", output1);
           out_put.Text = output1;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_data_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
