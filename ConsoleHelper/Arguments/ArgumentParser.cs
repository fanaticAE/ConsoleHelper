using System;
using System.Collections; 
using System.Collections.Generic; 
using Fanaticae.Console.Arguments.Exceptions; 


namespace Fanaticae.Console.Arguments
{
	public class ArgumentParser
	{
	
		Dictionary<string,Argument> arguments = new Dictionary<string, Argument> (); 

		string[] args; 

		public ArgumentParser (string[] args)
		{
			this.args = args; 
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

		public void parseArguments(int startArgument = 0){

			for (int x = startArgument; x < this.args.Length; x++) {
				ActiveArguments activeArgs = new ActiveArguments (this.args, x); 
				if (this.arguments.ContainsKey (this.args [x])) {
					this.arguments [this.args [x]].run (ref activeArgs); 
					x = activeArgs.CurrentPosition; 
				}else 
					throw new ArgumentNotFoundException(args[x]); 
			}

		}
	}
}

