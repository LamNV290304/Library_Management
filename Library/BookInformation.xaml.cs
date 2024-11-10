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
        public BookInformation(BookViewModel selectionBook)
        {
            InitializeComponent();

        }

        private Book BookSelection(int selectionBookId)
        {

        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
        
        }
    }
}
