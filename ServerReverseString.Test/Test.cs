using System;
using System.Text;
using System.Net;
using NUnit.Framework;
using System.Collections.Generic;

namespace ServerReverseString.Test
{
    class Test
    {
        private Server server;
        private FakeTransport transport;
        private FakeEndPoint client;

        [SetUp]
        public void SetUpTest()
        {
            transport = new FakeTransport();
            server = new Server(transport);
            client = new FakeEndPoint("client", 0);
        }

        [Test]
        public void TestWork()
        {
            FakeData data = new FakeData();
            data.data = Encoding.UTF8.GetBytes("cane");
            data.endPoint = client;

            transport.ClientEnqueue(data);
            server.SingleStep();

            string revertedString = Encoding.UTF8.GetString(transport.ClientDequeue().data);

            Assert.That("enac", Is.EqualTo(revertedString));
        }

        [Test]
        public void TestEmptyQueue()
        {
            Assert.That(() => transport.ClientDequeue(), Throws.InstanceOf<FakeQueueEmpty>());
        }
    }
}
