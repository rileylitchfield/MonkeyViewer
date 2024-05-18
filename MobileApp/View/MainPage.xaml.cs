using MobileApp.ViewModel;

namespace MobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MonkeyViewModel monkeyViewModel)
        {
            InitializeComponent();
            BindingContext = monkeyViewModel;
        }

    }
}
