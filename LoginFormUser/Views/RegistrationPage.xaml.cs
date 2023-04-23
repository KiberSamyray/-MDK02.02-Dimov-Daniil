using LoginFormUser.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LoginFormUser.Views
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Window
    {
        public static UserDBEntities dBEntitiesUser = new UserDBEntities();
        
        Regex regex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
        Regex Fregex = new Regex(@"^[А-ЯЁ][а-яё]+ [А-ЯЁ][а-яё]+$");
        public RegistrationPage()
        {
            InitializeComponent();
            ListSecretQuestion.ItemsSource = dBEntitiesUser.SecretQuestion.ToList();
            FName.PreviewTextInput += new TextCompositionEventHandler(Field_PreviewTextInput);
            LName.PreviewTextInput += new TextCompositionEventHandler(Field_PreviewTextInput);
        }
        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            AddNewUser();
        }

        private void AddNewUser()
        {
            var CurrentListQuestion = ListSecretQuestion.SelectedItem as SecretQuestion;
            User user = new User();
            user.FirstName = FName.Text.Trim();
            user.FirstName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(user.FirstName.ToLower());
            user.LastName = LName.Text.Trim();
            user.LastName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(user.LastName.ToLower());
            user.Email = Email.Text.Trim().ToLower();
            user.Codeword = SecretWord.Text.Trim();
            user.Password = Password.Password.Trim();

            if (Password.Password.Length < 8)
            {
                MessageBox.Show("Поле пароль должно быть больше 8 символов");
            }
            else if (regex.IsMatch(user.Password) == false)
            {
                MessageBox.Show("Поле пароль должно содержать цифры, заглавные символы, и специальные символы");
            }
            if (user.Email.Length < 5 || !user.Email.Contains("@") || !user.Email.Contains(".") || !user.Email.Contains("com"))
            {
                MessageBox.Show("Поле почта должна содержать символ @ и приписку .com , .ru");
            }

            if (Password.Password != FPassword.Password)
            {
                MessageBox.Show("Пароли не совпадают");
            }
            else
                user.Password = Password.Password.Trim();


            if (CurrentListQuestion == null)
            {
                MessageBox.Show("Выберите секретный вопрос");

            }
            else
            {
                user.CodeSecretQuestionId = CurrentListQuestion.SecretCodeId;
            }
            user.SecretQuestionAnswer = Answer.Text.Trim();
            if (user.FirstName == "" || user.LastName == "" || user.Email == "" || user.Codeword == "" || user.Password == "" || user.SecretQuestionAnswer == "")
            {
                MessageBox.Show("Одно из ключевых полей не заполнено! Проверьте все ли поля заполнены");
            }

            if (Checked.IsChecked == true)
            {   
                
                if (Password.Password.Length > 8 && regex.IsMatch(user.Password) == true && Password.Password == FPassword.Password && CurrentListQuestion != null && user.FirstName != "" && user.LastName != "" && user.Email != "" && user.Codeword != "" && user.Password != "" && user.SecretQuestionAnswer != "")
                {
                   
                    if (dBEntitiesUser.User.FirstOrDefault(u => u.Email == Email.Text) != null)
                    {
                        MessageBox.Show("Пользователь с таким логином уже зарегистрирован!");
                    }
                    else
                    {
                        dBEntitiesUser.User.Add(user);
                        dBEntitiesUser.SaveChanges();
                        MessageBox.Show("Вы зарегистированы!");
                        PersonalAccountPage accountPage = new PersonalAccountPage();
                        accountPage.FName.Text = user.FirstName;
                        accountPage.LName.Text = user.LastName;

                    }
                }

            }
            else
            {
                MessageBox.Show("Примите соглашение!");
            }
        }
        private void Field_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (int.TryParse(e.Text, out int i))
            {
                e.Handled = true;
            }
        }

        private void LoginPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow logpage = new MainWindow();
            Close();
            
            logpage.Show();
        }
    }
}
