namespace Tdd.TestDoubles.HandRolledMocks
{
    public class DbGatewaySpy : IDbGateway
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
    }
}
