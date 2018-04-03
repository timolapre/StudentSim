using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class Camera : MonoBehaviour {

    public Player player;
    [Range(1,6)]
    public int Offset;

    private PostProcessingProfile profile;
    private DepthOfFieldModel.Settings DrunkSettings;
    private VignetteModel.Settings SleepySettings;
    private MotionBlurModel.Settings DrunkSettingsBlur;

    public Canvas CanvasDrunk, CanvasTired;

    // Use this for initialization
    void Start () {
        CanvasDrunk.enabled = false;
        CanvasTired.enabled = false;
        profile = GetComponent<PostProcessingBehaviour>().profile;
        SleepySettings = profile.vignette.settings;
        DrunkSettings = profile.depthOfField.settings;
        DrunkSettingsBlur = profile.motionBlur.settings;

        DrunkSettings.focalLength = 1;
        profile.depthOfField.settings = DrunkSettings;
        DrunkSettingsBlur.frameBlending = 0;
        DrunkSettingsBlur.shutterAngle = 0;
        profile.motionBlur.settings = DrunkSettingsBlur;
    }
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = new Vector3(-player.transform.position.x/Offset,2,-2);

        SleepySettings.intensity = Mathf.Max(player.Sleep*(-1)/50 + 1,0);
        profile.vignette.settings= SleepySettings;
        if(player.Sleep < 20)
            CanvasTired.enabled = true;
        else
            CanvasTired.enabled = false;
    }

    public void DrunkEffect(float time)
    {
        CanvasDrunk.enabled = true;
        DrunkSettings.focalLength = 15;
        profile.depthOfField.settings= DrunkSettings;
        DrunkSettingsBlur.frameBlending = 32;
        DrunkSettingsBlur.shutterAngle = 360;
        profile.motionBlur.settings = DrunkSettingsBlur;
        StartCoroutine(WaitXSeconds(time));
    }

    IEnumerator WaitXSeconds(float time)
    {
        yield return new WaitForSeconds(time);
        CanvasDrunk.enabled = false;
        DrunkSettings.focalLength = 1;
        profile.depthOfField.settings = DrunkSettings;
        DrunkSettingsBlur.frameBlending = 0;
        DrunkSettingsBlur.shutterAngle = 0;
        profile.motionBlur.settings = DrunkSettingsBlur;
    }
}
