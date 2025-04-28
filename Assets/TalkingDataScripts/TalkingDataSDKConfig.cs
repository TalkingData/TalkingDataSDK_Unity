using UnityEngine;


public class TalkingDataSDKConfig
{
    public AndroidJavaObject javaObj;

    public static TalkingDataSDKConfig CreateConfig()
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
            TalkingDataSDKConfig config = new TalkingDataSDKConfig();
#if UNITY_ANDROID
            config.javaObj = new AndroidJavaObject("com.tendcloud.tenddata.TalkingDataSDKConfig");
#endif
            return config;
        }
        return null;
    }

    public TalkingDataSDKConfig SetIMEIAndMEIDEnabled(bool enabled)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            javaObj.Call<AndroidJavaObject>("setIMEIAndMEIDEnabled", enabled);
#endif
            return this;
        }
        return null;
    }

    public TalkingDataSDKConfig SetMACEnabled(bool enabled)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            javaObj.Call<AndroidJavaObject>("setMACEnabled", enabled);
#endif
            return this;
        }
        return null;
    }

    public TalkingDataSDKConfig SetAppListEnabled(bool enabled)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            javaObj.Call<AndroidJavaObject>("setAppListEnabled", enabled);
#endif
            return this;
        }
        return null;
    }

    public TalkingDataSDKConfig SetLocationEnabled(bool enabled)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            javaObj.Call<AndroidJavaObject>("setLocationEnabled", enabled);
#endif
            return this;
        }
        return null;
    }

    public TalkingDataSDKConfig SetWifiEnabled(bool enabled)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            javaObj.Call<AndroidJavaObject>("setWifiEnabled", enabled);
#endif
            return this;
        }
        return null;
    }
}
