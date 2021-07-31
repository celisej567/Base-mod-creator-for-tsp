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
using System.Windows.Shapes;

using System.Net;
using System.IO;
using System.Threading;

namespace filezamena
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        




        public void DLL()
        {


            if (!Directory.Exists(foldername + "bin"))
                Directory.CreateDirectory(foldername + "bin");

            var client = new WebClient();
            client.DownloadFile("https://github.com/celisej567/Base-mod-creator-for-tsp/blob/master/filezamena/Resources/client.dll?raw=true", foldername + "bin\\client.dll");

            var server = new WebClient();
            client.DownloadFile("https://github.com/celisej567/Base-mod-creator-for-tsp/blob/master/filezamena/Resources/server.dll?raw=tru", foldername + "bin\\server.dll");

            var matchmaking = new WebClient();
            client.DownloadFile("https://github.com/celisej567/Base-mod-creator-for-tsp/blob/master/filezamena/Resources/matchmaking.dll?raw=tru", foldername + "bin\\matchmaking.dll");

            

        }



        public string foldername
        {
            get;set;
        }


        public Window1()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(() => { DLL(); }));
            
            thread.Start();
            
            this.Close();
            
        }

    }
}
