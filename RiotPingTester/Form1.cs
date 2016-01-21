using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RiotPingTester
{
    public partial class Form1 : Form
    {
        delegate void UpdatePingCallback(string Text);
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            switch(this.comboBox1.SelectedItem.ToString())
            {
                case "NA" :
                    {
                        for (int i = 0; i < int.Parse(this.comboBox2.SelectedItem.ToString()); i++)
                        {
                            PingController PC = new PingController("104.160.131.1", 32, false);
                            await Task.Run(() => { this.UpdatePingResponse("NA1: " + PC.PingHost().ToString() + "ms\r\n"); });
                            await Task.Delay(500); //Add delay as not to spam ping Rito Games.
                        }
                        break;
                    };
                case "EUW" :
                    {
                        for (int i = 0; i < int.Parse(this.comboBox2.SelectedItem.ToString()); i++)
                        {
                            PingController PC = new PingController("185.40.65.1", 32, false);
                            PingController PC1 = new PingController("162.249.72.1", 32, false);
                            await Task.Run(() => { 
                                this.UpdatePingResponse("EUW1: " + PC.PingHost().ToString() + "ms\r\n");
                                this.UpdatePingResponse("EUW2: " + PC1.PingHost().ToString() + "ms\r\n"); 
                            });
                            await Task.Delay(500); //Add delay as not to spam ping Rito Games.
                        }
                        break;
                    };
                case "EUNE" :
                    {
                        for (int i = 0; i < int.Parse(this.comboBox2.SelectedItem.ToString()); i++)
                        {
                            PingController PC = new PingController("31.186.224.42", 32, false);
                            PingController PC1 = new PingController("95.172.65.100", 32, false);
                            await Task.Run(() =>
                            {
                                this.UpdatePingResponse("EUNE1: " + PC.PingHost().ToString() + "ms\r\n");
                                this.UpdatePingResponse("EUNE2: " + PC1.PingHost().ToString() + "ms\r\n");
                            });
                            await Task.Delay(500); //Add delay as not to spam ping Rito Games.
                        }
                        break;
                    };
                case "OCE" :
                    {
                        for (int i = 0; i < int.Parse(this.comboBox2.SelectedItem.ToString()); i++)
                        {
                            PingController PC = new PingController("103.240.227.5", 32, false);
                            PingController PC1 = new PingController("103.240.227.25", 32, false);
                            await Task.Run(() =>
                            {
                                this.UpdatePingResponse("OCE1: " + PC.PingHost().ToString() + "ms\r\n");
                                this.UpdatePingResponse("OCE2: " + PC1.PingHost().ToString() + "ms\r\n");
                            });
                            await Task.Delay(500); //Add delay as not to spam ping Rito Games.
                        }
                        break;
                    };
            }
            
        }
        private void UpdatePingResponse(string text)
        {
            if (this.richTextBox1.InvokeRequired)
            {
                UpdatePingCallback d = new UpdatePingCallback(UpdatePingResponse);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.richTextBox1.Text += text;
            }
        }
    }
}
