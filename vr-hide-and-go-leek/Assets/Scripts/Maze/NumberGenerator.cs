using UnityEngine;
using System.Collections;

public class NumberGenerator {
	public static int currentPosition = 0;
	public const string key = "123424123342421432233144441212334432121223344";

	public static int GetNumber() {
		string currentNum = key.Substring(currentPosition++ % key.Length, 1);
		return int.Parse (currentNum);
    // return Random.Range(1,5);
	}
}
