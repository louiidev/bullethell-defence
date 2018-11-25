using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UtilMethods {
  public static class MyUtils {

    public static T GetRandomValue<T>(this T[] array) {
      return array[Random.Range(0, array.Length)];
    }

    public static T GetRandomValue<T>(this List<T> list) {
      return list[Random.Range(0, list.Count)];
    }

  }
}


