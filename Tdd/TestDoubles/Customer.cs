namespace Tdd.TestDoubles
{
    public class Customer
    {
        private readonly IDbGateway _dbGateway;
        private readonly ILogger _logger;

        public Customer(IDbGateway dbGateway, ILogger logger)
        {
            _dbGateway = dbGateway;
            _logger = logger;
        }

        public int GetWage(int id)
        {
            if (!_dbGateway.Connected) return 0;

            WorkingStatistics workingStatistics;
            try
            {
                workingStatistics = _dbGateway.GetWorkingStatistics(id);
            }
            catch 
            {
                return 0;
            }

            int wage;
            if (workingStatistics.PayHourly)
            {
                wage = workingStatistics.HourlySalary * workingStatistics.WorkingHours;
            }
            else
            {
                wage = workingStatistics.MonthlySalary;
            }
            _logger.Info($"Customer ID={id}, Wage={wage}");

            return wage;
        }
    }

    public interface ILogger
    {
        void Info(string log);
    }

    public interface IDbGateway
    {
        WorkingStatistics GetWorkingStatistics(int id);
        bool Connected { get; }
    }

    public class WorkingStatistics
    {
        public bool PayHourly { get; set; }
        public int WorkingHours { get; set; }
        public int HourlySalary { get; set; }
        public int MonthlySalary { get; set; }
    }
}
