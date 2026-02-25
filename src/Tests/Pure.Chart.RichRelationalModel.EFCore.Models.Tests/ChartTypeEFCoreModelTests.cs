using Pure.Chart.RelationalModel.Abstractions;
using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;
using Guid = Pure.Primitives.Guid.Guid;
using String = Pure.Primitives.String.String;

namespace Pure.Chart.RichRelationalModel.EFCore.Models.Tests;

public sealed record ChartTypeEFCoreModelTests
{
    [Fact]
    public void ConstructorAssignsId()
    {
        IGuid id = new Guid();
        IString name = new String("Line");

        IChartTypeRelationalModel model = new ChartTypeEFCoreModel(id, name);

        Assert.Equal(id.GuidValue, model.Id.GuidValue);
    }

    [Fact]
    public void ConstructorAssignsName()
    {
        IGuid id = new Guid();
        IString name = new String("Line");

        IChartTypeRelationalModel model = new ChartTypeEFCoreModel(id, name);

        Assert.Equal(name.TextValue, model.Name.TextValue);
    }

    [Fact]
    public void EqualWhenSameProperties()
    {
        IGuid id = new Guid();
        IString name = new String("Line");

        IChartTypeRelationalModel a = new ChartTypeEFCoreModel(id, name);
        IChartTypeRelationalModel b = new ChartTypeEFCoreModel(id, name);

        Assert.Equal(a, b);
    }

    [Fact]
    public void NotEqualWhenDifferentId()
    {
        IString name = new String("Line");

        IChartTypeRelationalModel a = new ChartTypeEFCoreModel(
            new Guid(),
            name
        );
        IChartTypeRelationalModel b = new ChartTypeEFCoreModel(
            new Guid(),
            name
        );

        Assert.NotEqual(a, b);
    }
}
