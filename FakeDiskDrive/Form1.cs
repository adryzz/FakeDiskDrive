using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DokanNet;

namespace FakeDiskDrive
{
    public partial class Form1 : Form
    {
        List<VirtualDrive> Drives = new List<VirtualDrive>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListBoxWriter w = new ListBoxWriter(listBox2);
            Console.SetOut(w);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0) return;
            UpdateStatus(Drives.ElementAt(listBox1.SelectedIndex));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewDrive d = new NewDrive();
            d.ShowDialog();
            if (d.IsOK)
            {
                new Thread(new ThreadStart(() => { d.Drive.Mount(d.Drive.DriveLetter, d.Drive.Options); })).Start();
                Drives.Add(d.Drive);
                listBox1.Items.Add(d.Drive.DriveLetter + " -  Mounted");
                UpdateStatus(d.Drive);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dokan.Unmount(Drives.ElementAt(listBox1.SelectedIndex).DriveLetter.ToCharArray()[0]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var d = Drives.ElementAt(listBox1.SelectedIndex);
            new Thread(new ThreadStart(() => { d.Mount(d.DriveLetter, d.Options); })).Start();
            UpdateStatus(d);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0) return;
            Dokan.Unmount(Drives.ElementAt(listBox1.SelectedIndex).DriveLetter.ToCharArray()[0]);
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void UpdateStatus(VirtualDrive d)
        {
            label2.Text = String.Format("Drive letter: {0}\nFile system: {1}\nLabel: {2}\nTotal number of bytes: {3}\nTotal number of free bytes: {4}\nFree bytes available: {5}", d.DriveLetter, d.FileSystem, d.Label, d.TotalNumberOfBytes, d.TotalNumberOfFreeBytes, d.FreeBytesAvailable);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            int i = Dokan.DriverVersion;
        }
    }
}
