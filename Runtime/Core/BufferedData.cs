using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TinyBitTurtle.Toolkit
{
    public class BufferedData<C/*class*/, P/*payload*/> : SingletonMonoBehaviour<C> where C : MonoBehaviour
    {
        private Queue<P> queue = new Queue<P>();
        [HideInInspector]
        public Action<P> actionPopData = null;

        // produce entry
        public void Add(P payload)
        {
            queue.Enqueue(payload);
        }

        // consume entry at a constant rate
        private void FixedUpdate() 
        {
            // if the queue has something
            if(queue.Count)
            {
                P first = queue.dequeue();
                // fire a message
                ActionCtrl.Instance.actionPopData?.Invoke(first);
            }   
        }
    }
}