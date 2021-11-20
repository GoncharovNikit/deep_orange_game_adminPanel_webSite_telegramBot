using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
using System.ComponentModel;
using test_task.ViewModels;

namespace test_task.Views
{
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            DataContext = new AuthorizationViewModel();
        }

        private void CreateAccountClick(object sender, RoutedEventArgs e)
        {
            this.Close();
            new CreateNewAccountWindow().Show();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

    }
}
