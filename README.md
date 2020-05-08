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

Assert.False(
    condition: interval.Contains(
        point: "B",
        comparer: StringComparer.Ordinal)); // => false

Assert.True(
    condition: interval.Contains(
        point: "B",
        comparer: StringComparer.OrdinalIgnoreCase)); // => false
```

### Get Boundaries Points

```csharp
var interval = new Interval.Interval<int>(
    lowerBound: new ClosedLowerBound<int>(1),
    upperBound: new ClosedUpperBound<int>(2));

var boundPoints = interval.GetBoundariesPoints(); // => [1,2]
```