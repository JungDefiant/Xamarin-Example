using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.StyleSheets;
using Xamarin.Forms.Xaml;

namespace Example_Xamarin_App
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DiceRollerPage : ContentPage
    {
        private Random _rand = new Random();
        public int RollResult { get; private set; }

        public DiceRollerPage()
        {
            InitializeComponent();

            string style = @"
            .direction {
                color: black;
                font-size: 48;
            }

            .result {
                color: red;
                font-size: 90;
            }";

            using (var reader = new StringReader(style))
            {
                Resources.Add(StyleSheet.FromReader(reader));
            }
        }

        public void OnRollTwoDice(object sender, EventArgs e)
        {
            int diceOne = _rand.Next(1, 7);
            int diceTwo = _rand.Next(1, 7);
            int result = diceOne + diceTwo;
            RollResult = result;
            Result.Text = "" + RollResult;
        }
    }
}