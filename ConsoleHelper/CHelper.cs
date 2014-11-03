using System;
using System.IO; 
using System.Diagnostics; 
using System.Text.RegularExpressions; 
using Fanaticae.ConsoleHelper.Exceptions; 

namespace Fanaticae.ConsoleHelper
{
	public static class DefaultRegexPatterns{
		public const string TrueYes = @"(^[t](rue)?$)|(^[y](es)?$)";
		public const string FalseNo = @"(^[f](alse)?$)|(^[n](o)?$)"; 
		public const string Integ = @"^\-?[0-9]{1,}$";
		public const string Doub= @"^\-?[0-9]{1,}([.][0-9]{1,})?$";
		public const string Strin = "^.{1,}$"; 

	}



	public class CHelper
	{
		#region read
		public static string ExternalReadString(string currentValue, bool guessEditor = true){
			string file = Path.GetTempFileName (); 
			string editor = Environment.GetEnvironmentVariable ("EDITOR"); 
			string result; 

			if (!String.IsNullOrEmpty (currentValue)) 
				File.WriteAllText (file, currentValue); 

			if (string.IsNullOrEmpty (editor)) {
				if ((Environment.OSVersion.Platform == PlatformID.Unix) && guessEditor) {
					editor = "vi"; 
				} else if ((Environment.OSVersion.Platform == PlatformID.Win32Windows)&&guessEditor) {
					editor = "notepad"; 
				}
				else throw new EditorNotSetException (); 
			}

			Process.Start (new ProcessStartInfo (editor, file)).WaitForExit (); 

			result = File.ReadAllText (file); 
			File.Delete (file); 
			return result; 
		}

		public static bool PromptReadBool(string prompt, bool useDefault = true, bool defaultValue = false, string trueRegexPattern = DefaultRegexPatterns.TrueYes, string falseRegexPattern = DefaultRegexPatterns.FalseNo){
			bool isRead = false; 
			bool result = false; 
			Regex trueRegex = new Regex (trueRegexPattern,RegexOptions.IgnoreCase); 
			Regex falseRegex = new Regex (falseRegexPattern,RegexOptions.IgnoreCase); 

			do {
				Console.Write (prompt); 
				string res = Console.ReadLine ().Trim (); 
				if (useDefault && String.IsNullOrEmpty (res)) {
					result = defaultValue;
					isRead = true; 
				} else if (trueRegex.IsMatch (res)) {
					result = true;
					isRead = true; 
				} else if (falseRegex.IsMatch (res)) {
					result = false; 
					isRead = true; 
				}
			} while (!isRead); 

			return result; 
		}
		public static int PromptReadInteger(string prompt, bool useDefault = true, int defaultValue = 0, string intRegexPattern = DefaultRegexPatterns.Integ){
			bool isRead = false; 
			int result = 0; 
			Regex intRegex = new Regex (intRegexPattern); 
			do {
				Console.Write(prompt); 
				string res = Console.ReadLine().Trim(); 
				if(useDefault&&String.IsNullOrEmpty(res)){
					isRead = true; 
					result = defaultValue; 

				}
				else if(intRegex.IsMatch(res)){
					isRead = true; 
					try{
						result = int.Parse(res); 
					}catch(Exception ex){
						isRead = false; 
					}
				}
			} while (!isRead);
			return result;
		}
		public static double PromptReadDouble(string prompt, bool useDefault = true, double defaultValue = 0, string doubleRegexPattern = DefaultRegexPatterns.Doub){
			bool isRead = false; 
			double result = 0; 
			Regex doubleRegex = new Regex (doubleRegexPattern); 
			do {
				Console.Write(prompt); 
				string res = Console.ReadLine().Trim(); 
				if(useDefault&&String.IsNullOrEmpty(res)){
					isRead = true; 
					result = defaultValue; 
				}
				else if(doubleRegex.IsMatch(res)){
					isRead = true; 
					try{
						result = double.Parse(res); 
					}catch(Exception ex){
						isRead = false; 
					}
				}
			} while (!isRead);
			return result;
		}
		public static string PromptReadString(string prompt, bool useDefault = true, string defaultValue = "", string stringRegexPattern = DefaultRegexPatterns.Strin){
			bool isRead = false; 
			string result = ""; 
			Regex stringRegex = new Regex (stringRegexPattern); 
			do {
				Console.Write(prompt); 
				string res = Console.ReadLine().Trim(); 
				if(useDefault&&String.IsNullOrEmpty(res)){
					isRead = true; 
					result = defaultValue; 
				}
				else if(stringRegex.IsMatch(res)){
					isRead = true; 
					result = res; 
				}
			} while (!isRead);
			return result;
		}




		#endregion

		#region write

		public static void WriteTitledParagraph(string title, string content, char seperator = '='){
			Console.Clear (); 
			Console.WriteLine (title);
			for(int i = 0; i<Console.BufferWidth; i++)Console.Write (seperator);
			Console.Write (Environment.NewLine); 
			Console.WriteLine (content); 
		}



		#endregion
	
	}
}

