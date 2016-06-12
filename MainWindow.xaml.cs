using Skelton.WpfMahAppsPrismReactiveProperty.ViewModels;
using System;
using System.Windows;

namespace Skelton.WpfMahAppsPrismReactiveProperty
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var vm = DataContext as IDisposable;
            if (vm != null) { vm.Dispose(); }
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new MainWindowViewModel();
        }
    }
}
