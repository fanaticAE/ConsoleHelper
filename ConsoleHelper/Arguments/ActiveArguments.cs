using System;
using Fanaticae.Console.Arguments.Exceptions;

namespace Fanaticae.Console.Arguments
{
	public class ActiveArguments
	{
		string[] args; 

		public int CurrentPosition{ get; private set; } 
		public string CurrentArg{ get {return args [CurrentPosition];} }

		public ActiveArguments (string[] args, int currentPosition)
		{
			this.args = args; 
			this.CurrentPosition = currentPosition; 
		}

		public void moveToNextArg(){
			if (args.Length > (CurrentPosition + 1))
				CurrentPosition++;
			else
				throw new ArgumentIndexOutOfRangeException ();  
		}
		public void moveToPreviousArg(){
			if (CurrentPosition > 0)
				CurrentPosition--;
			else
				throw new ArgumentIndexOutOfRangeException (); 
		}

	}
}

