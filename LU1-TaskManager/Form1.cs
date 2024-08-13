using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LU1_TaskManager
{
    public partial class Form1 : Form
    {
        int processId;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var runningProcs = from proc in Process.GetProcesses(".")
                               orderby proc.ProcessName
                               select proc;

            foreach (var p in runningProcs)
            {
                listBox1.Items.Add(string.Format("-> PID: {0} \t Name: {1} ", p.Id, p.ProcessName));
            }
        }

        private void btnStartChrome_Click(object sender, EventArgs e)
        {
            Process chromeProc;
            try
            {
                ProcessStartInfo startInfor = new ProcessStartInfo("chrome.exe", "www.varsitycollege.co.za");
                startInfor.WindowStyle = ProcessWindowStyle.Maximized;
                chromeProc = Process.Start(startInfor);
                processId = chromeProc.Id;
                //MessageBox.Show(porcessId.ToString());
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnKillChrome_Click(object sender, EventArgs e)
        {
            Process[] chromeProc = Process.GetProcessesByName("chrome");
            try
            {
                foreach (Process p in chromeProc)
                {
                    p.Kill();
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEndTaskMng_Click(object sender, EventArgs e)
        {
            Process p = Process.GetCurrentProcess();
            try 
            {
                p.Kill();
            }
            catch (InvalidOperationException ex) 
            { 
                Console.WriteLine(ex.Message);
            }
        }

        private void btnThreads_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a process first.");
                return;
            }

            string id = listBox1.SelectedItem.ToString().Substring(8, 5);
            string newId = new string(id.Where(c => char.IsDigit(c)).ToArray());
            int i = Convert.ToInt32(newId);

            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(i);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (theProc != null)
            {
                string info = "";
                ProcessThreadCollection theThreads = theProc.Threads;
                foreach (ProcessThread pt in theThreads)
                {
                    info += string.Format("-> Thread ID: {0}\tStart Time: {1}\tPriority: {2} \n", pt.Id, pt.StartTime.ToShortTimeString(), pt.PriorityLevel);
                }
                MessageBox.Show(info);
            }
        }

        private void btnLoadedModules_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a process first.");
                return;
            }

            string id = listBox1.SelectedItem.ToString().Substring(8, 5);
            string newId = new string(id.Where(c => char.IsDigit(c)).ToArray());
            int i = Convert.ToInt32(newId);

            //MessageBow.Show("'" + newId + "'");

            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(i);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }

            string info = "";
            
            ProcessModuleCollection theMods = theProc.Modules;
            foreach (ProcessModule pm in theMods)
            {

                info += string.Format("-> Module Name: {0} \n", pm.ModuleName);
            }
            MessageBox.Show(info);
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            AppDomain defaultAD = AppDomain.CurrentDomain;

            string output = "";
            output += "Name of this domain: " + defaultAD.FriendlyName + "\n";
            output += "ID of domain in this process: " + defaultAD.Id + "\n";
            output += "Is this the default domain? " + defaultAD.IsDefaultAppDomain() + "\n";
            output += "Base directory of this domain: " + defaultAD.BaseDirectory;

            MessageBox.Show(output);
        }

        private void btnAssemblies_Click(object sender, EventArgs e)
        {
            AppDomain defaultAD = AppDomain.CurrentDomain;

            Assembly[] loadedAssemblies = defaultAD.GetAssemblies();
            string output = "Assemblies loaded in " + defaultAD.FriendlyName;

            foreach (Assembly a in loadedAssemblies)
            {
                output += "-> Name: " + a.GetName().Name + "\n";
                output += "-> Version: " + a.GetName().Version + "\n";
            }
            MessageBox.Show(output);

        }
    }
}