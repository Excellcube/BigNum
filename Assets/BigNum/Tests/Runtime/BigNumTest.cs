using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Numerics;

using Excellcube;

public class BigNumTest
{
    [Test]
    public void AdditionTest()
    {
        BigNum num1 = 10;
        BigNum num2 = 20;
        Assert.IsTrue(num1 + num2 == 30);
    }

    [Test]
    public void SubstractTest()
    {
        BigNum num1 = 10;
        BigNum num2 = 20;
        Assert.IsTrue(num1 - num2 == -10);
    }

    [Test]
    public void MultiplicationTest()
    {
        BigNum num1 = 10;
        BigNum num2 = 20;
        Assert.IsTrue(num1 * num2 == 200);
    }

    [Test]
    public void DivisionTest()
    {
        BigNum num1 = 20;
        BigNum num2 = 10;
        Assert.IsTrue(num1 / num2 == 2, $"expected {2}, actual {num1 / num2}");

        BigNum num3 = 3;
        BigNum num4 = 2;
        Assert.IsTrue(num3 / num4 == 1.5f, $"expected {1.5f}, actual {num3 / num4}");

        BigNum num5 = 1;
        BigNum num6 = 2;
        Assert.IsTrue(num5 / num6 == 0.5, $"expected {0.5}, actual {num5 / num6}");
    }

    [Test]
    public void LargeNumberAdditionTest()
    {
        BigNum num1 = "1000000000000000000000000000";
        BigNum num2 = "2000000000000000000000000000";
        Assert.IsTrue(num1 + num2 == "3000000000000000000000000000");
    }

    [Test]
    public void MaxLargeNumberTest()
    {
        // 소숫점 표현 때문에 decimal 사용.
        // 추후에 자릿수 제한이 없는 숫자 모듈로 구현.
        BigNum num1 = "8765432109876543210987654321"; // 28자리.
        Assert.IsTrue(num1 == "8765432109876543210987654321");
    }

    [Test]
    public void ToStringTest()
    {
        BigNum num1 = "123456789";
        string num1Str = num1.ToString("N0");
        Assert.AreEqual(num1Str, "123,456,789");

        BigNum num2 = "123456789123456789";
        string num2Str = num2.ToString("N0");
        Assert.AreEqual(num2Str, "123,456,789,123,456,789");
    }

    [Test]
    public void ToShortFormKoeanTest()
    {
        BigNum num;
        string numStr;

        num = "1234";
        numStr = num.ToShortForm("ko");
        Assert.AreEqual(numStr, "1234");

        num = "123456789";
        numStr = num.ToShortForm("ko");
        Assert.AreEqual(numStr, "1억 2345만");

        num = "1023456789";
        numStr = num.ToShortForm("ko");
        Assert.AreEqual(numStr, "10억 2345만");

        num = "10023456789";
        numStr = num.ToShortForm("ko");
        Assert.AreEqual(numStr, "100억 2345만");

        num = "100023456789";
        numStr = num.ToShortForm("ko");
        Assert.AreEqual(numStr, "1000억 2345만");

        num = "1000023456789";
        numStr = num.ToShortForm("ko");
        Assert.AreEqual(numStr, "1조");

        num = "1020023456789";
        numStr = num.ToShortForm("ko");
        Assert.AreEqual(numStr, "1조 200억");

        //    해   경   조    억    만   
        // 8765,4321,2345,6789,8765,4321
        BigNum num2 = "876543212345678987654321";
        string num2Str = num2.ToShortForm("ko");
        Assert.AreEqual("8765해 4321경", num2Str);
    }

    [Test]
    public void ToShortFormAlphabetTest()
    {
        BigNum num;
        string numStr;

        num = "123";
        numStr = num.ToShortForm("en");
        Assert.AreEqual(numStr, "123");

        num = "1234";
        numStr = num.ToShortForm("en");
        Assert.AreEqual(numStr, "1.23K");

        num = "123456789";
        numStr = num.ToShortForm("en");
        Assert.AreEqual(numStr, "123M");

        num = "1023456789";
        numStr = num.ToShortForm("en");
        Assert.AreEqual(numStr, "1.02B");

        num = "10023456789";
        numStr = num.ToShortForm("en");
        Assert.AreEqual(numStr, "10.0B");

        num = "100023456789";
        numStr = num.ToShortForm("en");
        Assert.AreEqual(numStr, "100B");

        num = "1000023456789";
        numStr = num.ToShortForm("en");
        Assert.AreEqual(numStr, "1.00T");

        num = "1020023456789";
        numStr = num.ToShortForm("en");
        Assert.AreEqual(numStr, "1.02T");

        BigNum num2 = "876543212345678987654321";
        string num2Str = num2.ToShortForm("en");
        Assert.AreEqual(num2Str, "876ac");
    }

    [Test]
    public void EqualityTest()
    {
        BigNum num = 10;
        Assert.IsTrue(num == 10);
        Assert.IsFalse(num == 20);
    }
}
