# Visibility Remapping Examples

For historical/backward compatibility reasons, MAUI.Controls only supports 2-state visibilty (via the `IsVisible` property). A view is either visible or it is collapsed (meaning it takes up no space).

Some other UI platforms (e.g., WPF and Android) also support a "hidden" visibility state, where the view is not visible but it still takes up space. The underlying MAUI.Core library actually supports all three states on all of the platforms (which is why the Core `Visibility` enum has three values). 

Users who want to handle visibility differently in a MAUI.Controls app can do so with some custom code. 

## Mapping `IsVisible = false` to `Visibility.Hidden`

The [basic-remap branch](https://github.com/hartez/RemapVisibility/tree/basic-remap) shows how to do this by [modifying the Visibility mapping](https://github.com/hartez/RemapVisibility/blob/basic-remap/RemapVisibility/MauiProgram.cs#L22) - `IsVisible = true` continues to map to `Visibility.Visible`, but `IsVisible = false` maps to `Hidden` rather than `Collapsed`.

The [decorator-remap branch](https://github.com/hartez/RemapVisibility/tree/decorator-remap) shows an alternate way to handle this by creating decorator for `IView` which [modifies how `IsVisible` is interpreted](https://github.com/hartez/RemapVisibility/blob/decorator-remap/RemapVisibility/CustomViewWrapper.cs#L31) when updating the `Visiblity` property in Core.

## Creating a custom Visibility property

The [attached-property branch](https://github.com/hartez/RemapVisibility/tree/attached-property) demonstrates the creation of an [alternate attached property on View](https://github.com/hartez/RemapVisibility/blob/attached-property/RemapVisibility/CustomVisibility.cs) which can handle 3-state visibility. The actual work of mapping the states to the native properties on each platform is handled in a [new mapping added at startup](https://github.com/hartez/RemapVisibility/blob/attached-property/RemapVisibility/MauiProgram.cs#L28).  