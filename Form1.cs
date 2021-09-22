using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Regression
{
    public partial class Regexp : Form
    {
        public Regexp()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            //  mail@mail.com                        => ^([\w]+)@([\w]+)\.([\w]+)$
            //  http://www.google.com                => ^(http://www\.)([\w]+)\.([\w]+)$
            //  Phone Number like : 0011 XXX XXX XXX => ^(0011)(([ ][0-9]{3}){3})$
            //  Date XX/XX/XXXX                      => ^([0-9]{2})\/([0-9]{2})\/([0-9]{4})$
            Regex(@"^([\w]+)@([\w]+)\.([\w]+)$", textBox1, pictureBox1, lblemail, "Mail");

            Regex(@"^(http://www\.)([\w]+)\.([\w]+)$", textBox2, pictureBox2, lblewebsite, "Web Site");
            Regex(@"^^(\+91[\-\s]?)?[0]?(91)?[789]\d{9}$", textBox3, pictureBox3, lblephone, "Phone Number");

            Regex(@"^([0-9]{2})\/([0-9]{2})\/([0-9]{4})$", textBox4, pictureBox4, lbledate, "Date");
        }
        public void Regex(String re, TextBox td, PictureBox pc, Label lbl, String s)
        {
            Regex regex = new Regex(re);
            if (regex.IsMatch(td.Text))
            {
                pc.Image = Properties.Resources.valid;
                lbl.ForeColor = Color.Green;
                lbl.Text = s + " is Valid";
            }
            else
            {
                pc.Image = Properties.Resources.invalid;
                lbl.ForeColor = Color.Red;
                lbl.Text = s + " is InValid";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Saved ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
