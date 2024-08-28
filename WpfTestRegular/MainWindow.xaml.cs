using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WpfTestRegular
{
    public partial class MainWindow : Window
    {
        private List<KeyValuePair<string, string>> _data;

        public MainWindow()
        {
            InitializeComponent();
            InitializeData();
            ResultsDataGrid.ItemsSource = _data.Select(kvp => new { Key = kvp.Key, Value = kvp.Value }).ToList();


            // Получаем активный экран
            var screenWidth = System.Windows.Forms.Screen.FromPoint(System.Windows.Forms.Cursor.Position).Bounds.Width;
            var screenHeight = System.Windows.Forms.Screen.FromPoint(System.Windows.Forms.Cursor.Position).Bounds.Height;
            // Устанавливаем максимальные размеры окна
            this.MaxWidth = screenWidth;
            this.MaxHeight = screenHeight;


            ResultsDataGrid.MaxHeight = screenHeight - 400;
        }

        private void InitializeData()
        {
            _data = new  List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string,string>( "вып В1-1 корпус 4.2.1 отм. 3,2", "Value 1" ),
                new KeyValuePair<string,string>( "вып B1-1 корпус 4.2.1 отм. 3,2", "Value 2" ),
                new KeyValuePair<string,string>( "вып В1-23 корпус 4.2.1 отм.3,3", "Value 3" ),
                new KeyValuePair<string,string>( "вып В1.3-2 корпус 4.2.1 отм.3,3", "Value 4" ),
                new KeyValuePair<string,string>( "вып В1-3 \nкорпус 4.2.1 \nотм. 3,2", "Value 5" ),
                new KeyValuePair<string,string>( "корпус 4.2.1 \nвып В1-3 \nотм. 3,2", "Value 5" ),
                new KeyValuePair<string,string>( "В1-4 \nкорпус 4.2.1 отм. 3,2", "Value 6" ),
                new KeyValuePair<string,string>( "К1-1 \nотм. 3,2", "Value 7" ),
                new KeyValuePair<string,string>( "Ввод К2-1 \nотм. 3,2", "Value 8" ),
                new KeyValuePair<string,string>( "вып В1.3-2 корпус 4.2.1 отм.3,3", "Value 4" ),
                new KeyValuePair<string,string>( "вып В1-3 \nкорпус 4.2.1 \nотм. 3,2", "Value 5" ),
                new KeyValuePair<string,string>( "корпус 4.2.1 \nвып В1-3 \nотм. 3,2", "Value 5" ),
                new KeyValuePair<string,string>( "В1-4 \nкорпус 4.2.1 отм. 3,2", "Value 6" ),
                new KeyValuePair<string,string>( "К1-1 \nотм. 3,2", "Value 7" ),
                new KeyValuePair<string,string>( "Ввод К2-1 \nотм. 3,2", "Value 8" ),
                new KeyValuePair<string,string>( "вып В1.3-2 корпус 4.2.1 отм.3,3", "Value 4" ),
                new KeyValuePair<string,string>( "вып В1-3 \nкорпус 4.2.1 \nотм. 3,2", "Value 5" ),
                new KeyValuePair<string,string>( "корпус 4.2.1 \nвып В1-3 \nотм. 3,2", "Value 5" ),
                new KeyValuePair<string,string>( "В1-4 \nкорпус 4.2.1 отм. 3,2", "Value 6" ),
                new KeyValuePair<string,string>( "К1-1 \nотм. 3,2", "Value 7" ),
                new KeyValuePair<string,string>( "Ввод К2-1 \nотм. 3,2", "Value 8" ),
                new KeyValuePair<string,string>( "вып В1.3-2 корпус 4.2.1 отм.3,3", "Value 4" ),
                new KeyValuePair<string,string>( "вып В1-3 \nкорпус 4.2.1 \nотм. 3,2", "Value 5" ),
                new KeyValuePair<string,string>( "корпус 4.2.1 \nвып В1-3 \nотм. 3,2", "Value 5" ),
                new KeyValuePair<string,string>( "В1-4 \nкорпус 4.2.1 отм. 3,2", "Value 6" ),
                new KeyValuePair<string,string>( "К1-1 \nотм. 3,2", "Value 7" ),
                new KeyValuePair<string,string>( "Ввод К2-1 \nотм. 3,2", "Value 8" ),
                new KeyValuePair<string,string>( "вып В1.3-2 корпус 4.2.1 отм.3,3", "Value 4" ),
                new KeyValuePair<string,string>( "вып В1-3 \nкорпус 4.2.1 \nотм. 3,2", "Value 5" ),
                new KeyValuePair<string,string>( "корпус 4.2.1 \nвып В1-3 \nотм. 3,2", "Value 5" ),
                new KeyValuePair<string,string>( "В1-4 \nкорпус 4.2.1 отм. 3,2", "Value 6" ),
                new KeyValuePair<string,string>( "К1-1 \nотм. 3,2", "Value 7" ),
                new KeyValuePair<string,string>( "Ввод К2-1 \nотм. 3,2", "Value 8" ),
                new KeyValuePair<string,string>( "вып В1.3-2 корпус 4.2.1 отм.3,3", "Value 4" ),
                new KeyValuePair<string,string>( "вып В1-3 \nкорпус 4.2.1 \nотм. 3,2", "Value 5" ),
                new KeyValuePair<string,string>( "корпус 4.2.1 \nвып В1-3 \nотм. 3,2", "Value 5" ),
                new KeyValuePair<string,string>( "В1-4 \nкорпус 4.2.1 отм. 3,2", "Value 6" ),
                new KeyValuePair<string,string>( "К1-1 \nотм. 3,2", "Value 7" ),
                new KeyValuePair<string,string>( "Ввод К2-1 \nотм. 3,2", "Value 8" ),
                new KeyValuePair<string,string>( "вып В1.3-2 корпус 4.2.1 отм.3,3", "Value 4" ),
                new KeyValuePair<string,string>( "вып В1-3 \nкорпус 4.2.1 \nотм. 3,2", "Value 5" ),
                new KeyValuePair<string,string>( "корпус 4.2.1 \nвып В1-3 \nотм. 3,2", "Value 5" ),
                new KeyValuePair<string,string>( "В1-4 \nкорпус 4.2.1 отм. 3,2", "Value 6" ),
                new KeyValuePair<string,string>( "К1-1 \nотм. 3,2", "Value 7" ),
                new KeyValuePair<string,string>( "Ввод К2-1 \nотм. 3,2", "Value 8" ),
                new KeyValuePair<string,string>( "вып В1.3-2 корпус 4.2.1 отм.3,3", "Value 4" ),
                new KeyValuePair<string,string>( "вып В1-3 \nкорпус 4.2.1 \nотм. 3,2", "Value 5" ),
                new KeyValuePair<string,string>( "корпус 4.2.1 \nвып В1-3 \nотм. 3,2", "Value 5" ),
                new KeyValuePair<string,string>( "В1-4 \nкорпус 4.2.1 отм. 3,2", "Value 6" ),
                new KeyValuePair<string,string>( "К1-1 \nотм. 3,2", "Value 7" ),
                new KeyValuePair<string,string>( "Ввод К2-1 \nотм. 3,2", "Value 8" ),
                new KeyValuePair<string,string>( "вып В1.3-2 корпус 4.2.1 отм.3,3", "Value 4" ),
                new KeyValuePair<string,string>( "вып В1-3 \nкорпус 4.2.1 \nотм. 3,2", "Value 5" ),
                new KeyValuePair<string,string>( "корпус 4.2.1 \nвып В1-3 \nотм. 3,2", "Value 5" ),
                new KeyValuePair<string,string>( "В1-4 \nкорпус 4.2.1 отм. 3,2", "Value 6" ),
                new KeyValuePair<string,string>( "К1-1 \nотм. 3,2", "Value 7" ),
                new KeyValuePair<string,string>( "Ввод К2-1 \nотм. 3,2", "Value 8" ),
                new KeyValuePair<string,string>( "Ввод К2.2-13 \nотм. 3,2", "Value 9" )
            };
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text;
            //string regexPattern = TemplateInterpreter.InterpretTemplate(searchText);

            var filteredResults = _data

                .Select(kvp => new
                {
                    Key = kvp.Key,
                    Value =
              TemplateInterpreter.ExtractMatch(kvp.Key, searchText /*regexPattern*/)

                })
                .ToList();

            ResultsDataGrid.ItemsSource = filteredResults;
        }

    }
}

public static class TemplateInterpreter
{
    public static string ExtractMatch(this string input, string pattern)
    {
        Match match = null;
        try { match = Regex.Match(input, InterpretTemplate(pattern)); }
        catch { }
        return ((bool)(match?.Success ?? false)) ? (match?.Value ?? "NULL") : "NULL";
    }

    public static string InterpretTemplate(string template)
    {
        StringBuilder regexBuilder = new StringBuilder();
        for (int i = 0; i < template.Length; i++)
        {
            char currentChar = template[i];
            switch (currentChar)
            {
                case '+':
                    if (i > 0 && template[i - 1] == '#')
                    {
                        //regexBuilder.Length--; // Удалить предыдущий символ
                        //regexBuilder.Append(@"[0-9]+"); // Соответствует любому числу
                        regexBuilder.Append(@"+"); // Соответствует любому числу
                    }
                    break;
                case '#':
                    regexBuilder.Append(@"\d"); // Соответствует любой одиночной цифре
                    break;
                case '@':
                    regexBuilder.Append(@"[a-zA-Zа-яА-Я]"); // Соответствует любой одиночной букве
                    break;
                case '[':
                    int endIndex = template.IndexOf(']', i);
                    if (endIndex != -1)
                    {
                        string group = template.Substring(i + 1, endIndex - i - 1);
                        group = InterpretTemplate1(group);

                        regexBuilder.Append($"({group})"); // Группа, которую будем интерпретировать
                        i = endIndex; // Пропустить обработанный участок
                    }
                    break;
                case '~':
                    regexBuilder.Append(@"[^a-zA-Zа-яА-Я0-9]"); // Соответствует любому символу, кроме букв и цифр
                    break;
                case '*':
                    regexBuilder.Append(".*"); // Соответствует любой последовательности символов
                    break;
                case '?':
                    regexBuilder.Append("?"); // Делает предыдущий символ необязательным
                    break;
                case '!':
                    int notEndIndex = template.IndexOf(' ', i); // Находим конец шаблона
                    string notPattern = (notEndIndex == -1) ? template.Substring(i + 1) : template.Substring(i + 1, notEndIndex - i - 1);
                    regexBuilder.Append($"^(?!.*{notPattern}).*$"); // Соответствует всем строкам, кроме отвечающих шаблону
                    i = (notEndIndex == -1) ? template.Length : notEndIndex - 1; // Пропустить обработанный участок
                    break;
                case '\'':
                    if (i + 1 < template.Length)
                    {
                        regexBuilder.Append(template[i + 1]); // Следующий за ним специальный символ трактуется как обычный
                        i++; // Пропустить следующий символ
                    }
                    break;
                case '|':
                    regexBuilder.Append("|");
                    break;

                default:
                    regexBuilder.Append(Regex.Escape(currentChar.ToString())); // Экранировать обычные символы
                    break;
            }
        }

        return regexBuilder.ToString();
    }

    public static string InterpretTemplate1(string template)
    {
        StringBuilder regexBuilder = new StringBuilder();
        for (int i = 0; i < template.Length; i++)
        {
            char currentChar = template[i];
            switch (currentChar)
            {
                case '#':
                    regexBuilder.Append(@"\d"); // Соответствует любой одиночной цифре
                    break;
                case '+':
                    if (i > 0 && template[i - 1] == '#')
                    {
                        regexBuilder.Length--; // Удалить предыдущий символ
                        regexBuilder.Append(@"[0-9]+"); // Соответствует любому числу
                    }
                    break;
                case '@':
                    regexBuilder.Append(@"[a-zA-Zа-яА-Я]"); // Соответствует любой одиночной букве латиницы или кирилицы
                    break;
                case '[':
                    int endIndex = template.IndexOf(']', i);
                    if (endIndex != -1)
                    {
                        string group = template.Substring(i + 1, endIndex - i - 1);
                        regexBuilder.Append($"[{group}]");
                        i = endIndex; // Пропустить обработанный участок
                    }
                    break;
                case '~':
                    regexBuilder.Append(@"[^a-zA-Zа-яА-Я0-9]"); // Соответствует любому символу, кроме букв и цифр
                    break;
                case '*':
                    regexBuilder.Append(".*"); // Соответствует любой последовательности символов
                    break;
                case '?':
                    regexBuilder.Append("."); // Соответствует любому одиночному символу
                    break;
                case '!':
                    int notEndIndex = template.IndexOf(' ', i); // Находим конец шаблона
                    string notPattern = (notEndIndex == -1) ? template.Substring(i + 1) : template.Substring(i + 1, notEndIndex - i - 1);
                    regexBuilder.Append($"^(?!.*{notPattern}).*$"); // Соответствует всем строкам, кроме отвечающих шаблону
                    i = (notEndIndex == -1) ? template.Length : notEndIndex - 1; // Пропустить обработанный участок
                    break;
                case '\'':
                    if (i + 1 < template.Length)
                    {
                        regexBuilder.Append(template[i + 1]); // Следующий за ним специальный символ трактуется как обычный
                        i++; // Пропустить следующий символ
                    }
                    break;
                default:
                    regexBuilder.Append(Regex.Escape(currentChar.ToString())); // Экранировать обычные символы
                    break;
            }
        }
        return regexBuilder.ToString();
    }
}





