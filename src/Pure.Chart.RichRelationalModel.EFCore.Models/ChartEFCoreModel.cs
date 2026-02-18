using Pure.Chart.Model.Abstractions;
using Pure.Chart.RichRelationalModel.Abstractions;
using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;

namespace Pure.Chart.RichRelationalModel.EFCore.Models;

public sealed record ChartEFCoreModel : IChartRichRelationalModel
{
    public ChartEFCoreModel(IGuid id, IString title, IString description, IGuid typeId)
        : this(id, title, description, typeId, null!, null!, null!, null!) { }

    public ChartEFCoreModel(
        IGuid id,
        IString title,
        IString description,
        IGuid typeId,
        ChartTypeEFCoreModel typeNavigation,
        AxisEFCoreModel xAxisNavigation,
        AxisEFCoreModel yAxisNavigation,
        IEnumerable<SeriesEFCoreModel> seriesNavigation
    )
    {
        Id = id;
        Title = title;
        Description = description;
        TypeId = typeId;
        TypeNavigation = typeNavigation;
        XAxisNavigation = xAxisNavigation;
        YAxisNavigation = yAxisNavigation;
        SeriesNavigation = seriesNavigation;
    }

    public IGuid Id { get; }

    public IString Title { get; }

    public IString Description { get; }

    public IGuid TypeId { get; }

    public IChartType Type => TypeNavigation;

    public ChartTypeEFCoreModel TypeNavigation { get; }

    public IAxis XAxis => XAxisNavigation;

    public AxisEFCoreModel XAxisNavigation { get; }

    public IAxis YAxis => YAxisNavigation;

    public AxisEFCoreModel YAxisNavigation { get; }

    public IEnumerable<ISeries> Series => SeriesNavigation;

    public IEnumerable<SeriesEFCoreModel> SeriesNavigation { get; }
}
