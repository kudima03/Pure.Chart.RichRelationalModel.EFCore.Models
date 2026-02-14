using Pure.Chart.RichRelationalModel.Abstractions;
using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;

namespace Pure.Chart.RichRelationalModel.EFCore.Models;

public sealed record AxisEFCoreModel : IAxisRichRelationalModel
{
    public AxisEFCoreModel(IGuid id, IGuid chartId, IString legend)
    {
        Id = id;
        Legend = legend;
        ChartId = chartId;
    }

    public IGuid Id { get; }

    public IGuid ChartId { get; }

    public IString Legend { get; }
}
