// Copyright 2017
// Author Adam Kaszubowski
// All Rights Reserved 

#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

#endregion

namespace MethodsGetByReflection.Core
{
	public class ReflectionClass
	{
		#region Public Methods and Operators

		/// <summary>
		/// Run methods form class <see cref="ClassWithMethods" /> but pick only first from overloaded methods.
		/// </summary>
		public void RunDistincted()
		{
			var methodClassType = typeof(ClassWithMethods);

			var methodsInfo = methodClassType.GetMethods(
				BindingFlags.Public | BindingFlags.Instance |
				//This one remove inherited methods.(eg. ToString())
				BindingFlags.DeclaredOnly);

			//Group by method name, then pick first for each method name.
			var distinctedMethods = methodsInfo.GroupBy(mthd => mthd.Name).Select(group => group.First());

			foreach (var distinctedMethod in distinctedMethods)
			{
				this.RunMethod(distinctedMethod);
			}
		}

		/// <summary>
		/// Run all methods from class <see cref="ClassWithMethods" />.
		/// </summary>
		public void RunnAll()
		{
			var methodClassType = typeof(ClassWithMethods);

			var methodsInfo = methodClassType.GetMethods(
				BindingFlags.Public | BindingFlags.Instance |
				//This one remove inherited methods.(eg. ToString())
				BindingFlags.DeclaredOnly);

			foreach (var method in methodsInfo)
			{
				this.RunMethod(method);
			}
		}

		#endregion

		#region Methods

		/// <summary>
		/// Help method to get default value of object.
		/// </summary>
		/// <param name="type">
		/// The type required to determinate default value.
		/// </param>
		/// <returns>
		/// Value of passed type or null.
		/// </returns>
		private object GetDefault(Type type)
		{
			if (type.IsValueType)
			{
				return Activator.CreateInstance(type);
			}
			return null;
		}

		/// <summary>
		/// Run method based on <see cref="MethodInfo" /> with dummy attributes.
		/// </summary>
		/// <param name="methodInfo">
		/// The method info to run.
		/// </param>
		private void RunMethod(MethodInfo methodInfo)
		{
			var paramList = new List<object>();

			//prepare params
			foreach (var parameterInfo in methodInfo.GetParameters())
			{
				var dummyObject = this.GetDefault(parameterInfo.ParameterType);
				paramList.Add(dummyObject);
			}

			//run the method
			var constructor = methodInfo.ReflectedType.GetConstructor(Type.EmptyTypes);
			var classInstance = constructor.Invoke(new object[] { });
			methodInfo.Invoke(classInstance, paramList.ToArray());
		}

		#endregion
	}
}