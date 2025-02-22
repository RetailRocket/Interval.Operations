namespace Operations.Comparers
{
    using System;
    using System.Collections.Generic;
    using Interval.IntervalBound;
    using Interval.IntervalBound.UpperBound;

    public class UpperBoundComparer<TPoint>
        : IComparer<IUpperBound<TPoint>>
    {
        private readonly IComparer<TPoint> comparer;

        public UpperBoundComparer(
            IComparer<TPoint> comparer)
        {
            this.comparer = comparer;
        }

        public int Compare(
            IUpperBound<TPoint> left,
            IUpperBound<TPoint> right)
        {
            switch (left)
            {
                case InfinityUpperBound<TPoint> _ when right is InfinityUpperBound<TPoint>:
                    return 0;
                case IPointedBound<TPoint> _ when right is InfinityUpperBound<TPoint>:
                    return -1;
                case InfinityUpperBound<TPoint> _ when right is IPointedBound<TPoint>:
                    return 1;
            }

            var leftPointedBorder = (IPointedBound<TPoint>)left;
            var rightPointedBorder = (IPointedBound<TPoint>)right;

            var resultOfComparisonsPointedBorders = this.comparer
                .Compare(
                    x: leftPointedBorder.Point,
                    y: rightPointedBorder.Point);

            if (resultOfComparisonsPointedBorders != 0)
            {
                return resultOfComparisonsPointedBorders;
            }

            switch (left)
            {
                case OpenUpperBound<TPoint> _ when right is OpenUpperBound<TPoint>:
                case ClosedUpperBound<TPoint> _ when right is ClosedUpperBound<TPoint>:
                    return 0;
                case ClosedUpperBound<TPoint> _ when right is OpenUpperBound<TPoint>:
                    return 1;
                case OpenUpperBound<TPoint> _ when right is ClosedUpperBound<TPoint>:
                    return -1;
            }

            throw new AggregateException(string.Empty);
        }
    }
}