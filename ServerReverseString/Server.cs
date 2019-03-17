using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ServerReverseString
{
    public class Server
    {
        private ITransport transport;

        public Server(ITransport transport)
        {
            this.transport = transport;
        }

        public void Run()
        {
            while (true)
            {
                SingleStep();
            }
        }

        public void SingleStep()
        {
            EndPoint sender = transport.CreateEndPoint();
            byte[] data = transport.Recv(256, ref sender);
            if (data != null)
            {
                Array.Reverse(data);
                transport.Send(data, sender);
            }
        }
    }
}
