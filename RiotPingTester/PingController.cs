using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;
namespace RiotPingTester
{
    public class PingController
    {
        private string IPAddress;
        private byte[] Buffer;
        private Ping PingBase = new Ping();
        private PingOptions PingOptions;
        
        public PingController(string ip, int BufferSize, bool Fragment)
        {
            this.IPAddress = ip;
            if (BufferSize % 8 != 0)
                throw new Exception("The Buffer Size must be divisable by 8");
            Buffer = new byte[BufferSize];
            new Random().NextBytes(Buffer); //Just use Random Data for the Buffer.
            PingOptions = new PingOptions(128, !Fragment); //!Fragment because the actuall parameter is "DontFragment"; 128 TTL is standard.
        }
        public long PingHost()
        {
            PingReply PingReply = PingBase.Send(this.IPAddress, 120, this.Buffer, this.PingOptions);
            if (PingReply.Status == IPStatus.Success)
            {
                return PingReply.RoundtripTime;
            }
            return -1l;
        }
    }
}
