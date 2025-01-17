using Avalonia.Media;
using CarinaStudio.AppSuite;
using CarinaStudio.Controls;
using CarinaStudio.Data.Converters;
using CarinaStudio.ULogViewer.ViewModels.Analysis;
using System.Globalization;

namespace CarinaStudio.ULogViewer.Converters;

/// <summary>
/// Convert from object to icon of <see cref="DisplayableLogAnalysisResult"/>.
/// </summary>
class DisplayableLogAnalysisResultIconConverter : BaseValueConverter<object?, IImage?>
{
    /// <summary>
    /// Default instance.
    /// </summary>
    public static readonly DisplayableLogAnalysisResultIconConverter Default = new(App.Current);


    // Fields.
    readonly IAppSuiteApplication app;


    // Constructor.
    DisplayableLogAnalysisResultIconConverter(IAppSuiteApplication app) =>
        this.app = app;


    /// <inheritdoc/>
    protected override IImage? Convert(object? value, object? parameter, CultureInfo culture)
    {
        var type = value switch
        {
            DisplayableLogAnalysisResult result => result.Type,
            DisplayableLogAnalysisResultType => (DisplayableLogAnalysisResultType?)value,
            _ => null,
        };
        if (type.HasValue)
        {
            IImage? image;
            if ((parameter as string) != "Light")
                app.TryGetResource($"Image/DisplayableLogAnalysisResult.{type.Value}.Colored", out image);
            else
                app.TryGetResource($"Image/DisplayableLogAnalysisResult.{type.Value}.Light", out image);
            return image;
        }
        return null;
    }
}