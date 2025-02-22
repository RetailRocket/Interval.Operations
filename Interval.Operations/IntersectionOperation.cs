namespace Operations
{
    using System.Collections.Generic;
    using Interval;
    using Operations.Comparers;
    using Optional;

    public static class IntersectionOperation
    {
        public static Option<Interval<TPoint>> Intersect<TPoint>(
            this Interval<TPoint> left,
            Interval<TPoint> right,
            IComparer<TPoint> comparer)
        {
            if (!left.IsConnected(
                second: right,
                comparer: comparer))
            {
                return Option.None<Interval<TPoint>>();
            }

            var lowerBoundComparer = new LowerBoundComparer<TPoint>(
                comparer: comparer);

            var lowerBound = lowerBoundComparer.Compare(
                                 left: left.LowerBound,
                                 right: right.LowerBound) <= 0
                ? left.LowerBound
                : right.LowerBound;

            var upperBoundComparer = new UpperBoundComparer<TPoint>(
                comparer: comparer);

            var upperBound = upperBoundComparer.Compare(
                                 left: left.UpperBound,
                                 right: right.UpperBound) <= 0
                ? right.UpperBound
                : left.UpperBound;

            return new Interval<TPoint>(
                    lowerBound: lowerBound,
                    upperBound: upperBound)
                .Some();
        }
    }
}