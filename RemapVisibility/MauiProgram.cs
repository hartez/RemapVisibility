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
				// Make IsVisible have no effect at all
			});

			// Handle our new custom attached property
			Microsoft.Maui.Handlers.ViewHandler.ViewMapper.Add(CustomVisibility.VisibilityProperty.PropertyName, (handler, view) => {

			// Again, only handling Windows for this example; other platforms are left as an exercise for the reader
#if WINDOWS
				var opacity = view.Opacity;
				var visibility = (Visibility)(((VisualElement)view).GetValue(CustomVisibility.VisibilityProperty));
				var platformView = ((Microsoft.UI.Xaml.FrameworkElement)handler.PlatformView);

				switch (visibility)
				{
					case Visibility.Visible:
						platformView.Opacity = opacity;
						platformView.Visibility = Microsoft.UI.Xaml.Visibility.Visible;
						break;
					case Visibility.Hidden:
						platformView.Opacity = 0;
						platformView.Visibility = Microsoft.UI.Xaml.Visibility.Visible;
						break;
					case Visibility.Collapsed:
						platformView.Opacity = opacity;
						platformView.Visibility = Microsoft.UI.Xaml.Visibility.Collapsed;
						break;
				}
#endif

			});

			return builder.Build();
		}
	}

}
