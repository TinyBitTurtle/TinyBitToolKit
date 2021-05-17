using System.Collections.Generic;
using UnityEngine;
using System;

namespace TinyBitTurtle.Toolkit
{
    public class QueuedData<C/*class*/,P/*template*/> : SingletonMonoBehaviour<C> where C : MonoBehaviour where P : Core_Template
    {
        // queue with a capacity of 64 (avoid re-allocations of internal array)
        public QueuedDataSettings<P> settings;
        private Queue<P> queue = new Queue<P>(64);
        protected Action<P> actionPopData = null;
    
        // produce entry
        protected void Add(string templateID)
        {
            P template = default(P);
            template = settings.templateList.Find(e => e.ID == templateID);
            if(template != null)
            {
                // Queue up the template
                queue.Enqueue(template);
            }
        }

        // consume all the entries at a constant rate
        private void FixedUpdate() 
        {
            // if the queue has something
            while(queue.Count > 0)
            {
                // pop the front object
                P frontTemplate = queue.Dequeue();
                // fire a message
                actionPopData?.Invoke(frontTemplate);
            }   
        }
    }

    public class QueuedDataSettings<P> : ScriptableObject
    {
        public int size;
        [Header("TEMPLATES")]
        [Space(10)]
       public List<P> templateList = new List<P>();
    }
}