using System.Windows;
using System.Windows.Controls;
using CSharp_lab2.ViewModel;


namespace CSharp_lab2.View
{
    /// <summary>
    /// Логика взаимодействия для SignUpView.xaml
    /// </summary>
    public partial class SignUpView : UserControl
    {
        public SignUpView()
        {
            InitializeComponent();
            DataContext = new SignUpViewModel();
        }
    }
}
