using UnityEngine;


public enum TalkingDataProfileType
{
    ANONYMOUS   = 0,
    REGISTERED  = 1,
    SINA_WEIBO  = 2,
    QQ          = 3,
    QQ_WEIBO    = 4,
    ND91        = 5,
    WEIXIN      = 6,
    TYPE1       = 11,
    TYPE2       = 12,
    TYPE3       = 13,
    TYPE4       = 14,
    TYPE5       = 15,
    TYPE6       = 16,
    TYPE7       = 17,
    TYPE8       = 18,
    TYPE9       = 19,
    TYPE10      = 20
}


public enum TalkingDataGender
{
    UNKNOWN     = 0,
    MALE        = 1,
    FEMALE      = 2
}


public class TalkingDataProfile
{
#if UNITY_ANDROID
    public AndroidJavaObject javaObj;
#endif

#if UNITY_IPHONE
    private string name;
    private TalkingDataProfileType type;
    private TalkingDataGender gender;
    private int age;
    private object property1;
    private object property2;
    private object property3;
    private object property4;
    private object property5;
    private object property6;
    private object property7;
    private object property8;
    private object property9;
    private object property10;
#endif

    public static TalkingDataProfile CreateProfile()
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
            TalkingDataProfile profile = new TalkingDataProfile();
#if UNITY_ANDROID
            AndroidJavaClass javaClass = new AndroidJavaClass("com.tendcloud.tenddata.TalkingDataProfile");
            profile.javaObj = javaClass.CallStatic<AndroidJavaObject>("createProfile");
#endif
            return profile;
        }
        return null;
    }

    // 账户名称
    public TalkingDataProfile SetName(string name)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (javaObj != null)
            {
                javaObj.Call<AndroidJavaObject>("setName", name);
            }
#endif
#if UNITY_IPHONE
            this.name = name;
#endif
        }
        return this;
    }

    // 账户类型
    public TalkingDataProfile SetType(TalkingDataProfileType type)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (javaObj != null)
            {
                AndroidJavaClass enumClass = new AndroidJavaClass("com.tendcloud.tenddata.TalkingDataProfileType");
                AndroidJavaObject typeObj = enumClass.CallStatic<AndroidJavaObject>("valueOf", type.ToString());
                javaObj.Call<AndroidJavaObject>("setType", typeObj);
            }
#endif
#if UNITY_IPHONE
            this.type = type;
#endif
        }
        return this;
    }

    // 性别
    public TalkingDataProfile SetGender(TalkingDataGender gender)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (javaObj != null)
            {
                AndroidJavaClass enumClass = new AndroidJavaClass("com.tendcloud.tenddata.TalkingDataGender");
                AndroidJavaObject genderObj = enumClass.CallStatic<AndroidJavaObject>("valueOf", gender.ToString());
                javaObj.Call<AndroidJavaObject>("setGender", genderObj);
            }
#endif
#if UNITY_IPHONE
            this.gender = gender;
#endif
        }
        return this;
    }

    // 年龄
    public TalkingDataProfile SetAge(int age)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (javaObj != null)
            {
                javaObj.Call<AndroidJavaObject>("setAge", age);
            }
#endif
#if UNITY_IPHONE
            this.age = age;
#endif
        }
        return this;
    }

    // 用户属性1
    public TalkingDataProfile SetProperty1(object property)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (javaObj != null)
            {
                AndroidJavaObject androidObject = AndroidJavaObjectFromObject(property);
                javaObj.Call<AndroidJavaObject>("setProperty1", androidObject);
            }
#endif
#if UNITY_IPHONE
            this.property1 = property;
#endif
        }
        return this;
    }

    // 用户属性2
    public TalkingDataProfile SetProperty2(object property)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (javaObj != null)
            {
                AndroidJavaObject androidObject = AndroidJavaObjectFromObject(property);
                javaObj.Call<AndroidJavaObject>("setProperty2", androidObject);
            }
#endif
#if UNITY_IPHONE
            this.property2 = property;
#endif
        }
        return this;
    }

    // 用户属性3
    public TalkingDataProfile SetProperty3(object property)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (javaObj != null)
            {
                AndroidJavaObject androidObject = AndroidJavaObjectFromObject(property);
                javaObj.Call<AndroidJavaObject>("setProperty3", androidObject);
            }
#endif
#if UNITY_IPHONE
            this.property3 = property;
#endif
        }
        return this;
    }

    // 用户属性4
    public TalkingDataProfile SetProperty4(object property)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (javaObj != null)
            {
                AndroidJavaObject androidObject = AndroidJavaObjectFromObject(property);
                javaObj.Call<AndroidJavaObject>("setProperty4", androidObject);
            }
#endif
#if UNITY_IPHONE
            this.property4 = property;
#endif
        }
        return this;
    }

    // 用户属性5
    public TalkingDataProfile SetProperty5(object property)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (javaObj != null)
            {
                AndroidJavaObject androidObject = AndroidJavaObjectFromObject(property);
                javaObj.Call<AndroidJavaObject>("setProperty5", androidObject);
            }
#endif
#if UNITY_IPHONE
            this.property5 = property;
#endif
        }
        return this;
    }

    // 用户属性6
    public TalkingDataProfile SetProperty6(object property)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (javaObj != null)
            {
                AndroidJavaObject androidObject = AndroidJavaObjectFromObject(property);
                javaObj.Call<AndroidJavaObject>("setProperty6", androidObject);
            }
#endif
#if UNITY_IPHONE
            this.property6 = property;
#endif
        }
        return this;
    }

    // 用户属性7
    public TalkingDataProfile SetProperty7(object property)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (javaObj != null)
            {
                AndroidJavaObject androidObject = AndroidJavaObjectFromObject(property);
                javaObj.Call<AndroidJavaObject>("setProperty7", androidObject);
            }
#endif
#if UNITY_IPHONE
            this.property7 = property;
#endif
        }
        return this;
    }

    // 用户属性8
    public TalkingDataProfile SetProperty8(object property)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (javaObj != null)
            {
                AndroidJavaObject androidObject = AndroidJavaObjectFromObject(property);
                javaObj.Call<AndroidJavaObject>("setProperty8", androidObject);
            }
#endif
#if UNITY_IPHONE
            this.property8 = property;
#endif
        }
        return this;
    }

    // 用户属性9
    public TalkingDataProfile SetProperty9(object property)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (javaObj != null)
            {
                AndroidJavaObject androidObject = AndroidJavaObjectFromObject(property);
                javaObj.Call<AndroidJavaObject>("setProperty9", androidObject);
            }
#endif
#if UNITY_IPHONE
            this.property9 = property;
#endif
        }
        return this;
    }

    // 用户属性10
    public TalkingDataProfile SetProperty10(object property)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (javaObj != null)
            {
                AndroidJavaObject androidObject = AndroidJavaObjectFromObject(property);
                javaObj.Call<AndroidJavaObject>("setProperty10", androidObject);
            }
#endif
#if UNITY_IPHONE
            this.property10 = property;
#endif
        }
        return this;
    }

#if UNITY_ANDROID
    private AndroidJavaObject AndroidJavaObjectFromObject(object parameter)
    {
        AndroidJavaObject androidObject = null;
        if (parameter is string)
        {
            androidObject = new AndroidJavaObject("java.lang.String", parameter);
        }
        else if (parameter is byte || parameter is sbyte)
        {
            androidObject = new AndroidJavaObject("java.lang.Byte", parameter);
        }
        else if (parameter is short || parameter is ushort)
        {
            androidObject = new AndroidJavaObject("java.lang.Short", parameter);
        }
        else if (parameter is int || parameter is uint)
        {
            androidObject = new AndroidJavaObject("java.lang.Integer", parameter);
        }
        else if (parameter is long || parameter is ulong)
        {
            androidObject = new AndroidJavaObject("java.lang.Long", parameter);
        }
        else if (parameter is float)
        {
            androidObject = new AndroidJavaObject("java.lang.Float", parameter);
        }
        else if (parameter is double)
        {
            androidObject = new AndroidJavaObject("java.lang.Double", parameter);
        }
        return androidObject;
    }
#endif

#if UNITY_IPHONE
    public override string ToString()
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
            string profileStr = "{\"name\":\"" + name + "\""
                              + ",\"type\":" + (int)type
                              + ",\"gender\":" + (int)gender
                              + ",\"age\":" + age;
            if (property1 is string)
            {
                profileStr += ",\"property1\":\"" + property1 + "\"";
            }
            else
            {
                profileStr += ",\"property1\":" + property1;
            }
            if (property2 is string)
            {
                profileStr += ",\"property2\":\"" + property2 + "\"";
            }
            else
            {
                profileStr += ",\"property2\":" + property2;
            }
            if (property3 is string)
            {
                profileStr += ",\"property3\":\"" + property3 + "\"";
            }
            else
            {
                profileStr += ",\"property3\":" + property3;
            }
            if (property4 is string)
            {
                profileStr += ",\"property4\":\"" + property4 + "\"";
            }
            else
            {
                profileStr += ",\"property4\":" + property4;
            }
            if (property5 is string)
            {
                profileStr += ",\"property5\":\"" + property5 + "\"";
            }
            else
            {
                profileStr += ",\"property5\":" + property5;
            }
            if (property6 is string)
            {
                profileStr += ",\"property6\":\"" + property6 + "\"";
            }
            else
            {
                profileStr += ",\"property6\":" + property6;
            }
            if (property7 is string)
            {
                profileStr += ",\"property7\":\"" + property7 + "\"";
            }
            else
            {
                profileStr += ",\"property7\":" + property7;
            }
            if (property8 is string)
            {
                profileStr += ",\"property8\":\"" + property8 + "\"";
            }
            else
            {
                profileStr += ",\"property8\":" + property8;
            }
            if (property9 is string)
            {
                profileStr += ",\"property9\":\"" + property9 + "\"";
            }
            else
            {
                profileStr += ",\"property9\":" + property9;
            }
            if (property10 is string)
            {
                profileStr += ",\"property10\":\"" + property10 + "\"";
            }
            else
            {
                profileStr += ",\"property10\":" + property10;
            }
            profileStr += "}";
            return profileStr;
        }
        return null;
    }
#endif
}
