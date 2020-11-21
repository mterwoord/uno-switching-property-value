
using Windows.UI.Xaml;

namespace TestUnoApp
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            _viewModel = (MainViewModel)DataContext;
            ;
        }

        private readonly MainViewModel _viewModel;

        private async void MainPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.InitializeAsync();
        }
    }
}
