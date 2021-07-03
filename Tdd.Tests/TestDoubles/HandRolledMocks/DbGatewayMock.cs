using Tdd.TestDoubles;

namespace Tdd.Tests.TestDoubles.HandRolledMocks
{
    public class DbGatewayMock : IDbGateway
    {
        private WorkingStatistics _workingStatistics;

        public int Id { get; private set; }

        public bool Connected => true;

        public WorkingStatistics GetWorkingStatistics(int id)
        {
            Id = id;
            return _workingStatistics;
        }

        public void SetWorkingStatistics(WorkingStatistics workingStatistics)
        {
            _workingStatistics = workingStatistics;
        }

        public bool VerifyCalledWithCorrectId(int id)
        {
            return Id == id;
        }
    }
}
