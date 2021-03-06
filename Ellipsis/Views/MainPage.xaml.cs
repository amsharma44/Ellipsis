﻿using Ellipsis.Data;
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
using System.Windows.Shapes;

namespace Ellipsis.Views
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void AddVideoButton_Click(object sender, RoutedEventArgs e)
        {
            await ViewModel.Add();
        }

        private void ClearListButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Clear();
        }

        private async void ConvertVideoButton_Click(object sender, RoutedEventArgs e)
        {
            await ViewModel.Convert();
        }
    }
}
