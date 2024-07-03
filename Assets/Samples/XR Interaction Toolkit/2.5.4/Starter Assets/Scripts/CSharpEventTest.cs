using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void SomeEvent(int a);

public class CSharpEventTest : MonoBehaviour
{
    // C# 이벤트란
    // 1. 이벤트를 선언한 클래스만 호출할 수 있다.
    // 이런 불편한 Event가 존재하는 이유는 Observer 패턴을 위해
    // 2. delegate 필드는 Interface에서 선언할 수 없지만 event는 가능
    public event SomeEvent someEvent;
    public event Action<int, int> someAction;
    public event Func<int, int> someFuc;

    private void Start()
    {
        EventTestClass testClass = new EventTestClass();
        testClass.OnInit(this);

        someEvent?.Invoke(1);
    }
}

public class EventTestClass
{
    public void OnInit(CSharpEventTest tester)
    {
        tester.someEvent += (int a) => { new GameObject(a.ToString()); };
    }
}

public interface IDestory
{
    public event SomeEvent OnDestory;
}

public class DestoryWhen10Sec : IDestory
{
    public event SomeEvent OnDestory;

    // 10초 후에 파괴되면서 호출될 함수
    private void WhenDestory()
    {
        // 파괴되는 절차를 수행 후에
        OnDestory?.Invoke(1);
    }
}