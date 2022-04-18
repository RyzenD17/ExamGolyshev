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
    /// Логика взаимодействия для ShopPage.xaml
    /// </summary>
    public partial class ShopPage : Page
    {
        public List<Shop> basket = new List<Shop>();
        public float sum = 0;
        public int count = 0;
        public ShopPage()
        {
            InitializeComponent();
            LVShop.ItemsSource = BaseClass.Base.Shop.ToList();
            Cost.Text = "Стоимость покупки: "+sum.ToString();
            BooksCount.Text = "Количество выбранных книг:"+ count.ToString();
        }

        private void TitleGenre_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);
            string titlegenre = "";
            List<Shop> S = BaseClass.Base.Shop.Where(x => x.ID == index).ToList();
            foreach(Shop s in S)
            {
                titlegenre += "Назвиние: " + s.Title + " | Жанр: " + s.Genre;
            }
            tb.Text = titlegenre;
        }

        private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);
            string countInStock = "";
            List<Shop> S = BaseClass.Base.Shop.Where(x => x.ID == index).ToList();
            foreach (Shop s in S)
            {
                if(s.CountInStock>=5)
                {
                    countInStock = "Количество на складе: Много";
                }
                if(s.CountInStock==0)
                {
                    countInStock = "Количество на складе: Нету";
                }
                if(s.CountInStock<5)
                {
                    countInStock = "Количество на складе: "+s.CountInStock.ToString();
                }
            }
            tb.Text = countInStock;
        }

        private void TextBlock_Loaded_1(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);
            string countInShop = "";
            List<Shop> S = BaseClass.Base.Shop.Where(x => x.ID == index).ToList();
            foreach (Shop s in S)
            {
                if (s.CountInShop >= 5)
                {
                    countInShop = "Количество в магазие: Много";
                }
                if (s.CountInShop == 0)
                {
                    countInShop = "Количество в магазие: Нету";
                }
                if (s.CountInShop < 5)
                {
                    countInShop = "Количество в магазие: " + s.CountInShop.ToString();
                }
            }
            tb.Text = countInShop;
        }

        private void btnAddToBasket_Click(object sender, RoutedEventArgs e)
        {
            var book = (Shop)((Button)sender).DataContext;
            if (book.CountInStock == 0 && book.CountInShop == 0)
            {
                MessageBox.Show("Книг нет в наличии!");
                return;
            }
            book.Count++;
            if (!basket.Any(a => a.Title == book.Title))
            {
                basket.Add(book);
            }
            BooksCount.Text = "Количество выбранных книг: " + basket.Sum(a => a.Count).ToString();
            sum = (float)basket.Sum(a => a.Cost * a.Count);
            Cost.Text = "Стоимость покупки: " + sum.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new BasketPage(basket));
        }
    }
}
