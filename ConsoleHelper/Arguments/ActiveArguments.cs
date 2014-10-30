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

		public int moveToNextArg(){
			if (args.Length > (CurrentPosition + 1)){
				CurrentPosition++;
				return CurrentPosition;
			}else
				throw new ArgumentIndexOutOfRangeException ((CurrentPosition +1).ToString());  
		}
		public int moveToPreviousArg(){
			if (CurrentPosition > 0) {
				CurrentPosition--;
				return CurrentPosition; 
			}else
				throw new ArgumentIndexOutOfRangeException ((CurrentPosition -1).ToString()); 
		}

	}
}

