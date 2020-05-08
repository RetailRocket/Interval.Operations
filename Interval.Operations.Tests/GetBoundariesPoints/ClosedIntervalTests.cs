namespace OperationsTests.GetBoundariesPoints
{
    using Interval.IntervalBound.LowerBound;
    using Interval.IntervalBound.UpperBound;
    using Operations;
    using Xunit;

    public class ClosedIntervalTests
    {
        [Theory]
        [InlineData(1, 2)]
        [InlineData(-1, -2)]
        public void TwoPointsTest(
            int lowerBoundPoint,
            int upperBoundPoint)
        {
            var closedInterval = new Interval.Interval<int>(
                lowerBound: new ClosedLowerBound<int>(lowerBoundPoint),
                upperBound: new ClosedUpperBound<int>(upperBoundPoint));

            var boundPoints = closedInterval.GetBoundariesPoints();

            Assert.Contains(
                collection: boundPoints,
                expected: lowerBoundPoint);

            Assert.Contains(
                collection: boundPoints,
                expected: upperBoundPoint);
        }
    }
}