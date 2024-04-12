using System;
using System.Collections.Generic;
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

namespace WpfApp1_test2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            TreeView treeView = new TreeView();
            treeView.Margin = new Thickness(10, 10, 10, 10);

            GD.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            this.GD.Children.Add(treeView);
            Grid.SetRow(treeView, 0);


            Structure structure = new Structure()
            {
                Age = 1,
                Name = "adfgbf",
                Nested = new NestedStructure() { Value = 0.0 }
            };

            List<TreeViewItem> treeItems = GetPropertiesTreeViewItems(structure);

            foreach (TreeViewItem item in treeItems)
            {
                treeView.Items.Add(item);
            }


        }

        private List<TreeViewItem> GetPropertiesTreeViewItems(object obj)
        {
            List<TreeViewItem> treeItems = new List<TreeViewItem>();
            PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                TreeViewItem item = new TreeViewItem();
                item.Header = property.Name;

                if (property.PropertyType.IsClass && property.PropertyType != typeof(string))
                {
                    object nestedObject = property.GetValue(obj);
                    List<TreeViewItem> nestedItems = GetPropertiesTreeViewItems(nestedObject);
                    foreach (TreeViewItem nestedItem in nestedItems)
                    {
                        item.Items.Add(nestedItem);
                    }
                }
                else
                {
                    // Добавьте нужные вам типы свойств, например string, int, double и т.д.
                    if (property.PropertyType == typeof(string) || property.PropertyType == typeof(int) || property.PropertyType == typeof(double))
                    {
                        item.Items.Add(property.PropertyType.Name);
                    }
                }

                treeItems.Add(item);
            }

            return treeItems;
        }
    }

    public class Structure
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public NestedStructure Nested { get; set; }
    }

    public class NestedStructure
    {
        public double Value { get; set; }
    }
}
