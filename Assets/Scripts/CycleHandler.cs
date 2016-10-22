using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum Seasons {
	SPRING = 0,
	SUMMER,
	AUTUMN,
	WINTER
};

public class CycleHandler : MonoBehaviour {
	// Day duration with night + daytime
	[SerializeField]
	float cDayDuration;

	// Number of day per year
	[SerializeField]
	int cNumberDayPerYear;

	// Current season
	int cCurrentSeason;

	// Current day of the current year
	int cCurrentDay;

	// Current year
	int cCurrentYear;

	// Time of the current day
	float cCurrentTime;

	// Half of the day time
	float cHalfDay;

	string[] seasonsName;

	// Use this for initialization
	void Start () {
		cCurrentSeason = 0;
		cCurrentTime = 0;
		cCurrentDay = 0;
		cCurrentYear = 1;
		cHalfDay = cDayDuration / 2.0f;

		seasonsName = new string[4];
		seasonsName [0] = "Sp";
		seasonsName [1] = "Su";
		seasonsName [2] = "Au";
		seasonsName [3] = "Wi";
	}

	void Update() {
		float prev = cCurrentTime;
		cCurrentTime = Time.time % cDayDuration;
		GameObject.FindGameObjectWithTag ("Light").GetComponent<Light> ().intensity = 1.0f - Mathf.Abs(cHalfDay - cCurrentTime) / cHalfDay;
		if (prev > cCurrentTime) {
			changeDay ();
		}
		ChangeUI ();
	}

	void ChangeUI() {
		float hour = ((cCurrentTime * 24) / cDayDuration);
		float minute = (hour - (int)hour);
		int iMinute = (int)(minute * 60);
		int iHour = (int)hour;

		GameObject.FindGameObjectWithTag ("HourText").GetComponent<Text> ().text = iHour.ToString("00") + ":" + (iMinute).ToString("00");
		GameObject.Find ("YearText").GetComponent<Text> ().text = cCurrentYear.ToString ("0000");
		GameObject.Find ("DayText").GetComponent<Text> ().text = (cCurrentDay + 1).ToString ("000");
		GameObject.Find ("SeasonText").GetComponent<Text> ().text = seasonsName [cCurrentSeason];
	}

	void changeDay() {
		++cCurrentDay;
		if (cCurrentDay > cNumberDayPerYear) {
			++cCurrentYear;
			cCurrentDay = 1;
		}
		if (cCurrentDay % (cNumberDayPerYear / 4) == 0) {
			cCurrentSeason = (cCurrentSeason + 1) % 4;
		}
		cCurrentTime = 0;
	}

	// hour is a number from 0 to 24;
	public void JumpTo(int hour) {
	}

	public Seasons GetCurrentSeason() {
		return (Seasons)cCurrentSeason;
	}
}
