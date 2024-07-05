using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �Ϲ� 1�� ¥�� �ּ�
/* �Ϲ� ������ �ּ�
 * 
 */

/// 1�� ¥�� ���� �ּ�
/// ���� �ּ��� ��������: �±װ� ���� ���ڴ� �Ϲ� �ּ��� ���� �ƹ� ȿ���� ����.
/// <summary>
/// �Ʒ� ���� ���(class, field, property, method ��)�� ���� �Ϲ� ����
/// </summary>

public class DocCommentTestClass
{
    /// <summary>
    /// �ǹ� ���� <seealso cref="int"/> ����
    /// </summary>
    public int filedA;

    /// <summary>
    /// �ǹ� ���� Method.
    /// </summary>
    /// <param name="param">�ǹ� ���� �Ķ����.</param>
    public void SomeMethod(string param) { }

    /// <summary>
    /// ���� �ǹ̾��� Method.
    /// </summary>
    /// <returns>�ǹ̾��� ��ȯ ��</returns>
    public int SomeReturnableMethod() { return 0; }

    #region ���� �ۼ��ߴ��� / Ȥ�� ��� ���� ���
    #endregion
}

/**
 * <summary>
 * ���� �� ����
 * </summary>
 */

public class DocumentTest : MonoBehaviour
{
    /// <summary>
    /// �ʿ��� ��쿡�� ���� �Ҵ��ϼ���.
    /// �ƴϸ� 0
    /// </summary>
    [Tooltip("�ʿ��� ��쿡�� ���� �Ҵ��ϼ���. �ƴϸ� 0.")]
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
    // todo: ���� �� �� - ����
    // ToDo: ���� �� �� - ����
    // tOdO: ���� �� �� - ����
}

// Ȯ�� �޼���
// ù ��° �Ķ���͸� . �����ڸ� ���ؼ� ���� �� �� �ִ� �޼���.

public static class Extentions
{
    public static string IntValueToString(this int param)
    {
        return param.ToString();
    }
}
