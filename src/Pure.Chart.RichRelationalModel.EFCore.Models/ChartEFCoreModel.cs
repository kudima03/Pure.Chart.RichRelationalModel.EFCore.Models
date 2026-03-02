using Pure.Chart.Model.Abstractions;
using Pure.Chart.RichRelationalModel.Abstractions;
using Pure.Primitives.Abstractions.Guid;
using Pure.Primitives.Abstractions.String;

namespace Pure.Chart.RichRelationalModel.EFCore.Models;

public sealed record ChartEFCoreModel : IChartRichRelationalModel
{
    public ChartEFCoreModel(
        IGuid id,
        IString title,
        IString description,
        IGuid typeId,
        IGuid xAxisId,
        IGuid yAxisId
    )
        : this(
            id,
            title,
            description,
            typeId,
            null!,
            xAxisId,
            null!,
            yAxisId,
            null!,
            null!
        )
    { }

    public ChartEFCoreModel(
        IGuid id,
        IString title,
        IString description,
        IGuid typeId,
        ChartTypeEFCoreModel typeNavigation,
        IGuid xAxisId,
        AxisEFCoreModel xAxisNavigation,
        IGuid yAxisId,
        AxisEFCoreModel yAxisNavigation,
        ICollection<SeriesEFCoreModel> seriesNavigation
    )
    {
        Id = id;
        Title = title;
        Description = description;
        TypeId = typeId;
        TypeNavigation = typeNavigation;
        XAxisId = xAxisId;
        XAxisNavigation = xAxisNavigation;
        YAxisId = yAxisId;
        YAxisNavigation = yAxisNavigation;
        SeriesNavigation = seriesNavigation;
    }

    public IGuid Id { get; }

    public IString Title { get; }

    public IString Description { get; }

    public IGuid TypeId { get; }

    public IChartType Type => TypeNavigation;

    public ChartTypeEFCoreModel TypeNavigation { get; }

    public IGuid XAxisId { get; }

    public IAxis XAxis => XAxisNavigation;

    public AxisEFCoreModel XAxisNavigation { get; }

    public IGuid YAxisId { get; }

    public IAxis YAxis => YAxisNavigation;

    public AxisEFCoreModel YAxisNavigation { get; }

    public IEnumerable<ISeries> Series => SeriesNavigation;

    public ICollection<SeriesEFCoreModel> SeriesNavigation { get; }
}
