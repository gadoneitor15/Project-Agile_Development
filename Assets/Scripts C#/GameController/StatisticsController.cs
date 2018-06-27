/*
 * StatisticsController.cs
 * Handles the statistics of the progress
 * the user has made by not smoking.
 */

using System;
using Assets;
using UnityEngine;
using UnityEngine.UI;

public class StatisticsController : MonoBehaviour {

	public Text time;
    public Text saved;
    private TimeSpan span;

    // Timer for saving
	static double moneySaved;

    // Use this for initialization
    void Start () {
        time.text = "Je hebt al <i>Loading...</i> niet meer gerookt!";
        saved.text = "Hierdoor heb je <i>Loading...</i> euro bespaard! Ga zo door!";
    }

	void Update () {
		time.text = "Je hebt al " + StatisticsController.TimeNotSmoked() + " niet meer gerookt!";
		saved.text = "Hierdoor heb je " + Saved() + " euro bespaard! Ga zo door!"; //Doesn't work?
    }

    // When the "I smoked" button is pressed, the timer will reset to the current system time.
    public void Smoked() {
		GameController.control.PlayerData.Time = DateTime.Now;
        GameController.control.PlayerData.Balance = 0;
		if (GameController.control.PlayerData.saveData ())
			Debug.Log ("Saved Successful.");
		Debug.Log ("Smoked button pressed at: " + GameController.control.PlayerData.Time.ToString ());
    }

    // Calculates how long the user have not smoked during a period of time
	// and returns the time in string.
	public static string TimeNotSmoked() {

        string format;

        DateTime currentDate = DateTime.Now;
        TimeSpan span = currentDate.Subtract(GameController.control.PlayerData.Time);

		//Orders the TimeSpan in a more viewable ints.
        int days        = (int) span.Days;
        int hours       = (int) span.Hours;
        int minutes     = (int) span.Minutes;
		int secondes 	= (int)	span.Seconds;
		moneySaved 		= (double) span.TotalHours;

        if (days > 1) format = days + " dagen, ";
        else format = days + " dag, ";

        if (hours > 1) format += hours + " uren, ";
        else format += hours + " uur, ";

        if (minutes > 1) format += minutes + " minuten en ";
        else format += minutes + " minuut en ";

        if (secondes > 1) format += secondes + " seconden";
        else format += secondes + " seconde";

        return format;
    }

	//Calculates how much the user has saved in euro and returns it in euro
    private string Saved() {
		int cigaretten = GameController.control.PlayerData.Cigarettes;
		double prijs = GameController.control.PlayerData.Price;

        return (1 * 1 * moneySaved).ToString("#.##");
    }

}
