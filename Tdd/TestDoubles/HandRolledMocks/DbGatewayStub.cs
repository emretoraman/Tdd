namespace Tdd.TestDoubles.HandRolledMocks
{
    public class DbGatewayStub : IDbGateway
    {
        private WorkingStatistics _workingStatistics;

        public bool Connected => true;

        public WorkingStatistics GetWorkingStatistics(int id)
        {
            return _workingStatistics;
        }

        public void SetWorkingStatistics(WorkingStatistics workingStatistics)
        {
            _workingStatistics = workingStatistics;
        }
    }
}
