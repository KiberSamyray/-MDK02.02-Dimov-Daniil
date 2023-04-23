using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using MyPersonClass1;
using System;
using System.Windows;
using System.Windows.Input;

namespace MyPersonClass1
{
    
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            FirstName.PreviewTextInput += new TextCompositionEventHandler(Field_PreviewTextInput);
            FirstName.PreviewKeyDown += new KeyEventHandler(Field_PreviewKeyDown);
            LastName.PreviewTextInput += new TextCompositionEventHandler(Field_PreviewTextInput);
            LastName.PreviewKeyDown += new KeyEventHandler(Field_PreviewKeyDown);
            FirstName.CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, OnPasteCommand));
            LastName.CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, OnPasteCommand));
            DatePL.SelectedDate = DateTime.Now;
        }
        [Benchmark]
        private void Buttin_Zapis_Click(object sender, RoutedEventArgs e)
        {
            Person person = new Person();
            person.FirstName = FirstName.Text;
            person.LastName = LastName.Text;
            DateTime birthdate = DatePL.SelectedDate.Value;
            int age = person.Age(birthdate);
            if (FirstName.Text == "" || LastName.Text == "")
            {
                MessageBox.Show("Одно из полей имени или фамилии не заполнено");
                return;
            }
            else if(age<18 || age > 65)
            {
                MessageBox.Show("Введите корректный возраст");
                return;
            }
            else
            {
                MessageBox.Show($"{person.FirstName} {person.LastName} в возрасте {age} лет");
                return;
            }

        }
            private void Field_PreviewKeyDown(object sender, KeyEventArgs e) 
            {
            if (e.Key == Key.Space)
                {
                    e.Handled = true;
                }
            }
        private void Field_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (int.TryParse(e.Text, out int i))
            {
                e.Handled = true;
            }
        }
          public void OnPasteCommand(object sender, ExecutedRoutedEventArgs e)
        {

        }
    }
}
