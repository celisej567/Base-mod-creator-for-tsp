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
            string modname = this.modname.Text;
            string foldername = this.Foldername.Text+"\\";
            string clearfoldername = this.Foldername.Text;
            
            void DLL()
            {
                if (!Directory.Exists(foldername + "bin"))
                    Directory.CreateDirectory(foldername + "bin");

                byte[] client = Properties.Resources.client;
                File.WriteAllBytes(foldername + "bin\\client.dll", client);

                byte[] server = Properties.Resources.server;
                File.WriteAllBytes(foldername + "bin\\server.dll", server);

                byte[] matchmaking = Properties.Resources.matchmaking;
                File.WriteAllBytes(foldername + "bin\\matchmaking.dll", matchmaking);
            }


            string path_dir = "thestanleyparable\\";
            string path = "gameinfo.txt";
            if (!Directory.Exists(path_dir))
                Directory.CreateDirectory(path_dir);
            if (!File.Exists(path_dir+path))
                File.Create(path_dir+path);


                bool? check_dll = this.DLLCheck.IsChecked;
            if (check_dll == true)
            {
                DLL();
                Workgameinfo();

            }
            if (check_dll == false)
            {
                Workgameinfo();
            }
                






            void Workgameinfo()
                {

                this.End.Visibility = Visibility.Hidden;

                this.Progressbar.Visibility = Visibility.Visible;

                Console.WriteLine("---READING---\n");
                string gameinfo_read_write = File.ReadAllText(path_dir+path);
                Console.WriteLine(gameinfo_read_write);

                this.Progressbar.Value = 20;

                Console.WriteLine("---GENERATING---");
                
                {
                    gameinfo_read_write = gameinfo_read_write.Replace("			Game				|gameinfo_path|.", $"			Game				|all_source_engine_paths|{clearfoldername}\n\t\t\tGame				|gameinfo_path|.");
                }
                Console.WriteLine("---GENERATED---");


                Console.WriteLine("---WRITTING---");
                File.WriteAllText(path_dir+path, gameinfo_read_write);
                Console.WriteLine("---WRITED---\n");
                Console.WriteLine(gameinfo_read_write);
                this.Progressbar.Value = 60;

                Console.WriteLine("---CREATING FOLDER---");
                if (!Directory.Exists(foldername))
                    Directory.CreateDirectory(foldername);

                this.Progressbar.Value = 70;

                Console.WriteLine("---COPING FILES---");

                




                    if (!File.Exists(foldername + path))
                    { File.WriteAllText(foldername + path, Properties.Resources.gameinfo); }
                    else
                    {
                        File.Delete(foldername + path);
                        string g = Properties.Resources.gameinfo;
                        File.WriteAllText(foldername + path, g);



                    }

                    this.Progressbar.Value = 90;

                    string gameinfo_new_mod = File.ReadAllText(foldername + path);
                    gameinfo_new_mod = gameinfo_new_mod.Replace($"			Game				|all_source_engine_paths|{clearfoldername}", "//deleted");

                    gameinfo_new_mod = gameinfo_new_mod.Replace("\"The Stanley Parable\"", "\"" + modname + "\"");
                    File.WriteAllText(foldername + path, gameinfo_new_mod);

                    this.Progressbar.Value = 100;
                    this.End.Visibility = Visibility.Visible;
                

                
            }
        }


    }
}
