using System.Diagnostics;

namespace MultiCounterApp.Controls;

public partial class Counter : ContentView
{
    public int counterState = 0;
    public string counterID = string.Empty;

    string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "temp.txt");

    public Counter(string counterID)
	{
        this.counterID= counterID;

		InitializeComponent();

        this.readStateFromFile();

        CounterValue.Text = counterState.ToString();
    }

    void IncrementCounter(object sender, EventArgs args)
    {
        changeCounterState(1);
        updateCounterValueText();
        saveStateToFile();
    }

    void DecrementCounter(object sender, EventArgs args)
    {
        changeCounterState(-1);
        updateCounterValueText();
        saveStateToFile();
    }

    void changeCounterState(int value) { 
        counterState+= value;
    }


    void updateCounterValueText() { 
        CounterValue.Text = counterState.ToString();
    }

    void saveStateToFile()
    {
        File.WriteAllText(fileName, counterID + ":" + counterState.ToString());
    }

    void readStateFromFile() { 
        if(File.Exists(fileName))
        {
            string fileContent = File.ReadAllText(fileName);
            string[] lines = fileContent.Split("\n");
            foreach (string line in lines)
            {
                string[] splittedLine = line.Split(":");
                if (splittedLine[0] == counterID) { 
                    counterState= int.Parse(splittedLine[1]);
                } 
            }
;
        } else
        {
            counterState = -1;
        }
    }
}