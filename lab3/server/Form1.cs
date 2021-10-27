using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace server
{
    public partial class Form1 : Form
    {
        //private TcpListener listener = null;
        private Thread listener = null;
        private bool active = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Log(string msg) // clear the log if message is not supplied or is empty
        {
            logTextBox.Invoke((MethodInvoker)delegate
            {
                logTextBox.AppendText(msg + "\n");
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (active)
            {
                active = false;
            }
            else
            {
                listener = new Thread(() => Listener());
                listener.Start();
            }

        }

        private void Listener()
        {
            TcpListener listener = null;
            try
            {
                listener = new TcpListener(IPAddress.Any, 5555);
                listener.Start();
                Active(true);
                while (active)
                {
                    if (listener.Pending())
                    {
                        try
                        {
                            TcpClient client = listener.AcceptTcpClient();
                            Log("Client has connected");
                            Server server = new Server(client);
                            Thread thread = new Thread(new ThreadStart(server.Process));
                            thread.Start();
                        }
                        catch (Exception ex)
                        {
                            Log("Error: " + ex.Message);
                        }
                    }
                }
                Active(false);
            }
            catch (Exception ex)
            {
                Log("Error: " + ex.Message);
            }
            finally
            {
                if (listener != null)
                {
                    listener.Stop();
                }
            }
        }

        private void Active(bool status)
        {
            startButton.Invoke((MethodInvoker)delegate
            {
                active = status;
                if (status)
                {
                    startButton.Text = "Stop";
                    Log("Server has started");
                }
                else
                {
                    startButton.Text = "Start";
                    Log("Server has stopped");
                }
            });

        }
    }
}
