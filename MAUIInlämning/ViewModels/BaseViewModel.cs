using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAUIInlämning.ViewModels
{
    public partial class BaseViewModel : ObservableObject //Impelementerar denna funktion från NugetPackage CommunityToolkit.Mvvm
    {
        

        //Använder dataanotation för att skapa en property med OnPropertyChanged automatiskt
        [ObservableProperty]
        private string? title;


       
    }
}
