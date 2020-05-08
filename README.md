![.NET Core](https://github.com/RetailRocket/Interval.Operations/workflows/.NET%20Core/badge.svg)
[![NuGet version](https://img.shields.io/nuget/v/Interval.Operations.svg?style=flat-square)](https://www.nuget.org/packages/Interval.Operations/)

# Interval.Operations
Library of operations for interval type from [Interval Library](https://github.com/RetailRocket/Interval). There are operations of comparisons for low and upper boundary and for entry interval, operation to check interval on containing point etc.

### Usage ###

### Contains Point Operation

```csharp
var openInterval = new Interval<int>(
    lowerBound: new OpenLowerBound<int>(0),
    upperBound: new OpenUpperBound<int>(10));

openInterval.Contains(
    point: 5,
    comparer: Comparer<int>.Default) // => true

openInterval.Contains(
    point: 11,
    comparer: Comparer<int>.Default) // => false

```

#### Different Comparer

```csharp
var interval = new Interval.Interval<string>(
    lowerBound: new OpenLowerBound<string>("a"),
    upperBound: new OpenUpperBound<string>("z"));

interval.Contains(
    point: "B",
    comparer: StringComparer.Ordinal) // => false

interval.Contains(
    point: "B",
    comparer: StringComparer.OrdinalIgnoreCase); // => false
```

### Get Boundaries Points

```csharp
new Interval<int>(
        lowerBound: new ClosedLowerBound<int>(1),
        upperBound: new ClosedUpperBound<int>(2))
    .GetBoundariesPoints(); // -> [1,2]
```

### Boundary Comparer
You can compare deferent types of lower or upper boundary

```csharp
new LowerBoundComparer<int>(
        comparer: Comparer<int>.Default)
    .Compare(
        left: new ClosedLowerBound<int>(10),
        right: new ClosedLowerBound<int>(11)); // -> 1
```

The same for upper boundary

```csharp
new UpperBoundComparer<int>(
        comparer: Comparer<int>.Default)
    .Compare(
        left: new ClosedUpperBound<int>(10),
        right: new ClosedUpperBound<int>(11)); // -> 1
```

### Interval Comparer

```csharp
var intervalA = new Interval.Interval<int>(
    lowerBound: new ClosedLowerBound<int>(0),
    upperBound: new ClosedUpperBound<int>(10));

var intervalB = new Interval.Interval<int>(
    lowerBound: new ClosedLowerBound<int>(1),
    upperBound: new ClosedUpperBound<int>(9));

new IntervalComparer<int>(
        comparer: Comparer<int>.Default)
    .Compare(
        left: intervalA,
        right: intervalB); // -> -1
```