using System.Net.NetworkInformation;

namespace PortStatusApp
{
    public interface INetworking
    {
        bool IsTcpPortListening(int port);
        bool IsTcpPortConnected(int port);
        string GetPortStatusString(int port);
        void ShowTcpStatistics(NetworkInterfaceComponent version);
    }
}