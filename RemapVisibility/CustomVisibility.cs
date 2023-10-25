namespace RemapVisibility
{
	public static class CustomVisibility
	{
		public static readonly BindableProperty VisibilityProperty =
			BindableProperty.CreateAttached("VisibilityProperty", typeof(Visibility), typeof(View), Visibility.Visible, propertyChanged: VisibilityPropertyChanged);

		public static Visibility GetVisiblity(BindableObject view)
		{
			return (Visibility)view.GetValue(VisibilityProperty);
		}

		public static void SetVisibility(BindableObject view, Visibility value)
		{
			view.SetValue(VisibilityProperty, value);
		}

		static void VisibilityPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var view = (IView)bindable;
			view.Handler.UpdateValue(nameof(VisibilityProperty.PropertyName));
		}
	}
}
