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
        private DecimalVo _Height=null;

        public string Height
        {
            get => _Height;
            set => _Height = value;
        }

        public decimal? HeightNumer
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

        private DecimalVo(decimal value)
        {
            this.number = value;
            this.value = this.value.ToString();
        }
        
        public static implicit operator DecimalVo(string value) => new DecimalVo(value);
        public static implicit operator DecimalVo(decimal value) => new DecimalVo(value);
        public static implicit operator string(DecimalVo source) => source.value;
        public static implicit operator decimal?(DecimalVo source) => source.number;
    }
}