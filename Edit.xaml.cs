using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {


        public Product p { get; set; } = new();

        public Edit(Product pr)
        {
            InitializeComponent();
            lbl_name.Content = pr.Name;
            lbl_price.Content = pr.Price;
            lbl_image.Content = pr.Image;
        }

    

        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {

            p.Name = tb_name.Text;
            p.Price = Convert.ToDouble(tb_price.Text);
            p.Image = tb_image.Text;
            MessageBox.Show("Successful","",MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
