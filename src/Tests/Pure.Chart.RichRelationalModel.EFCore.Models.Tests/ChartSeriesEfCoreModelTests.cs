using Pure.Chart.RelationalModel.Abstractions;
using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;
using Guid = Pure.Primitives.Guid.Guid;
using String = Pure.Primitives.String.String;

namespace Pure.Chart.RichRelationalModel.EFCore.Models.Tests;

public sealed record ChartSeriesEfCoreModelTests
{
    [Fact]
    public void ConstructorAssignsId()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new String("Series 1");
        IString xAxisSource = new String("Time");
        IString yAxisSource = new String("Value");
        IString lineType = new String("dashed");

        IChartSeriesRelationalModel model = new ChartSeriesEFCoreModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource,
            lineType
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
        IString lineType = new String("dashed");

        IChartSeriesRelationalModel model = new ChartSeriesEFCoreModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource,
            lineType
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
        IString lineType = new String("dashed");

        IChartSeriesRelationalModel model = new ChartSeriesEFCoreModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource,
            lineType
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
        IString lineType = new String("dashed");

        IChartSeriesRelationalModel model = new ChartSeriesEFCoreModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource,
            lineType
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
        IString lineType = new String("dashed");

        IChartSeriesRelationalModel model = new ChartSeriesEFCoreModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource,
            lineType
        );

        Assert.Equal(yAxisSource.TextValue, model.YAxisSource.TextValue);
    }

    [Fact]
    public void ConstructorAssignsLineType()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new String("Series 1");
        IString xAxisSource = new String("Time");
        IString yAxisSource = new String("Value");
        IString lineType = new String("dashed");

        IChartSeriesRelationalModel model = new ChartSeriesEFCoreModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource,
            lineType
        );

        Assert.Equal(lineType.TextValue, model.LineType.TextValue);
    }

    [Fact]
    public void EqualWhenSameProperties()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new String("Series 1");
        IString xAxisSource = new String("Time");
        IString yAxisSource = new String("Value");
        IString lineType = new String("dashed");

        IChartSeriesRelationalModel a = new ChartSeriesEFCoreModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource,
            lineType
        );
        IChartSeriesRelationalModel b = new ChartSeriesEFCoreModel(
            id,
            chartId,
            legend,
            xAxisSource,
            yAxisSource,
            lineType
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
        IString lineType = new String("dashed");

        IChartSeriesRelationalModel a = new ChartSeriesEFCoreModel(
            new Guid(),
            chartId,
            legend,
            xAxisSource,
            yAxisSource,
            lineType
        );
        IChartSeriesRelationalModel b = new ChartSeriesEFCoreModel(
            new Guid(),
            chartId,
            legend,
            xAxisSource,
            yAxisSource,
            lineType
        );

        Assert.NotEqual(a, b);
    }
}
