using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DokanNet;

namespace FakeDiskDrive
{
    public partial class NewDrive : Form
    {
        public bool IsOK = false;

        public VirtualDrive Drive;

        public NewDrive()
        {
            InitializeComponent();
        }

        private void NewDrive_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1) return;

            string driveLetter = comboBox1.SelectedItem.ToString() + @":";

            string label = textBox1.Text;

            string fs = textBox2.Text;

            long b1 = Convert.ToInt64(numericUpDown1.Value);

            long b2 = Convert.ToInt64(numericUpDown2.Value);

            long b3 = Convert.ToInt64(numericUpDown3.Value);

            DokanOptions o = DokanOptions.FixedDrive;

            foreach(int i in checkedListBox1.CheckedIndices)
            {
                 DokanOptions[] v = (DokanOptions[])Enum.GetValues(typeof(DokanOptions));
                o |= v[i];
            }
            Drive = new VirtualDrive(driveLetter, fs, label, b1, b2, b3, o);
            IsOK = true;
            Close();
        }
    }
}
