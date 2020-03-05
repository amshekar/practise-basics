using System;

public class Program
{
	public static void Main()
	{
		// Given an array of integers, write a function that finds all the duplicates in the array. 

		var A = new[] { 1, 2, 1, 2 };
		FindDuplicates(A); // expected: [1,2]

		//var B = new []{3,3,3}; 
		//FindDuplicates(A); // expected: [3]
	}


	internal static int[] FindDuplicates(int[] arr)
	{//[1,2,1,2]
		int[] a = new int[arr.Length];
		for (int i = 0; i < arr.Length; i++)
		{
			if (arr[Math.Abs(arr[i])] >= 0)
				arr[Math.Abs(arr[i])] = -arr[Math.Abs(arr[i])];
			else
				a[i] = arr[i];
			// Console.Write(Math.Abs(arr[i]) + " ");	
		}
		Console.Write(Math.Abs(5) + " ");
		return a;
	}
}