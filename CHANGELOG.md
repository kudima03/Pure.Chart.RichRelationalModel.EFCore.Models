# Changelog

All notable changes to Pure.Chart.RichRelationalModel.EFCore.Models are documented here.

Format follows [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).

---

## [0.1.0-preview.7.0.0] — 2026-04-26

### Removed
- `AxisEFCoreModel.ChartId` property and the constructor parameter that set it were removed.

## [0.1.0-preview.6.0.0] — 2026-04-20

### Changed
- `SeriesEFCoreModel` renamed to `ChartSeriesEFCoreModel`, now implementing `IChartSeriesRichRelationalModel` (previously `ISeriesRichRelationalModel`).
- `ChartEFCoreModel.SeriesNavigation` and its constructor parameter changed from `ICollection<SeriesEFCoreModel>` to `ICollection<ChartSeriesEFCoreModel>`; `ChartEFCoreModel.Series` now returns `IEnumerable<IChartSeries>`.

## [0.1.0-preview.5.0.0] — 2026-02-27

### Added
- `ChartEFCoreModel.XAxisId` and `ChartEFCoreModel.YAxisId` properties restored, with matching parameters on both the full and lightweight constructors.

## [0.1.0-preview.4.0.0] — 2026-02-18

### Changed
- `ChartEFCoreModel.SeriesNavigation` and its constructor parameter changed from `IEnumerable<SeriesEFCoreModel>` to `ICollection<SeriesEFCoreModel>` to support EF Core change tracking.

## [0.1.0-preview.3.1.0] — 2026-02-18

### Added
- `ChartEFCoreModel` gained a lightweight constructor, `ChartEFCoreModel(IGuid id, IString title, IString description, IGuid typeId)`, for use without navigation properties.

## [0.1.0-preview.3.0.0] — 2026-02-16

### Removed
- `ChartEFCoreModel.XAxisId` and `ChartEFCoreModel.YAxisId` properties and their constructor parameters removed as redundant with the axis navigation properties.

## [0.1.0-preview.2.0.0] — 2026-02-16

- Maintenance release: dependency and build updates.

## [0.1.0-preview.1.0.0] — 2026-02-14

### Changed
- `AxisEFCoreModel` constructor and record now also carry a `ChartId` property.

## [0.1.0-preview.0.1.0] — 2026-02-12

### Added
- Initial release: `ChartEFCoreModel`, `ChartTypeEFCoreModel`, `AxisEFCoreModel`, and `SeriesEFCoreModel` — EF Core-mapped implementations of the `Pure.Chart.RichRelationalModel.Abstractions` interfaces (`IChartRichRelationalModel`, `IChartTypeRichRelationalModel`, `IAxisRichRelationalModel`, `ISeriesRichRelationalModel`) with EF Core navigation properties for the `Chart`, `ChartType`, `Axis`, and `Series` relations.
