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
			TheImage.IsVisible = !TheImage.IsVisible;
		}
	}
}
