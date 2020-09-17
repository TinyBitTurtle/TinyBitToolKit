﻿using UnityEngine;

namespace TinyBitTurtle.Toolkit
{
    public class JsonHelper
    {
        public static T[] getJsonArray<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.array;
        }

        [System.Serializable]
        private class Wrapper<T>
        {
            public T[] array;
        }
    }
}