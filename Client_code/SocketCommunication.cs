using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Smart_building
{
    public class SocketCommunication : IDisposable
    {
        private Socket sender;
        private byte[] bytes = new byte[1024];

        public string CurrentString { get; private set; }
        public bool IsReceiving { get; private set; }

        public async Task StartReceivingFromServerAsync()
        {
            CurrentString = await Task.Run(() => StartServer());
        }

        public void StopReceivingFromServer()
        {
            StopServer();
        }

        public async Task CollectValuesAsync()
        {
            CurrentString = await Task.Run(() => KeepCollectingValues());
        }

        private string StartServer()
        {
            string currentString = string.Empty;

            try
            {
                //IPHostEntry host = Dns.GetHostEntry("localhost");
                //IPAddress ipAddress = host.AddressList[0];

                IPAddress ipAddress = IPAddress.Parse("169.254.88.165");
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11800);

                sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    sender.Connect(remoteEP);
                    System.Windows.Forms.MessageBox.Show($"Socket connected to {sender.RemoteEndPoint.ToString()}");
                    currentString = KeepCollectingValues();
                }
                catch (Exception ex)
                {
                    HandleException("Error connecting to remote endpoint", ex);
                }
            }
            catch (Exception ex)
            {
                HandleException("Error initializing socket", ex);
            }

            return currentString;
        }

        private string KeepCollectingValues()
        {
            string currentString = string.Empty;

            try
            {
                int bytesRec = sender.Receive(bytes);
                currentString = Encoding.ASCII.GetString(bytes, 0, bytesRec);
            }
            catch (Exception ex)
            {
                HandleException("Error receiving data", ex);
            }

            return currentString;
        }

        private void StopServer()
        {
            try
            {
                sender?.Shutdown(SocketShutdown.Both);
                sender?.Close();
            }
            catch (Exception ex)
            {
                HandleException("Error stopping server", ex);
            }
        }

        private void HandleException(string message, Exception ex)
        {

            System.Windows.Forms.MessageBox.Show($" {message}: {ex.Message}");
            Environment.Exit(1);
        }

        public void Dispose()
        {
            sender?.Dispose();
        }
    }
}
