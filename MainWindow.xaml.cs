using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.DirectoryServices.ActiveDirectory;
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

namespace On__Store
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public Product Product
        {
            get { return (Product)GetValue(ProductProperty); }
            set { SetValue(ProductProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Product.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProductProperty =
            DependencyProperty.Register("Product", typeof(Product), typeof(MainWindow));


        public ObservableCollection<Product>? products { get; set; } = new()
        {
            new Product {Count =1,Name = "Coca Cola" ,Price =1.2,Color = new SolidColorBrush(Colors.Red),Image = "https://thumbs.dreamstime.com/b/krasnoyarsk-russia-june-coca-cola-classic-glass-bottle-dark-toned-foggy-reds-black-background-coke-delicious-appetizing-151878046.jpg"},
            new Product {Count =1,Name = "Red Bull" ,Price =3.5,Color = new SolidColorBrush(Colors.DodgerBlue),Image = "C:\\Users\\memme\\OneDrive\\Masaüstü\\Red Bull.png"},
            new Product { Count =1,Name = "Fanta" ,Price =1.2,Color = new SolidColorBrush(Colors.Orange),Image = "https://thumbs.dreamstime.com/b/bottle-fanta-drink-gradient-background-bottle-fanta-drink-gradient-background-fanta-fruit-flavored-carbonated-soft-109700534.jpg"},
            new Product {Count =1, Name = "Bonaqua" ,Price =0.7,Color = new SolidColorBrush(Colors.SkyBlue),Image = "https://thumbs.dreamstime.com/b/gomel-belarus-february-bonaqua-beverage-plastic-bottle-black-background-bottles-watergomel-86222591.jpg"},
            new Product {Count = 1,  Name = "Lays" ,Price =2.45,Color = new SolidColorBrush(Colors.Yellow),Image = "https://stories.pepsicojobs.com/wp-content/uploads/2020/08/SYI-Lays-Header-mobile.jpg"},
            new Product {Count = 1,  Name = "Doritos" ,Price =2.7,Color = new SolidColorBrush(Colors.DarkRed),Image = "https://cdn.cheapism.com/images/Nacho_Cheese_Doritos.max-784x410.png"},
            new Product {Count = 1,  Name = "Snickers" ,Price =1.3,Color = new SolidColorBrush(Colors.SaddleBrown),Image = "https://my-live-01.slatic.net/p/ab6814f372a909773c09b834de386b81.jpg"},
            new Product {Count = 1,  Name = "Twix" ,Price =1.3,Color = new SolidColorBrush(Colors.Chocolate),Image = "https://i.pinimg.com/222x/78/c2/0b/78c20b5665d1a0e587df51cd65c49c3e.jpg"},
            new Product {Count = 1,  Name = "Magnum" ,Price =3,Color = new SolidColorBrush(Colors.Sienna),Image = "http://2.bp.blogspot.com/_lIlojMYK6_k/TNQ9BOEfJ1I/AAAAAAAAAe0/1miw7pSQFB4/s1600/cream-almond.jpg"},

        };

        public ObservableCollection<Product> markerBasket { get; set; } = new();
        public ObservableCollection<Product> Temp { get; set; } = new();
      

        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < products.Count; i++)
            {
                Temp.Add(products[i]);
            }
            DataContext = this;
        }

        private void btn_basket_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                double cash = 0;

                Basket basket = new Basket();
                basket.basket = markerBasket;
                foreach (var pr in basket.basket)
                {
                    cash += Convert.ToDouble(pr.Price);
                }
                basket.Cash = cash;
                basket.Show();
            }
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {

            Add add = new Add();
            add.ShowDialog();
            if (add.check)
            {
                products?.Add(add.productAdd);
            }
            else
            {
                MessageBox.Show("Yeni Mehsul Elave oluna bilmedi");
            }
        }

        private void lv_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListBox listBox)
            {
                if (listBox.SelectedItem is Product pr)
                {

                    Edit edit = new(pr);
                    edit.ShowDialog();

                    foreach (Product p in products)
                    {
                        if (pr.Name == p.Name)
                        {
                            p.Name = edit.p.Name;
                            p.Price = edit.p.Price;
                            p.Color = edit.p.Color;
                            p.Image = edit.p.Image;
                        }
                    }

                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double cash = 0;

            if (sender is Button btn)
            {
                if (btn.DataContext is Product product)
                {
                    markerBasket.Add(product);
                    MessageBox.Show("Mehsul Sebete Elave Olundu", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void TextBox_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is TextBox txt)
            {
                if (txt.Text == "Search")
                {
                    txt.Text = "";
                }
            }
        }

        private void TextBox_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is TextBox txt)
            {
                if (txt.Text.Length == 0)
                {
                    txt.Text = "Search";
                }
            }
        }



        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            
            var list = new ObservableCollection<Product>();
            for (int i = 0; i < products.Count; i++)
            {
                list.Add(products[i]);
            }
         
            products.Clear();
            if (tb_search.Text != "Search" && tb_search.Text != "")
            {
                products.Clear();
                foreach (var item in list)
                {
                    if (tb_search.Text.ToLower() == item.Name.ToLower())
                    {
                        products.Add(item);
                    }
                }
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    products.Add(list[i]);
                }
            }

        }

        private void tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(tb_search.Text  == "")
            {
                products.Clear();
                for (int i = 0; i < Temp.Count; i++)
                {
                    products.Add(Temp[i]);
                }
            }
        }
    }
}
