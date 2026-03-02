using Pure.Chart.RelationalModel.Abstractions;
using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;
using Guid = Pure.Primitives.Guid.Guid;
using String = Pure.Primitives.String.String;

namespace Pure.Chart.RichRelationalModel.EFCore.Models.Tests;

public sealed record SeriesEFCoreModelTests
{
    [Fact]
    public void ConstructorAssignsId()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new String("Series 1");
        IString xAxisSource = new String("Time");
        IString yAxisSource = new String("Value");

        ISeriesRelationalModel model = new SeriesEFCoreModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource
        );

        Assert.Equal(id.GuidValue, model.Id.GuidValue);
    }

    [Fact]
    public void ConstructorAssignsChartId()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new String("Series 1");
        IString xAxisSource = new String("Time");
        IString yAxisSource = new String("Value");

        ISeriesRelationalModel model = new SeriesEFCoreModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource
        );

        Assert.Equal(chartId.GuidValue, model.ChartId.GuidValue);
    }

    [Fact]
    public void ConstructorAssignsLegend()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new String("Series 1");
        IString xAxisSource = new String("Time");
        IString yAxisSource = new String("Value");

        ISeriesRelationalModel model = new SeriesEFCoreModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource
        );

        Assert.Equal(legend.TextValue, model.Legend.TextValue);
    }

    [Fact]
    public void ConstructorAssignsXAxisSource()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new String("Series 1");
        IString xAxisSource = new String("Time");
        IString yAxisSource = new String("Value");

        ISeriesRelationalModel model = new SeriesEFCoreModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource
        );

        Assert.Equal(xAxisSource.TextValue, model.XAxisSource.TextValue);
    }

    [Fact]
    public void ConstructorAssignsYAxisSource()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new String("Series 1");
        IString xAxisSource = new String("Time");
        IString yAxisSource = new String("Value");

        ISeriesRelationalModel model = new SeriesEFCoreModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource
        );

        Assert.Equal(yAxisSource.TextValue, model.YAxisSource.TextValue);
    }

    [Fact]
    public void EqualWhenSameProperties()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new String("Series 1");
        IString xAxisSource = new String("Time");
        IString yAxisSource = new String("Value");

        ISeriesRelationalModel a = new SeriesEFCoreModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource
        );
        ISeriesRelationalModel b = new SeriesEFCoreModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource
        );

        Assert.Equal(a, b);
    }

    [Fact]
    public void NotEqualWhenDifferentId()
    {
        IGuid chartId = new Guid();
        IString legend = new String("Series 1");
        IString xAxisSource = new String("Time");
        IString yAxisSource = new String("Value");

        ISeriesRelationalModel a = new SeriesEFCoreModel(
            new Guid(),
            chartId,
            legend,
            xAxisSource,
            yAxisSource
        );
        ISeriesRelationalModel b = new SeriesEFCoreModel(
            new Guid(),
            chartId,
            legend,
            xAxisSource,
            yAxisSource
        );

        Assert.NotEqual(a, b);
    }
}
