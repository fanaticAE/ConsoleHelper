using System;
using System.Collections; 
using System.Collections.Generic; 
using Fanaticae.Console.Arguments.Exceptions; 


namespace Fanaticae.Console.Arguments
{
	public class ArgumentParser
	{
	
		Dictionary<string,Argument> arguments = new Dictionary<string, Argument> (); 

		public ArgumentParser ()
		{
		}

		public ArgumentParser(IEnumerable<Argument> arguments){
			foreach (Argument a in arguments)
				addArgument (a); 
		}

		public void addArgument(Argument argument){
			if (!this.arguments.ContainsKey (argument.ArgumentName))
				this.arguments.Add (argument.ArgumentName, argument);
			else
				throw new ArgumentNameAlreadyUsedException ("The Argument " + argument.ArgumentName + " has already been used"); 
		}






	}
}

