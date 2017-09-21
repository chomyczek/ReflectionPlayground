// Copyright 2017
// Author Adam Kaszubowski
// All Rights Reserved 

#region Usings

using System;

#endregion

namespace MethodsGetByReflection.Core
{
	public class ClassWithMethods
	{
		#region Public Methods and Operators

		public string MethodA()
		{
			var str = "MethodA()";
			Console.WriteLine(str);
			return str;
		}

		public string MethodA(int i)
		{
			var str = $"MethodA(int i):{i}";
			Console.WriteLine(str);
			return str;
		}

		public string MethodA(bool b, int i)
		{
			var str = $"MethodA(bool b, int i):{b},{i}";
			Console.WriteLine(str);
			return str;
		}

		public string MethodA(bool b, string s = "string s")
		{
			var str = $"MethodA(bool b, string s= \"string s\"):{b},{s}";
			Console.WriteLine(str);
			return str;
		}

		public string MethodB(int i)
		{
			var str = $"MethodB(int i): {i}";
			Console.WriteLine(str);
			return str;
		}

		#endregion
	}
}