using Exam.Service.Interfaces;
using Exam.Service.Services;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExamDesktop.UI.Pages
{
    /// <summary>
    /// Interaction logic for DeletePage.xaml
    /// </summary>
    public partial class DeletePage : Page
    {
        private readonly IStudentService studentService;
        public DeletePage()
        {
            studentService = new StudentService();
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if(StudentId.Text is not null)
            {
                await studentService.DeleteAsync(long.Parse(StudentId.Text));
                StudentId.Clear();
            }
        }
    }
}
