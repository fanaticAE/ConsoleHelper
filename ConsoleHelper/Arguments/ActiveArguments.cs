using System;
using Fanaticae.Console.Arguments.Exceptions;

namespace Fanaticae.Console.Arguments
{
	public class ActiveArguments
	{
		string[] args; 

		public int CurrentPosition{ get; private set; } 
		public string CurrentArg{ get {return args [CurrentPosition];} }
		public bool CanMoveNext{ get { return (args.Length > (CurrentPosition +1)); }}
		public bool IsInRange{ get { return args.Length > CurrentPosition; } }

		public ActiveArguments (string[] args, int currentPosition)
		{
			this.args = args; 
			this.CurrentPosition = currentPosition; 
		}

		public int moveToNextArg(){
			if (CanMoveNext) {
				CurrentPosition++;
				return CurrentPosition;
			} throw new ArgumentIndexOutOfRangeException ((CurrentPosition +1).ToString()); 

		}
		public int moveToPreviousArg(){
				CurrentPosition--;
				return CurrentPosition; 
		}



	}
}

