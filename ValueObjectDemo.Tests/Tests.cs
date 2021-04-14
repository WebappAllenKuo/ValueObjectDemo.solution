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
            
            decimal? actual = model.HeightNumber;
            
            Assert.IsTrue(actual.HasValue);
            Assert.AreEqual(100.8M, actual.Value);
        }
        
        [Test]
        public void AssignNullStringAndGetNumber()
        {
            var model = new Member();
            model.Height = null;
            
            decimal? actual = model.HeightNumber;
            
            Assert.IsFalse(actual.HasValue);
        }
        
        [Test]
        public void AssignNumberAndGetString()
        {
            var model = new Member();
            model.HeightNumber = 100.8M;
            
            string actual = model.Height;
            
            Assert.AreEqual("100.8", actual);
        }
        
        [Test]
        public void AssignNullNumberAndGetString()
        {
            var model = new Member();
            model.HeightNumber = null;
            
            string actual = model.Height;
            
            Assert.IsNull(actual);
        }
    }

    public class Member
    {
        private DecimalVo _Height=null;

        public string Height
        {
            get => _Height;
            set => _Height = value;
        }

        public decimal? HeightNumber
        {
            get => _Height;
            set => _Height = value;
        }
    }

    public class DecimalVo
    {
        private string value = null;
        private decimal? number = null;
        
        private DecimalVo(string value)
        {
            this.value = value;

            if (decimal.TryParse(value, out decimal num))
            {
                this.number = num;
            }
            else
            {
                this.number = null;
            }
        }

        private DecimalVo(decimal? value)
        {
            if (value.HasValue)
            {
                this.number = value.Value;
                this.value = this.number.ToString();
            }
            else
            {
                this.value = null;
                this.number = null;
            }
            
        }
        
        public static implicit operator DecimalVo(string value) => new DecimalVo(value);
        public static implicit operator DecimalVo(decimal? value) => new DecimalVo(value);
        public static implicit operator string(DecimalVo source) => source.value;
        public static implicit operator decimal?(DecimalVo source) => source.number;
    }
}