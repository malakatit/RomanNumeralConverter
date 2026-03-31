using Converter; 
using Microsoft.Maui.Controls;

namespace RomanNumeralConverter
{
    public partial class MainPage : ContentPage
    {
        private RomanConverter converter = new RomanConverter();
        private int KeyValue = 0;
        private string RomanValue = "";

        public MainPage()
        {
            InitializeComponent();
        }

        private void Clear_OnClicked(object sender, EventArgs e)
        {
            TxtNumber.Text = "";
            TxtRoman.Text = "";
            KeyValue = 0;
            RomanValue = "";
        }

        private async void Convert_OnClicked(object sender, EventArgs e)
        {
            if (KeyValue > 0)
            {
                TxtRoman.Text = converter.NumberToRoman(KeyValue);
            }
            else if (!string.IsNullOrWhiteSpace(RomanValue))
            {
                int result = converter.RomanToNumber(RomanValue);

                if (result == -1)
                    await DisplayAlert("Error", "Invalid Roman numeral", "OK");
                else
                    TxtNumber.Text = result.ToString();
            }
        }

        private void TxtNumber_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(TxtNumber.Text, out int number))
            {
                KeyValue = number;
                RomanValue = "";
            }
            else
            {
                KeyValue = 0;
            }
        }

        private void TxtRoman_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxtRoman.Text))
            {
                RomanValue = TxtRoman.Text.ToUpper();
                KeyValue = 0;
            }
            else
            {
                RomanValue = "";
            }
        }
    }
}