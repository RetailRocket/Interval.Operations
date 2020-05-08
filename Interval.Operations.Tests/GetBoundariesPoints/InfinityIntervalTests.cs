namespace OperationsTests.GetBoundariesPoints
{
    using Interval.IntervalBound.LowerBound;
    using Interval.IntervalBound.UpperBound;
    using Operations;
    using Xunit;

    public class InfinityIntervalTests
    {
        [Fact]
        public void NoPointsTest()
        {
            var infinityInterval = new Interval.Interval<int>(
                lowerBound: new InfinityLowerBound<int>(),
                upperBound: new InfinityUpperBound<int>());

            var boundPoints = infinityInterval.GetBoundariesPoints();

            Assert.Empty(
                collection: boundPoints);
        }
    }
}