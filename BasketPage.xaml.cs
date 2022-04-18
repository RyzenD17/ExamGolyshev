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

namespace ExamGolyshev
{
    /// <summary>
    /// Логика взаимодействия для BasketPage.xaml
    /// </summary>
    public partial class BasketPage : Page
    {
        public float sum = 0;
        public int count = 0;
        public BasketPage(List<Shop> basket)
        {
            InitializeComponent();
            LVBasket.ItemsSource = basket;
        }

        private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);
            string titlegenre = "";
            List<Shop> S = BaseClass.Base.Shop.Where(x => x.ID == index).ToList();
            foreach (Shop s in S)
            {
                titlegenre += "Назвиние: " + s.Title + " | Жанр: " + s.Genre;
            }
            tb.Text = titlegenre;
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            List<Shop> S = BaseClass.Base.Shop.ToList();
            foreach (Shop n in S)
            {
                count+=n.Count;
                sum +=(float)n.Count * (float)n.Cost;
            }
            string order = "Общая стоимость заказа: "+sum+"\n"+"Количество книг: "+count;
            MessageBox.Show(Convert.ToString(order), "Заказ");
            foreach (Shop s in S)
            {
              s.Count = 0;
            }
            FrameClass.MainFrame.Navigate(new ShopPage());
        }

        private void TextBlock_Loaded_1(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);
            string bookcount = "";
            List<Shop> S = BaseClass.Base.Shop.Where(x => x.ID == index).ToList();
            foreach (Shop s in S)
            {
                bookcount = "Количество книг: "+s.Count.ToString();
            }
            tb.Text = bookcount;
        }
    }
}
