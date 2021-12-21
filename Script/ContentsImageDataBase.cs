using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ContentsImageDataBase : MonoBehaviour
{
    [Header("13 = 지심도 " +
        "14 = 내도")]

    [Header("11 = 구천댐 " +
        "12 = 저도 ")]

    [Header("9 = 거제 해금강 " +
        "10 = 학동 뭉돌해수욕장 ")]

    [Header("7 = 바람의 언덕 " +
        "8 = 외도 ")]
    [Header("///////////////////////////////////////////////")]
    [Header("5 = 비워 " +
        "6 = 비워 ")]

    [Header("3 = 해송숲 탐험 " +
        "4 = 맹죽숲 명상 걷기 ")]

    [Header("1 = AR 작가 전시전 " +
           "2 = 해송숲 테마 미술 전시 ")]



    public Sprite []contentsImage;

    public Sprite[] contentsBarImage;


    [Header("14: 39~41")]
    [Header("13: 36~38")]
    [Header("12: 33~35")]
    [Header("11: 30~32")]
    [Header("10: 27~29")]
    [Header("9: 24~26")]
    [Header("8: 21~23")]
    [Header("7: 18~20")]

    [Header("6: 15~17")]
    [Header("5: 12~14")]
    [Header("4: 9~11")]
    [Header("3: 6~8")]
    [Header("2: 3~5")]
    [Header("1: 0~2")]
    public Sprite[] contentsDetailImage;
}
