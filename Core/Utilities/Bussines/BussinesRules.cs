using System;
using Core.Utilities.Results;

namespace Core.Utilities.Bussines
{
	public class BussinesRules
	{
		public static IResult Run(params IResult[] logics)
		{
			foreach (var logic in logics)
			{
				if (!logic.Succes)
				{
					return logic;
				}
			}

			return null;
        }
	}
}

