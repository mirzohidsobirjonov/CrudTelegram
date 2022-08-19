﻿using Exam.Service.DTOs.Users;
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
    /// Interaction logic for CreationPage.xaml
    /// </summary>
    public partial class CreationPage : Page
    {
        private readonly IStudentService studentService;
        public CreationPage()
        {
            studentService = new StudentService();
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (firsname.Text is not null && lastname is not null && faculty.Text is not null)
            {
                await studentService.CreateAsync(new StudentForCreationDTO()
                {
                    Firstname = firsname.Text,
                    Lastname = lastname.Text,
                    Faculty = faculty.Text
                });

                firsname.Clear();
                lastname.Clear();
                faculty.Clear();
            }
        }
    }
}
