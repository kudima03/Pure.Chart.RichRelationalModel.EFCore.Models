# Pure.Chart.RichRelationalModel.EFCore.Models

EF Core entity record implementations of the chart rich relational model for the **Pure** ecosystem.

[![.NET build & test](https://github.com/kudima03/Pure.Chart.RichRelationalModel.EFCore.Models/actions/workflows/build-and-test.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Chart.RichRelationalModel.EFCore.Models/actions/workflows/build-and-test.yml)
[![Build and Deploy](https://github.com/kudima03/Pure.Chart.RichRelationalModel.EFCore.Models/actions/workflows/publish-nuget.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Chart.RichRelationalModel.EFCore.Models/actions/workflows/publish-nuget.yml)
[![NuGet](https://img.shields.io/nuget/v/Pure.Chart.RichRelationalModel.EFCore.Models)](https://www.nuget.org/packages/Pure.Chart.RichRelationalModel.EFCore.Models)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

## Overview

`Pure.Chart.RichRelationalModel.EFCore.Models` provides four `sealed record` types that implement the interfaces from [`Pure.Chart.RichRelationalModel.Abstractions`](https://github.com/kudima03/Pure.Chart.RichRelationalModel.Abstractions/tree/0.1.0-preview.4.0.0) and are designed to be used as EF Core entity types.

Each model exposes both a strongly-typed navigation property (e.g. `ChartTypeEFCoreModel TypeNavigation`) that EF Core can bind to, and an abstract interface property (e.g. `IChartType Type`) that delegates to the navigation property — allowing callers to program against the abstraction while EF Core works with the concrete type.

## Models

| Class | Implements | Properties |
|---|---|---|
| `ChartEFCoreModel` | `IChartRichRelationalModel` | `Id`, `Title`, `Description`, `TypeId`, `TypeNavigation`/`Type`, `XAxisId`, `XAxisNavigation`/`XAxis`, `YAxisId`, `YAxisNavigation`/`YAxis`, `SeriesNavigation`/`Series` |
| `ChartTypeEFCoreModel` | `IChartTypeRichRelationalModel` | `Id`, `Name` |
| `ChartSeriesEFCoreModel` | `IChartSeriesRichRelationalModel` | `Id`, `ChartId`, `Legend`, `XAxisSource`, `YAxisSource` |
| `AxisEFCoreModel` | `IAxisRichRelationalModel` | `Id`, `Legend` |

All types live in the `Pure.Chart.RichRelationalModel.EFCore.Models` namespace.

## Design Principles

- **Immutable** — all properties are get-only; values are set via constructor only.
- **Dual surface** — typed navigation properties satisfy EF Core; interface properties satisfy calling code.
- **AOT-compatible** — `IsAotCompatible = true`; no reflection-based patterns.

## Dependencies

- [`Pure.Chart.RichRelationalModel.Abstractions`](https://github.com/kudima03/Pure.Chart.RichRelationalModel.Abstractions/tree/0.1.0-preview.4.0.0) — chart rich relational model interfaces (`IChartRichRelationalModel`, `IAxisRichRelationalModel`, `IChartSeriesRichRelationalModel`, `IChartTypeRichRelationalModel`)

## Target Frameworks

- .NET 7
- .NET 8
- .NET 9
- .NET 10

## Installation

```
dotnet add package Pure.Chart.RichRelationalModel.EFCore.Models
```

## Usage

```csharp
using Pure.Chart.RichRelationalModel.Abstractions;
using Pure.Chart.RichRelationalModel.EFCore.Models;

// Construct with navigation objects for in-memory use or testing
IChartRichRelationalModel chart = new ChartEFCoreModel(
    id:              guid,
    title:           title,
    description:     description,
    typeId:          typeId,
    typeNavigation:  new ChartTypeEFCoreModel(typeId, typeName),
    xAxisId:         xAxisId,
    xAxisNavigation: new AxisEFCoreModel(xAxisId, xAxisLegend),
    yAxisId:         yAxisId,
    yAxisNavigation: new AxisEFCoreModel(yAxisId, yAxisLegend),
    seriesNavigation: []
);

// Or use the FK-only constructor when EF Core will populate navigations
ChartEFCoreModel chartFk = new ChartEFCoreModel(
    id, title, description, typeId, xAxisId, yAxisId
);
```
