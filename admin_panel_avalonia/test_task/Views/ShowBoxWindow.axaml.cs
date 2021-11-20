using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace test_task.Views
{
    public partial class ShowBoxWindow : Window
    {
        public string TextInfo;
        public ShowBoxWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }
        public ShowBoxWindow(string text) : this()
        {
            TextInfo = text;
        }

        private void TextChange(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Content = TextInfo;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
