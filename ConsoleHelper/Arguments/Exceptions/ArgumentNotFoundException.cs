using System;

namespace Fanaticae.ConsoleHelper.Arguments.Exceptions
{
	public class ArgumentNotFoundException:Exception
	{
		public ArgumentNotFoundException ():base()
		{
		}
		public ArgumentNotFoundException(string message) : base(message){
		}
		public ArgumentNotFoundException(string message, Exception inner):base(message,inner){
		}

	}
}

