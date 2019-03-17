using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace ServerReverseString
{
    public interface ITransport
    {
        void Bind(string address, int port);
        bool Send(byte[] data, EndPoint endPoint);
        byte[] Recv(int bufferSize, ref EndPoint sender);
        EndPoint CreateEndPoint();
    }
}
