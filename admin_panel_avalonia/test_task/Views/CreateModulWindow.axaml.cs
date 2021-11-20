using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace test_task.Views
{
    public partial class CreateModulWindow : Window
    {
        public CreateModulWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
