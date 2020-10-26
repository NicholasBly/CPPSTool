using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace CPPS_Unlocker
{
    public partial class Form1 : Form
    {
        string Version = "1.2";
        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        // constants for the mouse_input() API function
        private const int MOUSEEVENTF_MOVE = 0x0001;
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const int MOUSEEVENTF_RIGHTUP = 0x0010;
        private const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        private const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        private const int MOUSEEVENTF_ABSOLUTE = 0x8000;

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        string color, color2;
        string[] colors = {"0000FF", "FF0000", "00FF00", "FFFF00", "00FFFF", "FF00FF"};
        string errormsg = "You are not on CPPS! Make sure CPPS is the active page or make sure your browser is Google Chrome or Mozilla Firefox";
        public Form1()
        {
            InitializeComponent();
        }
        bool isCPPSActive()
        {
            WindowState = FormWindowState.Minimized;
            IntPtr hWnd = GetForegroundWindow();
            uint procId = 0;
            GetWindowThreadProcessId(hWnd, out procId);
            var proc = Process.GetProcessById((int)procId);
            string process = proc.ToString();
            WindowState = FormWindowState.Normal;
            if(process.Contains("chrome") || process.Contains("firefox"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isCPPSActive())
            {
                WindowState = FormWindowState.Minimized;
                for (int i = (int)numericUpDown2.Value; i <= numericUpDown1.Value; i++)
                {
                    Clipboard.SetText("!ai " + i);
                    SendKeys.Send("^{v}");
                    SendKeys.Send("{ENTER}");
                    System.Threading.Thread.Sleep(1600);
                    mouse_event(MOUSEEVENTF_LEFTDOWN, Control.MousePosition.X, Control.MousePosition.Y, 0, 0);
                    mouse_event(MOUSEEVENTF_LEFTUP, Control.MousePosition.X, Control.MousePosition.Y, 0, 0);
                    mouse_event(MOUSEEVENTF_LEFTDOWN, Control.MousePosition.X, Control.MousePosition.Y, 0, 0);
                    mouse_event(MOUSEEVENTF_LEFTUP, Control.MousePosition.X, Control.MousePosition.Y, 0, 0);
                    SendKeys.Send("{TAB}");
                }
                WindowState = FormWindowState.Normal;
            }
            else
            {
                MessageBox.Show(errormsg);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("In the first box, enter the ID of the item you want to start at. In the second box, enter the ID of the item you want to stop unlocking at. Keep your cursor over the 'OK' button so that it will click OK.");
        }
        Dictionary<string, string> Values = new Dictionary<string, string>()
            {
                {"Town" , "jr 100" }, 
                {"Coffee Shop" , "jr 110" }, 
                {"Book Room" , "jr 111" }, 
                {"Dance Club" , "jr 120" }, 
                {"Lounge" , "jr 121" }, 
                {"Recycling Plant" , "jr 122" }, 
                {"Gift Shop" , "jr 130" }, 
                {"Ski Village" , "jr 200" }, 
                {"Sport Shop" , "jr 210" }, 
                {"Facillity" , "jr 211" }, 
                {"Phoning Facillity" , "jr 212" }, 
                {"VR Room" , "jr 213" }, 
                {"Ski Lodge" , "jr 220" }, 
                {"Lodge Attic" , "jr 221" }, 
                {"Ski Hill" , "jr 230" }, 
                {"Plaza" , "jr 300" }, 
                {"Pet Shop" , "jr 310" }, 
                {"Dojo" , "jr 320" }, 
                {"Dojo Courtyard" , "jr 321" }, 
                {"Ninja Hideout" , "jr 322" }, 
                {"EPF Command Room" , "jr 323" }, 
                {"Pizza Parlor" , "jr 330" }, 
                {"Stage" , "jr 340" }, 
                {"Beach" , "jr 400" }, 
                {"Light House" , "jr 410" }, 
                {"Beacon" , "jr 411" }, 
                {"Rockhopper Ship" , "jr 420" }, 
                {"Ship Hold" , "jr 421" }, 
                {"Captain’s Quarters" , "jr 422" }, 
                {"Crow Nest" , "jr 423" }, 
                {"Dock" , "jr 800" }, 
                {"Snow Forts" , "jr 801" }, 
                {"Stadium" , "jr 802" }, 
                {"HQ" , "jr 803" }, 
                {"Boilder Room" , "jr 804" }, 
                {"Iceberg" , "jr 805" }, 
                {"Cave" , "jr 806" }, 
                {"Mine Shank" , "jr 807" }, 
                {"Mine" , "jr 808" }, 
                {"Forest" , "jr 809" }, 
                {"Cove" , "jr 810" }, 
                {"Box Dimension" , "jr 811" }, 
                {"Fire Dojo" , "jr 812" }, 
                {"Cave Mine" , "jr 813" }, 
                {"Hidden Lake" , "jr 814" }, 
                {"UnderWater Room" , "jr 815" }, 
                {"Water Dojo" , "jr 816" }, 
                {"HoeDown" , "jr 851" }, 
                {"Haunted House" , "jr 852" }, 
                {"Dark Swamp" , "jr 853" }, 
                {"Maze1" , "jr 854" }, 
                {"Maze2" , "jr 855" }, 
                {"Maze3" , "jr 856" }, 
                {"Maze4" , "jr 857" }, 
                {"Maze5" , "jr 858" }, 
                {"Maze6" , "jr 859" }, 
                {"Maze7" , "jr 860" }, 
                {"Maze8" , "jr 861" }, 
                {"Maze9" , "jr 862" }, 
                {"Maze Finish" , "jr 863" }, 
                {"Beneath The Volcano" , "jr 864" }, 
                {"Dragon Duel Room" , "jr 867" }, 
                {"Dragon Gold Room" , "jr 868" }, 
                {"Astro" , "jr 900" }, 
                {"Beans" , "jr 901" }, 
                {"Puffle" , "jr 902" }, 
                {"Biscuit" , "jr 903" }, 
                {"Fish" , "jr 904" }, 
                {"Minecar1" , "jr 905" }, 
                {"JetPack" , "jr 906" }, 
                {"Mission1" , "jr 907" }, 
                {"Mission2" , "jr 908" }, 
                {"ThinIce" , "jr 909" }, 
                {"PizzaTron" , "jr 910" }, 
                {"Mission3" , "jr 911" }, 
                {"Wave" , "jr 912" }, 
                {"Mission4" , "jr 913" }, 
                {"Mission5" , "jr 914" }, 
                {"Mission6" , "jr 915" }, 
                {"SubGame" , "jr 916" }, 
                {"BookGame1" , "jr 917" }, 
                {"BookGame2" , "jr 918" }, 
                {"BookGame3" , "jr 919" }, 
                {"Mission7" , "jr 920" }, 
                {"Mission8" , "jr 921" }, 
                {"Mission9" , "jr 922" }, 
                {"Mission10" , "jr 923" }, 
                {"Game24" , "jr 924" }, 
                {"Game25" , "jr 925" }, 
                {"MixMaster" , "jr 926" }, 
                {"Mission11" , "jr 927" }, 
                {"Puffle Soaker" , "jr 941" }, 
                {"Balloon Pop" , "jr 942" }, 
                {"Ring The Bell" , "jr 943" }, 
                {"Feed a Puffle" , "jr 944" }, 
                {"Memory Cards" , "jr 945" }, 
                {"Puffle Paddle" , "jr 946" }, 
                {"Puffle Shuffle" , "jr 947" }, 
                {"Grab and Spin" , "jr 948" }, 
                {"Puffle Rescue" , "jr 949" }, 
                {"System Defender" , "jr 950" }, 
                {"Sensei" , "jr 951" }, 
                {"Dancing" , "jr 952" }, 
                {"Fire Sensei" , "jr 953" }, 
                {"Water Sensei" , "jr 954" }, 
                {"Fire" , "jr 997" }, 
                {"Party19" , "jr 999" }, 
                {"Party20" , "jr 1000" },
                {"Party21" , "jr 1001" },
                {"Party22" , "jr 1002" },
                {"Party23", "jr 1003" }};
        void joinroom()
        {
                WindowState = FormWindowState.Minimized;
                Clipboard.SetText("!" + Values[comboBox1.Text]);
                SendKeys.Send("{TAB}");
                SendKeys.Send("^{v}");
                SendKeys.Send("{ENTER}");
                WindowState = FormWindowState.Normal;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (isCPPSActive())
            {
                joinroom();
            }
            else
            {
                MessageBox.Show(errormsg);
            }
        }
        private static String HexConverter(System.Drawing.Color c)
        {
            return c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (isCPPSActive())
            {
                MessageBox.Show("Set the text color first, then the glow.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult result = colorDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    color = HexConverter(colorDialog1.Color);
                }
                DialogResult result2 = colorDialog2.ShowDialog();
                if (result2 == DialogResult.OK)
                {
                    color2 = HexConverter(colorDialog2.Color);
                }
                WindowState = FormWindowState.Minimized;
                Clipboard.SetText("!NG " + color + " " + color2);
                SendKeys.Send("{TAB}");
                SendKeys.Send("^{v}");
                SendKeys.Send("{ENTER}");
                WindowState = FormWindowState.Normal;
            }
            else
            {
                MessageBox.Show(errormsg);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (isCPPSActive())
            {
                MessageBox.Show("Set the text color first, then the bubble.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult result = colorDialog3.ShowDialog();
                if (result == DialogResult.OK)
                {
                    color = HexConverter(colorDialog3.Color);
                }
                DialogResult result2 = colorDialog4.ShowDialog();
                if (result2 == DialogResult.OK)
                {
                    color2 = HexConverter(colorDialog4.Color);
                }
                WindowState = FormWindowState.Minimized;
                Clipboard.SetText("!BC " + color + " " + color2);
                SendKeys.Send("{TAB}");
                SendKeys.Send("^{v}");
                SendKeys.Send("{ENTER}");
                WindowState = FormWindowState.Normal;
            }
            else
            {
                MessageBox.Show(errormsg);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (isCPPSActive())
            {
                WindowState = FormWindowState.Minimized;
                Clipboard.SetText("!SPEED " + numericUpDown3.Value);
                SendKeys.Send("{TAB}");
                SendKeys.Send("^{v}");
                SendKeys.Send("{ENTER}");
                WindowState = FormWindowState.Normal;
            }
            else
            {
                MessageBox.Show(errormsg);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if(isCPPSActive())
            {
            WindowState = FormWindowState.Minimized;
            for (int i = (int)numericUpDown4.Value; i <= numericUpDown5.Value; i++)
            {
                Clipboard.SetText("!af " + i);
                SendKeys.Send("^{v}");
                SendKeys.Send("{ENTER}");
                System.Threading.Thread.Sleep(1600);
                mouse_event(MOUSEEVENTF_LEFTDOWN, Control.MousePosition.X, Control.MousePosition.Y, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, Control.MousePosition.X, Control.MousePosition.Y, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTDOWN, Control.MousePosition.X, Control.MousePosition.Y, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, Control.MousePosition.X, Control.MousePosition.Y, 0, 0);
                SendKeys.Send("{TAB}");
            }
            WindowState = FormWindowState.Normal;
            }
            else
            {
                MessageBox.Show(errormsg);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (isCPPSActive())
            {
                WindowState = FormWindowState.Minimized;
                for (int i = (int)numericUpDown6.Value; i <= numericUpDown7.Value; i++)
                {
                    Clipboard.SetText("!as " + i);
                    SendKeys.Send("^{v}");
                    SendKeys.Send("{ENTER}");
                    System.Threading.Thread.Sleep(1600);
                }
                WindowState = FormWindowState.Normal;
            }
            else
            {
                MessageBox.Show(errormsg);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (isCPPSActive())
            {
                WindowState = FormWindowState.Minimized;
                Clipboard.SetText("!AC " + numericUpDown8.Value);
                SendKeys.Send("{TAB}");
                SendKeys.Send("^{v}");
                SendKeys.Send("{ENTER}");
                WindowState = FormWindowState.Normal;
            }
            else
            {
                MessageBox.Show(errormsg);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (isCPPSActive())
            {
                WindowState = FormWindowState.Minimized;
                Clipboard.SetText("!PIN " + numericUpDown9.Value);
                SendKeys.Send("{TAB}");
                SendKeys.Send("^{v}");
                SendKeys.Send("{ENTER}");
                WindowState = FormWindowState.Normal;
            }
            else
            {
                MessageBox.Show(errormsg);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (isCPPSActive())
            {
                WindowState = FormWindowState.Minimized;
                Clipboard.SetText("!ROOMID");
                SendKeys.Send("{TAB}");
                SendKeys.Send("^{v}");
                SendKeys.Send("{ENTER}");
                WindowState = FormWindowState.Normal;
            }
            else
            {
                MessageBox.Show(errormsg);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (isCPPSActive())
            {
                DialogResult result = colorDialog5.ShowDialog();
                if (result == DialogResult.OK)
                {
                    color = HexConverter(colorDialog5.Color);
                }
                WindowState = FormWindowState.Minimized;
                Clipboard.SetText("!COLOR " + color);
                SendKeys.Send("{TAB}");
                SendKeys.Send("^{v}");
                SendKeys.Send("{ENTER}");
                WindowState = FormWindowState.Normal;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (isCPPSActive())
            {
                WindowState = FormWindowState.Minimized;
                Clipboard.SetText("!PING");
                SendKeys.Send("{TAB}");
                SendKeys.Send("^{v}");
                SendKeys.Send("{ENTER}");
                WindowState = FormWindowState.Normal;
            }
            else
            {
                MessageBox.Show(errormsg);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (isCPPSActive())
            {
                WindowState = FormWindowState.Minimized;
                Clipboard.SetText("!UPTIME");
                SendKeys.Send("{TAB}");
                SendKeys.Send("^{v}");
                SendKeys.Send("{ENTER}");
                WindowState = FormWindowState.Normal;
            }
            else
            {
                MessageBox.Show(errormsg);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (isCPPSActive())
            {
                WindowState = FormWindowState.Minimized;
                Clipboard.SetText("!COUNT");
                SendKeys.Send("{TAB}");
                SendKeys.Send("^{v}");
                SendKeys.Send("{ENTER}");
                WindowState = FormWindowState.Normal;
            }
            else
            {
                MessageBox.Show(errormsg);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (isCPPSActive())
            {
                WindowState = FormWindowState.Minimized;
                for (int i = 0; i < 100; i++ )
                {
                    SendKeys.SendWait("e");
                    SendKeys.SendWait("t");
                }
                WindowState = FormWindowState.Normal;
            }
            else
            {
                MessageBox.Show(errormsg);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (isCPPSActive())
            {
                WindowState = FormWindowState.Minimized;
                Clipboard.SetText("!CLONE " + textBox1.Text);
                SendKeys.Send("{TAB}");
                SendKeys.Send("^{v}");
                SendKeys.Send("{ENTER}");
                WindowState = FormWindowState.Normal;
            }
            else
            {
                MessageBox.Show(errormsg);
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (isCPPSActive())
            {
                MessageBox.Show("Don't abuse this, mods might kick you from the server lel\n\nPress '\' key to stop.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                WindowState = FormWindowState.Minimized;
                for (int i = 0; i < 9999999; i++)
                {
                    Clipboard.SetText("!COLOR " + colors[i]); // blue
                    SendKeys.Send("{TAB}");
                    SendKeys.Send("^{v}");
                    SendKeys.Send("{ENTER}");
                    Thread.Sleep(700);
                    if (Control.ModifierKeys == Keys.OemBackslash)
                    {
                        break;
                    }
                }
                WindowState = FormWindowState.Normal;
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Process.Start("http://media.cpps.me/play/loader_r15_2016.swf");
        }

        private void button20_Click_1(object sender, EventArgs e)
        {
            if (isCPPSActive())
            {
                WindowState = FormWindowState.Minimized;
                Clipboard.SetText("!SANTA");
                SendKeys.Send("{TAB}");
                SendKeys.Send("^{v}");
                SendKeys.Send("{ENTER}");
                WindowState = FormWindowState.Normal;
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (isCPPSActive())
            {
                WindowState = FormWindowState.Minimized;
                Clipboard.SetText("!CAR");
                SendKeys.Send("{TAB}");
                SendKeys.Send("^{v}");
                SendKeys.Send("{ENTER}");
                WindowState = FormWindowState.Normal;
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            //CADENCE
            //GARY
            //AUNT ARCTIC
            //G BILLY
            //FRANKY
            //STOMPIN BOB
            //PETEY K
            //ROCKHOPPER
            if (isCPPSActive())
            {
                if (comboBox2.SelectedIndex == 0)
                {
                    WindowState = FormWindowState.Minimized;
                    Clipboard.SetText("!UP BILLYBOB");
                    SendKeys.Send("{TAB}");
                    SendKeys.Send("^{v}");
                    SendKeys.Send("{ENTER}");
                    WindowState = FormWindowState.Normal;
                }
                if (comboBox2.SelectedIndex == 1)
                {
                    WindowState = FormWindowState.Minimized;
                    Clipboard.SetText("!UP SCREENHOG");
                    SendKeys.Send("{TAB}");
                    SendKeys.Send("^{v}");
                    SendKeys.Send("{ENTER}");
                    WindowState = FormWindowState.Normal;
                }
                if (comboBox2.SelectedIndex == 2)
                {
                    WindowState = FormWindowState.Minimized;
                    Clipboard.SetText("!UP HAPPY77");
                    SendKeys.Send("{TAB}");
                    SendKeys.Send("^{v}");
                    SendKeys.Send("{ENTER}");
                    WindowState = FormWindowState.Normal;
                }
                if (comboBox2.SelectedIndex == 3)
                {
                    WindowState = FormWindowState.Minimized;
                    Clipboard.SetText("!UP GIZMO");
                    SendKeys.Send("{TAB}");
                    SendKeys.Send("^{v}");
                    SendKeys.Send("{ENTER}");
                    WindowState = FormWindowState.Normal;
                }
                if (comboBox2.SelectedIndex == 4)
                {
                    WindowState = FormWindowState.Minimized;
                    Clipboard.SetText("!UP RSNAIL");
                    SendKeys.Send("{TAB}");
                    SendKeys.Send("^{v}");
                    SendKeys.Send("{ENTER}");
                    WindowState = FormWindowState.Normal;
                }
                if (comboBox2.SelectedIndex == 5)
                {
                    WindowState = FormWindowState.Minimized;
                    Clipboard.SetText("!UP ROOKIE");
                    SendKeys.Send("{TAB}");
                    SendKeys.Send("^{v}");
                    SendKeys.Send("{ENTER}");
                    Clipboard.SetText("!up a 1783");
                    SendKeys.Send("{TAB}");
                    SendKeys.Send("^{v}");
                    SendKeys.Send("{ENTER}");
                    WindowState = FormWindowState.Normal;
                }
                if (comboBox2.SelectedIndex == 6)
                {
                    WindowState = FormWindowState.Minimized;
                    Clipboard.SetText("!UP CADENCE");
                    SendKeys.Send("{TAB}");
                    SendKeys.Send("^{v}");
                    SendKeys.Send("{ENTER}");
                    WindowState = FormWindowState.Normal;
                }
                if (comboBox2.SelectedIndex == 7)
                {
                    WindowState = FormWindowState.Minimized;
                    Clipboard.SetText("!UP GARY");
                    SendKeys.Send("{TAB}");
                    SendKeys.Send("^{v}");
                    SendKeys.Send("{ENTER}");
                    WindowState = FormWindowState.Normal;
                }
                if (comboBox2.SelectedIndex == 8)
                {
                    WindowState = FormWindowState.Minimized;
                    Clipboard.SetText("!UP AA");
                    SendKeys.Send("{TAB}");
                    SendKeys.Send("^{v}");
                    SendKeys.Send("{ENTER}");
                    WindowState = FormWindowState.Normal;
                }
                if (comboBox2.SelectedIndex == 9)
                {
                    WindowState = FormWindowState.Minimized;
                    Clipboard.SetText("!UP GB");
                    SendKeys.Send("{TAB}");
                    SendKeys.Send("^{v}");
                    SendKeys.Send("{ENTER}");
                    WindowState = FormWindowState.Normal;
                }
                if (comboBox2.SelectedIndex == 10)
                {
                    WindowState = FormWindowState.Minimized;
                    Clipboard.SetText("!UP FRANKY");
                    SendKeys.Send("{TAB}");
                    SendKeys.Send("^{v}");
                    SendKeys.Send("{ENTER}");
                    WindowState = FormWindowState.Normal;
                }
                if (comboBox2.SelectedIndex == 11)
                {
                    WindowState = FormWindowState.Minimized;
                    Clipboard.SetText("!UP SB");
                    SendKeys.Send("{TAB}");
                    SendKeys.Send("^{v}");
                    SendKeys.Send("{ENTER}");
                    WindowState = FormWindowState.Normal;
                }
                if (comboBox2.SelectedIndex == 12)
                {
                    WindowState = FormWindowState.Minimized;
                    Clipboard.SetText("!UP PK");
                    SendKeys.Send("{TAB}");
                    SendKeys.Send("^{v}");
                    SendKeys.Send("{ENTER}");
                    WindowState = FormWindowState.Normal;
                }
                if (comboBox2.SelectedIndex == 13)
                {
                    WindowState = FormWindowState.Minimized;
                    Clipboard.SetText("!UP RH");
                    SendKeys.Send("{TAB}");
                    SendKeys.Send("^{v}");
                    SendKeys.Send("{ENTER}");
                    WindowState = FormWindowState.Normal;
                }
                if (comboBox2.SelectedIndex == 14)
                {
                    WindowState = FormWindowState.Minimized;
                    Clipboard.SetText("!UP Sensei");
                    SendKeys.Send("{TAB}");
                    SendKeys.Send("^{v}");
                    SendKeys.Send("{ENTER}");
                    WindowState = FormWindowState.Normal;
                }
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (isCPPSActive())
            {
                WindowState = FormWindowState.Minimized;
                Clipboard.SetText("!WOW");
                SendKeys.Send("{TAB}");
                SendKeys.Send("^{v}");
                SendKeys.Send("{ENTER}");
                WindowState = FormWindowState.Normal;
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (isCPPSActive())
            {
                WindowState = FormWindowState.Minimized;
                Clipboard.SetText("!WOW OFF");
                SendKeys.Send("{TAB}");
                SendKeys.Send("^{v}");
                SendKeys.Send("{ENTER}");
                WindowState = FormWindowState.Normal;
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (isCPPSActive())
            {
                DialogResult result = colorDialog6.ShowDialog();
                if (result == DialogResult.OK)
                {
                    color = HexConverter(colorDialog6.Color);
                }
                WindowState = FormWindowState.Minimized;
                Clipboard.SetText("!PC " + color);
                SendKeys.Send("{TAB}");
                SendKeys.Send("^{v}");
                SendKeys.Send("{ENTER}");
                WindowState = FormWindowState.Normal;
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (isCPPSActive())
            {
                WindowState = FormWindowState.Minimized;
                Clipboard.SetText("!SUMMON");
                SendKeys.Send("{TAB}");
                SendKeys.Send("^{v}");
                SendKeys.Send("{ENTER}");
                WindowState = FormWindowState.Normal;
            }
            else
            {
                MessageBox.Show(errormsg);
            }
        }

        private void getItemIDsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.cpitems.com");
            WindowState = FormWindowState.Minimized;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Current Version: " + Version);
        }

        private void cPPSmeCustomClothingIDsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.speedycppshq.com/cppsme-custom-items/");
            WindowState = FormWindowState.Minimized;  
        }
    }
}
