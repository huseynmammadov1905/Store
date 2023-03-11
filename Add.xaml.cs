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

namespace On__Store
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public bool check = false;
        public Product productAdd { get; set; } = new();
        public Add()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tb_image.Text.Length > 0 && tb_name.Text.Length > 0 && tb_price.Text.Length > 0)
            {
                productAdd = new Product()
                {
                    Name = tb_name.Text,
                    Price = Convert.ToDouble(tb_price.Text),
                    Image = tb_image.Text.ToString(),
                };
                MessageBox.Show("Mehsul Stende elave olundu","",MessageBoxButton.OK, MessageBoxImage.Information);
                check = true;
                this.Close();
            }
            else
            {
                check = false;
                MessageBox.Show("Melumatlar bosh buraxila bilmez", "warning", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
