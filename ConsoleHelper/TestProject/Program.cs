using System;
using Fanaticae.Console.Arguments; 


namespace TestProject
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			string[] testArgs = new string[]{"HelloWorld","--readNext"}; 

			Console.WriteLine (testArgs.Length); 
			ArgumentParser parser = new ArgumentParser (testArgs); 
			parser.addArgument(new Argument("HelloWorld",delegate(ref ActiveArguments arguments) {
				Console.WriteLine("Hello World"); 
			})); 
			parser.addArgument (new Argument ("--readNext", delegate(ref ActiveArguments arguments) {
				arguments.moveToNextArg(); 
				Console.WriteLine(arguments.CurrentArg); 
			})); 

			parser.parseArguments (); 

		}
	}
}
