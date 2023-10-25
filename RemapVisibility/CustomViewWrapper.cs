namespace RemapVisibility
{
	internal class CustomViewWrapper : IView
	{
		readonly IView _internal;

		public CustomViewWrapper(IView @internal)
		{
			_internal = @internal;
		}

		public string AutomationId => _internal.AutomationId;

		public FlowDirection FlowDirection => _internal.FlowDirection;

		public Microsoft.Maui.Primitives.LayoutAlignment HorizontalLayoutAlignment => _internal.HorizontalLayoutAlignment;

		public Microsoft.Maui.Primitives.LayoutAlignment VerticalLayoutAlignment => _internal.VerticalLayoutAlignment;

		public Semantics Semantics => _internal.Semantics;

		public IShape Clip => _internal.Clip;

		public IShadow Shadow => _internal.Shadow;

		public bool IsEnabled => _internal.IsEnabled;

		public bool IsFocused { get => _internal.IsFocused; set => _internal.IsFocused = value; }

		// Redirect `IsVisible == false` from `Collapsed` to `Hidden`
		public Visibility Visibility => _internal.Visibility == Visibility.Collapsed ? Visibility.Hidden : _internal.Visibility;

		public double Opacity => _internal.Opacity;

		public Paint Background => _internal.Background;

		public Rect Frame { get => _internal.Frame; set => _internal.Frame = value; }

		public double Width => _internal.Width;

		public double MinimumWidth => _internal.MinimumWidth;

		public double MaximumWidth => _internal.MaximumWidth;

		public double Height => _internal.Height;

		public double MinimumHeight => _internal.MinimumHeight;

		public double MaximumHeight => _internal.MaximumHeight;

		public Thickness Margin => _internal.Margin;

		public Size DesiredSize => _internal.DesiredSize;

		public int ZIndex => _internal.ZIndex;

		public IViewHandler Handler { get => _internal.Handler; set => _internal.Handler = value; }

		public bool InputTransparent => _internal.InputTransparent;

		public IElement Parent => _internal.Parent;

		public double TranslationX => _internal.TranslationX;

		public double TranslationY => _internal.TranslationY;

		public double Scale => _internal.Scale;

		public double ScaleX => _internal.ScaleX;

		public double ScaleY => _internal.ScaleY;

		public double Rotation => _internal.Rotation;

		public double RotationX => _internal.RotationX;

		public double RotationY => _internal.RotationY;

		public double AnchorX => _internal.AnchorX;

		public double AnchorY => _internal.AnchorY;

		IElementHandler IElement.Handler { get => ((IElement)_internal).Handler; set => ((IElement)_internal).Handler = value; }

		public Size Arrange(Rect bounds)
		{
			return _internal.Arrange(bounds);
		}

		public bool Focus()
		{
			return _internal.Focus();
		}

		public void InvalidateArrange()
		{
			_internal.InvalidateArrange();
		}

		public void InvalidateMeasure()
		{
			_internal.InvalidateMeasure();
		}

		public Size Measure(double widthConstraint, double heightConstraint)
		{
			return _internal.Measure(widthConstraint, heightConstraint);
		}

		public void Unfocus()
		{
			_internal.Unfocus();
		}
	}
}
