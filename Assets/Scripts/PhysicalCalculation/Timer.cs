using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class Timer
{
    public enum CountType
    {
        countdown = -1,
        NONE = 0,
        countup = 1,
    }

    [SerializeField] private CountType countType;
    [SerializeField] private Unit.Time.Seconds seconds;
    [SerializeField] private bool isStarted;
    private readonly MonoBehaviour _monoBehaviour;
    private IEnumerator _routine;

    public Timer(float initialTime, CountType countType, MonoBehaviour monoBehaviour)
    {
        if (initialTime < 0f)
            initialTime = 0f;

        seconds = new(initialTime);
        _monoBehaviour = monoBehaviour;
        this.countType = countType;
    }

    public void Start()
    {
        if (countType == CountType.countdown)
            _routine ??= Countdown();
        else if (countType == CountType.countup)
            _routine ??= Countup();
        else
            _routine = null;

        if (_routine == null)
            return;

        isStarted = true;
        _monoBehaviour.StartCoroutine(_routine);
    }

    public void Pause()
    {
        isStarted = false;
    }

    public void Stop()
    {
        isStarted = false;
        seconds = new(0f);
        countType = CountType.NONE;
        _monoBehaviour.StopCoroutine(_routine);
        _routine = null;
    }

    private IEnumerator Countup()
    {
        float time = seconds.value;

        do
        {
            time -= Time.deltaTime;
            seconds = new(time);
            yield return null;
        } while (isStarted);
    }

    private IEnumerator Countdown()
    {
        float time = seconds.value;

        while (isStarted || time > 0f)
        {
            seconds = new(time);
            time -= Time.deltaTime;
            yield return null;
        }

        if (seconds.value <= 0f)
            isStarted = false;
    }

    public Unit.Time.Seconds Seconds => seconds;
}