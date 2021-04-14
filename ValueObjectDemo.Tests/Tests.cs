using System;
using NUnit.Framework;

namespace ValueObjectDemo.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void AssignStringAndGetNumber()
        {
            var model = new Member();
            model.Height = "100.8";
            
            decimal? actual = model.HeightNumer;
            
            Assert.IsTrue(actual.HasValue);
            Assert.AreEqual(100.8M, actual.Value);
        }
    }

    public class Member
    {
        public string Height { get; set; }
        public decimal? HeightNumer { get; set; }
    }
}