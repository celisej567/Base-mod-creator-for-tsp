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
using System.Diagnostics;



using System.Net;
using System.IO;




namespace filezamena
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string modname;
        public string foldername;
        public string clearfoldername;


        public MainWindow()
        {
            Window1 window1 = new Window1();
            GameinfoProccess gameinfoProccess = new GameinfoProccess();
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            this.End.Visibility = Visibility.Hidden;
            this.Progressbar.Visibility = Visibility.Visible;
            this.Progressbar.Value = 20;


             modname = this.Modname.Text;
             foldername = this.Foldername.Text+"\\";
             clearfoldername = this.Foldername.Text;



            /*
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
            */

            string path_dir = "thestanleyparable\\";
            string path = "gameinfo.txt";
            if (!Directory.Exists(path_dir))
                Directory.CreateDirectory(path_dir);
            if (!File.Exists(path_dir+path))
                File.Create(path_dir+path);


                bool? check_dll = this.DLLCheck.IsChecked;
            if (check_dll == true)
            {

                this.End.Visibility = Visibility.Hidden;
                this.Progressbar.Visibility = Visibility.Visible;
                this.Progressbar.Value = 20;
                Window1 window1 = new Window1();
                window1.foldername = foldername;
                window1.Show();
                

                Workgameinfo();

            }
            if (check_dll == false)
            {
                this.End.Visibility = Visibility.Hidden;
                this.Progressbar.Visibility = Visibility.Visible;
                this.Progressbar.Value = 20;
                Workgameinfo();
            }
                






            void Workgameinfo()
                {

                GameinfoProccess proccessGameinfo = new GameinfoProccess();
                proccessGameinfo.Show();
                this.Wait.Visibility = Visibility.Visible;

                Console.WriteLine("---READING---\n");


                if (!File.Exists(path_dir + path))
                {
                    var fixgameinfo = new WebClient();
                    string string_fixgameinfo = fixgameinfo.DownloadString("https://raw.githubusercontent.com/celisej567/Base-mod-creator-for-tsp/master/filezamena/bin/Release/thestanleyparable/gameinfo.txt");
                    File.WriteAllText(path_dir+path, string_fixgameinfo);
                }



                string gameinfo_read_write = File.ReadAllText(path_dir+path);
                Console.WriteLine(gameinfo_read_write);

                

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


                var gameinfo = new WebClient();

                    if (!File.Exists(foldername + path))
                    {

                    string string_gameinfo = gameinfo.DownloadString("https://raw.githubusercontent.com/celisej567/Base-mod-creator-for-tsp/master/filezamena/bin/Release/thestanleyparable/gameinfo.txt");
                    File.WriteAllText(foldername+path,string_gameinfo);

                    }
                    else
                    {
                    string read_gameinfo = File.ReadAllText(path_dir + path);
                    File.WriteAllText(foldername+path,read_gameinfo);
                    }

                    this.Progressbar.Value = 90;

                    string gameinfo_new_mod = File.ReadAllText(foldername + path);
                    gameinfo_new_mod = gameinfo_new_mod.Replace($"			Game				|all_source_engine_paths|{clearfoldername}", "//deleted");

                    gameinfo_new_mod = gameinfo_new_mod.Replace("\"The Stanley Parable\"", "\"" + modname + "\"");
                    File.WriteAllText(foldername + path, gameinfo_new_mod);

                    File.WriteAllText("information.lgbt", "Generated by \"Base mod creator for tsp\".\n \t\tCreator celisej567/NTT.");


                    this.Progressbar.Value = 100;
                    this.End.Visibility = Visibility.Visible;
                    this.Wait.Visibility = Visibility.Hidden;

                    //proccessGameinfo.Hide();

            }
        }


    }
}
