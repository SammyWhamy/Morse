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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Morse
{
    public partial class MainWindow : Window
    {
        public static Dictionary<string, string> Dict = new Dictionary<string, string>()
        {
            {"A", ".-"},
            {"B", "-..."},
            {"C", "-.-."},
            {"D", "-.."},
            {"E", "."},
            {"F", "..-."},
            {"G", "--."},
            {"H", "...."},
            {"I", ".."},
            {"J", ".---"},
            {"K", "-.-"},
            {"L", ".-.."},
            {"M", "--"},
            {"N", "-."},
            {"O", "---"},
            {"P", ".--."},
            {"Q", "--.-"},
            {"R", ".-."},
            {"S", "..."},
            {"T", "-"},
            {"U", "..-"},
            {"V", "...-"},
            {"W", ".--"},
            {"X", "-..-"},
            {"Y", "-.--"},
            {"Z", "--.."}
        };
        public static Dictionary<string, string> ReverseDict = Dict.ToDictionary(x => x.Value, x => x.Key);
        public MainWindow()
        {
            InitializeComponent();
        }

        public string Translate(string convertFrom, string input)
        {
            string[] newArr;
            if(convertFrom != "Morse" && convertFrom != "Latin")
            {
                return "Internal error occured.";
            }
            
            if (convertFrom == "Morse")
            {
                string[] arr = input.Split();
                newArr = arr.Select(key => key.ToString() == "/" ? " " : (ReverseDict.ContainsKey(key.ToString()) ? ReverseDict[key.ToString()] : "?")).ToArray();
            }
            else
            {
                char[] arr = input.ToCharArray();
                newArr = arr.Select(key => key.ToString() == " " ? "/ " : (Dict.ContainsKey(key.ToString()) ? Dict[key.ToString()]+" " : "? ")).ToArray();
            }

            return string.Join("", newArr);
        }

        private void ToMorse_Click(object sender, RoutedEventArgs e)
        {
            Output.Text = Translate("Latin", Input.Text.ToUpper().Trim());
        }

        private void ToDutch_Click(object sender, RoutedEventArgs e)
        {
            Output.Text = Translate("Morse", Input.Text.ToUpper().Trim());
        }
    }
}
