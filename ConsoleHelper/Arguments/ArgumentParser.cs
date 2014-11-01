using System;
using System.Collections; 
using System.Collections.Generic; 
using Fanaticae.ConsoleHelper.Arguments.Exceptions; 


namespace Fanaticae.ConsoleHelper.Arguments
{
	public class ArgumentParser
	{
	
		Dictionary<string,Argument> arguments = new Dictionary<string, Argument> (); 

		public ArgumentParser(){
		 
		}

		public ArgumentParser(IEnumerable<Argument> arguments){
			addArguments (arguments); 
		}

		public void addArguments(IEnumerable<Argument> arguments){
			foreach (Argument a in arguments)
				addArgument (a);

		}

		public void addArgument(Argument argument){
			if (!this.arguments.ContainsKey (argument.ArgumentName))
				this.arguments.Add (argument.ArgumentName, argument);
			else
				throw new ArgumentNameAlreadyUsedException ("The Argument " + argument.ArgumentName + " has already been used"); 
		}

		public void removeArgument(string key){
			if (this.arguments.ContainsKey (key))
				this.arguments.Remove (key); 

		}

		public void parseArguments(string[] args, int startArgument = 0){

			for (int x = startArgument; x < args.Length; x++) {
				ActiveArguments activeArgs = new ActiveArguments (args, x); 
				if (this.arguments.ContainsKey (args [x])) {
					this.arguments [args [x]].run (ref activeArgs); 
					x = activeArgs.CurrentPosition; 
				}else 
					throw new ArgumentNotFoundException(args[x]); 
			}

		}
	}
}

