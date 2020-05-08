namespace OperationsTests.IsConnected
{
    using System.Collections.Generic;
    using Interval;
    using Interval.IntervalBound.LowerBound;
    using Interval.IntervalBound.UpperBound;
    using Operations;
    using Xunit;

    public class InfinityIntervalTests
    {
        [Fact]
        public void AlwaysConnected()
        {
            var infinityInterval = new Interval.Interval<int>(
                lowerBound: new InfinityLowerBound<int>(),
                upperBound: new InfinityUpperBound<int>());

            var isConnected = infinityInterval.IsConnected(
                second: new Interval<int>(
                    lowerBound: new InfinityLowerBound<int>(),
                    upperBound: new InfinityUpperBound<int>()),
                comparer: Comparer<int>.Default);

            Assert.True(isConnected);
        }
    }
}