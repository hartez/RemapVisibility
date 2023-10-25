namespace RemapVisibility
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		private void OnClicked(object sender, EventArgs e)
		{
			// Cycle through the various visibility options

			var currentVisibility = (Visibility)TheImage.GetValue(CustomVisibility.VisibilityProperty);

			switch (currentVisibility)
			{
				case Visibility.Visible:
					TheImage.SetValue(CustomVisibility.VisibilityProperty, Visibility.Hidden);
					break;
				case Visibility.Hidden:
					TheImage.SetValue(CustomVisibility.VisibilityProperty, Visibility.Collapsed);
					break;
				default:
					TheImage.SetValue(CustomVisibility.VisibilityProperty, Visibility.Visible);
					break;
			}
		}
	}
}
