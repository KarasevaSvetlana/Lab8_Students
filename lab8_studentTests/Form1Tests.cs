using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab8_student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8_student.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void LoadMyFileTest()
        {
            Assert.AreEqual(-1, Form1.LoadMyFile("viewtest.xml"));
        }
        [TestMethod()]
        public void LoadMyFileTest2()
        {
            Assert.AreEqual(0, Form1.LoadMyFile("viewtest23.xml"));
        }
        [TestMethod()]
        public void LoadMyFileTest3()
        {
            Assert.AreEqual(2, Form1.LoadMyFile("viewtest3.xml"));
        }
        [TestMethod()]
        public void LoadMyFileTest4()
        {
            Assert.AreEqual(3, Form1.LoadMyFile("viewtest4.xml"));
        }
        [TestMethod()]
        public void LoadMyFileTest5()
        {
            Assert.AreEqual(6, Form1.LoadMyFile("viewtest5.xml"));
        }
    }
}