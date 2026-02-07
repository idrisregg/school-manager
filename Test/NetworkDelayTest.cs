using System;
using System.Diagnostics;
using Xunit;
using Dap.Helper;

namespace Dap.Test
{
    public class NetworkDelayTests
    {
        [Fact]
        public void MinDelay_DefaultValue_ShouldBe1000()
        {
            Assert.Equal(1000, NetworkDelay.MinDelay);
        }

        [Fact]
        public void MaxDelay_DefaultValue_ShouldBe5000()
        {
            Assert.Equal(5000, NetworkDelay.MaxDelay);
        }

        [Fact]
        public void MinDelay_SetValidValue_ShouldUpdate()
        {
            NetworkDelay.MinDelay = 2000;
            Assert.Equal(2000, NetworkDelay.MinDelay);

            NetworkDelay.MinDelay = 1000;
        }

        [Fact]
        public void MinDelay_SetLessThan1000_ShouldThrowException()
        {
            var exception = Assert.Throws<Exception>(() => NetworkDelay.MinDelay = 500);
            Assert.Equal("Minimum Delay cannot be Less than 1000ms", exception.Message);
        }

        [Fact]
        public void MaxDelay_SetValidValue_ShouldUpdate()
        {
            NetworkDelay.MaxDelay = 3000;
            Assert.Equal(3000, NetworkDelay.MaxDelay);

            NetworkDelay.MaxDelay = 5000;
        }

        [Fact]
        public void MaxDelay_SetMoreThan5000_ShouldThrowException()
        {
            var exception = Assert.Throws<Exception>(() => NetworkDelay.MaxDelay = 6000);
            Assert.Equal("Maximum Delay cannot be more than 5000ms", exception.Message);
        }

        [Fact]
        public void SimulateNetworkDelay_ShouldDelayBetweenMinAndMax()
        {
            var sw = Stopwatch.StartNew();

            NetworkDelay.SimulateNetworkDelay();

            sw.Stop();
            
            Assert.InRange(sw.ElapsedMilliseconds, 900, 5100); 
        }

        [Fact]
        public void PayEntity_ShouldUpdateBalance()
        {
            int balance = 100;

            NetworkDelay.PayEntity("Employee", "John", ref balance, 50);

            Assert.Equal(150, balance);
        }

        [Fact]
        public void PayEntity_ShouldIncludeDelay()
        {
            int balance = 0;
            var sw = Stopwatch.StartNew();

            NetworkDelay.PayEntity("Employee", "Jane", ref balance, 100);

            sw.Stop();
            Assert.InRange(sw.ElapsedMilliseconds, 900, 5100);
            Assert.Equal(100, balance);
        }
    }
}