using ListFlix.Models;
using ListFlix.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ListFlix
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Filess _Filess;
        private BindingList<TodoModel> _todoDataList;
        private readonly string PATH = $"{Environment.CurrentDirectory}\\todoDataList.json";
        private  Filess  filess;
        public MainWindow()
        {
            
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            _Filess = new Filess(PATH);

            try
            {
                _todoDataList = _Filess.LoadDate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();

                
            }





            


            Tasks.ItemsSource = _todoDataList;
            _todoDataList.ListChanged += _todoDataList_ListChanged;

        }

        private void _todoDataList_ListChanged(object sender, ListChangedEventArgs e)
        {

            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemChanged )
            {
                try
                {
                    _Filess.SaveDate(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();


                }
            }

        }

        private void Tasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
