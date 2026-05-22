# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Commands

All `dotnet` commands must be run from the `./src` directory.

```bash
dotnet restore
dotnet build --no-restore -warnaserror
dotnet format --verify-no-changes             # check code style (CI enforces this)
dotnet format                                  # auto-fix code style
dotnet test --no-build --verbosity normal --logger trx --collect:"XPlat Code Coverage"
dotnet pack --configuration Release -p:PackageVersion=<version> --output .
```

## Architecture

This is a **concrete-implementation NuGet library** — four `sealed record` types that implement the interfaces from `Pure.Chart.RichRelationalModel.Abstractions` and serve as EF Core entity types.

**Models and their abstractions:**
- `ChartEFCoreModel` → `IChartRichRelationalModel` — root chart aggregate with references to type, axes, and series
- `ChartTypeEFCoreModel` → `IChartTypeRichRelationalModel` — lookup entity for chart kind (e.g. Line, Bar)
- `AxisEFCoreModel` → `IAxisRichRelationalModel` — axis entity with a legend label
- `ChartSeriesEFCoreModel` → `IChartSeriesRichRelationalModel` — series entity mapping legend and axis data sources

**Dual navigation property pattern:** Each model exposes a strongly-typed navigation property (e.g. `ChartTypeEFCoreModel TypeNavigation`) alongside the abstract interface property it satisfies (e.g. `IChartType Type => TypeNavigation`). EF Core binds to the concrete navigation; callers code against the interface.

**FK-only constructor:** `ChartEFCoreModel` has a second constructor that takes only foreign-key IDs — used when EF Core will populate navigation properties from a query.

**Dependency chain:** `Pure.Primitives.Abstractions` → `Pure.Chart.Model.Abstractions` + `Pure.Chart.RelationalModel.Abstractions` → `Pure.Chart.RichRelationalModel.Abstractions` → this library → `Pure.Chart.RichRelationalModel.EFCore.Models.Configurations` → `Pure.Chart.RichRelationalModel.EFCore`

**Multi-targeting:** net7.0, net8.0, net9.0, net10.0. All models must remain AOT-compatible (`IsAotCompatible = true`).

**Package validation:** `EnablePackageValidation = true` with `PackageValidationBaselineVersion = 0.1.0-preview.7.0.0`. Breaking API changes fail the build.

**Tests:** xUnit test project targeting net10.0 only, 99% line-coverage threshold enforced by CI, Stryker mutation testing at 99% threshold.

**Publishing:** triggered by pushing a semver tag matching `*.*.*`. The tag becomes the `PackageVersion`.

## Code Style

Enforced via `.editorconfig` and `dotnet format --verify-no-changes` in CI:

- No `var` — always use explicit types
- No expression-bodied methods, constructors, operators, or local functions — only expression-bodied properties, indexers, accessors, and lambdas
- File-scoped namespace declarations (`namespace Foo.Bar;`)
- `using` directives must appear outside the namespace
- Private fields: `_camelCase` (underscore prefix)
- No implicit `new()` when type is apparent — write `new TypeName()` explicitly
- Max line length: 90 characters
- Parentheses required in arithmetic and relational binary expressions for clarity

## Commit Messages

Do not mention Claude or AI assistance in commit messages.
