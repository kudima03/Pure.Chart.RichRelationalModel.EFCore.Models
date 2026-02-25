using Pure.Chart.Model.Abstractions;
using Pure.Chart.RelationalModel.Abstractions;
using Pure.Chart.RichRelationalModel.Abstractions;
using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;
using Guid = Pure.Primitives.Guid.Guid;
using String = Pure.Primitives.String.String;

namespace Pure.Chart.RichRelationalModel.EFCore.Models.Tests;

public sealed record ChartEFCoreModelTests
{
    [Fact]
    public void ConstructorAssignsId()
    {
        IGuid id = new Guid();
        IGuid chartId = new Guid();
        IString legend = new String("Axis");

        IChartRelationalModel model = new ChartEFCoreModel(
            id,
            new String("Title"),
            new String("Description"),
            new Guid(),
            new ChartTypeEFCoreModel(new Guid(), new String("Line")),
            new AxisEFCoreModel(new Guid(), chartId, legend),
            new AxisEFCoreModel(new Guid(), chartId, legend),
            []
        );

        Assert.Equal(id.GuidValue, model.Id.GuidValue);
    }

    [Fact]
    public void ConstructorAssignsTitle()
    {
        IGuid chartId = new Guid();
        IString legend = new String("Axis");
        IString title = new String("My Chart");

        IChartRelationalModel model = new ChartEFCoreModel(
            new Guid(),
            title,
            new String("Description"),
            new Guid(),
            new ChartTypeEFCoreModel(new Guid(), new String("Line")),
            new AxisEFCoreModel(new Guid(), chartId, legend),
            new AxisEFCoreModel(new Guid(), chartId, legend),
            []
        );

        Assert.Equal(title.TextValue, model.Title.TextValue);
    }

    [Fact]
    public void ConstructorAssignsDescription()
    {
        IGuid chartId = new Guid();
        IString legend = new String("Axis");
        IString description = new String("A description");

        IChartRelationalModel model = new ChartEFCoreModel(
            new Guid(),
            new String("Title"),
            description,
            new Guid(),
            new ChartTypeEFCoreModel(new Guid(), new String("Line")),
            new AxisEFCoreModel(new Guid(), chartId, legend),
            new AxisEFCoreModel(new Guid(), chartId, legend),
            []
        );

        Assert.Equal(description.TextValue, model.Description.TextValue);
    }

    [Fact]
    public void ConstructorAssignsTypeId()
    {
        IGuid chartId = new Guid();
        IString legend = new String("Axis");
        IGuid typeId = new Guid();

        IChartRelationalModel model = new ChartEFCoreModel(
            new Guid(),
            new String("Title"),
            new String("Description"),
            typeId,
            new ChartTypeEFCoreModel(new Guid(), new String("Line")),
            new AxisEFCoreModel(new Guid(), chartId, legend),
            new AxisEFCoreModel(new Guid(), chartId, legend),
            []
        );

        Assert.Equal(typeId.GuidValue, model.TypeId.GuidValue);
    }

    [Fact]
    public void TypeReturnsTypeNavigation()
    {
        IGuid chartId = new Guid();
        IString legend = new String("Axis");
        ChartTypeEFCoreModel typeNavigation = new ChartTypeEFCoreModel(
            new Guid(),
            new String("Bar")
        );

        IChart model = new ChartEFCoreModel(
            new Guid(),
            new String("Title"),
            new String("Description"),
            new Guid(),
            typeNavigation,
            new AxisEFCoreModel(new Guid(), chartId, legend),
            new AxisEFCoreModel(new Guid(), chartId, legend),
            []
        );

        Assert.Equal(typeNavigation, model.Type);
    }

    [Fact]
    public void XAxisReturnsXAxisNavigation()
    {
        IGuid chartId = new Guid();
        IString legend = new String("Axis");
        AxisEFCoreModel xAxisNavigation = new AxisEFCoreModel(
            new Guid(),
            chartId,
            new String("X")
        );

        IChart model = new ChartEFCoreModel(
            new Guid(),
            new String("Title"),
            new String("Description"),
            new Guid(),
            new ChartTypeEFCoreModel(new Guid(), new String("Line")),
            xAxisNavigation,
            new AxisEFCoreModel(new Guid(), chartId, legend),
            []
        );

        Assert.Equal(xAxisNavigation, model.XAxis);
    }

    [Fact]
    public void YAxisReturnsYAxisNavigation()
    {
        IGuid chartId = new Guid();
        IString legend = new String("Axis");
        AxisEFCoreModel yAxisNavigation = new AxisEFCoreModel(
            new Guid(),
            chartId,
            new String("Y")
        );

        IChart model = new ChartEFCoreModel(
            new Guid(),
            new String("Title"),
            new String("Description"),
            new Guid(),
            new ChartTypeEFCoreModel(new Guid(), new String("Line")),
            new AxisEFCoreModel(new Guid(), chartId, legend),
            yAxisNavigation,
            []
        );

        Assert.Equal(yAxisNavigation, model.YAxis);
    }

    [Fact]
    public void SeriesReturnsSeriesNavigation()
    {
        IGuid chartId = new Guid();
        IString legend = new String("Axis");
        ICollection<SeriesEFCoreModel> series =
        [
            new SeriesEFCoreModel(
                new Guid(),
                chartId,
                new String("S1"),
                new String("Time"),
                new String("Value")
            ),
        ];

        IChart model = new ChartEFCoreModel(
            new Guid(),
            new String("Title"),
            new String("Description"),
            new Guid(),
            new ChartTypeEFCoreModel(new Guid(), new String("Line")),
            new AxisEFCoreModel(new Guid(), chartId, legend),
            new AxisEFCoreModel(new Guid(), chartId, legend),
            series
        );

        Assert.Equal(series, model.Series);
    }

    [Fact]
    public void EqualWhenSameProperties()
    {
        IGuid id = new Guid();
        IString title = new String("Title");
        IString description = new String("Desc");
        IGuid typeId = new Guid();
        ChartTypeEFCoreModel typeNavigation = new ChartTypeEFCoreModel(
            new Guid(),
            new String("Line")
        );
        IGuid chartId = new Guid();
        IString legend = new String("Axis");
        AxisEFCoreModel xAxis = new AxisEFCoreModel(
            new Guid(),
            chartId,
            legend
        );
        AxisEFCoreModel yAxis = new AxisEFCoreModel(
            new Guid(),
            chartId,
            legend
        );
        ICollection<SeriesEFCoreModel> series = [];

        IChartRichRelationalModel a = new ChartEFCoreModel(
            id,
            title,
            description,
            typeId,
            typeNavigation,
            xAxis,
            yAxis,
            series
        );
        IChartRichRelationalModel b = new ChartEFCoreModel(
            id,
            title,
            description,
            typeId,
            typeNavigation,
            xAxis,
            yAxis,
            series
        );

        Assert.Equal(a, b);
    }

    [Fact]
    public void NotEqualWhenDifferentId()
    {
        IString title = new String("Title");
        IString description = new String("Desc");
        IGuid typeId = new Guid();
        ChartTypeEFCoreModel typeNavigation = new ChartTypeEFCoreModel(
            new Guid(),
            new String("Line")
        );
        IGuid chartId = new Guid();
        IString legend = new String("Axis");
        AxisEFCoreModel xAxis = new AxisEFCoreModel(
            new Guid(),
            chartId,
            legend
        );
        AxisEFCoreModel yAxis = new AxisEFCoreModel(
            new Guid(),
            chartId,
            legend
        );
        ICollection<SeriesEFCoreModel> series = [];

        IChartRichRelationalModel a = new ChartEFCoreModel(
            new Guid(),
            title,
            description,
            typeId,
            typeNavigation,
            xAxis,
            yAxis,
            series
        );
        IChartRichRelationalModel b = new ChartEFCoreModel(
            new Guid(),
            title,
            description,
            typeId,
            typeNavigation,
            xAxis,
            yAxis,
            series
        );

        Assert.NotEqual(a, b);
    }
}
