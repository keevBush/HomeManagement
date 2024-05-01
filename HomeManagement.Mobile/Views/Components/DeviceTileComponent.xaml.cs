using CommunityToolkit.Maui.Extensions;
using MauiIcons.Core;

namespace HomeManagement.Mobile.Views.Components;

public partial class DeviceTileComponent : ContentView
{
    #region Bindable Property

    #region Bindable OnBackground Property 
    public static readonly BindableProperty OnBackgroundProperty = 
        BindableProperty.Create(nameof(OnBackground), typeof(Color), typeof(DeviceTileComponent), defaultValue: Color.FromArgb("3D8AFE"));

    public Color OnBackground
    {
        get => (Color)GetValue(OnBackgroundProperty); 
        set => SetValue(OnBackgroundProperty, value);
    }
    #endregion

    #region Bindable OffBackground Property 

    public static readonly BindableProperty OffBackgroundProperty =
       BindableProperty.Create(nameof(OffBackground), typeof(Color), typeof(DeviceTileComponent), defaultValue: Color.FromArgb("AAAAAA"));
    public Color OffBackground
    {
        get => (Color)GetValue(OffBackgroundProperty); 
        set => SetValue(OffBackgroundProperty, value);
    }
    #endregion

    #region Bindable OnBackground IsChecked 

    public static readonly BindableProperty IsCheckedProperty =
       BindableProperty.Create(nameof(IsChecked), typeof(bool), typeof(DeviceTileComponent), defaultValue: false);

    public bool IsChecked
    {
        get => (bool)GetValue(IsCheckedProperty);
        set => SetValue(IsCheckedProperty, value);
    }
    #endregion

    #region Device Type ImageSource
    public static readonly BindableProperty DeviceTypeImageSourceProperty =
      BindableProperty.Create(nameof(DeviceTypeImageSource), typeof(ImageSource), typeof(DeviceTileComponent), propertyChanged: DeviceTypeImageSourceChanged);

    public ImageSource DeviceTypeImageSource
    {
        get => (ImageSource)GetValue(DeviceTypeImageSourceProperty);
        set => SetValue(DeviceTypeImageSourceProperty, value);
    }

    private static void DeviceTypeImageSourceChanged(BindableObject bindable, object oldValue, object newValue)
        => ((DeviceTileComponent)bindable).OnOffDeviceTypeImage.Source = (ImageSource)newValue;
    #endregion

    #region Device Connection Type ImageSource

    public static readonly BindableProperty DeviceConnectionTypeImageSourceProperty =
      BindableProperty.Create(nameof(DeviceConnectionTypeImageSource), typeof(ImageSource), typeof(DeviceTileComponent), propertyChanged: DeviceConnectionTypeImageSourceChanged);
   
    public ImageSource DeviceConnectionTypeImageSource
    {
        get => (ImageSource)GetValue(DeviceConnectionTypeImageSourceProperty);
        set => SetValue(DeviceConnectionTypeImageSourceProperty, value);
    }

    private static void DeviceConnectionTypeImageSourceChanged(BindableObject bindable, object oldValue, object newValue)
    {
        ((DeviceTileComponent)bindable).OnOffDeviceConnectionTypeImage.Source = (ImageSource)newValue;
    }
    #endregion


    #region Device Description
    public static readonly BindableProperty DeviceDescriptionProperty =
      BindableProperty.Create(nameof(DeviceDescription), typeof(string), typeof(DeviceTileComponent), defaultValue: string.Empty, propertyChanged: DeviceDescriptionChanged);

    public string DeviceDescription
    {
        get => (string)GetValue(DeviceDescriptionProperty);
        set => SetValue(DeviceDescriptionProperty, value);
    }

    private static void DeviceDescriptionChanged(BindableObject bindable, object oldValue, object newValue)
        => ((DeviceTileComponent)bindable).OnOffDeviceDescription.Text = (string)newValue;

    #endregion
    #region Device Name
    public static readonly BindableProperty DeviceNameProperty =
      BindableProperty.Create(nameof(DeviceName), typeof(string), typeof(DeviceTileComponent), defaultValue: string.Empty, propertyChanged: DeviceNameChanged);

    public string DeviceName
    {
        get => (string)GetValue(DeviceNameProperty);
        set => SetValue(DeviceNameProperty, value);
    }
    private static void DeviceNameChanged(BindableObject bindable, object oldValue, object newValue)
        => ((DeviceTileComponent)bindable).OnOffDeviceName.Text = (string)newValue;
    #endregion

    #endregion

    public DeviceTileComponent()
	{
		InitializeComponent();
	}

    private async Task EnableIcon()
    {
        await Task.WhenAll( 
            this.OnOffDeviceTypeImage.RotateTo(60),
            this.OnOffDeviceTypeImage.ScaleTo(0.8), 
            this.OnOffDeviceConnectionTypeImage.ScaleTo(0.8));
        await Task.WhenAll( 
            this.OnOffDeviceTypeImage.RotateTo(0),
            this.OnOffDeviceTypeImage.ScaleTo(1), 
            this.OnOffDeviceConnectionTypeImage.ScaleTo(1));
    }
    private void OnOffSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        OnOffDeviceTypeImage.IconColor(!IsChecked ? Color.FromArgb("#FFF") : OnBackground);
        OnOffDeviceConnectionTypeImage.IconColor(!IsChecked ? Color.FromArgb("#FFF") : Color.FromArgb("#444"));

        Task.WhenAll(

            EnableIcon(),
            OnOffDeviceName.TextColorTo(!IsChecked ? Color.FromArgb("#FFF") : Color.FromArgb("#000")),
            OnOffSwitchText.TextColorTo(!IsChecked ? Color.FromArgb("#FFF") : Color.FromArgb("#000")),
            OnOffSeparator.BackgroundColorTo(!IsChecked ? Color.FromArgb("#FFF") : Color.FromArgb("#AAA")),
            OnOffDeviceDescription.TextColorTo(!IsChecked ? Color.FromArgb("#FFF") : Color.FromArgb("#000")),
            this.BaseLayout.BackgroundColorTo(OnOffSwitch.IsToggled ? OnBackground : OffBackground,length:500)
            );
        IsChecked = OnOffSwitch.IsToggled;
    } 

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        => OnOffSwitch.IsToggled = !OnOffSwitch.IsToggled;

}