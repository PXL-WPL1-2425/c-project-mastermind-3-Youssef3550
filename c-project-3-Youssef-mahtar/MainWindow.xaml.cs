using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace c_project_3_Youssef_mahtar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        private bool timerLoopt = false;
        private List<string> code;
        int attempts = 1;
        int maxAttempts = 10;
        string codeString = "";
        int sec = 0;
        int score = 100;
        string[] highScore = new string[15];
        string highScoreList;
        string playerName = "";
        List<string> spelersLijst = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            RandomKleuren();
            LabelBorder();
            TextBoxCode();
            Attempts();
            showScore();
            startGame();

            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.Tick += startCountdown;
            timer.Start();
            timerLoopt = false;
        }

        private void TimerPauze()
        {
            if (timer.IsEnabled)
            {
                timer.Stop();
                timerLoopt = true;
            }
        }

        private void TimerContinue()
        {
            if (timerLoopt)
            {
                timer.Start();
                timerLoopt = false;
            }
        }

        private void startCountdown(object sender, EventArgs e)
        {
            tijdTextBox.Text = $"Seconden : {sec}";
            sec++;
            stopCountdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            attempts++;
            Attempts();
            sec = 0;

            string checkKleur1 = ComboBox1.SelectedItem?.ToString() ?? "";
            string checkKleur2 = ComboBox2.SelectedItem?.ToString() ?? "";
            string checkKleur3 = ComboBox3.SelectedItem?.ToString() ?? "";
            string checkKleur4 = ComboBox4.SelectedItem?.ToString() ?? "";

            string kleurCode1 = GekozenKleuren(ComboBox1);
            SolidColorBrush colorBrush1 = (SolidColorBrush)new BrushConverter().ConvertFromString(kleurCode1);

            string kleurCode2 = GekozenKleuren(ComboBox2);
            SolidColorBrush colorBrush2 = (SolidColorBrush)new BrushConverter().ConvertFromString(kleurCode2);

            string kleurCode3 = GekozenKleuren(ComboBox3);
            SolidColorBrush colorBrush3 = (SolidColorBrush)new BrushConverter().ConvertFromString(kleurCode3);

            string kleurCode4 = GekozenKleuren(ComboBox4);
            SolidColorBrush colorBrush4 = (SolidColorBrush)new BrushConverter().ConvertFromString(kleurCode4);

            if (checkKleur1 == code[0])
            {
                Label1.BorderBrush = Brushes.DarkRed;
                var pogingCheck = new Rectangle
                {
                    Fill = colorBrush1,
                    Width = 50,
                    Height = 20,
                    StrokeThickness = 4,
                    Stroke = Brushes.DarkRed
                };
                WrapPanel1.Children.Add(pogingCheck);
            }
            else if (checkKleur1 == code[1] || checkKleur1 == code[2] || checkKleur1 == code[3])
            {
                Label1.BorderBrush = Brushes.Wheat;
                score -= 1;
                var pogingCheck = new Rectangle
                {
                    Fill = colorBrush1,
                    Width = 50,
                    Height = 20,
                    StrokeThickness = 4,
                    Stroke = Brushes.White
                };
                WrapPanel1.Children.Add(pogingCheck);
            }
            else
            {
                Label1.BorderBrush = Brushes.Transparent;
                score -= 2;
                var pogingCheck = new Rectangle
                {
                    Fill = colorBrush1,
                    Width = 50,
                    Height = 20,
                    StrokeThickness = 4,
                    Stroke = Brushes.White
                };
                WrapPanel1.Children.Add(pogingCheck);
            }

            if (checkKleur2 == code[1])
            {
                Label2.BorderBrush = Brushes.DarkRed;
                var pogingCheck = new Rectangle
                {
                    Fill = colorBrush2,
                    Width = 50,
                    Height = 20,
                    StrokeThickness = 4,
                    Stroke = Brushes.DarkRed
                };
                WrapPanel2.Children.Add(pogingCheck);
            }
            else if (checkKleur2 == code[0] || checkKleur2 == code[2] || checkKleur2 == code[3])
            {
                Label2.BorderBrush = Brushes.Wheat;
                score -= 1;
                var pogingCheck = new Rectangle
                {
                    Fill = colorBrush2,
                    Width = 50,
                    Height = 20,
                    StrokeThickness = 4,
                    Stroke = Brushes.White
                };
                WrapPanel2.Children.Add(pogingCheck);
            }
            else
            {
                Label2.BorderBrush = Brushes.Transparent;
                score -= 2;
                var pogingCheck = new Rectangle
                {
                    Fill = colorBrush2,
                    Width = 50,
                    Height = 20,
                    StrokeThickness = 4,
                    Stroke = Brushes.White
                };
                WrapPanel2.Children.Add(pogingCheck);
            }

            if (checkKleur3 == code[2])
            {
                Label3.BorderBrush = Brushes.DarkRed;
                var pogingCheck = new Rectangle
                {
                    Fill = colorBrush3,
                    Width = 50,
                    Height = 20,
                    StrokeThickness = 4,
                    Stroke = Brushes.DarkRed
                };
                WrapPanel3.Children.Add(pogingCheck);
            }
            else if (checkKleur3 == code[0] || checkKleur3 == code[1] || checkKleur3 == code[3])
            {
                Label3.BorderBrush = Brushes.Wheat;
                score -= 1;
                var pogingCheck = new Rectangle
                {
                    Fill = colorBrush3,
                    Width = 50,
                    Height = 20,
                    StrokeThickness = 4,
                    Stroke = Brushes.White
                };
                WrapPanel3.Children.Add(pogingCheck);
            }
            else
            {
                Label3.BorderBrush = Brushes.Transparent;
                score -= 2;
                var pogingCheck = new Rectangle
                {
                    Fill = colorBrush3,
                    Width = 50,
                    Height = 20,
                    StrokeThickness = 4,
                    Stroke = Brushes.White
                };
                WrapPanel3.Children.Add(pogingCheck);
            }

            if (checkKleur4 == code[3])
            {
                Label4.BorderBrush = Brushes.DarkRed;
                var pogingCheck = new Rectangle
                {
                    Fill = colorBrush4,
                    Width = 50,
                    Height = 20,
                    StrokeThickness = 4,
                    Stroke = Brushes.DarkRed
                };
                WrapPanel4.Children.Add(pogingCheck);
            }
            else if (checkKleur4 == code[0] || checkKleur4 == code[1] || checkKleur4 == code[2])
            {
                Label4.BorderBrush = Brushes.Wheat;
                score -= 1;
                var pogingCheck = new Rectangle
                {
                    Fill = colorBrush4,
                    Width = 50,
                    Height = 20,
                    StrokeThickness = 4,
                    Stroke = Brushes.White
                };
                WrapPanel4.Children.Add(pogingCheck);
            }
            else
            {
                Label4.BorderBrush = Brushes.Transparent;
                score -= 2;
                var pogingCheck = new Rectangle
                {
                    Fill = colorBrush4,
                    Width = 50,
                    Height = 20,
                    StrokeThickness = 4,
                    Stroke = Brushes.White
                };
                WrapPanel4.Children.Add(pogingCheck);
            }

            showScore();

            if (Label1.BorderBrush == Brushes.DarkRed && Label2.BorderBrush == Brushes.DarkRed &&
                Label3.BorderBrush == Brushes.DarkRed && Label4.BorderBrush == Brushes.DarkRed)
            {
                TimerPauze();
                highscoreRegistreren();
                var result = MessageBox.Show
                    ($"Code gekraakt in {attempts} pogingen! Wil je nog eens?",
                    "WINNER!",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Information);

                if (result == MessageBoxResult.Yes)
                {
                    nieuwSpel();
                    TimerContinue();
                }


            }
        }


        private void RandomKleuren()
        {
            Random random = new Random();
            List<string> kleuren = new List<string> { "rood", "geel", "oranje", "wit", "groen", "blauw" };

            code = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                string randomKleur = kleuren[random.Next(kleuren.Count)];
                code.Add(randomKleur);
            }

            codeString = string.Join(", ", code);


            foreach (string kleur in kleuren)
            {
                ComboBox1.Items.Add(kleur);
                ComboBox2.Items.Add(kleur);
                ComboBox3.Items.Add(kleur);
                ComboBox4.Items.Add(kleur);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;


            string kleurCode = GekozenKleuren(comboBox);
            SolidColorBrush colorBrush = (SolidColorBrush)new BrushConverter().ConvertFromString(kleurCode);


            if (comboBox == ComboBox1)
            {
                Label1.Background = colorBrush;
            }
            else if (comboBox == ComboBox2)
            {
                Label2.Background = colorBrush;
            }
            else if (comboBox == ComboBox3)
            {
                Label3.Background = colorBrush;
            }
            else if (comboBox == ComboBox4)
            {
                Label4.Background = colorBrush;
            }
        }

        private string GekozenKleuren(ComboBox comboBox)
        {
            if (comboBox != null && comboBox.SelectedItem is string gekozenKleur)
            {

                switch (gekozenKleur.ToLower())
                {
                    case "rood":
                        return "#FF0000";
                    case "groen":
                        return "#008000";
                    case "blauw":
                        return "#0000FF";
                    case "geel":
                        return "#FFFF00";
                    case "oranje":
                        return "#FFA500";
                    case "wit":
                        return "#FFFFFF";
                    default:
                        return "#D3D3D3";
                }
            }

            return "#D3D3D3"; // Kleurcode "LIGHTGRAY". Is hetzelfde als achtergrond voor de kleur wit te kunnen laten zien.
        }

        private void LabelBorder()
        {
            Label1.BorderThickness = new Thickness(5);
            Label2.BorderThickness = new Thickness(5);
            Label3.BorderThickness = new Thickness(5);
            Label4.BorderThickness = new Thickness(5);
        }

        private void textBoxCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F12 && Keyboard.IsKeyDown(Key.LeftCtrl) && textBoxCode.Visibility == Visibility.Visible)
            {
                textBoxCode.Visibility = Visibility.Hidden;
            }
            else if (e.Key == Key.F12 && Keyboard.IsKeyDown(Key.LeftCtrl) && textBoxCode.Visibility == Visibility.Hidden)
            {
                textBoxCode.Visibility = Visibility.Visible;
            }
        }

        private void TextBoxCode()
        {
            textBoxCode.Text = $"{codeString}";
        }

        private void Attempts()
        {
            this.Title = $"Mastermind Attempt: {attempts}";

            if (attempts > maxAttempts)
            {
                TimerPauze();
                var result = MessageBox.Show($"You failed! De correcte code was {codeString}." +
                    $"Nog eens proberen?", "FAILED"
                    , MessageBoxButton.YesNo
                    , MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    nieuwSpel();
                }
                TimerContinue();
            }
        }

        private void stopCountdown()
        {
            if (sec > 10)
            {
                TimerPauze();
                MessageBox.Show("Tijd is op.");
                sec = 0;
                attempts++;
                Attempts();
                TimerContinue();
            }
        }
        private void showScore()
        {
            scoreTextBox.Text = "Score: " + score.ToString();
        }

        private void nieuwSpel()
        {
            TimerPauze();
            startGame();
            ComboBox1.Items.Clear();
            ComboBox2.Items.Clear();
            ComboBox3.Items.Clear();
            ComboBox4.Items.Clear();
            RandomKleuren();
            updateLabels();
            TextBoxCode();
            Attempts();
            updateWrapPanels();
            TimerContinue();
            sec = 0;
            attempts = 1;
            score = 100;
            showScore();
        }
        private void MnuNieuwSpel_Click(object sender, RoutedEventArgs e)
        {
            spelersLijst.Clear();
            nieuwSpel();
        }

        private void updateWrapPanels()
        {
            WrapPanel1.Children.Clear();
            WrapPanel2.Children.Clear();
            WrapPanel3.Children.Clear();
            WrapPanel4.Children.Clear();
        }

        private void updateLabels()
        {
            Label1.BorderBrush = Brushes.Transparent;
            Label1.Background = Brushes.Transparent;

            Label2.BorderBrush = Brushes.Transparent;
            Label2.Background = Brushes.Transparent;

            Label3.BorderBrush = Brushes.Transparent;
            Label3.Background = Brushes.Transparent;

            Label4.BorderBrush = Brushes.Transparent;
            Label4.Background = Brushes.Transparent;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TimerPauze();
            MessageBoxResult result = MessageBox.Show("Wilt u het spel vroegtijdig beëindigen?", $"Poging {attempts}/{maxAttempts}", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
            TimerContinue();
        }

        private void MnuAfluiten_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void startGame()
        {
            string antwoord = Interaction.InputBox("Geef de PlayerName in!", "PlayerName", "PlayerName", 500);
            while (string.IsNullOrEmpty(antwoord))
            {
                MessageBox.Show("Geef een Naam in!", "Foutieve invoer");
                antwoord = Interaction.InputBox("Geef de PlayerName in!", "PlayerName", "PlayerName", 500);
            }
            playerName = antwoord;
            spelersLijst.Add(playerName);

            while (true)
            {
                MessageBoxResult result = MessageBox.Show("Wil je nog een speler toevoegen?", "Speler's Toevoegen!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.No)
                {
                    break;
                }

                string nieuweSpeler = Interaction.InputBox("Geef de PlayerName in!", "PlayerName", "PlayerName", 500);
                while (string.IsNullOrEmpty(nieuweSpeler))
                {
                    MessageBox.Show("Geef een Naam in!", "Foutieve invoer");
                    nieuweSpeler = Interaction.InputBox("Geef de PlayerName in!", "PlayerName", "PlayerName", 500);
                }
                spelersLijst.Add(nieuweSpeler);
            }
        }

        private void MnuAantalPoging_Click(object sender, RoutedEventArgs e)
        {
            TimerPauze();
            string antwoord = Interaction.InputBox("Geef een getal tussen 3 - 20!", "Pogingen aanpassen", "", 500);
            maxAttempts = Convert.ToInt32(antwoord);
            while (string.IsNullOrEmpty(antwoord))
            {
                MessageBox.Show("Geef getal!", "Foutieve invoer");
                antwoord = Interaction.InputBox("Geef een getal tussen 3 - 20!", "Pogingen aanpassen", "", 500);
                maxAttempts = Convert.ToInt32(antwoord);
            }
            while (maxAttempts < 3 || maxAttempts > 20)
            {
                MessageBox.Show("Geef getal!", "Foutieve invoer");
                antwoord = Interaction.InputBox("Geef een getal tussen 3 - 20!", "Pogingen aanpassen", "", 500);
                maxAttempts = Convert.ToInt32(antwoord);
            }
            TimerContinue();
        }

        private void MnuHighscore_Click(object sender, RoutedEventArgs e)
        {
            TimerPauze();
            showHighscore();
            TimerContinue();
        }

        private void highscoreRegistreren()
        {
            string highscoreString = $"{playerName} - {attempts} pogingen - {score}/100";

            for (int i = 0; i < highScore.Length; i++)
            {
                if (highScore[i] == null)
                {
                    highScore[i] = highscoreString;
                    break;
                }
            }

            highScoreList = ""; // reset de Highscore zodat het niet Opnieuw de lijst overpakt en dubbel plakt.
            for (int i = 0; i < highScore.Length; i++)
                if (highScore[i] != null)
                {
                    highScoreList = highScoreList + "\n " + highScore[i];
                }
        }

        private void showHighscore()
        {
            if (string.IsNullOrEmpty(highScoreList))
            {
                MessageBox.Show("Er zijn nog geen highscores!", "Highscores", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show($"{highScoreList}", "Highscores", MessageBoxButton.OK, MessageBoxImage.None);
            }
        }
    }
}
