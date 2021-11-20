using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;

namespace test_task.Views
{
    public partial class MainWindow : Window, IDisposable
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.Opened += AuthWindow;
        }

        private void AuthWindow(object? sender, EventArgs e)
        {
            var auth = new AuthorizationWindow();
            auth.ShowDialog(this);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            DBContext.ShowMessage += ShMS;
        }

        static void ShMS(string Mes)
        {
            new ShowBoxWindow(Mes).Show();
        }

        public void Dispose()
        {
            DBContext.Close();
        }
    }
}
