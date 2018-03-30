using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace WishTag
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// wish 关键词采集Api
        /// </summary>
        private static readonly string wishTagApiUrl = "https://merchant.wish.com/api/contest-tag/search";

        private WebClient webClient;

        public MainWindow()
        {
            InitializeComponent();
            this.ContentRendered += MainWindow_ContentRendered;
        }

        private void MainWindow_ContentRendered(object sender, EventArgs e)
        {
            webClient = new WebClient();
            var wishlist = new List<WishTagModel>();
            wishlist.Add(new WishTagModel() { TagName = "Led" });
            wishlist.Add(new WishTagModel() { TagName = "Led" });
            wishlist.Add(new WishTagModel() { TagName = "Led" });
            wishlist.Add(new WishTagModel() { TagName = "Led" });
            wishlist.Add(new WishTagModel() { TagName = "Led" });

            listWishTag.ItemsSource = wishlist;
        }

        private void listWishTag_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = listWishTag.SelectedItem as WishTagModel;
            if(item!=null)
            {
                Clipboard.SetText(item.TagName);
            }
        }

        private void listZhTag_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = listWishTag.SelectedItem as WishTagModel;
            if (item != null)
            {
                Clipboard.SetText(item.ZhTagName);
            }
        }

        /// <summary>
        /// 搜索关键词
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {

            loading.Visibility = Visibility.Visible;
            var result= webClient.UploadString(wishTagApiUrl, "q=led");

            loading.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// 翻译
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTranslate_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExport_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
