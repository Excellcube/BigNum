using System;
using System.Numerics;
using UnityEngine;

namespace Excellcube
{
    public struct BigInt
    {
        private BigInteger m_Value;

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

        public static bool operator ==(BigInt lhs, BigInt rhs)
        {
            return lhs.m_Value == rhs.m_Value;
        }

         public static bool operator !=(BigInt lhs, BigInt rhs)
        {
            return lhs.m_Value != rhs.m_Value;
        }

        public static bool operator ==(BigInt lhs, int rhs)
        {
            return lhs.m_Value == rhs;
        }

        public static bool operator !=(BigInt lhs, int rhs)
        {
            return lhs.m_Value != rhs;
        }

        public static bool operator ==(BigInt lhs, long rhs)
        {
            return lhs.m_Value == rhs;
        }

        public static bool operator !=(BigInt lhs, long rhs)
        {
            return lhs.m_Value != rhs;
        }

        public static bool operator ==(BigInt lhs, string rhs)
        {
            return lhs.m_Value == BigInteger.Parse(rhs);
        }

        public static bool operator !=(BigInt lhs, string rhs)
        {
            return lhs.m_Value != BigInteger.Parse(rhs);
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

        private string ToShortFormAlphabet()
        {
            if(m_Value < 1000) {
                return m_Value.ToString();
            } else {
                string[] unitCode = { "", "K", "M", "B", "t", "q", "Q", "s", "S", "o", "n", "d", "U" };

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
    }
}
