using System;
using System.Collections.Generic;
using System.IO;
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


namespace Wordle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        bool canProceed = false;
        int currentRow = 0;
        string testWord = "WORDLE";
        string[] chars;
        List<string> foundLetters;
        string active1;
        string active2;
        string active3;
        string active4;
        string active5;
        string active6;
        string[] activeLetters = new string[6];
        List<string> words = new List<string>();
        bool winner = false;
        int gamesPlayed;
        int wins;
        int losses;
        string bestScore;


        public MainWindow()
        {
            InitializeComponent();

            using (StreamReader sr = new StreamReader(@"..\..\FutureWords.csv"))
            {
                while (!sr.EndOfStream)
                {
                    words.Add(sr.ReadLine());
                    Console.WriteLine(sr.ReadLine());
                }
                
            }

            using (StreamReader stats = new StreamReader(@"..\..\Stats.csv"))
            {
                
                while (!stats.EndOfStream)
                {
                    string[] temp = stats.ReadLine().Split(',');

                    if (temp[0].Contains("Games Played"))
                    {
                        gamesPlayed = Convert.ToInt16(temp[1]);
                    }

                    else if (temp[0].Contains("Wins"))
                    {
                        wins = Convert.ToInt16(temp[1]);
                    }

                    else if (temp[0].Contains("Losses"))
                    {
                        losses = Convert.ToInt16(temp[1]);
                    }

                    else if (temp[0].Contains("Best Score"))
                    {
                        bestScore = temp[1].ToString();
                    }
                }
                
            }

            Random rnd = new Random();
            int index = rnd.Next(words.Count);
            testWord = words[index].ToString();

            Row1_1.Focus();
            chars = new string[testWord.Length];
            foundLetters = new List<string>();
            for (int i = 0; i < testWord.Length; i++)
            {
                chars[i] = testWord[i].ToString();
            }
        }

        private void Row1_1_KeyUp(object sender, KeyEventArgs e)
        {
            active1 = Row1_1.Text;
            Row1_2.Focus();
            Row1_2.Clear();
            CheckForProceed();
        }
        
        private void Row1_2_KeyUp(object sender, KeyEventArgs e)
        {
            active2 = Row1_2.Text;
            Row1_3.Focus();
            Row1_3.Clear();
            CheckForProceed();
        }

        private void Row1_4_KeyUp(object sender, KeyEventArgs e)
        {
            active4 = Row1_4.Text;
            Row1_5.Focus();
            Row1_5.Clear();
            CheckForProceed();
        }

        private void Row1_5_KeyUp(object sender, KeyEventArgs e)
        {
            active5 = Row1_5.Text;
            Row1_6.Focus();
            Row1_6.Clear();
            CheckForProceed();
        }

        private void Row1_3_KeyUp(object sender, KeyEventArgs e)
        {
            active3 = Row1_3.Text;
            Row1_4.Focus();
            Row1_4.Clear();
            CheckForProceed();
        }

        private void Row1_6_KeyUp(object sender, KeyEventArgs e)
        {
            active6 = Row1_6.Text;
            //CheckForProceed();

            //if (canProceed)
            // {
            //     Row2_1.Focus();
            //     Row2_1.Clear();
            // }

            // canProceed = false;
            button.IsEnabled = true;
       }

        private void Row2_2_KeyUp(object sender, KeyEventArgs e)
        {
            active2 = Row2_2.Text;
            Row2_3.Focus();
            Row2_3.Clear();
            CheckForProceed();

        }

        private void Row2_3_KeyUp(object sender, KeyEventArgs e)
        {
            active3 = Row2_3.Text;
            Row2_4.Focus();
            Row2_4.Clear();
            CheckForProceed();

        }

        private void Row2_4_KeyUp(object sender, KeyEventArgs e)
        {
            active4 = Row2_4.Text;
            Row2_5.Focus();
            Row2_5.Clear();
            CheckForProceed();

        }

        private void Row2_5_KeyUp(object sender, KeyEventArgs e)
        {
            active5 = Row2_5.Text;
            Row2_6.Focus();
            Row2_6.Clear();
            CheckForProceed();

        }

        private void Row2_6_KeyUp(object sender, KeyEventArgs e)
        {
            //CheckForProceed();
            active6 = Row2_6.Text;
        }

        private void Row2_1_KeyUp(object sender, KeyEventArgs e)
        {
            active1 = Row2_1.Text;
            Row2_2.Focus();
            Row2_2.Clear();
            CheckForProceed();
        }

        private void CheckForProceed()
        {
            switch (currentRow)
            {
                case 0:
                    if (Row1_1.Text.Length > 0 && Row1_2.Text.Length > 0 && Row1_3.Text.Length > 0 && Row1_4.Text.Length > 0 && Row1_5.Text.Length > 0 && Row1_6.Text.Length > 0)
                    {
                        canProceed = true;
                        Row1_1.IsEnabled = false;
                        Row1_2.IsEnabled = false;
                        Row1_3.IsEnabled = false;
                        Row1_4.IsEnabled = false;
                        Row1_5.IsEnabled = false;
                        Row1_6.IsEnabled = false;

                        Row2_1.IsEnabled = true;
                        Row2_2.IsEnabled = true;
                        Row2_3.IsEnabled = true;
                        Row2_4.IsEnabled = true;
                        Row2_5.IsEnabled = true;
                        Row2_6.IsEnabled = true;

                        button.IsEnabled = true;
                    }
                    break;
                case 1:
                    if (Row2_1.Text.Length > 0 && Row2_2.Text.Length > 0 && Row2_3.Text.Length > 0 && Row2_4.Text.Length > 0 && Row2_5.Text.Length > 0 && Row2_6.Text.Length > 0)
                    {
                        canProceed = true;
                        Row2_1.IsEnabled = false;
                        Row2_2.IsEnabled = false;
                        Row2_3.IsEnabled = false;
                        Row2_4.IsEnabled = false;
                        Row2_5.IsEnabled = false;
                        Row2_6.IsEnabled = false;

                        Row3_1.IsEnabled = true;
                        Row3_2.IsEnabled = true;
                        Row3_3.IsEnabled = true;
                        Row3_4.IsEnabled = true;
                        Row3_5.IsEnabled = true;
                        Row3_6.IsEnabled = true;
                    }
                    break;

                case 2:
                    if (Row3_1.Text.Length > 0 && Row3_2.Text.Length > 0 && Row3_3.Text.Length > 0 && Row3_4.Text.Length > 0 && Row3_5.Text.Length > 0 && Row3_6.Text.Length > 0)
                    {
                        canProceed = true;
                        Row3_1.IsEnabled = false;
                        Row3_2.IsEnabled = false;
                        Row3_3.IsEnabled = false;
                        Row3_4.IsEnabled = false;
                        Row3_5.IsEnabled = false;
                        Row3_6.IsEnabled = false;

                        Row4_1.IsEnabled = true;
                        Row4_2.IsEnabled = true;
                        Row4_3.IsEnabled = true;
                        Row4_4.IsEnabled = true;
                        Row4_5.IsEnabled = true;
                        Row4_6.IsEnabled = true;
                    }
                    break;

                case 3:
                    if (Row4_1.Text.Length > 0 && Row4_2.Text.Length > 0 && Row4_3.Text.Length > 0 && Row4_4.Text.Length > 0 && Row4_5.Text.Length > 0 && Row4_6.Text.Length > 0)
                    {
                        canProceed = true;
                        Row4_1.IsEnabled = false;
                        Row4_2.IsEnabled = false;
                        Row4_3.IsEnabled = false;
                        Row4_4.IsEnabled = false;
                        Row4_5.IsEnabled = false;
                        Row4_6.IsEnabled = false;

                        Row5_1.IsEnabled = true;
                        Row5_2.IsEnabled = true;
                        Row5_3.IsEnabled = true;
                        Row5_4.IsEnabled = true;
                        Row5_5.IsEnabled = true;
                        Row5_6.IsEnabled = true;
                    }
                    break;

                case 4:
                    if (Row5_1.Text.Length > 0 && Row5_2.Text.Length > 0 && Row5_3.Text.Length > 0 && Row5_4.Text.Length > 0 && Row5_5.Text.Length > 0 && Row5_6.Text.Length > 0)
                    {
                        canProceed = true;
                        Row5_1.IsEnabled = false;
                        Row5_2.IsEnabled = false;
                        Row5_3.IsEnabled = false;
                        Row5_4.IsEnabled = false;
                        Row5_5.IsEnabled = false;
                        Row5_6.IsEnabled = false;

                        Row6_1.IsEnabled = true;
                        Row6_2.IsEnabled = true;
                        Row6_3.IsEnabled = true;
                        Row6_4.IsEnabled = true;
                        Row6_5.IsEnabled = true;
                        Row6_6.IsEnabled = true;
                    }
                    break;

                case 5:
                    if (Row6_1.Text.Length > 0 && Row6_2.Text.Length > 0 && Row6_3.Text.Length > 0 && Row6_4.Text.Length > 0 && Row6_5.Text.Length > 0 && Row6_6.Text.Length > 0)
                    {
                        canProceed = true;
                        Row6_1.IsEnabled = false;
                        Row6_2.IsEnabled = false;
                        Row6_3.IsEnabled = false;
                        Row6_4.IsEnabled = false;
                        Row6_5.IsEnabled = false;
                        Row6_6.IsEnabled = false;
                    }
                    break;
                    
            }

        }

        private void Enter_Event_Handler(object sender, RoutedEventArgs e)
        {
            activeLetters[0] = active1;
            activeLetters[1] = active2;
            activeLetters[2] = active3;
            activeLetters[3] = active4;
            activeLetters[4] = active5;
            activeLetters[5] = active6;

            MatchLetters(activeLetters);

            CheckForProceed();

            if (canProceed)
            {
                switch (currentRow)
                {
                    case 0:
                        Row2_1.Focus();
                        break;

                    case 1:
                        Row3_1.Focus();
                        break;

                    case 2:
                        Row4_1.Focus();
                        break;

                    case 3:
                        Row5_1.Focus();
                        break;

                    case 4:
                        Row6_1.Focus();
                        break;

                    case 5:

                        break;
                }
                // Increment Current row
                currentRow += 1;

                canProceed = false;
            }

            // See if they won
            if (string.Join("",activeLetters).Equals(testWord))
            {
                winner = true;
                wins += 1;
                gamesPlayed++;

                double winloss;
                if (losses == 0)
                    winloss = 100;
                else
                    winloss = 100 * (double)wins / ((double)losses + (double)wins);
                // Update Stats

                System.IO.File.WriteAllText(@"..\..\Stats.csv", string.Empty);

                var csv = new StringBuilder();
                var gp = string.Format("Games Played,{0}", gamesPlayed);
                csv.AppendLine(gp);
                var winp = string.Format("Win %,{0}", winloss);
                csv.AppendLine(winp);
                var win = string.Format("Wins,{0}", wins);
                csv.AppendLine(win);
                var loss = string.Format("Losses,{0}", losses);
                csv.AppendLine(loss);
                var bestscore = string.Format("Best Score,{0}", currentRow);
                csv.AppendLine(bestscore);

                File.WriteAllText(@"..\..\Stats.csv", csv.ToString());

                if (currentRow < Convert.ToInt16(bestScore))
                {
                    MessageBox.Show("New Best Score!" + "   " + currentRow + "/6");
                }

                MessageBox.Show("Congrats! You're a winner!", "Winner",MessageBoxButton.OK,MessageBoxImage.Exclamation);

                
            }

            if (currentRow == 6 && !winner)
            {
                losses += 1;
                gamesPlayed++;
                double ratio = 100 * (double)wins / ((double)losses + (double)wins);
                // Update Stats

                System.IO.File.WriteAllText(@"..\..\Stats.csv", string.Empty);

                var csv = new StringBuilder();
                var gp = string.Format("Games Played," + gamesPlayed);
                csv.AppendLine(gp);
                var winp = string.Format("Win %,{0}", ratio.ToString());
                csv.AppendLine(winp);
                var win = string.Format("Wins,{0}", wins);
                csv.AppendLine(win);
                var loss = string.Format("Losses,{0}", losses);
                csv.AppendLine(loss);
                var bestscore = string.Format("Best Score,{0}", currentRow);
                csv.AppendLine(bestscore);

                File.WriteAllText(@"..\..\Stats.csv", csv.ToString());

                // Show the answer
                MessageBox.Show("Better luck next time! The word was " + testWord.ToString() + " .", "Oops!", MessageBoxButton.OK, MessageBoxImage.Error);

                
            }
        }

        private void MatchLetters(string[] input)
        {
            switch (currentRow)
            {
                case 0:
                    if (chars[0].Equals(input[0]))
                    {
                        // Color green
                        Row1_1.Background = Brushes.Green;
                        foundLetters.Add(input[0]);
                    }

                    else if (IsLetterInWord(input[0]) && !foundLetters.Contains(input[0]))
                    {
                        // Color yellow
                        Row1_1.Background = Brushes.Yellow;
                    }

                    if (chars[1].Equals(input[1]))
                    {
                        // Color green
                        Row1_2.Background = Brushes.Green;
                        foundLetters.Add(input[1]);
                    }

                    else if (IsLetterInWord(input[1]) && !foundLetters.Contains(input[1]))
                    {
                        // Color yellow
                        Row1_2.Background = Brushes.Yellow;
                    }

                    if (chars[2].Equals(input[2]))
                    {
                        // Color green
                        Row1_3.Background = Brushes.Green;
                        foundLetters.Add(input[2]);
                    }

                    else if (IsLetterInWord(input[2]) && !foundLetters.Contains(input[2]))
                    {
                        // Color yellow
                        Row1_3.Background = Brushes.Yellow;
                    }

                    if (chars[3].Equals(input[3]))
                    {
                        // Color green
                        Row1_4.Background = Brushes.Green;
                        foundLetters.Add(input[3]);
                    }

                    else if (IsLetterInWord(input[3]) && !foundLetters.Contains(input[3]))
                    {
                        // Color yellow
                        Row1_4.Background = Brushes.Yellow;
                    }

                    if (chars[4].Equals(input[4]))
                    {
                        // Color green
                        Row1_5.Background = Brushes.Green;
                        foundLetters.Add(input[4]);
                    }

                    else if (IsLetterInWord(input[4]) && !foundLetters.Contains(input[4]))
                    {
                        // Color yellow
                        Row1_5.Background = Brushes.Yellow;
                    }

                    if (chars[5].Equals(input[5]))
                    {
                        // Color green
                        Row1_6.Background = Brushes.Green;
                        foundLetters.Add(input[5]);
                    }

                    else if (IsLetterInWord(input[5]) && !foundLetters.Contains(input[5]))
                    {
                        // Color yellow
                        Row1_6.Background = Brushes.Yellow;
                    }

                    break;

/////////////////////////////////////////////////////////

                case 1:

                    if (chars[0].Equals(input[0]))
                    {
                        // Color green
                        Row2_1.Background = Brushes.Green;
                    }

                    else if (IsLetterInWord(input[0]) && !foundLetters.Contains(input[0]))
                    {
                        // Color yellow
                        Row2_1.Background = Brushes.Yellow;
                    }

                    if (chars[1].Equals(input[1]))
                    {
                        // Color green
                        Row2_2.Background = Brushes.Green;
                    }

                    else if (IsLetterInWord(input[1]) && !foundLetters.Contains(input[1]))
                    {
                        // Color yellow
                        Row2_2.Background = Brushes.Yellow;
                    }

                    if (chars[2].Equals(input[2]))
                    {
                        // Color green
                        Row2_3.Background = Brushes.Green;
                    }

                    else if (IsLetterInWord(input[2]) && !foundLetters.Contains(input[2]))
                    {
                        // Color yellow
                        Row2_3.Background = Brushes.Yellow;
                    }

                    if (chars[3].Equals(input[3]))
                    {
                        // Color green
                        Row2_4.Background = Brushes.Green;
                    }

                    else if (IsLetterInWord(input[3]) && !foundLetters.Contains(input[3]))
                    {
                        // Color yellow
                        Row2_4.Background = Brushes.Yellow;
                    }

                    if (chars[4].Equals(input[4]))
                    {
                        // Color green
                        Row2_5.Background = Brushes.Green;
                    }

                    else if (IsLetterInWord(input[4]) && !foundLetters.Contains(input[4]))
                    {
                        // Color yellow
                        Row2_5.Background = Brushes.Yellow;
                    }

                    if (chars[5].Equals(input[5]))
                    {
                        // Color green
                        Row2_6.Background = Brushes.Green;
                    }

                    else if (IsLetterInWord(input[5]) && !foundLetters.Contains(input[5]))
                    {
                        // Color yellow
                        Row2_6.Background = Brushes.Yellow;
                    }

                    break;

////////////////////////////////////////////////////////////////////////////

                case 2:

                    if (chars[0].Equals(input[0]))
                    {
                        // Color green
                        Row3_1.Background = Brushes.Green;
                    }

                    else if (IsLetterInWord(input[0]) && !foundLetters.Contains(input[0]))
                    {
                        // Color yellow
                        Row3_1.Background = Brushes.Yellow;
                    }

                    if (chars[1].Equals(input[1]))
                    {
                        // Color green
                        Row3_2.Background = Brushes.Green;
                    }

                    else if (IsLetterInWord(input[1]) && !foundLetters.Contains(input[1]))
                    {
                        // Color yellow
                        Row3_2.Background = Brushes.Yellow;
                    }

                    if (chars[2].Equals(input[2]))
                    {
                        // Color green
                        Row3_3.Background = Brushes.Green;
                    }

                    else if (IsLetterInWord(input[2]) && !foundLetters.Contains(input[2]))
                    {
                        // Color yellow
                        Row3_3.Background = Brushes.Yellow;
                    }

                    if (chars[3].Equals(input[3]))
                    {
                        // Color green
                        Row3_4.Background = Brushes.Green;
                    }

                    else if (IsLetterInWord(input[3]) && !foundLetters.Contains(input[3]))
                    {
                        // Color yellow
                        Row3_4.Background = Brushes.Yellow;
                    }

                    if (chars[4].Equals(input[4]))
                    {
                        // Color green
                        Row3_5.Background = Brushes.Green;
                    }

                    else if (IsLetterInWord(input[4]) && !foundLetters.Contains(input[4]))
                    {
                        // Color yellow
                        Row3_5.Background = Brushes.Yellow;
                    }

                    if (chars[5].Equals(input[5]))
                    {
                        // Color green
                        Row3_6.Background = Brushes.Green;
                    }

                    else if (IsLetterInWord(input[5]) && !foundLetters.Contains(input[5]))
                    {
                        // Color yellow
                        Row3_6.Background = Brushes.Yellow;
                    }

                    break;

                case 3:

                    if (chars[0].Equals(input[0]))
                    {
                        // Color green
                        Row4_1.Background = Brushes.Green;
                    }

                    else if (IsLetterInWord(input[0]) && !foundLetters.Contains(input[0]))
                    {
                        // Color yellow
                        Row4_1.Background = Brushes.Yellow;
                    }

                    if (chars[1].Equals(input[1]))
                    {
                        // Color green
                        Row4_2.Background = Brushes.Green;
                    }

                    else if (IsLetterInWord(input[1]) && !foundLetters.Contains(input[1]))
                    {
                        // Color yellow
                        Row4_2.Background = Brushes.Yellow;
                    }

                    if (chars[2].Equals(input[2]))
                    {
                        // Color green
                        Row4_3.Background = Brushes.Green;
                    }

                    else if (IsLetterInWord(input[2]) && !foundLetters.Contains(input[2]))
                    {
                        // Color yellow
                        Row4_3.Background = Brushes.Yellow;
                    }

                    if (chars[3].Equals(input[3]))
                    {
                        // Color green
                        Row4_4.Background = Brushes.Green;
                    }

                    else if (IsLetterInWord(input[3]) && !foundLetters.Contains(input[3]))
                    {
                        // Color yellow
                        Row4_4.Background = Brushes.Yellow;
                    }

                    if (chars[4].Equals(input[4]))
                    {
                        // Color green
                        Row4_5.Background = Brushes.Green;
                    }

                    else if (IsLetterInWord(input[4]) && !foundLetters.Contains(input[4]))
                    {
                        // Color yellow
                        Row4_5.Background = Brushes.Yellow;
                    }

                    if (chars[5].Equals(input[5]))
                    {
                        // Color green
                        Row4_6.Background = Brushes.Green;
                    }

                    else if (IsLetterInWord(input[5]) && !foundLetters.Contains(input[5]))
                    {
                        // Color yellow
                        Row4_6.Background = Brushes.Yellow;
                    }

                    break;

/////////////////////////////////////////////////////////////////////////////////

                case 4:

                    if (chars[0].Equals(input[0]))
                    {
                        // Color green
                        Row5_1.Background = Brushes.Green;
                    }

                    else if (IsLetterInWord(input[0]) && !foundLetters.Contains(input[0]))
                    {
                        // Color yellow
                        Row5_1.Background = Brushes.Yellow;
                    }

                    if (chars[1].Equals(input[1]))
                    {
                        // Color green
                        Row5_2.Background = Brushes.Green;
                    }

                    else if (IsLetterInWord(input[1]) && !foundLetters.Contains(input[1]))
                    {
                        // Color yellow
                        Row5_2.Background = Brushes.Yellow;
                    }

                    if (chars[2].Equals(input[2]))
                    {
                        // Color green
                        Row5_3.Background = Brushes.Green;
                    }

                    else if (IsLetterInWord(input[2]) && !foundLetters.Contains(input[2]))
                    {
                        // Color yellow
                        Row5_3.Background = Brushes.Yellow;
                    }

                    if (chars[3].Equals(input[3]))
                    {
                        // Color green
                        Row5_4.Background = Brushes.Green;
                    }

                    else if (IsLetterInWord(input[3]) && !foundLetters.Contains(input[3]))
                    {
                        // Color yellow
                        Row5_4.Background = Brushes.Yellow;
                    }

                    if (chars[4].Equals(input[4]))
                    {
                        // Color green
                        Row5_5.Background = Brushes.Green;
                    }

                    else if (IsLetterInWord(input[4]) && !foundLetters.Contains(input[4]))
                    {
                        // Color yellow
                        Row5_5.Background = Brushes.Yellow;
                    }

                    if (chars[5].Equals(input[5]))
                    {
                        // Color green
                        Row5_6.Background = Brushes.Green;
                    }

                    else if (IsLetterInWord(input[5]) && !foundLetters.Contains(input[5]))
                    {
                        // Color yellow
                        Row5_6.Background = Brushes.Yellow;
                    }

                    break;

///////////////////////////////////////////////////////////////////////////

                case 5:

                    if (chars[0].Equals(input[0]))
                    {
                        // Color green
                        Row6_1.Background = Brushes.Green;
                    }

                    else if (IsLetterInWord(input[0]) && !foundLetters.Contains(input[0]))
                    {
                        // Color yellow
                        Row6_1.Background = Brushes.Yellow;
                    }

                    if (chars[1].Equals(input[1]))
                    {
                        // Color green
                        Row6_2.Background = Brushes.Green;
                    }

                    else if (IsLetterInWord(input[1]) && !foundLetters.Contains(input[1]))
                    {
                        // Color yellow
                        Row6_2.Background = Brushes.Yellow;
                    }

                    if (chars[2].Equals(input[2]))
                    {
                        // Color green
                        Row6_3.Background = Brushes.Green;
                    }

                    else if (IsLetterInWord(input[2]) && !foundLetters.Contains(input[2]))
                    {
                        // Color yellow
                        Row6_3.Background = Brushes.Yellow;
                    }

                    if (chars[3].Equals(input[3]))
                    {
                        // Color green
                        Row6_4.Background = Brushes.Green;
                    }

                    else if (IsLetterInWord(input[3]) && !foundLetters.Contains(input[3]))
                    {
                        // Color yellow
                        Row6_4.Background = Brushes.Yellow;
                    }

                    if (chars[4].Equals(input[4]))
                    {
                        // Color green
                        Row6_5.Background = Brushes.Green;
                    }

                    else if (IsLetterInWord(input[4]) && !foundLetters.Contains(input[4]))
                    {
                        // Color yellow
                        Row6_5.Background = Brushes.Yellow;
                    }

                    if (chars[5].Equals(input[5]))
                    {
                        // Color green
                        Row6_6.Background = Brushes.Green;
                    }

                    else if (IsLetterInWord(input[5]) && !foundLetters.Contains(input[5]))
                    {
                        // Color yellow
                        Row6_6.Background = Brushes.Yellow;
                    }

                    button.IsEnabled = false;

                    break;
            }
            
        }

        private bool IsLetterInWord(string letter)
        {
            bool val = false;

            for (int j = 0; j < 6; j++)
            {
                if (letter.Equals(testWord[j].ToString()))
                {
                    val = true;
                }
            }

            return val;
        }

        private void Row3_1_KeyUp(object sender, KeyEventArgs e)
        {
            active1 = Row3_1.Text;
            Row3_2.Focus();
            Row3_2.Clear();
            CheckForProceed();
        }

        private void Row3_3_KeyUp(object sender, KeyEventArgs e)
        {
            active3 = Row3_3.Text;
            Row3_4.Focus();
            Row3_4.Clear();
            CheckForProceed();
        }

        private void Row3_2_KeyUp(object sender, KeyEventArgs e)
        {
            active2 = Row3_2.Text;
            Row3_3.Focus();
            Row3_3.Clear();
            CheckForProceed();
        }

        private void Row3_4_KeyUp(object sender, KeyEventArgs e)
        {
            active4 = Row3_4.Text;
            Row3_5.Focus();
            Row3_5.Clear();
            CheckForProceed();
        }

        private void Row3_5_KeyUp(object sender, KeyEventArgs e)
        {
            active5 = Row3_5.Text;
            Row3_6.Focus();
            Row3_6.Clear();
            CheckForProceed();
        }

        private void Row3_6_KeyUp(object sender, KeyEventArgs e)
        {
            active6 = Row3_6.Text;
            //CheckForProceed();
        }

        private void Row4_1_KeyUp(object sender, KeyEventArgs e)
        {
            active1 = Row4_1.Text;
            Row4_2.Focus();
            Row4_2.Clear();
            CheckForProceed();
        }

        private void Row4_3_KeyUp(object sender, KeyEventArgs e)
        {
            active3 = Row4_3.Text;
            Row4_4.Focus();
            Row4_4.Clear();
            CheckForProceed();
        }

        private void Row4_2_KeyUp(object sender, KeyEventArgs e)
        {
            active2 = Row4_2.Text;
            Row4_3.Focus();
            Row4_3.Clear();
            CheckForProceed();
        }

        private void Row4_4_KeyUp(object sender, KeyEventArgs e)
        {
            active4 = Row4_5.Text;
            Row4_5.Focus();
            Row4_5.Clear();
            CheckForProceed();
        }

        private void Row4_5_KeyUp(object sender, KeyEventArgs e)
        {
            active5 = Row4_5.Text;
            Row4_6.Focus();
            Row4_6.Clear();
            CheckForProceed();
        }

        private void Row4_6_KeyUp(object sender, KeyEventArgs e)
        {
            active6 = Row4_6.Text;
            //CheckForProceed();
        }

        private void Row5_1_KeyUp(object sender, KeyEventArgs e)
        {
            active1 = Row5_1.Text;
            Row5_2.Focus();
            Row5_2.Clear();
            CheckForProceed();
        }

        private void Row5_3_KeyUp(object sender, KeyEventArgs e)
        {
            active3 = Row5_3.Text;
            Row5_4.Focus();
            Row5_4.Clear();
            CheckForProceed();
        }

        private void Row5_2_KeyUp(object sender, KeyEventArgs e)
        {
            active2 = Row5_2.Text;
            Row5_3.Focus();
            Row5_3.Clear();
            CheckForProceed();
        }

        private void Row5_4_KeyUp(object sender, KeyEventArgs e)
        {
            active4 = Row5_4.Text;
            Row5_5.Focus();
            Row5_5.Clear();
            CheckForProceed();
        }

        private void Row5_5_KeyUp(object sender, KeyEventArgs e)
        {
            active5 = Row5_5.Text;
            Row5_6.Focus();
            Row5_6.Clear();
            CheckForProceed();
        }

        private void Row5_6_KeyUp(object sender, KeyEventArgs e)
        {
            active6 = Row5_6.Text;
            //CheckForProceed();
        }

        private void Row6_4_KeyUp(object sender, KeyEventArgs e)
        {
            active4 = Row6_4.Text;
            Row6_5.Focus();
            Row6_5.Clear();
            CheckForProceed();
        }

        private void Row6_1_KeyUp(object sender, KeyEventArgs e)
        {
            active1 = Row6_1.Text;
            Row6_2.Focus();
            Row6_2.Clear();
            CheckForProceed();
        }

        private void Row6_3_KeyUp(object sender, KeyEventArgs e)
        {
            active3 = Row6_3.Text;
            Row6_4.Focus();
            Row6_4.Clear();
            CheckForProceed();
        }

        private void Row6_2_KeyUp(object sender, KeyEventArgs e)
        {
            active2 = Row6_2.Text;
            Row6_3.Focus();
            Row6_3.Clear();
            CheckForProceed();
        }

        private void Row6_5_KeyUp(object sender, KeyEventArgs e)
        {
            active5 = Row6_5.Text;
            Row6_6.Focus();
            Row6_6.Clear();
            CheckForProceed();
        }

        private void Row6_6_KeyUp(object sender, KeyEventArgs e)
        {
            active6 = Row6_6.Text;
            //CheckForProceed();
        }

        private void StatsEventHandler(object sender, RoutedEventArgs e)
        {
            // Launch Stats window
            new Stats().Show();
        }
    }
}
