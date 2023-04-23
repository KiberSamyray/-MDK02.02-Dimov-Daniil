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
            
                MessageBox.Show($"{person.FirstName} {person.LastName} в возрасте {age} лет");
    
            

        }
            
    }
}
