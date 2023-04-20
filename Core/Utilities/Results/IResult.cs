using System;
namespace Core.Utilities.Results
{
	//Temel Voidler İçin Başlangıç

	public interface IResult
	{
		bool Succes { get; }

		string Message { get; }
	}
}

