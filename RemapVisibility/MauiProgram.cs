using Microsoft.Extensions.Logging;

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
				// Doing this in Windows for the example; I'll leave the other platforms as an exercise for the reader
#if WINDOWS
				var opacity = view.Opacity;
				var isVisible = ((VisualElement)view).IsVisible;
				var platformView = (Microsoft.UI.Xaml.FrameworkElement)handler.PlatformView;

				if (isVisible)
				{
					platformView.Opacity = opacity;
					platformView.Visibility = Microsoft.UI.Xaml.Visibility.Visible;
				}
				else
				{
					// Hidden - unlike WPF, WinUI doesn't have "hidden", so we'll fake it with Opacity
					platformView.Opacity = 0;
					platformView.Visibility = Microsoft.UI.Xaml.Visibility.Visible;
				}

#else
				// Use the default behavior
				map(handler, view);
#endif
			});

			return builder.Build();
		}
	}

}
