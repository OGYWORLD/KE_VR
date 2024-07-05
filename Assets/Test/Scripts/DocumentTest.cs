using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 일반 1줄 짜리 주석
/* 일반 여러줄 주석
 * 
 */

/// 1줄 짜리 설명석 주석
/// 설명서 주석의 강제사항: 태그가 없는 문자는 일반 주석과 같이 아무 효과가 없음.
/// <summary>
/// 아래 오는 요소(class, field, property, method 등)에 대한 일반 설명
/// </summary>

public class DocCommentTestClass
{
    /// <summary>
    /// 의미 없는 <seealso cref="int"/> 변수
    /// </summary>
    public int filedA;

    /// <summary>
    /// 의미 없는 Method.
    /// </summary>
    /// <param name="param">의미 없는 파라미터.</param>
    public void SomeMethod(string param) { }

    /// <summary>
    /// 역시 의미없는 Method.
    /// </summary>
    /// <returns>의미없는 반환 값</returns>
    public int SomeReturnableMethod() { return 0; }

    #region 누가 작성했는지 / 혹은 기능 별로 묶어서
    #endregion
}

/**
 * <summary>
 * 여러 줄 설명문
 * </summary>
 */

public class DocumentTest : MonoBehaviour
{
    /// <summary>
    /// 필요한 경우에만 값을 할당하세요.
    /// 아니면 0
    /// </summary>
    [Tooltip("필요할 경우에만 값을 할당하세요. 아니면 0.")]
    public int fieldA;

    [Range(0, 100)]
    public int myRangeField;

    public string fieldC;
    private void Start()
    {
        DocCommentTestClass classA = new DocCommentTestClass();
        classA.filedA = 1;
        //fieldC = Extentions.IntValueToString(fieldA);
        fieldC = fieldA.IntValueToString();
    }

    // view > Task List
    // todo: 오늘 살 것 - 대파
    // ToDo: 내일 살 것 - 양파
    // tOdO: 어제 산 것 - 쪽파
}

// 확장 메서드
// 첫 번째 파라미터를 . 연산자를 통해서 대입 할 수 있는 메서드.

public static class Extentions
{
    public static string IntValueToString(this int param)
    {
        return param.ToString();
    }
}
