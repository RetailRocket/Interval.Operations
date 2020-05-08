namespace OperationsTests.GetBoundariesPoints
{
    using Interval.IntervalBound.LowerBound;
    using Interval.IntervalBound.UpperBound;
    using Operations;
    using Xunit;

    public class OpenIntervalTests
    {
        [Theory]
        [InlineData(1, 2)]
        [InlineData(-1, -2)]
        public void TwoPointsTest(
            int lowerBoundPoint,
            int upperBoundPoint)
        {
            var openInterval = new Interval.Interval<int>(
                lowerBound: new OpenLowerBound<int>(lowerBoundPoint),
                upperBound: new OpenUpperBound<int>(upperBoundPoint));

            var boundPoints = openInterval.GetBoundariesPoints();

            Assert.Contains(
                collection: boundPoints,
                expected: lowerBoundPoint);

            Assert.Contains(
                collection: boundPoints,
                expected: upperBoundPoint);
        }
    }
}