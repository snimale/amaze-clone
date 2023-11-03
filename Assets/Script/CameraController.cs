using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private AnimationCurve levelTransitionCurveIn;
    [SerializeField] private AnimationCurve levelTransitionCurveOut;
    private Vector3 cameraOffsetVector = new Vector3(15, 0, 0);
    private Vector3 initialCameraPosition;

    void Start()
    {
        initialCameraPosition = transform.position;
    }

    private IEnumerator level_transition_out(float transitionTime)
    {
        // left to right
        Vector3 startPosition = initialCameraPosition;
        Vector3 endPosition = initialCameraPosition + cameraOffsetVector;
        float timeElapsed = 0;
        while(timeElapsed < transitionTime)
        {
            timeElapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, endPosition, levelTransitionCurveOut.Evaluate(timeElapsed / transitionTime));
            yield return new WaitForEndOfFrame();
        }
        yield return StartCoroutine(level_transition_in(transitionTime));
    }

    private IEnumerator level_transition_in(float transitionTime)
    {
        // right to left
        Vector3 startPosition = initialCameraPosition - cameraOffsetVector;
        Vector3 endPosition = initialCameraPosition;
        float timeElapsed = 0;
        while(timeElapsed < transitionTime) {
            timeElapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, endPosition, levelTransitionCurveIn.Evaluate(timeElapsed / transitionTime));
            yield return new WaitForEndOfFrame();
        }
    }

    public void animateLevelSwitchTransition(float transitionTime) 
    {
        StartCoroutine(level_transition_out(transitionTime / 2));
    }

    public void animateLevelInTransition(float transitionTime) 
    {
        StartCoroutine(level_transition_in(transitionTime));
    }

}