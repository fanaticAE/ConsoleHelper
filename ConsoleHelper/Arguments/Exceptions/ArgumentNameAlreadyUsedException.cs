﻿using System;

namespace Fanaticae.ConsoleHelper.Arguments.Exceptions
{
	public class ArgumentNameAlreadyUsedException:Exception
	{
		public ArgumentNameAlreadyUsedException () : base ()
		{
		}

		public ArgumentNameAlreadyUsedException(string message) :base(message){
		}
		public ArgumentNameAlreadyUsedException (string message, Exception inner) : base (message, inner){
		}
	}
}

