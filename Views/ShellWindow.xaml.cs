using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using ModuleA.ViewModels;
using PrismDEMO.ViewModels;
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

namespace PrismDEMO.Views
{
    /// <summary>
    /// Interaction logic for ShellWindow.xaml
    /// </summary>
    public partial class ShellWindow : MetroWindow
    {



        public ShellWindow()
        {


            
            InitializeComponent();
           
            
            


        }
        
        


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "OK",
                ColorScheme = MetroDialogColorScheme.Accented
            };





            var sb = new StringBuilder();
            sb.AppendLine("The goal of this program is to predict Both To Score outcome between two football clubs");
            sb.AppendLine("using Neural Network Binary Classification Algorithm");
            sb.AppendLine("Copyright(c) 2022, I.Mandic");

            await this.ShowMessageAsync("About Neural BTTS Predictor", $"{sb}",
                MessageDialogStyle.Affirmative, mySettings);
        }

        private async void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var holderContent = this;

            var progress = new ProgressRing
            {
                IsActive = true,
                Visibility = Visibility.Visible,
                IsLarge = false,
                Width = 75,
                Height = 75,
                
            };
            var def = holderContent.Content;
            holderContent.Content = progress;
            
           //var progressCtrl = await holderContent.ShowProgressAsync("Loading predictions...", "");
            
            await Task.Run(async () => await ViewAViewModel.Instance.MultiLoader().ContinueWith(delegate
            {
                {
                    Dispatcher.Invoke(() =>
                    {
                        //holderContent.ShowMessageAsync("", "Predictions Loaded", MessageDialogStyle.Affirmative, null);
                       
                        holderContent.Content = def;
                        
                    });
                }
            }));



        }
    }
}

