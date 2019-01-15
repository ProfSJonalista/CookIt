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
            BindingContext = CurrentStep;
            UpdateUI(CurrentStep.StepNumber);

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
                UpdateUI(CurrentStep.StepNumber);
            }

            AdjustButtons();
        }

        private void NextStepButton_Clicked(object sender, EventArgs e)
        {
            if (NextStepButton.IsEnabled)
            {
                CurrentStep = Steps[CurrentStep.StepNumber];
                BindingContext = CurrentStep;
                UpdateUI(CurrentStep.StepNumber);
            }

            AdjustButtons();
        }

        private void UpdateUI(int stepNumber)
        {
            CounterLabel.Text = String.Format(Strings.StepCounter, stepNumber, Steps.Count);
            var timerSpanListVisible = CurrentStep.TimeSpans.Count > 0;

            if (timerSpanListVisible)
            {
                TimerSpansList.HeightRequest = TimerSpansList.RowHeight * CurrentStep.TimeSpans.Count; /*(40 * CurrentStep.TimeSpans.Count) + (10 * CurrentStep.TimeSpans.Count);*/
                TimerSpansList.IsVisible = timerSpanListVisible;
                TimerSpansList.ItemsSource = CurrentStep.TimeSpans;
            }
            else
            {
                TimerSpansList.IsVisible = timerSpanListVisible;
            }
        }

        private void TimerSpansList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            ((ListView)sender).SelectedItem = null;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}