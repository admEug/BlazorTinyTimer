using System.Timers;

namespace BlazorTinyTimer.Pages
{
	public partial class Index
    {
        const string DEFAULT_TIME = "00:00:00";
        string elapsedTime = DEFAULT_TIME;
        System.Timers.Timer timer = new System.Timers.Timer(1);
        DateTime startTime = DateTime.Now;
        bool isRunning = false;

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            DateTime currentTime = e.SignalTime;
            elapsedTime = $"{currentTime.Subtract(startTime)}";
            StateHasChanged();
        }

        void StartTimer()
        {
            startTime = DateTime.Now;
            timer = new System.Timers.Timer(1);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
            isRunning = true;
        }

        void StopTimer()
        {
            isRunning = false;
            Console.WriteLine($"Elapsed Time: {elapsedTime}");
            timer.Enabled = false;
            elapsedTime = DEFAULT_TIME;
        }

        void OnTimerChanged()
        {
            if (!isRunning)
                StartTimer();
            else
                StopTimer();
        }
    }
}