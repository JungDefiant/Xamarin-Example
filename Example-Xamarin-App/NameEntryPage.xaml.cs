using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Example_Xamarin_App
{ 
    public partial class NameEntryPage : ContentPage
    {
        string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.txt");

        ObservableCollection<TextString> text = new ObservableCollection<TextString>();
        public ObservableCollection<TextString> Text { get { return text; } }

        public NameEntryPage()
        {
            InitializeComponent();
            if (File.Exists(_fileName))
            {
                var arr = File.ReadAllLines(_fileName);

                foreach (var str in arr)
                {
                    //text.Add(new TextString { Line = str } );
                    text.Add(new TextString { Line = str });
                }

                //ListView List = new ListView();
                List.ItemsSource = text;
            }
        }

        public class TextString
        {
            public string Line { get; set; }
        }
    }
}