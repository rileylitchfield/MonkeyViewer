
using MobileApp.Model;
using MobileApp.Services;
using System.Collections.ObjectModel;

namespace MobileApp.ViewModel
{
    public class MonkeyViewModel : BaseViewModel
    {
        public ObservableCollection<Monkey> Monkeys { get; set; } = new();
        public Command GetMonkeysCommand { get; }

        MonkeyService _monkeyService;
        public MonkeyViewModel(MonkeyService monkeyService) 
        {
            Title = "Monkey Finder";
            _monkeyService = monkeyService;
            GetMonkeysCommand = new Command(async () => await GetMonkeysAsync());
        }

        async Task GetMonkeysAsync()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;

                var monkeys = await _monkeyService.GetMonkeysAsync();

                if(Monkeys.Count != 0)
                {
                    Monkeys.Clear();
                }

                foreach (var monkey in monkeys)
                {
                    Monkeys.Add(monkey);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
