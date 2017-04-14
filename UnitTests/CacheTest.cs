using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CacheRestSharp;

namespace UnitTests
{
    [TestClass]
    public class CacheTest
    {
        [TestMethod]
        public void TestAdd()
        {
            string keyAdd = "KeyAdd";
            string valueAdd = "ValueAdd";

            Cache.Add(keyAdd, valueAdd);

            string value = string.Empty;
            Cache.Get(keyAdd, out value);
                

            Assert.AreEqual(valueAdd, value, "Adding to cache dont work properly");
        }

        [TestMethod]
        public void TestDelay()
        {
            string keyAdd = "KeyAdd";
            string valueAdd = "ValueAdd";

            Cache.SetRetention(10);
            Cache.Add(keyAdd, valueAdd);


            string value = string.Empty;
            if (Cache.Get(keyAdd, out value))
                Assert.AreEqual(valueAdd, value, "Getting from cache dont work properly");

            System.Threading.Thread.Sleep(5000);
            value = string.Empty;
            if (Cache.Get(keyAdd, out value))
                Assert.AreEqual(valueAdd, value, "Getting from cache dont work properly after 5s when setting duration - 11s");

            System.Threading.Thread.Sleep(11000);
            value = string.Empty;
            if (Cache.Get(keyAdd, out value))
                Assert.AreEqual(valueAdd, value, "Getting from cache dont work properly after 11s  when setting duration - 11s");



        }

    }
}
