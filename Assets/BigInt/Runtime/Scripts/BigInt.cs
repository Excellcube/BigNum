using System;
using System.Numerics;
using UnityEngine;


///
/// *** BigInt 사용 시 주의사항 ***
/// Equals 메서드 사용 시 항상 BigInt가 lhs에 할당이 되어야 한다.
/// BigInt bigInt(5)와 int value = 5를 비교할 때
/// Assert.AreEqual(bigInt, 5)는 true지만
/// Assert.AreEqual(5, bigInt)는 false가 된다.
/// BigInt의 Equals가 호출되지 않기 때문이다.
///

namespace Excellcube
{
    public struct BigInt
    {
        private BigInteger m_Value;
        public  BigInteger value => m_Value;

        public BigInt(int value)
        {
            m_Value = value;
        }

        public BigInt(long value)
        {
            m_Value = value;
        }

        public BigInt(string value)
        {
            if(!BigInteger.TryParse(value, out m_Value))
            {
                Debug.LogWarning($"[BigInt] {value}를 BigInt로 변환하는데 실패했습니다.");
                m_Value = 0;
            }
        }

        public BigInt(BigInteger value)
        {
            m_Value = value;
        }

        public static implicit operator BigInt(int value)
        {
            return new BigInt(value);
        }

        public static implicit operator BigInt(long value)
        {
            return new BigInt(value);
        }

        public static implicit operator BigInt(string value)
        {
            return new BigInt(value);
        }


        //// BigInt operators

        public static implicit operator BigInt(BigInteger value)
        {
            return new BigInt(value);
        }

        public static BigInt operator +(BigInt lhs, BigInt rhs)
        {
            lhs.m_Value += rhs.m_Value;
            return lhs;
        }

        public static BigInt operator -(BigInt lhs, BigInt rhs)
        {
            lhs.m_Value -= rhs.m_Value;
            return lhs;
        }

        public static BigInt operator *(BigInt lhs, BigInt rhs)
        {
            lhs.m_Value *= rhs.m_Value;
            return lhs;
        }

        public static BigInt operator /(BigInt lhs, BigInt rhs)
        {
            lhs.m_Value /= rhs.m_Value;
            return lhs;
        }

        public static bool operator <(BigInt lhs, BigInt rhs)
        {
            return lhs.m_Value < rhs.m_Value;
        }

        public static bool operator >(BigInt lhs, BigInt rhs)
        {
            return lhs.m_Value > rhs.m_Value;
        }

        public static bool operator <=(BigInt lhs, BigInt rhs)
        {
            return lhs.m_Value <= rhs.m_Value;
        }

        public static bool operator >=(BigInt lhs, BigInt rhs)
        {
            return lhs.m_Value >= rhs.m_Value;
        }

        public static bool operator ==(BigInt lhs, BigInt rhs)
        {
            return lhs.m_Value == rhs.m_Value;
        }

         public static bool operator !=(BigInt lhs, BigInt rhs)
        {
            return lhs.m_Value != rhs.m_Value;
        }


        //// int operators

        public static BigInt operator +(BigInt lhs, int rhs)
        {
            lhs.m_Value += rhs;
            return lhs;
        }

        public static BigInt operator -(BigInt lhs, int rhs)
        {
            lhs.m_Value -= rhs;
            return lhs;
        }

        public static BigInt operator *(BigInt lhs, int rhs)
        {
            lhs.m_Value *= rhs;
            return lhs;
        }

        public static BigInt operator /(BigInt lhs, int rhs)
        {
            lhs.m_Value /= rhs;
            return lhs;
        }

        public static bool operator <(BigInt lhs, int rhs)
        {
            return lhs.m_Value < rhs;
        }

        public static bool operator >(BigInt lhs, int rhs)
        {
            return lhs.m_Value > rhs;
        }

        public static bool operator <=(BigInt lhs, int rhs)
        {
            return lhs.m_Value <= rhs;
        }

        public static bool operator >=(BigInt lhs, int rhs)
        {
            return lhs.m_Value >= rhs;
        }

        public static bool operator ==(BigInt lhs, int rhs)
        {
            return lhs.m_Value == rhs;
        }

        public static bool operator !=(BigInt lhs, int rhs)
        {
            return lhs.m_Value != rhs;
        }


        ///// long

        public static BigInt operator +(BigInt lhs, long rhs)
        {
            lhs.m_Value += rhs;
            return lhs;
        }

        public static BigInt operator -(BigInt lhs, long rhs)
        {
            lhs.m_Value -= rhs;
            return lhs;
        }

        public static BigInt operator *(BigInt lhs, long rhs)
        {
            lhs.m_Value *= rhs;
            return lhs;
        }

        public static BigInt operator /(BigInt lhs, long rhs)
        {
            lhs.m_Value /= rhs;
            return lhs;
        }

        public static bool operator <(BigInt lhs, long rhs)
        {
            return lhs.m_Value < rhs;
        }

        public static bool operator >(BigInt lhs, long rhs)
        {
            return lhs.m_Value > rhs;
        }

        public static bool operator <=(BigInt lhs, long rhs)
        {
            return lhs.m_Value <= rhs;
        }

        public static bool operator >=(BigInt lhs, long rhs)
        {
            return lhs.m_Value >= rhs;
        }

        public static bool operator ==(BigInt lhs, long rhs)
        {
            return lhs.m_Value == rhs;
        }

        public static bool operator !=(BigInt lhs, long rhs)
        {
            return lhs.m_Value != rhs;
        }


        ///// string

        public static BigInt operator +(BigInt lhs, string rhs)
        {
            lhs.m_Value += BigInteger.Parse(rhs);
            return lhs;
        }

        public static BigInt operator -(BigInt lhs, string rhs)
        {
            lhs.m_Value -= BigInteger.Parse(rhs);
            return lhs;
        }

        public static BigInt operator *(BigInt lhs, string rhs)
        {
            lhs.m_Value *= BigInteger.Parse(rhs);
            return lhs;
        }

        public static BigInt operator /(BigInt lhs, string rhs)
        {
            lhs.m_Value /= BigInteger.Parse(rhs);
            return lhs;
        }

        public static bool operator <(BigInt lhs, string rhs)
        {
            return lhs.m_Value < BigInteger.Parse(rhs);
        }

        public static bool operator >(BigInt lhs, string rhs)
        {
            return lhs.m_Value > BigInteger.Parse(rhs);
        }

        public static bool operator <=(BigInt lhs, string rhs)
        {
            return lhs.m_Value <= BigInteger.Parse(rhs);
        }

        public static bool operator >=(BigInt lhs, string rhs)
        {
            return lhs.m_Value >= BigInteger.Parse(rhs);
        }

        public static bool operator ==(BigInt lhs, string rhs)
        {
            return lhs.m_Value == BigInteger.Parse(rhs);
        }

        public static bool operator !=(BigInt lhs, string rhs)
        {
            return lhs.m_Value != BigInteger.Parse(rhs);
        }


        // 소수점 셋째자리까지의 나눗셈 결과를 리턴.
        public static double Divide(BigInt lhs, BigInt rhs)
        {
            // BigInterger의 경우 일반 나눗셈을 수행하면 소수점 이하 단위를 표현할 수 없다.
            // 소수점 이하 단위를 계산하기 위해 아래 방식을 사용.
            // (기존 방법) 246 / 200 = 1.23
            // (변경 방법) 24600 / 200 = 123
            //           123 / 100 = 1.23
            
            BigInt lhs1000 = lhs * 1000;
            BigInt quot1000 = lhs1000 / rhs;
            return ((double) quot1000.value) / 1000.0;
        }

        // 주로 rhs에 1,000,000 이하의 작은 숫자가 들어간다.
        public static BigInt Divide(BigInt lhs, float rhs)
        {
            // BigInterger의 경우 일반 나눗셈을 수행하면 소수점 이하 단위를 표현할 수 없다.
            // 소수점 이하 단위를 계산하기 위해 아래 방식을 사용.
            // (기존 방법) 246 / 200 = 1.23
            // (변경 방법) 24600 / 200 = 123
            //           123 / 100 = 1.23
            
            BigInt lhs1000000 = lhs * 1000000;
            BigInt rhs1000 = (long) (rhs * 1000);
            BigInt quot1000 = lhs1000000.value / rhs1000;
            return quot1000 / 1000;
        }

        public static BigInt Multiply(BigInt lhs, float rhs)
        {
            BigInt rhs1000 = (long) (rhs * 1000);
            return (lhs.value * rhs1000) / 1000;
        }

        
        public string ToString(string format = "")
        {
            return m_Value.ToString(format);
        }

        public string ToShortForm(string locale)
        {
            if(IsUsingKorean(locale))
            {
                return ToShortFormKorean();
            }
            else
            {
                return ToShortFormAlphabet();
            }
        }

        private bool IsUsingKorean(string locale)
        {
            return (locale == "ko") || (locale == "ko-KR");
        }

        private string ToShortFormKorean()
        {
            if(m_Value < 10000) {
                return m_Value.ToString();
            } else {
                string[] unitCode = { "", "만", "억", "조", "경", "해", "자", "양", "구", "간", "정", "재", "극" };

                string valueStr = m_Value.ToString();
                int valueStrLength = valueStr.Length;

                int majorCodeIdx = (valueStrLength - 1) / 4;
                int minorCodeIdx = majorCodeIdx - 1;

                // 1234567
                // 123 : majorValue, 4567 : minorValue
                // 12345
                // 1 : majorValue, 2345 : minorValue
                // 12345678
                // 1234 : majorValue, 5678 : minorValue
                int majorValueCount = valueStrLength % 4;
                if(majorValueCount <= 0)
                {
                    majorValueCount = 4;
                }
                int minorValueCount = 4;

                if(valueStrLength < 5)
                {
                    return valueStr;
                }
                else
                {
                    string majorValue = valueStr.Substring(0, majorValueCount);
                    string majorCode = unitCode[majorCodeIdx];

                    // '1억 0000만' 이라는 글자가 나오는 현상을 방지.
                    // minorValue가 0일 경우 스킵.
                    // minorValue가 0030일 경우 30으로 변환. 
                    string rawMinorValue = valueStr.Substring(majorValueCount, minorValueCount);
                    int numMinorValue = int.Parse(rawMinorValue);
                    string minorValue = numMinorValue.ToString();
                    string minorCode = unitCode[minorCodeIdx];

                    if(numMinorValue == 0) {
                        return $"{majorValue}{majorCode}";
                    } else {
                        return $"{majorValue}{majorCode} {minorValue}{minorCode}";
                    }
                }                
            }
        }

        // https://gram.gs/gramlog/formatting-big-numbers-aa-notation/
        private string ToShortFormAlphabet()
        {
            if(m_Value < 1000) {
                return m_Value.ToString();
            } else {
                // aa notation으로 구현.
                string[] unitCode = { "", "K", "M", "B", "t", "aa", "ab", "ac", "ad", "ae", "af", "ag", "ah" };

                string valueStr = m_Value.ToString();
                int valueStrLength = valueStr.Length;

                int majorCodeIdx = (valueStrLength - 1) / 3;
                int minorCodeIdx = majorCodeIdx - 1;
                
                int majorValueCount = valueStrLength % 3;
                if(majorValueCount <= 0)
                {
                    majorValueCount = 3;
                }
                int minorValueCount = 3;

                if(valueStrLength < 4)
                {
                    return valueStr;
                }
                else
                {
                    string majorValue = valueStr.Substring(0, majorValueCount);
                    string majorCode = unitCode[majorCodeIdx];
                    string minorValue = valueStr.Substring(majorValueCount, minorValueCount);
                    string minorCode = unitCode[minorCodeIdx];

                    return $"{majorValue}.{minorValue}{majorCode}";
                }                
            }
        }

        public override bool Equals(object obj)
        {
            Type type = obj.GetType();

            if(type == typeof(int))
            {
                return this == (int) obj;
            }
            else if(type == typeof(long))
            {
                return this == (long) obj;
            }
            else if(type == typeof(string))
            {
                return this == (string) obj;
            }
            else if(type == typeof(BigInt))
            {
                return this == (BigInt) obj;
            }
            else
            {
                Debug.LogError($"비교할 수 없는 타입. {type.Name}");
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return m_Value.ToString();
        }
    }
}
