using CookIt.Models.ViewModels;
using CookIt.Resources.strings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CookIt.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StepViewPage : ContentPage
    {
        private List<StepViewModel> Steps;
        private StepViewModel CurrentStep;

        public StepViewPage(List<StepViewModel> steps)
        {
            InitializeComponent();

            Steps = steps;
            CurrentStep = Steps.FirstOrDefault();
            SetCounterLabel(CurrentStep.StepNumber);
            BindingContext = CurrentStep;

            PreviousStepButton.Text = Strings.Previous;
            NextStepButton.Text = Strings.Next;

            AdjustButtons();
        }

        private void AdjustButtons()
        {
            if (CurrentStep.StepNumber == 1)
            {
                PreviousStepButton.IsEnabled = false;
                NextStepButton.IsEnabled = true;
            }
            else if (CurrentStep.StepNumber == Steps.Count)
            {
                PreviousStepButton.IsEnabled = true;
                NextStepButton.IsEnabled = false;
            }
            else
            {
                PreviousStepButton.IsEnabled = true;
                NextStepButton.IsEnabled = true;
            }
        }

        private void PreviousStepButton_Clicked(object sender, EventArgs e)
        {
            if (PreviousStepButton.IsEnabled)
            {
                var previousStepNumber = CurrentStep.StepNumber - 2;
                CurrentStep = Steps[previousStepNumber];
                BindingContext = CurrentStep;
                SetCounterLabel(CurrentStep.StepNumber);
            }

            AdjustButtons();
        }

        private void NextStepButton_Clicked(object sender, EventArgs e)
        {
            if (NextStepButton.IsEnabled)
            {
                CurrentStep = Steps[CurrentStep.StepNumber];
                BindingContext = CurrentStep;
                SetCounterLabel(CurrentStep.StepNumber);
            }

            AdjustButtons();
        }

        private void SetCounterLabel(int stepNumber)
        {
            CounterLabel.Text = String.Format(Strings.StepCounter, stepNumber, Steps.Count);
        }
    }
}