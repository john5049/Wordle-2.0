using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.IO;

namespace Wordle
{
    /// <summary>
    /// Interaction logic for Stats.xaml
    /// </summary>
    public partial class Stats : Window
    {

        int gamesPlayed;
        double winPercentage;
        string bestScore;
        int wins;
        int losses;

        public Stats()
        {
            InitializeComponent();

            using (StreamReader sr = new StreamReader(@"..\..\Stats.csv"))
            {


                while (!sr.EndOfStream)
                {
                    string[] temp = sr.ReadLine().Split(',');

                    if (temp[0].Contains("Games Played"))
                    {
                        gamesPlayed = Convert.ToInt16(temp[1]);
                    }

                    else if(temp[0].Contains("Win %"))
                    {
                        winPercentage = Convert.ToDouble(temp[1]);
                    }

                    else if (temp[0].Contains("Best Score"))
                    {
                        bestScore = temp[1].ToString();
                    }

                    //words.Add(sr.ReadLine());
                    Console.WriteLine(temp[0] + "  " + temp[1]);
                }

                GamesPlayedLabel.Content = gamesPlayed;
                WinPercentageLabel.Content = winPercentage;
                BestScoreLabel.Content = bestScore;

            }
        }
    }
}
