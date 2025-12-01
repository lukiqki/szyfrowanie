using System.IO;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace szyfrowanie;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private string SzyfrCezara(string tekst, int przesuniecie)
    {
        char[] zaszyfrowanyTekst = new char[tekst.Length];

        for (int i = 0; i < tekst.Length; i++)
        {
            char znak = tekst[i];


            if (znak >= 'a' && znak <= 'z')
            {
                zaszyfrowanyTekst[i] = (char)((((znak - 'a') + przesuniecie) % 26 + 26) % 26 + 'a');
            }
            else
            {
                zaszyfrowanyTekst[i] = znak;
            }
        }
        return new string(zaszyfrowanyTekst);
    }

    private void ZaszyfrujClick(object sender, RoutedEventArgs e)
    {
        string tekstDoZaszyfrowania = wprowadzonytext.Text;
        string kluczstr = kluczszyfrowania.Text;

        if (int.TryParse(kluczstr, out int klucz))
        {
            string zaszyfrowany = SzyfrCezara(tekstDoZaszyfrowania, klucz);

            zaszyfrowanytext.Text = zaszyfrowany;
        }
        else
        {
            zaszyfrowanytext.Text = tekstDoZaszyfrowania;
        }
    }

    private async void ZapiszClick(object sender, RoutedEventArgs e)
    {
        var oknozapisz = new SaveFileDialog();
        
        string? sciezka = await oknozapisz.ShowAsync(this);

        File.WriteAllText(sciezka, zaszyfrowanytext.Text);
    }
}