using Newtonsoft.Json;
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
using System.Xml;

namespace pract4
{
    /// <summary>
    /// Логика взаимодействия для RedactorPage.xaml
    /// </summary>
    public partial class RedactorPage : Page
    {
        public List<TestClass> test = new List<TestClass>();  
        public RedactorPage()
        {
            InitializeComponent();
            TestGrid.ItemsSource = test;
            LoadData();
        }
        private void LoadData()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = System.IO.Path.Combine(desktopPath, "test.json");
            var loadedData = JsonSerDeser.Deserialize<List<TestClass>>(filePath);
            if (loadedData != null)
            {
                test.AddRange(loadedData); 

            }
        }

        private void SaveData()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = System.IO.Path.Combine(desktopPath, "test.json");
            JsonSerDeser.Serialize(test, filePath);

        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            SaveData();

        }


    }
}
