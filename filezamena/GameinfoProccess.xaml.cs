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

namespace filezamena
{
    /// <summary>
    /// Логика взаимодействия для GameinfoProccess.xaml
    /// </summary>
    public partial class GameinfoProccess : Window
    {

        public bool isClose
        {
            get; set;
        } = true;


        public GameinfoProccess()
        {
            InitializeComponent();
            this.Closing += (o, e) =>
            {
                isClose = false;
            };
        }
    }
}
