using System;
using System.Collections.Generic;

namespace MOK.Library.Domain
{
	public class ValidationException : Exception
	{
		private string _message;

		public IEnumerable<string> ValidationErrors { get; set; }
		public override string Message => _message;

		public ValidationException(IEnumerable<string> validationErros) : base()
		{
			ValidationErrors = validationErros;
		}

		public ValidationException(IEnumerable<string> validationErros, string message) : this(validationErros)
		{
			_message = message;
		}

	}
}
