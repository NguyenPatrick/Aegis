/*
 * Created by:Bryan Battershill
 * Last Modified: 22-Jan-2015
 * Created for: ICS3UR
 * Final App Project – Gladiator of Dimensions
*/
// controls the position of the joystick
//
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Joystick : MonoBehaviour
{
    private bool touchControls = true;
    public static bool isActivated = false;
    public Image joystick;
    public static float radius;
    public static Vector2 joystickCenter;
    private Vector3 actualMousePosition;
    private float joystickSize;
    private CanvasScaler canvasScaler;
    private Vector2 screenScale;

    void Start()
    {

    // scaling code courtesy of jmorhart and esitoinatteso 
    http://answers.unity3d.com/questions/976184/ui-recttransform-position-screen-resolution.html

        if (canvasScaler == null)
        {
            canvasScaler = GetComponentInParent<CanvasScaler>();
        }

        if (canvasScaler)
        {
            screenScale = new Vector2((canvasScaler.referenceResolution.x / Screen.width), (canvasScaler.referenceResolution.y / Screen.height));
        }

        joystickCenter = new Vector2(joystick.rectTransform.position.x, joystick.rectTransform.position.y);
        joystickSize = joystick.rectTransform.rect.width;
        radius = joystickSize / screenScale.x / 2;
    }
}







/*
 void Update()
{

}
double mouseDistanceFromCenter;

Vector3 newMousePosition;
newMousePosition.x = 0;
newMousePosition.y = 0;

Touch touch = Input.GetTouch(0);
if (!touchControls)
{
    if (Input.GetMouseButton(0))
    {
        actualMousePosition = Input.mousePosition;
        newMousePosition.x = actualMousePosition.x - joystickCenter.x;
        newMousePosition.y = actualMousePosition.y - joystickCenter.y;
    }
}
else
{
    if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
    {
        actualMousePosition = touch.position;
        newMousePosition.x = actualMousePosition.x - joystickCenter.x;
        newMousePosition.y = actualMousePosition.y - joystickCenter.y;
    }
}

mouseDistanceFromCenter = Mathf.Sqrt(Mathf.Pow(newMousePosition.x, 2) + Mathf.Pow(newMousePosition.y, 2));
if (!touchControls)
{
    if (mouseDistanceFromCenter < radius)
    {
        if (mouseDistanceFromCenter < radius / 4)
        {
            isActivated = false;
        }
        else
        {
            isActivated = true;
        }
    }
    else
    {
        isActivated = false;
    }
}
else
{
    if (mouseDistanceFromCenter < radius && touch.phase == TouchPhase.Began)
    {
        if (mouseDistanceFromCenter < radius / 4)
        {
            isActivated = false;
        }
        else
        {
            isActivated = true;
        }
    }
    else if (mouseDistanceFromCenter > radius / 4 && touch.phase == TouchPhase.Began)
    {
        isActivated = false;
    }
    else if (touch.phase == TouchPhase.Ended)
    {
        isActivated = false;
    }
}
}
*/




