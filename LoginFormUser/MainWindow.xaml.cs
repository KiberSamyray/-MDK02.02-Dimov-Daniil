using LoginFormUser.Model;
using LoginFormUser.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity.Hierarchy;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace LoginFormUser
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       public static UserDBEntities dBEntitiesUser = new UserDBEntities();
        public MainWindow()
        {
            InitializeComponent();
            
           
        }

        private void Sign_Reg_Click(object sender, RoutedEventArgs e)
        {
            RegistrationPage regpage = new RegistrationPage();
            Close();
            regpage.Show();
        }

        private void Sign_In_Click(object sender, RoutedEventArgs e)
        {   
            if(LoginField.Text == "")
            {
                MessageBox.Show("Заполните поле Логин!");
            }
            else if(PasswordField.Password == "")
            {
                MessageBox.Show("Заполните поле пароль!");
            }
            else if(CodeField.Text == "")
            {
                MessageBox.Show("Введите кодовое слово!");
            }
            else
            {
                
                var CurrentUser = dBEntitiesUser.User.FirstOrDefault(u => u.Email == LoginField.Text && u.Password == PasswordField.Password && u.Codeword == CodeField.Text);
                if (CurrentUser != null)
                {
                    MessageBox.Show("Добро пожаловать!");
                    PersonalAccountPage accountPage = new PersonalAccountPage();
                    accountPage.FName.Text = CurrentUser.FirstName;
                    accountPage.LName.Text = CurrentUser.LastName;
                    accountPage.Show();
                    
                }
                else
                {
                    MessageBox.Show("Пользователь не найден зарегистрируйтесь");
                }

            }

            
            
        }
        
    }
}
