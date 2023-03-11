using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace On__Store
{
    /// <summary>
    /// Interaction logic for Basket.xaml
    /// </summary>
    public partial class Basket : Window
    {

        public double Cash
        {
            get { return (double)GetValue(CashProperty); }
            set { SetValue(CashProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Cash.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CashProperty =
            DependencyProperty.Register("Cash", typeof(double), typeof(Basket));


        public ObservableCollection<Product> basket { get; set; } = new();
        public Basket()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            basket.Clear();
            MainWindow mainWindow = new MainWindow();
            mainWindow.markerBasket.Clear();
            Cash = 0;
            MessageBox.Show("Sechilen Mehsullar Alindi","",MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
