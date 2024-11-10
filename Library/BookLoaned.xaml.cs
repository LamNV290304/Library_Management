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
    /// Interaction logic for BookLoaned.xaml
    /// </summary>
    public partial class BookLoaned : Page
    {
        private readonly LibraryContext _context;
        public BookLoaned()
        {
            InitializeComponent();
            _context = new LibraryContext();
        }

        private void LoadLoanedBooks()
        {
            int userId = 0;//= Session.Current.UserId;

            var loanedBooks = from b in _context.Books
                              join l in _context.Loans on b.BookId equals l.BookId
                              join u in _context.Users on l.UserId equals u.UserId
                              join a in _context.Authors on b.AuthorId equals a.AuthorId
                              join c in _context.Categories on b.CategoryId equals c.CategoryId
                              where u.UserId == userId && l.ReturnDate != null
                              select new
                              {
                                  Title = b.Title,
                                  AuthorName = a.Name,
                                  CategoryName = c.Name,
                                  DueDate = l.DueDate,
                                  Fine = l.Fine,
                                  OverdueDays = l.OverdueDays
                              };

            dgLoanedBooks.ItemsSource = loanedBooks.ToList();
        }

        private void dgLoanedBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
