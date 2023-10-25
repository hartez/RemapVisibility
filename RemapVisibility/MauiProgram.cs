using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls;

namespace RemapVisibility
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				});

#if DEBUG
			builder.Logging.AddDebug();
#endif

			Microsoft.Maui.Handlers.ViewHandler.ViewMapper.ModifyMapping(nameof(IView.Visibility), (handler, view, map) =>
			{
				// Call the original mapping, but decorate the View with a thin wrapper which modifies the property values
				// The custom wrapper will treat IsVisible == false as "hidden" instead of "collapsed". And the Core handlers
				// already know how to handle all three states. So this version already works on all the platforms with no 
				// additional code

				map(handler, new CustomViewWrapper(view));
			});

			return builder.Build();
		}
	}
}
