using Exam.Service.Interfaces;
using Exam.Service.Services;
using ExamDesktop.UI.Pages;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace ExamDesktop.UI.Controllers
{
    /// <summary>
    /// Interaction logic for PrivateChat.xaml
    /// </summary>
    public partial class PrivateChat : UserControl
    {
        private readonly IStudentService studentService;
        public PrivateChat()
        {
            studentService = new StudentService();
            InitializeComponent();
        }
    }
}
