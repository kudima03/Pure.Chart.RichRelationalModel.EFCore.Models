using Pure.Chart.RelationalModel.Abstractions;
using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;
using Guid = Pure.Primitives.Guid.Guid;
using String = Pure.Primitives.String.String;

namespace Pure.Chart.RichRelationalModel.EFCore.Models.Tests;

public sealed record AxisEFCoreModelTests
{
    [Fact]
    public void ConstructorAssignsId()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new String("legend");

        IAxisRelationalModel model = new AxisEFCoreModel(id, chartId, legend);

        Assert.Equal(id.GuidValue, model.Id.GuidValue);
    }

    [Fact]
    public void ConstructorAssignsChartId()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new String("legend");

        IAxisRelationalModel model = new AxisEFCoreModel(id, chartId, legend);

        Assert.Equal(chartId.GuidValue, model.ChartId.GuidValue);
    }

    [Fact]
    public void ConstructorAssignsLegend()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new String("legend");

        IAxisRelationalModel model = new AxisEFCoreModel(id, chartId, legend);

        Assert.Equal(legend.TextValue, model.Legend.TextValue);
    }

    [Fact]
    public void EqualWhenSameProperties()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new String("legend");

        IAxisRelationalModel a = new AxisEFCoreModel(id, chartId, legend);
        IAxisRelationalModel b = new AxisEFCoreModel(id, chartId, legend);

        Assert.Equal(a, b);
    }

    [Fact]
    public void NotEqualWhenDifferentId()
    {
        IGuid chartId = new Guid();
        IString legend = new String("legend");

        IAxisRelationalModel a = new AxisEFCoreModel(
            new Guid(),
            chartId,
            legend
        );
        IAxisRelationalModel b = new AxisEFCoreModel(
            new Guid(),
            chartId,
            legend
        );

        Assert.NotEqual(a, b);
    }
}
