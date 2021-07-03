using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Tdd.TestDoubles
{
    public class DeviceTests
    {
        [Theory]
        [InlineData("")]
        public void Connect_WhenProtocolConnectReturnsFalse_CallsProtocolConnectThreeTimes(string port)
        {
            Mock<IProtocol> mockProtocol = new();
            mockProtocol.Setup(p => p.Connect(port))
                .Returns(false);
            //mockProtocol.Setup(m => m.Connect(It.Is<string>(p => p == port)))
            //    .Returns(false);

            Device device = new(mockProtocol.Object);
            device.Connect(port);

            mockProtocol.Verify(p => p.Connect(port), Times.Exactly(3));
        }

        [Theory]
        [InlineData("")]
        public void Find_WhenProtocolWillFinishSearching_ReturnsCorrectTask(string port)
        {
            Mock<IProtocol> mockProtocol = new();

            Device device = new(mockProtocol.Object);
            Task<string> findTask = device.Find();

            mockProtocol.Raise(p => p.SearchingFinished += null, new DeviceSearchingEventArgs(port));

            Assert.True(findTask.IsCompletedSuccessfully);
            Assert.Equal(port, findTask.Result);
        }
    }
}
