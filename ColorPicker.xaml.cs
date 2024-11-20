using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ColorPickerControl
{
    /// <summary>
    /// Interaction logic for ColorPicker.xaml
    /// </summary>
    public partial class ColorPicker : UserControl
    {
        public static readonly DependencyProperty ColorProperty = DependencyProperty.Register(
            "Color", typeof(Color), typeof(ColorPicker),
            new FrameworkPropertyMetadata(Colors.Black, new PropertyChangedCallback(OnColorChanged)));

        public static readonly DependencyProperty RedProperty = DependencyProperty.Register(
            "Red", typeof(byte), typeof(ColorPicker),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));

        public static readonly DependencyProperty GreenProperty = DependencyProperty.Register(
            "Green", typeof(byte), typeof(ColorPicker),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));

        public static readonly DependencyProperty BlueProperty = DependencyProperty.Register(
            "Blue", typeof(byte), typeof(ColorPicker),
            new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));

        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public byte Red
        {
            get { return (byte)GetValue(RedProperty); }
            set { SetValue(RedProperty, value); }
        }

        public byte Green
        {
            get { return (byte)GetValue(GreenProperty); }
            set { SetValue(GreenProperty, value); }
        }

        public byte Blue
        {
            get { return (byte)GetValue(BlueProperty); }
            set { SetValue(BlueProperty, value); }
        }

        private static void OnColorRGBChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ColorPicker colorPicker = (ColorPicker)sender;
            Color color = colorPicker.Color;
            if (e.Property == RedProperty)
            {
                color.R = (byte)e.NewValue;
            }
            else if (e.Property == GreenProperty)
            {
                color.G = (byte)e.NewValue;
            }
            else if (e.Property == BlueProperty)
            {
                color.B = (byte)e.NewValue;
            }
            colorPicker.Color = color;
        }

        private static void OnColorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            Color color = (Color)e.NewValue;
            ColorPicker colorPicker = (ColorPicker)sender;
            colorPicker.Red = color.R;
            colorPicker.Green = color.G;
            colorPicker.Blue = color.B;
        }

        public ColorPicker()
        {
            InitializeComponent();
        }
    }
}