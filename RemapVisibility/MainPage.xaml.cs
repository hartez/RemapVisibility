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
			var old = (Visibility)TheImage.GetValue(CustomVisibility.VisibilityProperty);

			if (old == Visibility.Visible)
			{
				TheImage.SetValue(CustomVisibility.VisibilityProperty, Visibility.Hidden);
			}
			else if (old == Visibility.Hidden)
			{
				TheImage.SetValue(CustomVisibility.VisibilityProperty, Visibility.Collapsed);
			}
			else
			{
				TheImage.SetValue(CustomVisibility.VisibilityProperty, Visibility.Visible);
			}
		}
	}
}
