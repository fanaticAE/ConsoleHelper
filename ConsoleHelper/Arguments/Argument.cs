using System;

namespace Fanaticae.Console.Arguments
{
	public delegate void ExecuteArgument(ref Argument argument); 

	public class Argument
	{

		public string ArgumentName{get; private set;}
		private ExecuteArgument execute;


		public Argument (string ArgumentName, ExecuteArgument Execute)
		{
			this.ArgumentName = ArgumentName; 
			this.execute = Execute; 
		}

		public int run(ref ActiveArguments arguments){
			this.execute (ref arguments); 
		}

	}
}

