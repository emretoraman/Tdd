using System;
using System.Threading.Tasks;

namespace Tdd.TestDoubles
{
    public class Device
    {
        private readonly IProtocol _protocol;
        private readonly TaskCompletionSource<string> _deviceSearchingTask = new();

        public Device(IProtocol protocol)
        {
            _protocol = protocol;
        }

        public string PortName { get; }

        public Task<string> Find()
        {
            _protocol.SearchingFinished += Protocol_SearchingFinished;

            Task.Factory.StartNew(() => { _protocol.SearchForDevice(); });

            return _deviceSearchingTask.Task;
        }

        public bool Connect(string port)
        {
            for (int i = 0; i < 3; i++)
            {
                if (_protocol.Connect(port))
                {
                    return true;
                }
            }
            return false;
        }

        private void Protocol_SearchingFinished(object sender, DeviceSearchingEventArgs e)
        {
            _deviceSearchingTask.SetResult(e.Port);
        }
    }

    public interface IProtocol
    {
        event EventHandler<DeviceSearchingEventArgs> SearchingFinished;

        bool Connect(string port);

        void SearchForDevice();
    }

    public class DeviceSearchingEventArgs : EventArgs
    {
        public DeviceSearchingEventArgs(string port)
        {
            Port = port;
        }

        public string Port { get; }
    }
}
