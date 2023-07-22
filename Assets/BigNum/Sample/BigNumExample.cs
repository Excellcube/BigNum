using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

using Excellcube;

public class BigNumExample : MonoBehaviour
{
    public Text m_LargeNumIntText;
    public Text m_LargeNumBigNumberText;
    public Text m_LargeNumStrText;
    
    private void Start() {
        int largeNumInt = 987654321;
        BigNum bigIntInt = largeNumInt;
        m_LargeNumIntText.text = bigIntInt.ToShortForm("ko");

        decimal largeNumBigInteger = 12341234123412341234.0M;
        BigNum bigIntBigInteger = largeNumBigInteger;
        m_LargeNumBigNumberText.text = bigIntBigInteger.ToShortForm("ko");

        string largeNumStr = "8765432109876543210987654321";
        BigNum bigIntStr = largeNumStr;
        m_LargeNumStrText.text = bigIntStr.ToShortForm("en");
    }
}
