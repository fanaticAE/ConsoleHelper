using System;

namespace Fanaticae.ConsoleHelper.Arguments
{
	public delegate void ExecuteArgument(ref ActiveArguments arguments); 

	public class Argument
	{

		public string ArgumentName{get; private set;}
		private ExecuteArgument execute;


		public Argument (string ArgumentName, ExecuteArgument Execute)
		{
			this.ArgumentName = ArgumentName; 
			this.execute = Execute; 
		}

		public void run(ref ActiveArguments arguments){
			this.execute (ref arguments); 
		}

	}
}

