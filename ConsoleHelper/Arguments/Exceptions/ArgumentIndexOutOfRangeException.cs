using System;

namespace Fanaticae.Console.Arguments.Exceptions
{
	public class ArgumentIndexOutOfRangeException:Exception
	{
		public ArgumentIndexOutOfRangeException () : base ()
		{
		}
		public ArgumentIndexOutOfRangeException (string message) : base (message){

		}
		public ArgumentIndexOutOfRangeException(string message, Exception inner) : base(message,inner){
		}
	}
}

