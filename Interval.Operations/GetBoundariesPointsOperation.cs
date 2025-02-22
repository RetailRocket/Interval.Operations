namespace Operations
{
    using System.Collections.Generic;
    using Interval;
    using Interval.IntervalBound;

    public static class GetBoundariesPointsOperation
    {
        public static List<TPoint> GetBoundariesPoints<TPoint>(
            this Interval<TPoint> interval)
        {
            var result = new List<TPoint>();
            if (interval.LowerBound is IPointedBound<TPoint> lowePointedBound)
            {
                result.Add(lowePointedBound.Point);
            }

            if (interval.UpperBound is IPointedBound<TPoint> upperPointedBound)
            {
                result.Add(upperPointedBound.Point);
            }

            return result;
        }
    }
}