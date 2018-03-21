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

namespace ALevelProject
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        public Search()
        {
            InitializeComponent();
        }
        private void UpdateResults(object sender, TextChangedEventArgs e)
        {
            SearchParams search = new SearchParams()
            {
                ProductID = ProductID.Text,
                ProductName = ProductName.Text,
                Type = Type.Text,
                Colour = Colour.Text,
                Range = Range.Text,
                Date = Date.Text,
                StoreCode = StoreCode.Text,
                StoreName = StoreName.Text,
                TownCity = TownCity.Text,
                PostCode = Postcode.Text
            };
            var ProductFilterEntered = false;
            var StoreFilterEntered = false;
            if(ProductID.Text != "" || ProductName.Text != "" || Type.Text != "" || Colour.Text != "" || Range.Text != "")
            {
                ProductFilterEntered = true;
            }
            if(StoreCode.Text != "" || StoreName.Text != "" || TownCity.Text != "" || Postcode.Text != "")
            {
                StoreFilterEntered = true;
            }
            if (ProductFilterEntered && !StoreFilterEntered)
            {
                search.SearchType = 0;
            }
            if (!ProductFilterEntered && StoreFilterEntered)
            {
                search.SearchType = 1;
            }
            if(ProductFilterEntered && StoreFilterEntered)
            {
                search.SearchType = 2;
            }
            var resultsSource = SearchControler.Search(search);
            if (resultsSource != null && resultsSource.Count != 0)
            {
                switch (resultsSource[0].SearchType)
                {
                    case 0:
                        {
                            List<Products> products = resultsSource.Cast<Products>().ToList();
                            ResultViewer.Visibility = Visibility.Visible;
                            ListViewer.Visibility = Visibility.Collapsed;
                            ResultViewer.View = this.FindResource("Product") as ViewBase;
                            ResultViewer.ItemsSource = products;
                            break;
                        }
                    case 1:
                        {
                            List<Store> stores = resultsSource.Cast<Store>().ToList();
                            ResultViewer.Visibility = Visibility.Visible;
                            ListViewer.Visibility = Visibility.Collapsed;
                            ResultViewer.View = this.FindResource("Store") as ViewBase;
                            ResultViewer.ItemsSource = stores;
                            break;
                        }
                    case 2:
                        {
                            List<AdvancedSearch> AdvancedS = resultsSource.Cast<AdvancedSearch>().ToList();
                            ResultViewer.Visibility = Visibility.Collapsed;
                            ListViewer.Visibility = Visibility.Visible;
                            ListViewer.ItemsSource = AdvancedS;
                            break;
                        }

                }
            } else
            {
                ResultViewer.ItemsSource = null;
            }
        }
    }

}
