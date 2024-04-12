using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
using static Wpf_test.myclass;

namespace Wpf_test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BindingList<object> bl = new BindingList<object>();
        private ObservableCollection<object> obsoleteCollection;
        ObservableCollection<NetworkProps> obsCol;
        public MainWindow()
        {
            InitializeComponent();
            bl = NBL();




            obsCol = new ObservableCollection<NetworkProps>()
            {
                new NetworkProps(){NetName="set 01", NetDesc="01", NetType="SD",
                    PropFromDict=new PropFromDict("Очередь")
                    {
                         SelectedVal = "Second",
                         StrIdDicr=Dict
                    } },
                new NetworkProps(){NetName="set 02", NetDesc="01", NetType="SD", PropFromDict=new PropFromDict("Очередность"){SelectedVal = "Second",StrIdDicr=Dict } },
                new NetworkProps(){NetName="set 03", NetDesc="01", NetType="SD", PropFromDict=new PropFromDict("Очередность"){SelectedVal = "Second",StrIdDicr=Dict }},
                new NetworkProps(){NetName="set 04", NetDesc="01", NetType="SD", PropFromDict=new PropFromDict("Очередность"){SelectedVal = "Second",StrIdDicr=Dict }},
                new NetworkProps(){NetName="set 05", NetDesc="01", NetType="SD", PropFromDict=new PropFromDict("Очередность"){SelectedVal = "Second",StrIdDicr=Dict }},
            };




            DgSourse.ItemsSource = obsCol;

            DgSourse.AutoGenerateColumns = false;

            PropertyInfo[] propertyInfos = obsCol[0].GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var sd in propertyInfos)
            {
                if (!sd.Name.Contains("PropFrom"))
                {
                    if (sd.Name == "NetDesc")
                    {
                        DgSourse.Columns.Add(new DataGridTextColumn()
                        {
                            Header = sd.Name,
                            Binding = new Binding() { Path = new PropertyPath("PropFromDict.SelectedID") }
                        });

                    }
                    else
                    {
                        DgSourse.Columns.Add(new DataGridTextColumn()
                        {
                            Header = sd.Name,
                            Binding = new Binding() { Path = new PropertyPath(sd.Name) }
                        });
                    }
                }
                else
                {
                    DataGridComboBoxColumn column = new DataGridComboBoxColumn();
                    var sd1 = sd.PropertyType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                        .SingleOrDefault(e => e.Name == "PropName");
                    object obj = sd1.GetValue(obsCol[0].PropFromDict);
                    column.Header = obj.ToString();
                    column.ItemsSource = Dict.Keys;

                    column.SelectedValueBinding = new Binding()
                    {
                        Path = new PropertyPath(sd.Name + "." + "SelectedVal")
                    };

                    DgSourse.Columns.Add(column);
                }
            }


            DgSourse.CellEditEnding += DgSourse_CellEditEnding;
        }

        private void DgSourse_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            DgSourse.SelectedCellsChanged += DgSourse_SelectedCellsChanged;

        }

        private void DgSourse_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DgSourse.Items.Refresh();
            DgSourse.SelectedCellsChanged -= DgSourse_SelectedCellsChanged;

        }


        private void Btn_Ok_Click(object sender, RoutedEventArgs e)
        {
            //DialogResult = true;
            Close();
        }
        internal BindingList<object> rbl => bl;

        public BindingList<object> NBL()
        {
            BindingList<object> nbl = new BindingList<object>()
            {
                new BindData(){Name="name___1", MyCB = MyComboB(Dict)},
                new BindData(){Name="name___2", Value=Data.А15, MyCB = MyComboB(Dict) },
                new BindData(){Name="name___3", MyCB = MyComboB(Dict) },
                new BindData(){Name="name___4", MyCB = MyComboB(Dict) },
            };

            return nbl;
        }

        class MdataGrid : DataGrid
        {

            public MdataGrid(BindingList<object> nbl)
            {
                this.ItemsSource = nbl;

                Binding b1 = new Binding();
                b1.Path = new PropertyPath("DatafromDic");
                this.AutoGenerateColumns = false;
                this.Columns.Add(new DataGridTextColumn() { Binding = new Binding() { Path = new PropertyPath("Name") } });
                this.Columns.Add(new DataGridComboBoxColumn() { TextBinding = b1 });
                this.Columns.Add(new DataGridTemplateColumn() { CellTemplate = new DataTemplate() });
                DataTemplate dataTemplate = new DataTemplate() { DataType = typeof(string[]) };
            }


        }
        public class BindData
        {
            public string Name { get; set; }
            public Data Value { get; set; }
            public Collection<string> Coll { get; set; }
            public static string[] DatafromDic = Dict.Keys.ToArray();
            public string SelectedS = DatafromDic[0];
            public ComboBox MyCB { get; set; }
            public BindData() { }
        }
        public enum Data { А15, Т250, С150 }
        public interface Iprop
        {
            public object Value { get; set; }

        }
        struct ValData
        {
            public object Val { get; set; }
            public object[] Arr => new string[] { "K", "D", "T" };
        }

        private static Dictionary<string, int> Dict = new Dictionary<string, int>()
        {
            {"",0 },
            {"first",1 },
            {"Second",2 },
            {"third",3 },
            {"fourths",4 },
        };
        private static ComboBox MyComboB(Dictionary<string, int> dict)
        {
            ComboBox comboBox = new ComboBox();
            comboBox.ItemsSource = dict.Keys;
            return comboBox;
        }
    }
}
