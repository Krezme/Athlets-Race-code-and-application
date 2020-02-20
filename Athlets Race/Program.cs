using System;

namespace Athlets_Race
{
	class Program
	{
		//Variable for the user to choose between male or female that are included in the race
		string maleOrFemale;
		
		//How many athlets are in the race and how many lines are they using
		int runningLines;
		
		//The minimum and maximum atletes allowed per race
		int minimumAthletes = 4;
		int maximumAthletes = 8;
		
		//Temp variables used in the Bubble sort
		double tempTime;
		string tempName;
		
		//Array to store the athletes names
		string[] athletesNames;
		//Array to store the athletes Times
		double[] athletesTimes;
		//Array to store the World Record (index: 0 = World Record, 1 = European Record, 2 = British Record for men)
		double[] manRecordTimes = new double[3] {9.58, 9.86, 9.87};
		//Array to store the World Record (index: 0 = World Record, 1 = European Record, 2 = British Record for women)
		double[] womenRecordTimes = new double[3] {10.49, 10.73, 10.99};
		
		public static void Main(string[] args)
		{
			//Variable to allow me to run methods in the Static Main method
			Program program = new Program();
			//Refering to ApplicationAssembly method
			program.ApplicationAssembly();
			
		}
		
		//Method to assemle the application
		void ApplicationAssembly() {
			//Refering to MaleOrFemale method
			MaleOrFemale();
		}
		
		//Method to enter and choose male or female
		void MaleOrFemale() {
			//Outputting a message
			Console.WriteLine("Does the race invole Male or Female athletes? (Male/Female): ");
			maleOrFemale = Console.ReadLine();
			
			if (maleOrFemale == "Male" || maleOrFemale == "male"){
				//Refering to  method
				MaleAthlets();
			}
			else if (maleOrFemale == "Female" || maleOrFemale == "female") {
				//Refering to  method
				FemaleAthlets();
			}
			else {
				//Outputting a message
				Console.WriteLine("Please enter a valid input. Press any key to try again.");
				//Waithing for a key press
				Console.ReadKey();
				//Refering to MaleOrFemale method
				MaleOrFemale();
			}
		}
		
		//Method to run all functions for men
		void MaleAthlets() {
			//Refering to RaceLines method
			RaceLines();
			//Refering to EnterAthletesNamesAndTimes method
			EnterAthletesNamesAndTimes();
			//Refering to BubbleSort method
			BubbleSort();
			//Refering to OutputtingTimes method
			OutputtingTimes();
			//Refering to IsRecordAchievedMale method
			IsRecordAchievedMale();
			//Refering to Quit method
			Quit();
		}
		
		//Method to run all functions for woman
		void FemaleAthlets() {
			//Refering to RaceLines method
			RaceLines();
			//Refering to EnterAthletesNamesAndTimes method
			EnterAthletesNamesAndTimes();
			//Refering to BubbleSort method
			BubbleSort();
			//Refering to OutputtingTimes method
			OutputtingTimes();
			//Refering to IsRecordAchievedFemale method
			IsRecordAchievedFemale();
			//Refering to Quit method
			Quit();
		}
		
		//Method to choose how many athletes are in the race
		void RaceLines() {
			try {
				//Outputting a message
				Console.WriteLine("How many athletes are in the race or running lanes used: (Please enter a number between minimum 4 and maximum 8)");
				runningLines = int.Parse(Console.ReadLine());
				if (runningLines < minimumAthletes || runningLines > maximumAthletes) {
					//Outputting a message
					Console.WriteLine("Please enter a valid input. Press any key to try again.");
					//Waithing for a key press
					Console.ReadKey();
					//Refering to RaceLines method
					RaceLines();
				}
					athletesTimes = new double[runningLines];
					athletesNames = new string[runningLines];
			} catch (Exception) {
				//Outputting a message
				Console.WriteLine("Please enter valid input. Press any key to try again.");
				//Waithing for a key press
				Console.ReadKey();
				//Refering to RaceLines method
				RaceLines();
			}
		}
		
		//Method to input athletes names and times
		void EnterAthletesNamesAndTimes() {
			try {
				for (int i = 0; i < runningLines; i++) {
					//Outputting a message
					Console.WriteLine("Please enter the athlete's name in line " + (i + 1) + ": ");
					athletesNames[i] = Console.ReadLine();
					//Outputting a message
					Console.WriteLine("Please enter the athlete's time in line " + (i + 1) + ": ");
					//Waithing for a key press and recording in a variable
					athletesTimes[i] = double.Parse(Console.ReadLine());
				}
			} catch (Exception){
				//Outputting a message
				Console.WriteLine("Please enter valid input. Press any key to try again.");
				//Waithing for a key press
				Console.ReadKey();
				//Refering to EnterAthletesNamesAndTimes method
				EnterAthletesNamesAndTimes();
			}
		}
		
		//Method to sort the arrays
		void BubbleSort() {
			//Loop to check the right amout of times if a number is out of place
			for (int j = 0; j < athletesTimes.Length -1; j++){
				//Loop to check each index with next index
				for (int i = 0; i < athletesTimes.Length -1; i++){
					//Statement to check if the first is smaller that the second index
					if (athletesTimes[i] > athletesTimes[i + 1]) {
						//Swapping array indexes
						tempTime = athletesTimes[i];
						athletesTimes[i] = athletesTimes[i + 1];
						athletesTimes[i + 1] = tempTime;
						//Swapping array indexes
						tempName = athletesNames[i];
						athletesNames[i] = athletesNames[i + 1];
						athletesNames[i + 1] = tempName;
					}
				}
			}
		}
		
		//Method to output the times and names from first to last
		void OutputtingTimes() {
			for (int i = 0; i < athletesTimes.Length; i++) {
				//Outputting a message
				Console.WriteLine((i + 1) + " place is " + athletesNames[i] + " with " + Math.Round(athletesTimes[i], 2) + " time.");
				//Outputting a message
				Console.WriteLine("---------------------------------");
			}
		}
		
		//Method to decide if a record is acheaved for men
		void IsRecordAchievedMale(){
			for (int i = 0; i < athletesTimes.Length; i++) {
				if (athletesTimes[i] < manRecordTimes[0]) {
					//Outputting a message
					Console.WriteLine(athletesNames[i] + " has acheaved a new World Record with " + athletesTimes[i]);
					//Outputting a message
					Console.WriteLine("Press any key to continue.");
					//Waithing for a key press
					Console.ReadKey();
				}
				if (athletesTimes[i] < manRecordTimes[1]) {
					//Outputting a message
					Console.WriteLine(athletesNames[i] + " has acheaved a new European Record with " + athletesTimes[i]);
					//Outputting a message
					Console.WriteLine("Press any key to continue.");
					//Waithing for a key press
					Console.ReadKey();
				}
				if (athletesTimes[i] < manRecordTimes[2]) {
					//Outputting a message
					Console.WriteLine(athletesNames[i] + " has acheaved a new British Record with " + athletesTimes[i]);
					//Outputting a message
					Console.WriteLine("Press any key to continue.");
					//Waithing for a key press
					Console.ReadKey();
				}
			}
		}
		
		//Method to decide if a record is acheaved for women
		void IsRecordAchievedFemale(){
			for (int i = 0; i < athletesTimes.Length; i++) {
				if (athletesTimes[i] < womenRecordTimes[0]) {
					//Outputting a message
					Console.WriteLine(athletesNames[i] + " has acheaved a new World Record with " + athletesTimes[i]);
					//Outputting a message
					Console.WriteLine("Press any key to continue.");
					//Waithing for a key press
					Console.ReadKey();
				}
				if (athletesTimes[i] < womenRecordTimes[1]) {
					//Outputting a message
					Console.WriteLine(athletesNames[i] + " has acheaved a new European Record with " + athletesTimes[i]);
					//Outputting a message
					Console.WriteLine("Press any key to continue.");
					//Waithing for a key press
					Console.ReadKey();
				}
				if (athletesTimes[i] < womenRecordTimes[2]) {
					//Outputting a message
					Console.WriteLine(athletesNames[i] + " has acheaved a new British Record with " + athletesTimes[i]);
					//Outputting a message
					Console.WriteLine("Press any key to continue.");
					//Waithing for a key press
					Console.ReadKey();
				}
			}
		}
		
		//Method to anounce that the application is closing
		void Quit () {
			//Outputting a message
			Console.WriteLine("*********************************");
			//Outputting a message
			Console.WriteLine("---------------------------------");
			//Outputting a message
			Console.WriteLine("Application closing.");
			//Waithing for a key press
			Console.ReadKey();
		}
	}
}