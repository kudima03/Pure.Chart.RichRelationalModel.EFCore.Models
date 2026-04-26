using Pure.Chart.RichRelationalModel.Abstractions;
using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;

namespace Pure.Chart.RichRelationalModel.EFCore.Models;

public sealed record AxisEFCoreModel : IAxisRichRelationalModel
{
    public AxisEFCoreModel(IGuid id, IString legend)
    {
        Id = id;
        Legend = legend;
    }

    public IGuid Id { get; }

    public IString Legend { get; }
}
