using System;
using System.Linq;
using System.Net.NetworkInformation;
using Autofac;
using portstatus.IoC;
using PortStatusApp;

namespace portstatus
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Bootstrap().InitialiseContainer();
            var _nw = container.Resolve<INetworking>();
            _nw.ShowTcpStatistics(NetworkInterfaceComponent.IPv4);
            _nw.ShowTcpStatistics(NetworkInterfaceComponent.IPv6);
            int port;
            if (int.TryParse(args.First(), out port))
            {
                Console.WriteLine(_nw.GetPortStatusString(port));
            }
        }
    }
}
