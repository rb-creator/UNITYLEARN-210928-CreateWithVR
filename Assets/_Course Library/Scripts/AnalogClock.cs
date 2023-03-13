using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalogClock : MonoBehaviour
{
    [SerializeField]
    private Transform _hourHand;
    [SerializeField]
    private Transform _minuteHand;
    [SerializeField]
    private Transform _secondHand;

    private int _previousSeconds;
    private int _timeInSeconds;

    void Update()
    {
        ConvertTimeToSeconds();
        RotateClockHands();
    }

    private int ConvertTimeToSeconds()
    {
        int currentSeconds = DateTime.Now.Second;
        int currentMinute = DateTime.Now.Minute;
        int currentHour = DateTime.Now.Hour;

        if (currentHour >= 12)
        {
            currentHour -= 12;
        }

        _timeInSeconds = currentSeconds + (currentMinute * 60) + (currentHour * 60 * 60);

        return _timeInSeconds;
    }

    void RotateClockHands()
    {
        //Movement in Degrees per second for second, minute and hour hands
        float secondhandPerSecond = 360f / 60f;
        float minutehandPerSecond = 360f / (60f * 60f);
        float hourhandPerSecond = 360f / (60f * 60f * 12f);

        if (_timeInSeconds != _previousSeconds)
        {
            //Debug.Log(_timeInSeconds);
            _secondHand.localRotation = Quaternion.Euler(_timeInSeconds * secondhandPerSecond, 0, 0);
            _minuteHand.localRotation = Quaternion.Euler(_timeInSeconds * minutehandPerSecond, 0, 0);
            _hourHand.localRotation = Quaternion.Euler(_timeInSeconds * hourhandPerSecond, 0, 0);
        }
        _previousSeconds = _timeInSeconds;
    }

}
