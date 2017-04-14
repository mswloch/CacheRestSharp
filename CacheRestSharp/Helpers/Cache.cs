using CacheRestSharp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheRestSharp
{
    public sealed class Cache
    {
        #region singleton
        private static readonly Cache instance = new Cache();

        private Cache() { }

        public static Cache Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        private List<Triple<string, string, DateTime>> cache = new List<Triple<string, string, DateTime>>();
        /// <summary>
        /// Default 500 seconds
        /// </summary>
        private int Retention = 500; 

        /// <summary>
        /// Getting value by key from cache list
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool GetValue(string key, out String value)
        {
            value = string.Empty;
            var obj = cache.Find((x) => x.A.Equals(key));

            if (obj == null)
                return false;


            if((DateTime.Now - obj.C).TotalSeconds > Retention)
            {
                cache.Remove(obj);
                return false;
            }

            value = obj.B;
            return true;
        }

        /// <summary>
        /// Getting value by key from cache list, return true if item exist
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool Get(string key, out String value)
        {
           return Instance.GetValue(key, out value);
        }

        /// <summary>
        /// Add to cache list
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private void AddValue(string key, string value)
        {
            cache.Add(new Triple<string, string, DateTime>(key, value, DateTime.Now));
        }

        public static void Add(string key, string value)
        {
            Instance.AddValue(key, value);
        }

        /// <summary>
        /// Set duration of item existing 
        /// </summary>
        /// <param name="Retention">Duration in second</param>
        private void SetDelay(int Retention)
        {
            this.Retention = Retention;
        }

        public static void SetRetention(int Retention)
        {
            Instance.SetDelay(Retention);
        }
    }
}
