using MahApps.Metro.Controls;
using Prism.Interactivity;
using System.Windows;
using System.Windows.Media;

namespace Skelton.WpfMahAppsPrismReactiveProperty.Interactivity
{
    internal class MetroPopupWindowAction : PopupWindowAction
    {
        protected override Window CreateWindow()
        {
            return new MetroWindow
            {
                Style = new Style(),
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize,
                TitleCaps = false,
                ShowInTaskbar = false,
                ShowIconOnTitleBar = false,
                ShowMinButton = false,
                ShowMaxRestoreButton = false,
                GlowBrush = Brushes.Black,
            };
        }
    }
}
