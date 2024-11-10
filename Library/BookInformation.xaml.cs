using Library.Dto;
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
using System.Windows.Shapes;

namespace Library
{
    /// <summary>
    /// Interaction logic for BookInformation.xaml
    /// </summary>
    public partial class BookInformation : Page
    {
        private readonly LibraryContext _context;
        public BookInformation(BookViewModel selectionBook)
        {
            InitializeComponent();
            BookSelection(selectionBook.Title);

        }

        private void BookSelection(string selectionBookTitle)
        {
            var book = _context.Books.FirstOrDefault(b => b.Title.Equals(selectionBookTitle, StringComparison.OrdinalIgnoreCase));
            txtTitle.Text = book.Title;
            txtPublisher.Text = book.Publisher.Name;
            txtPublicationYear.Text = book.PublicationYear.ToString();
            txtCategory.Text = book.Category.Name;
            txtTotalCopies.Text = book.TotalCopies.ToString();
            txtAvailableCopies.Text = book.AvailableCopies.ToString();
            txtPrice.Text = book.Price.ToString();
        }
    }
}
