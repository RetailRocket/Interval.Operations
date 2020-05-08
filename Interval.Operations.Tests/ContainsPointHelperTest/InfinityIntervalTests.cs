namespace OperationsTests.ContainsPointHelperTest
{
    using System;
    using System.Collections.Generic;
    using Interval.IntervalBound.LowerBound;
    using Interval.IntervalBound.UpperBound;
    using Operations;
    using Operations.Comparers;
    using Xunit;

    public class InfinityIntervalTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(9)]
        [InlineData(-9)]
        [InlineData(int.MinValue)]
        [InlineData(int.MaxValue)]
        public void Contains(
            int point)
        {
            Assert.True(
                condition: new Interval.Interval<int>(
                        lowerBound: new InfinityLowerBound<int>(),
                        upperBound: new InfinityUpperBound<int>())
                    .Contains(
                        point: point,
                        comparer: Comparer<int>.Default));
        }

        [Fact]
        public void Comparer()
        {
            var interval = new Interval.Interval<string>(
                lowerBound: new InfinityLowerBound<string>(),
                upperBound: new InfinityUpperBound<string>());

            Assert.True(
                condition: interval.Contains(
                    point: "B",
                    comparer: StringComparer.Ordinal));

            Assert.True(
                condition: interval.Contains(
                    point: "B",
                    comparer: StringComparer.OrdinalIgnoreCase));
        }
    }
}