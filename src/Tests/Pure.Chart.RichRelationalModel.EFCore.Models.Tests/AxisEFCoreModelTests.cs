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
        IString legend = new String("legend");

        IAxisRelationalModel model = new AxisEFCoreModel(id, legend);

        Assert.Equal(id.GuidValue, model.Id.GuidValue);
    }

    [Fact]
    public void ConstructorAssignsLegend()
    {
        IGuid id = new Guid();
        IString legend = new String("legend");

        IAxisRelationalModel model = new AxisEFCoreModel(id, legend);

        Assert.Equal(legend.TextValue, model.Legend.TextValue);
    }

    [Fact]
    public void EqualWhenSameProperties()
    {
        IGuid id = new Guid();
        IString legend = new String("legend");

        IAxisRelationalModel a = new AxisEFCoreModel(id, legend);
        IAxisRelationalModel b = new AxisEFCoreModel(id, legend);

        Assert.Equal(a, b);
    }

    [Fact]
    public void NotEqualWhenDifferentId()
    {
        IString legend = new String("legend");

        IAxisRelationalModel a = new AxisEFCoreModel(new Guid(), legend);
        IAxisRelationalModel b = new AxisEFCoreModel(new Guid(), legend);

        Assert.NotEqual(a, b);
    }
}
