using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    private int[] gunsID = { 10, 9 , 8 , 7 , 6 , 5};
    private int count = 200;
    SortedDictionary<int, int> gunsRepeat = new SortedDictionary<int, int>();


    void Start()
    {
        for (int i = 0; i < count; i++)
        {

            int gunIndex = Mathf.RoundToInt(GetQuadOut(Random.value) * (gunsID.Length - 1));
            int gunId = gunsID[gunIndex];
            gunsRepeat[gunId] = gunsRepeat.ContainsKey(gunId) ? gunsRepeat[gunId] + 1 : 1;
        }
        foreach (var pair in gunsRepeat)
        {
            Debug.Log($"{pair.Key} repeated {pair.Value} times");
        }

    }

    float GetQuadOut(float t)
    {
        return 1 - Mathf.Pow(t - 1 , 2);
        //Mathf.Sqrt(1 - (--t) * t)
    }
}
