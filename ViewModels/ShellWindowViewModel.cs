using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using ModuleA.ViewModels;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace PrismDEMO.ViewModels
{
    public class ShellWindowViewModel : BindableBase
    {
       

        public ShellWindowViewModel()
        {
            
            ExportCommand = new DelegateCommand(Click, CanCLick);
            

        }



        private bool CanCLick()
        {
            return true;
        }

        private void Click()
        {
            var opt = new JsonSerializerOptions() { WriteIndented = true };
            List<ViewAViewModel> predictionsList = ViewAViewModel.Instance.PredictionDataItems.ToList();
            //var json = JsonSerializer.Serialize(predictionsList);
            //File.WriteAllText(@"predictions.json", json);

            List<PredictionOutput> predict = new List<PredictionOutput>();

            foreach (var item in predictionsList)
            {
                predict.Add(new PredictionOutput
                {
                    Date = item.Date,
                    HomeTeam = item.HomeTeam,
                    AwayTeam = item.AwayTeam,
                    BTTS = item.Result,
                    OverUnder = item.UnderOverResult,
                    BTTSPercentages = item.BTTSPercentages


                });  
            
            }

          
            predict.RemoveRange(0, predict.Count - (predict.Count - 1));
            

          



             var json = JsonSerializer.Serialize(predict);
            File.WriteAllText(@"prediction.json", json);
        }

        public DelegateCommand ExportCommand { get; private set; }




      

    }
}
