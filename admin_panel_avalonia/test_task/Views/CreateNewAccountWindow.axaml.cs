using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using test_task.ViewModels;

namespace test_task.Views
{
    public partial class CreateNewAccountWindow : Window
    {
        public CreateNewAccountWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            DataContext = new CreateNewAccountViewModel();
        }

        private void HasAccountClick(object sender, RoutedEventArgs e)
        {
            this.Close();
            new AuthorizationWindow().Show();
        }


        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
