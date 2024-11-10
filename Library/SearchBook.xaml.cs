using Library.Models;
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

namespace Library
{
    /// <summary>
    /// Interaction logic for SearchBook.xaml
    /// </summary>
    public partial class SearchBook : Page
    {
        private LibraryContext _context;
        public SearchBook()
        {
            InitializeComponent();
            _context = new LibraryContext();
        }

        private void LoadData()
        {
            var books = _context.Books.ToList();
            dgResults.ItemsSource = books;

            var categories = _context.Categories.ToList();
            cbCategory.ItemsSource = categories;

        }

        private void LoadCategories()
        {
            var categories = _context.Categories.ToList();

            var allCategoriesItem = new Category
            {
                Name = "Tất cả thể loại",
                CategoryId = 0
            };
            categories.Insert(0, allCategoriesItem);
            cbCategory.ItemsSource = categories;
        }

        private void cbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dgResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
