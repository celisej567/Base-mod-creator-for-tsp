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
using System.IO;
using System.Diagnostics;

namespace filezamena
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string path_dir = "thestanleyparable\\";
            string path = "gameinfo.txt";
            if (!Directory.Exists(path_dir))
                Directory.CreateDirectory(path_dir);
            if (!File.Exists(path_dir+path))
                File.Create(path_dir+path);

            Workgameinfo();




            void Workgameinfo()
                {
                Console.WriteLine("---READING---\n");
                string gameinfo_read_write = File.ReadAllText(path_dir+path);
                Console.WriteLine(gameinfo_read_write);


                Console.WriteLine("---GENERATING---");
                gameinfo_read_write = gameinfo_read_write.Replace("Game				|all_source_engine_paths|theraphaelparable", "Game				|all_source_engine_paths|theraphaelparable\n\t\t\tGame				|gameinfo_path|.");
                Console.WriteLine("---GENERATED---");


                Console.WriteLine("---WRITTING---");
                File.WriteAllText(path_dir+path, gameinfo_read_write);
                Console.WriteLine("---WRITED---\n");
                Console.WriteLine(gameinfo_read_write);
                }
        }


    }
}
