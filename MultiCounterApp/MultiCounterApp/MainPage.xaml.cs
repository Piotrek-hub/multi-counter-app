

using MultiCounterApp.Controls;

namespace MultiCounterApp;

public partial class MainPage : ContentPage
{
    // CollectionView

    public MainPage()
	{
		InitializeComponent();
	}
    void OnCreateCounter(object sender, EventArgs args)
    {
        string counterID = ((Entry)CounterIDInput).Text;

        Counter c = new(counterID);
        stackLayout.Children.Add(c);
        
    }

    void OnClearCounters(object sender, EventArgs args)
    {
        stackLayout.Children.Clear();

    }

}

