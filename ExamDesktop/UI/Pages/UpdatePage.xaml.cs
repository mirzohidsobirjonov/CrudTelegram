using Exam.Data.IRepositories;
using Exam.Data.Repositories;
using Exam.Domain.Entities.Students;
using Exam.Domain.Entities.Users;
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
    /// Interaction logic for UpdatePage.xaml
    /// </summary>
    public partial class UpdatePage : Page
    {
        private readonly IStudentService studentService;
        private readonly IAttachmentService attachmentService;
        string passportImagePath = string.Empty;
        string imagePath = string.Empty;
        public UpdatePage()
        {
            attachmentService = new AttachmentService();
            studentService = new StudentService();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.PNG,*.JPG;)|*.JPG;*.PNG";
            openFileDialog.InitialDirectory = Environment.GetFolderPath
                (Environment.SpecialFolder.MyPictures);

            if (openFileDialog.ShowDialog() == true)
            {
                passportImagePath = openFileDialog.FileName;

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.PNG,*.JPG;)|*.JPG;*.PNG";
            openFileDialog.InitialDirectory = Environment.GetFolderPath
                (Environment.SpecialFolder.MyPictures);

            if (openFileDialog.ShowDialog() == true)
            {
                imagePath = openFileDialog.FileName;

            }
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            imageName.Text = imagePath;
            passportName.Text = passportImagePath;
            if (Firstname.Text is not null && Lastname.Text is not null && Faculty.Text is not null)
            {
                await attachmentService.CreateAsync(long.Parse(StudentId.Text), imagePath, passportImagePath);
                var res = await studentService.UpdateAsync(long.Parse(StudentId.Text), new Student()
                {
                    FirstName = Firstname.Text,
                    LastName = Lastname.Text,
                    Faculty = Faculty.Text,
                    UpdatedAt = DateTime.UtcNow
                });
            }

        }
    }
}
