using System;
using Fanaticae.ConsoleHelper; 
using Fanaticae.ConsoleHelper.Arguments; 


namespace TestProject
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine (CHelper.PromptReadBool ("Enter a bool(F(alse),t(rue),y(es),n(o))")); 
			Console.WriteLine (CHelper.PromptReadInteger ("Enter an int[0]:")); 
			Console.WriteLine (CHelper.PromptReadDouble ("Enter an double[0]:")); 



//
//			string[] testArgs = new string[]{"HelloWorld","--readNext","Echo"}; 
//
//			Console.WriteLine (testArgs.Length); 
//			ArgumentParser parser = new ArgumentParser (testArgs); 
//			parser.addArgument(new Argument("HelloWorld",delegate(ref ActiveArguments arguments) {
//				Console.WriteLine("Hello World"); 
//			})); 
//			parser.addArgument (new Argument ("--readNext", delegate(ref ActiveArguments arguments) {
//				arguments.moveToNextArg(); 
//				Console.WriteLine(arguments.CurrentArg); 
//			})); 
//
//			parser.parseArguments (); 
//
		}
	}
}
