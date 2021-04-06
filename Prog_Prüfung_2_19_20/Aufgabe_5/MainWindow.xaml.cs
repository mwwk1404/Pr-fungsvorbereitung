using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
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

namespace Aufgabe_5
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ICollectionView icollectionview;
        public mondialEntities mondialEntities = new mondialEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mondialEntities.City.Load();
            icollectionview = CollectionViewSource.GetDefaultView(mondialEntities.City.Local);
            Maingrid.DataContext = icollectionview;

        }

        private void Vor_Click(object sender, RoutedEventArgs e)
        {
            icollectionview.MoveCurrentToNext();

            if(icollectionview.IsCurrentAfterLast)
            { icollectionview.MoveCurrentToFirst(); }
        }

        private void Zurück_Click(object sender, RoutedEventArgs e)
        {
            icollectionview.MoveCurrentToPrevious();
            if(icollectionview.IsCurrentBeforeFirst)
            {
                icollectionview.MoveCurrentToLast();
            }
        }

        private void speichern_Click(object sender, RoutedEventArgs e)
        {
            mondialEntities.SaveChanges();
        }

        private void Textbox_filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = Textbox_filter.Text;
            if (Textbox_filter.Text != "")
            {
                
                icollectionview.Filter = (x => ((City)x).Name.ToLower().Contains(filter));
            }
            else
            { icollectionview.Filter = null;
                icollectionview.MoveCurrentToFirst();
            }
            int zähler = 0;
            foreach (var item in mondialEntities.City)
            {
                if (item.Name.Contains(filter))
                {
                    zähler = zähler + 1;
                }
            }
            Datensätze.Content = zähler;
            
        }
    }
}
