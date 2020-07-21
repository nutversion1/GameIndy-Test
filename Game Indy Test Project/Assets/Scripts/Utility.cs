using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public static class Utility
{
    public static void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public static int GetRandomNum(int min, int max)
    {
        int randomNum = Random.Range(min, max+1);

        return randomNum;
    }

    public static float GetRandomNum(float min, float max)
    {
        float randomNum = Random.Range(min, max);

        return randomNum;
    }

    public static void ShuffleList<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            var temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    
    public static void ShuffleArray<T>(T[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            var temp = array[i];
            int randomIndex = Random.Range(i, array.Length);
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }

    public static T GetRandomFromList<T>(List<T> list)
    {
        List<T> newList = new List<T>(list);
        ShuffleList(newList);

        return newList[0];
    }

    public static T GetRandomFromArray<T>(T[] array)
    {
        T[] newArray = (T[]) array.Clone();
        ShuffleArray(newArray);

        return newArray[0];
    }

}
