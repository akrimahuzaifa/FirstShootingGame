using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDlegates : MonoBehaviour
{
    public delegate void ShowPlayerNameDelegate(string userName);
    public delegate void PlayGunSoundsDelegate();
    public delegate void UIDelegate(int mag);
    public delegate void TimerUIdelegate(int hours, int minutes, float seconds);
    public delegate void UserNameDelegate(string username);
    public delegate void BulletHandlerDelegate();
}
