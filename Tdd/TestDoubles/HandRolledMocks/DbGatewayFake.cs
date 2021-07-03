using System.Collections.Generic;

namespace Tdd.TestDoubles.HandRolledMocks
{
    public class DbGatewayFake : IDbGateway
    {
        private static readonly Dictionary<int, WorkingStatistics> _storage = new()
        {
            { 1, new WorkingStatistics { PayHourly = true, HourlySalary = 100, WorkingHours = 10 } },
            { 2, new WorkingStatistics { PayHourly = false, MonthlySalary = 1000 } },
            { 3, new WorkingStatistics { PayHourly = true, HourlySalary = 50, WorkingHours = 5 } }
        };

        public bool Connected => true;

        public WorkingStatistics GetWorkingStatistics(int id)
        {
            return _storage[id];
        }
    }
}
