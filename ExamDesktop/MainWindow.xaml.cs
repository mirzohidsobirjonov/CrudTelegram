using Exam.Domain.Entities.Users;
using Exam.Service.Interfaces;
using Exam.Service.Services;
using ExamDesktop.UI.Controllers;
using ExamDesktop.UI.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ExamDesktop
{
    public partial class MainWindow : Window
    {
        private readonly CreationPage creationPage;
        private readonly DeletePage deletePage;
        private readonly UpdatePage updatePage;
        private IEnumerable<Student> allStudents;
        private IStudentService studentService;
        private Thread thread;

        public MainWindow()
        {
            InitializeComponent();
            creationPage = new CreationPage();
            deletePage = new DeletePage();
            updatePage = new UpdatePage();
            studentService = new StudentService();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(async () =>
            {
                this.Dispatcher.Invoke(() => StudentsList.Items.Clear());

                allStudents = await studentService.GetAllAsync();

                await LoadStudents(allStudents);
            });

            thread.Start();

        }

        private async Task LoadStudents(IEnumerable<Student> students)
        {
            foreach (var student in students)
            {
                await this.Dispatcher.InvokeAsync(() =>
                {
                    PrivateChat privateChat = new PrivateChat();
                    privateChat.NameTxt.Text = student.FirstName + " " + student.LastName;
                    privateChat.LastMsgTxt.Text = student.Faculty;
                    privateChat.NewMsgCountTxt.Text = student.Id.ToString();
                    privateChat.DateTimeTxt.Text = DateTime.UtcNow.ToString("HH:mm");
                    privateChat.UserImg.ImageSource = student.Image is not null
                        ? new BitmapImage(new Uri("https://talabamiz.uz/" + student.Image.Path))
                        : new BitmapImage(new Uri("https://w7.pngwing.com/pngs/831/88/png-transparent-user-profile-computer-icons-user-interface-mystique-miscellaneous-user-interface-design-smile-thumbnail.png"));

                    StudentsList.Items.Add(privateChat);
                });
            }
        }

        private void SearchTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            StudentsList.Items.Clear();

            string text = SearchTxt.Text.ToLower();

            thread = new Thread(async () =>
            {
                var users = (await studentService.GetAllAsync()).Where(p => p.FirstName.ToLower().Contains(text)
                || p.LastName.ToLower().Contains(text)
                || p.Faculty.ToLower().Contains(text));

                await LoadStudents(users);
            });
            thread.Start();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            pages.Content = creationPage;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            pages.Content = deletePage;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pages.Content = updatePage;
        }
    }
}
