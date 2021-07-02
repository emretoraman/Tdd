﻿using Tdd.TestDoubles.HandRolledMocks;
using Xunit;

namespace Tdd.TestDoubles
{
    public class CustomerTests
    {
        [Fact]
        public void GetWage_WhenPayHourly_ReturnsCorrectWage()
        {
            DbGatewayStub dbGatewayStub = new();
            dbGatewayStub.SetWorkingStatistics(new WorkingStatistics { PayHourly = true, HourlySalary = 100, WorkingHours = 10 });

            const decimal expected = 100 * 10;

            Customer customer = new(dbGatewayStub, new LoggerDummy());

            Assert.Equal(expected, customer.GetWage(1));
        }

        [Fact]
        public void GetWage_WithId_PassesCorrectId()
        {
            DbGatewaySpy dbGatewaySpy = new();
            dbGatewaySpy.SetWorkingStatistics(new WorkingStatistics());

            Customer customer = new(dbGatewaySpy, new LoggerDummy());
            customer.GetWage(1);

            Assert.Equal(1, dbGatewaySpy.Id);
        }

        [Fact]
        public void GetWage_WithId_PassesCorrectId2()
        {
            DbGatewayMock dbGatewayMock = new();
            dbGatewayMock.SetWorkingStatistics(new WorkingStatistics());

            Customer customer = new(dbGatewayMock, new LoggerDummy());
            customer.GetWage(1);

            Assert.True(dbGatewayMock.VerifyCalledWithCorrectId(1));
        }
    }
}