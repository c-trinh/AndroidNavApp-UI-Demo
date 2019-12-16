using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Theia.Models.NavigationSystem;
using System.Windows.Input;
using Theia.Models.SettingsSystem;
using System.Threading.Tasks;
using static Theia.Models.NavigationSystem.Direction;

namespace Theia.ViewModels
{
    public class NavViewModel : INotifyPropertyChanged
    {
        Settings settings = Settings.GetInstance();
        int intervalInMiliseconds;

        public NavViewModel()
        {
            intervalInMiliseconds = 250 * settings.StepLength;
            Navigation.Started = true;
            RunNavigationTimer = new Command(RunNavigation);
            StopNavigationTimer = new Command(StopNavigation);
        }

        readonly Navigation Navigation = new Navigation();


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void RunNavigation()
        {
            
            if (!Navigation.LoadMap(settings.Building)){
                MessagingCenter.Send(this, "BadMapAlert", settings.Building);
                return;
            }
            Navigation.Started = true;
            Device.StartTimer(TimeSpan.FromMilliseconds(this.intervalInMiliseconds), () =>
            {

                if (Navigation.Started) Device.BeginInvokeOnMainThread(() => ChangeDirection());
                return !Navigation.Stopped;

            });
        }

        public ICommand RunNavigationTimer { get; set; }

        public ICommand StopNavigationTimer { get; set; }

        public void ChangeDirection()
        {   
            CurrentDirection = Navigation.GetNextDirection();

            //      Uncomment to make the navigation stop when the next direction is idle
            if (CurrentDirection == DirectionName.Idle)
            {
                Navigation.Stopped = true;
            }
            
        }
        private DirectionName direction;
        public DirectionName CurrentDirection
        {
            get => direction;
            set
            {
                if (direction == value)
                {
                    //SpeakDirection(); //Uncomment to have speak every timer tick. Leave commented to speak once.
                    return;  // Don't change, same value
                }
                direction = value;               // Change direction if different value
                SetNavigationImageSource();                 // Sets new image
                SpeakDirection();                           //Speaks the new direction
                OnPropertyChanged();                        //Alerts that the value has beenn changed
            }
        }

        public string NavigationImageSource
        {
            get => Navigation.NavigationImageSource;
            set
            {
                Navigation.NavigationImageSource = value;
                OnPropertyChanged();
            }
        }

        public void SetNavigationImageSource()
        {
            switch (CurrentDirection)
            {
                case (DirectionName.Straight):
                    NavigationImageSource = "arrow_forward.png";
                    break;
                case (DirectionName.Right):
                    NavigationImageSource = "arrow_right.png";
                    break;
                case (DirectionName.Left):
                    NavigationImageSource = "arrow_left.png";
                    break;
                default:
                    NavigationImageSource = "map_icon.png";
                    break;
            }
        }

        public void SpeakDirection()
        {
            
            switch (CurrentDirection)
            {
                case (DirectionName.Straight):
                    TextToSpeech.SpeakAsync(StraightSpeech).ContinueWith((t) =>
                    {
                        // Logic that will run after utterance finishes.

                    }, TaskScheduler.FromCurrentSynchronizationContext());
                    break;
                case (DirectionName.Right):
                    TextToSpeech.SpeakAsync(RightSpeech).ContinueWith((t) =>
                    {
                        // Logic that will run after utterance finishes.

                    }, TaskScheduler.FromCurrentSynchronizationContext());
                    break;
                case (DirectionName.Left):
                    TextToSpeech.SpeakAsync(LeftSpeech).ContinueWith((t) =>
                    {
                        // Logic that will run after utterance finishes.

                    }, TaskScheduler.FromCurrentSynchronizationContext());
                    break;
                case (DirectionName.North):
                    TextToSpeech.SpeakAsync(NorthSpeech).ContinueWith((t) =>
                    {
                        // Logic that will run after utterance finishes.

                    }, TaskScheduler.FromCurrentSynchronizationContext());
                    break;
                case (DirectionName.East):
                    TextToSpeech.SpeakAsync(EastSpeech).ContinueWith((t) =>
                    {
                        // Logic that will run after utterance finishes.

                    }, TaskScheduler.FromCurrentSynchronizationContext());
                    break;
                case (DirectionName.South):
                    TextToSpeech.SpeakAsync(SouthSpeech).ContinueWith((t) =>
                    {
                        // Logic that will run after utterance finishes.

                    }, TaskScheduler.FromCurrentSynchronizationContext());
                    break;
                case (DirectionName.West):
                    TextToSpeech.SpeakAsync(WestSpeech).ContinueWith((t) =>
                    {
                        // Logic that will run after utterance finishes.

                    }, TaskScheduler.FromCurrentSynchronizationContext());
                    break;
                default:
                    TextToSpeech.SpeakAsync(StopSpeech).ContinueWith((t) =>
                    {
                        // Logic that will run after utterance finishes.

                    }, TaskScheduler.FromCurrentSynchronizationContext());
                    break;
            }

        }
        public void StopNavigation()
        {
            Navigation.Stopped = true;
        }
    }
}