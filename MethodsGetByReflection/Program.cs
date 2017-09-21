// Copyright 2017
// Author Adam Kaszubowski
// All Rights Reserved 

#region Usings

using System;

using MethodsGetByReflection.Core;

#endregion

namespace MethodsGetByReflection
{
	public class Program
	{
		#region Methods

		static void Main(string[] args)
		{
			var reflection = new ReflectionClass();
			reflection.RunDistincted();
			Console.WriteLine("Press any key to continue..");
			Console.ReadKey(true);
			reflection.RunnAll();
			Console.WriteLine("Press any key to quit..");
			Console.ReadKey(true);
		}

		#endregion
	}
}