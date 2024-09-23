// version: 5.0.2

using UnityEngine;
using System.Collections.Generic;
#if UNITY_ANDROID
using System;
#endif
#if UNITY_IPHONE
using System.Runtime.InteropServices;
using System.Collections;
#endif


public static class TalkingDataSDK
{
#if UNITY_ANDROID
    private static readonly string TALKINGDATA_CLASS = "com.tendcloud.tenddata.TalkingDataSDK";
    private static AndroidJavaClass talkingdataClass;
    private static AndroidJavaClass unityPlayerClass;
#endif

#if UNITY_IPHONE
    [DllImport("__Internal")]
    private static extern void TDInitSDK(string appId, string channelId, string custom);

    [DllImport("__Internal")]
    private static extern void TDStartA();

    [DllImport("__Internal")]
    private static extern void TDBackgroundSessionEnabled();

    [DllImport("__Internal")]
    private static extern string TDGetDeviceId();

    [DllImport("__Internal")] 
    private static extern void TDSetVerboseLogDisable();

    [DllImport("__Internal")]
    private static extern void TDSetLocation(double latitude, double longitude);

    [DllImport("__Internal")]
    private static extern void TDOnPageBegin(string pageName);

    [DllImport("__Internal")]
    private static extern void TDOnPageEnd(string pageName);

    [DllImport("__Internal")]
    private static extern void TDOnReceiveDeepLink(string url);

    [DllImport("__Internal")]
    private static extern void TDOnRegister(string profileId, string profileJson, string invitationCode, string eventValueJson);

    [DllImport("__Internal")]
    private static extern void TDOnLogin(string profileId, string profileJson, string eventValueJson);

    [DllImport("__Internal")]
    private static extern void TDOnProfileUpdate(string profileJson);

    [DllImport("__Internal")]
    private static extern void TDOnCreateCard(string profileId, string method, string content);

    [DllImport("__Internal")]
    private static extern void TDOnFavorite(string category, string content, string eventValueJson);

    [DllImport("__Internal")]
    private static extern void TDOnShare(string profileId, string content, string eventValueJson);

    [DllImport("__Internal")]
    private static extern void TDOnPunch(string profileId, string punchId);

    [DllImport("__Internal")]
    private static extern void TDOnSearch(string searchJson);

#if TD_RETAIL || TD_FINANCE || TD_TOUR || TD_ONLINEEDU
    [DllImport("__Internal")]
    private static extern void TDOnContact(string profileId, string content);
#endif

#if TD_GAME || TD_TOUR || TD_ONLINEEDU || TD_READING || TD_OTHER
    [DllImport("__Internal")]
    private static extern void TDOnPay(string profileId, string orderId, int amount, string currencyType, string paymentType, string itemId, int itemCount);
#endif

#if TD_RETAIL || TD_FINANCE || TD_TOUR || TD_ONLINEEDU
    [DllImport("__Internal")]
    private static extern void TDOnChargeBack(string profileId, string orderId, string reason, string type);
#endif

#if TD_FINANCE || TD_ONLINEEDU
    [DllImport("__Internal")]
    private static extern void TDOnReservation(string profileId, string reservationId, string category, int amount, string term);
#endif

#if TD_RETAIL || TD_TOUR
    [DllImport("__Internal")]
    private static extern void TDOnBooking(string profileId, string bookingId, string category, int amount, string content);
#endif

#if TD_RETAIL
    [DllImport("__Internal")]
    private static extern void TDOnViewItem(string itemId, string category, string name, int unitPrice, string eventValueJson);

    [DllImport("__Internal")]
    private static extern void TDOnAddItemToShoppingCart(string item, string category, string name, int unitPrice, int amount, string eventValueJson);

    [DllImport("__Internal")]
    private static extern void TDOnViewShoppingCart(string shoppingCartJson);

    [DllImport("__Internal")]
    private static extern void TDOnPlaceOrder(string orderJson, string profileId, string eventValueJson);

    [DllImport("__Internal")]
    private static extern void TDOnOrderPaySucc(string orderJson, string paymentType, string profileId);

    [DllImport("__Internal")]
    private static extern void TDOnCancelOrder(string orderJson);
#endif

#if TD_FINANCE
    [DllImport("__Internal")]
    private static extern void TDOnCredit(string profileId, int amount, string content);

    [DllImport("__Internal")]
    private static extern void TDOnTransaction(string profileId, string transactionJson);
#endif

#if TD_GAME
    [DllImport("__Internal")]
    private static extern void TDOnCreateRole(string name);

    [DllImport("__Internal")]
    private static extern void TDOnLevelPass(string profileId, string levelId);

    [DllImport("__Internal")]
    private static extern void TDOnGuideFinished(string profileId, string content);
#endif

#if TD_ONLINEEDU
    [DllImport("__Internal")]
    private static extern void TDOnLearn(string profileId, string course, long begin, int duration);

    [DllImport("__Internal")]
    private static extern void TDOnPreviewFinished(string profileId, string content);
#endif

#if TD_READING
    [DllImport("__Internal")]
    private static extern void TDOnRead(string profileId, string book, long begin, int duration);

    [DllImport("__Internal")]
    private static extern void TDOnFreeFinished(string profileId, string content);
#endif

#if TD_GAME || TD_ONLINEEDU
    [DllImport("__Internal")]
    private static extern void TDOnAchievementUnlock(string profileId, string achievementId);
#endif

#if TD_FINANCE || TD_TOUR || TD_OTHER
    [DllImport("__Internal")]
    private static extern void TDOnBrowse(string profileId, string content, long begin, int duration);
#endif

#if TD_RETAIL || TD_FINANCE || TD_TOUR || TD_OTHER
    [DllImport("__Internal")]
    private static extern void TDOnTrialFinished(string profileId, string content);
#endif

    [DllImport("__Internal")]
    private static extern void TDOnEvent(string eventId, string parameters, string eventValueJson);

    [DllImport("__Internal")]
    private static extern void TDSetGlobalKV(string key, string strVal, double numVal);

    [DllImport("__Internal")]
    private static extern void TDRemoveGlobalKV(string key);
#endif

#if UNITY_ANDROID
    private static AndroidJavaObject GetCurrentActivity()
    {
        if (unityPlayerClass == null)
        {
            unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        }
        AndroidJavaObject activity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
        return activity;
    }

    private static AndroidJavaObject DictionaryToAndroidMap(Dictionary<string, object> parameters)
    {
        AndroidJavaObject map = null;
        if (parameters != null && parameters.Count > 0)
        {
            int count = parameters.Count;
            map = new AndroidJavaObject("java.util.HashMap", count);
            IntPtr method_Put = AndroidJNIHelper.GetMethodID(map.GetRawClass(), "put", "(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;");
            object[] args = new object[2];
            foreach (KeyValuePair<string, object> kvp in parameters)
            {
                args[0] = new AndroidJavaObject("java.lang.String", kvp.Key);
                args[1] = typeof(string).IsInstanceOfType(kvp.Value)
                    ? new AndroidJavaObject("java.lang.String", kvp.Value)
                    : new AndroidJavaObject("java.lang.Double", "" + kvp.Value);
                AndroidJNI.CallObjectMethod(map.GetRawObject(), method_Put, AndroidJNIHelper.CreateJNIArgArray(args));
            }
        }
        return map;
    }
#endif

#if UNITY_IPHONE
    private static string DictionaryToJSONString(Dictionary<string, object> parameters)
    {
        string json = null;
        if (parameters != null && parameters.Count > 0)
        {
            json = "{";
            foreach (KeyValuePair<string, object> kvp in parameters)
            {
                if (kvp.Value is string)
                {
                    json += "\"" + kvp.Key + "\":\"" + kvp.Value + "\",";
                }
                else
                {
                    try
                    {
                        double tmp = System.Convert.ToDouble(kvp.Value);
                        json += "\"" + kvp.Key + "\":" + tmp + ",";
                    }
                    catch (System.Exception)
                    {
                    }
                }
            }
            json = json.TrimEnd(',');
            json += "}";
        }
        return json;
    }
#endif

    public static void InitSDK(string appId, string channelId, string custom)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
            Debug.Log("TalkingData Unity SDK.");
#if UNITY_ANDROID
            using (AndroidJavaClass dz = new AndroidJavaClass("com.tendcloud.tenddata.dz"))
            {
                dz.SetStatic("a", 2);
            }
            if (talkingdataClass == null)
            {
                talkingdataClass = new AndroidJavaClass(TALKINGDATA_CLASS);
            }
            AndroidJavaObject activity = GetCurrentActivity();
            talkingdataClass.CallStatic("initSDK", activity, appId, channelId, custom);
#endif
#if UNITY_IPHONE
            TDInitSDK(appId, channelId, custom);
#endif
        }
    }

    public static void StartA()
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                AndroidJavaObject activity = GetCurrentActivity();
                talkingdataClass.CallStatic("startA", activity);
                talkingdataClass.CallStatic("onResume", activity);
            }
#endif
#if UNITY_IPHONE
            TDStartA();
#endif
        }
    }

    public static void OnPause()
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                talkingdataClass.CallStatic("onPause", GetCurrentActivity());
            }
#endif
        }
    }

    public static void BackgroundSessionEnabled()
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_IPHONE
            TDBackgroundSessionEnabled();
#endif
        }
    }

    private static string deviceId = null;
    public static string GetDeviceId()
    {
        if (deviceId == null && Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass == null)
            {
                talkingdataClass = new AndroidJavaClass(TALKINGDATA_CLASS);
            }
            deviceId = talkingdataClass.CallStatic<string>("getDeviceId", GetCurrentActivity());
#endif
#if UNITY_IPHONE
            deviceId = TDGetDeviceId();
#endif
        }
        return deviceId;
    }

    private static string oaid = null;
    public static string GetOAID()
    {
        if (oaid == null && Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass == null)
            {
                talkingdataClass = new AndroidJavaClass(TALKINGDATA_CLASS);
            }
            oaid = talkingdataClass.CallStatic<string>("getOAID", GetCurrentActivity());
#endif
        }
        return oaid;
    }

    public static void SetVerboseLogDisable()
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass == null)
            {
                talkingdataClass = new AndroidJavaClass(TALKINGDATA_CLASS);
            }
            talkingdataClass.CallStatic("setVerboseLogDisable");
#endif
#if UNITY_IPHONE
            TDSetVerboseLogDisable();
#endif
        }
    }

    public static void SetLocation(double latitude, double longitude)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_IPHONE
            TDSetLocation(latitude, longitude);
#endif
        }
    }

    public static void OnPageBegin(string pageName)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                talkingdataClass.CallStatic("onPageBegin", GetCurrentActivity(), pageName);
            }
#endif
#if UNITY_IPHONE
            TDOnPageBegin(pageName);
#endif
        }
    }

    public static void OnPageEnd(string pageName)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                talkingdataClass.CallStatic("onPageEnd", GetCurrentActivity(), pageName);
            }
#endif
#if UNITY_IPHONE
            TDOnPageEnd(pageName);
#endif
        }
    }

    public static void OnReceiveDeepLink(string url)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                talkingdataClass.CallStatic("onReceiveDeepLink", url);
            }
#endif
#if UNITY_IPHONE
            TDOnReceiveDeepLink(url);
#endif
        }
    }

    public static void OnRegister(string profileId, TalkingDataProfile profile, string invitationCode, Dictionary<string, object> eventValue)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                AndroidJavaObject eventValueMap = DictionaryToAndroidMap(eventValue);
                talkingdataClass.CallStatic("onRegister", profileId, profile.javaObj, invitationCode, eventValueMap);
                if (eventValueMap != null)
                {
                    eventValueMap.Dispose();
                }
            }
#endif
#if UNITY_IPHONE
            string eventValueJson = DictionaryToJSONString(eventValue);
            TDOnRegister(profileId, profile.ToString(), invitationCode, eventValueJson);
#endif
        }
    }

    public static void OnLogin(string profileId, TalkingDataProfile profile, Dictionary<string, object> eventValue)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                AndroidJavaObject eventValueMap = DictionaryToAndroidMap(eventValue);
                talkingdataClass.CallStatic("onLogin", profileId, profile.javaObj, eventValueMap);
                if (eventValueMap != null)
                {
                    eventValueMap.Dispose();
                }
            }
#endif
#if UNITY_IPHONE
            string eventValueJson = DictionaryToJSONString(eventValue);
            TDOnLogin(profileId, profile.ToString(), eventValueJson);
#endif
        }
    }

    public static void OnProfileUpdate(TalkingDataProfile profile)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                talkingdataClass.CallStatic("onProfileUpdate", profile.javaObj);
            }
#endif
#if  UNITY_IPHONE
            TDOnProfileUpdate(profile.ToString());
#endif
        }
    }
    public static void OnCreateCard(string profileId, string method, string content)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                talkingdataClass.CallStatic("onCreateCard", profileId, method, content);
            }
#endif
#if UNITY_IPHONE
            TDOnCreateCard(profileId, method, content);
#endif
        }
    }

    public static void OnFavorite(string category, string content, Dictionary<string, object> eventValue)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                AndroidJavaObject eventValueMap = DictionaryToAndroidMap(eventValue);
                talkingdataClass.CallStatic("onFavorite", category, content, eventValueMap);
                if (eventValueMap != null)
                {
                    eventValueMap.Dispose();
                }
            }
#endif
#if UNITY_IPHONE
            string eventValueJson = DictionaryToJSONString(eventValue);
            TDOnFavorite(category, content, eventValueJson);
#endif
        }
    }

    public static void OnShare(string profileId, string content, Dictionary<string, object> eventValue)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                AndroidJavaObject eventValueMap = DictionaryToAndroidMap(eventValue);
                talkingdataClass.CallStatic("onShare", profileId, content, eventValueMap);
                if (eventValueMap != null)
                {
                    eventValueMap.Dispose();
                }
            }
#endif
#if UNITY_IPHONE
            string eventValueJson = DictionaryToJSONString(eventValue);
            TDOnShare(profileId, content, eventValueJson);
#endif
        }
    }

    public static void OnPunch(string profileId, string punchId)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                talkingdataClass.CallStatic("onPunch", profileId, punchId);
            }
#endif
#if UNITY_IPHONE
            TDOnPunch(profileId, punchId);
#endif
        }
    }

    public static void OnSearch(TalkingDataSearch search)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                talkingdataClass.CallStatic("onSearch", search.javaObj);
            }
#endif
#if UNITY_IPHONE
            TDOnSearch(search.ToString());
#endif
        }
    }

#if TD_RETAIL || TD_FINANCE || TD_TOUR || TD_ONLINEEDU
    public static void OnContact(string profileId, string content)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                talkingdataClass.CallStatic("onContact", profileId, content);
            }
#endif
#if UNITY_IPHONE
            TDOnContact(profileId, content);
#endif
        }
    }
#endif

#if TD_GAME || TD_TOUR || TD_ONLINEEDU || TD_READING || TD_OTHER
    public static void OnPay(string profileId, string orderId, int amount, string currencyType, string paymentType, string itemId, int itemCount)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                talkingdataClass.CallStatic("onPay", profileId, orderId, amount, currencyType, paymentType, itemId, itemCount);
            }
#endif
#if UNITY_IPHONE
            TDOnPay(profileId, orderId, amount, currencyType, paymentType, itemId, itemCount);
#endif
        }
    }
#endif

#if TD_RETAIL || TD_FINANCE || TD_TOUR || TD_ONLINEEDU
    public static void OnChargeBack(string profileId, string orderId, string reason, string type)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                talkingdataClass.CallStatic("onChargeBack", profileId, orderId, reason, type);
            }
#endif
#if UNITY_IPHONE
            TDOnChargeBack(profileId, orderId, reason, type);
#endif
        }
    }
#endif

#if TD_FINANCE || TD_ONLINEEDU
    public static void OnReservation(string profileId, string reservationId, string category, int amount, string term)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                talkingdataClass.CallStatic("onReservation", profileId, reservationId, category, amount, term);
            }
#endif
#if UNITY_IPHONE
            TDOnReservation(profileId, reservationId, category, amount, term);
#endif
        }
    }
#endif

#if TD_RETAIL || TD_TOUR
    public static void OnBooking(string profileId, string bookingId, string category, int amount, string content)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                talkingdataClass.CallStatic("onBooking", profileId, bookingId, category, amount, content);
            }
#endif
#if UNITY_IPHONE
            TDOnBooking(profileId, bookingId, category, amount, content);
#endif
        }
    }
#endif

#if TD_RETAIL
    public static void OnViewItem(string itemId, string category, string name, int unitPrice, Dictionary<string, object> eventValue)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                AndroidJavaObject eventValueMap = DictionaryToAndroidMap(eventValue);
                talkingdataClass.CallStatic("onViewItem", itemId, category, name, unitPrice, eventValueMap);
                if (eventValueMap != null)
                {
                    eventValueMap.Dispose();
                }
            }
#endif
#if UNITY_IPHONE
            string eventValueJson = DictionaryToJSONString(eventValue);
            TDOnViewItem(itemId, category, name, unitPrice, eventValueJson);
#endif
        }
    }

    public static void OnAddItemToShoppingCart(string itemId, string category, string name, int unitPrice, int amount, Dictionary<string, object> eventValue)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                AndroidJavaObject eventValueMap = DictionaryToAndroidMap(eventValue);
                talkingdataClass.CallStatic("onAddItemToShoppingCart", itemId, category, name, unitPrice, amount, eventValueMap);
                if (eventValueMap != null)
                {
                    eventValueMap.Dispose();
                }
            }
#endif
#if UNITY_IPHONE
            string eventValueJson = DictionaryToJSONString(eventValue);
            TDOnAddItemToShoppingCart(itemId, category, name, unitPrice, amount, eventValueJson);
#endif
        }
    }

    public static void OnViewShoppingCart(TalkingDataShoppingCart shoppingCart)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                talkingdataClass.CallStatic("onViewShoppingCart", shoppingCart.javaObj);
            }
#endif
#if UNITY_IPHONE
            TDOnViewShoppingCart(shoppingCart.ToString());
#endif
        }
    }

    public static void OnPlaceOrder(TalkingDataOrder order, string profileId, Dictionary<string, object> eventValue)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                AndroidJavaObject eventValueMap = DictionaryToAndroidMap(eventValue);
                talkingdataClass.CallStatic("onPlaceOrder", order.javaObj, profileId, eventValueMap);
                if (eventValueMap != null)
                {
                    eventValueMap.Dispose();
                }
            }
#endif
#if UNITY_IPHONE
            string eventValueJson = DictionaryToJSONString(eventValue);
            TDOnPlaceOrder(order.ToString(), profileId, eventValueJson);
#endif
        }
    }

    public static void OnOrderPaySucc(TalkingDataOrder order, string paymentType, string profileId)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                talkingdataClass.CallStatic("onOrderPaySucc", order.javaObj, paymentType, profileId);
            }
#endif
#if UNITY_IPHONE
            TDOnOrderPaySucc(order.ToString(), paymentType, profileId);
#endif
        }
    }

    public static void OnCancelOrder(TalkingDataOrder order)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                talkingdataClass.CallStatic("onCancelOrder", order.javaObj);
            }
#endif
#if UNITY_IPHONE
            TDOnCancelOrder(order.ToString());
#endif
        }
    }
#endif

#if TD_FINANCE
    public static void OnCredit(string profileId, int amount, string content)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                talkingdataClass.CallStatic("onCredit", profileId, amount, content);
            }
#endif
#if UNITY_IPHONE
            TDOnCredit(profileId, amount, content);
#endif
        }
    }

    public static void OnTransaction(string profileId, TalkingDataTransaction transaction)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                talkingdataClass.CallStatic("onTransaction", profileId, transaction.javaObj);
            }
#endif
#if UNITY_IPHONE
            TDOnTransaction(profileId, transaction.ToString());
#endif
        }
    }
#endif

#if TD_GAME
    public static void OnCreateRole(string name)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                talkingdataClass.CallStatic("onCreateRole", name);
            }
#endif
#if UNITY_IPHONE
            TDOnCreateRole(name);
#endif
        }
    }

    public static void OnLevelPass(string profileId, string levelId)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                talkingdataClass.CallStatic("onLevelPass", profileId, levelId);
            }
#endif
#if UNITY_IPHONE
            TDOnLevelPass(profileId, levelId);
#endif
        }
    }

    public static void OnGuideFinished(string profileId, string content)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                talkingdataClass.CallStatic("onGuideFinished", profileId, content);
            }
#endif
#if UNITY_IPHONE
            TDOnGuideFinished(profileId, content);
#endif
        }
    }
#endif

#if TD_ONLINEEDU
    public static void OnLearn(string profileId, string course, long begin, int duration)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                talkingdataClass.CallStatic("onLearn", profileId, course, begin, duration);
            }
#endif
#if UNITY_IPHONE
            TDOnLearn(profileId, course, begin, duration);
#endif
        }
    }

    public static void OnPreviewFinished(string profileId, string content)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                talkingdataClass.CallStatic("onPreviewFinished", profileId, content);
            }
#endif
#if UNITY_IPHONE
            TDOnPreviewFinished(profileId, content);
#endif
        }
    }
#endif

#if TD_READING
    public static void OnRead(string profileId, string book, long begin, int duration)
     {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                talkingdataClass.CallStatic("onRead", profileId, book, begin, duration);
            }
#endif
#if UNITY_IPHONE
            TDOnRead(profileId, book, begin, duration);
#endif
        }
    }

    public static void OnFreeFinished(string profileId, string content)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                talkingdataClass.CallStatic("onFreeFinished", profileId, content);
            }
#endif
#if UNITY_IPHONE
            TDOnFreeFinished(profileId, content);
#endif
        }
    }
#endif

#if TD_GAME || TD_ONLINEEDU
    public static void OnAchievementUnlock(string profileId, string achievementId)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                talkingdataClass.CallStatic("onAchievementUnlock", profileId, achievementId);
            }
#endif
#if UNITY_IPHONE
            TDOnAchievementUnlock(profileId, achievementId);
#endif
        }
    }
#endif

#if TD_FINANCE || TD_TOUR || TD_OTHER
    public static void OnBrowse(string profileId, string content, long begin, int duration)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                talkingdataClass.CallStatic("onBrowse", profileId, content, begin, duration);
            }
#endif
#if UNITY_IPHONE
            TDOnBrowse(profileId, content, begin, duration);
#endif
        }
    }
#endif

#if TD_RETAIL || TD_FINANCE || TD_TOUR || TD_OTHER
    public static void OnTrialFinished(string profileId, string content)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                talkingdataClass.CallStatic("onTrialFinished", profileId, content);
            }
#endif
#if UNITY_IPHONE
            TDOnTrialFinished(profileId, content);
#endif
        }
    }
#endif

    public static void OnEvent(string eventId, Dictionary<string, object> parameters, Dictionary<string, object> eventValue)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                AndroidJavaObject parametersMap = DictionaryToAndroidMap(parameters);
                AndroidJavaObject eventValueMap = DictionaryToAndroidMap(eventValue);
                talkingdataClass.CallStatic("onEvent", GetCurrentActivity(), eventId, parametersMap, eventValueMap);
                if (parametersMap != null)
                {
                    parametersMap.Dispose();
                }
                if (eventValueMap != null)
                {
                    eventValueMap.Dispose();
                }
            }
#endif
#if UNITY_IPHONE
            string parametersJson = DictionaryToJSONString(parameters);
            string eventValueJson = DictionaryToJSONString(eventValue);
            TDOnEvent(eventId, parametersJson, eventValueJson);
#endif
        }
    }

    public static void SetGlobalKV(string key, object val)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                AndroidJavaObject valObject = typeof(string).IsInstanceOfType(val)
                                            ? new AndroidJavaObject("java.lang.String", val)
                                            : new AndroidJavaObject("java.lang.Double", "" + val);
                talkingdataClass.CallStatic("setGlobalKV", key, valObject);
            }
#endif
#if UNITY_IPHONE
            if (val is string)
            {
                string tmp = System.Convert.ToString(val);
                TDSetGlobalKV(key, tmp, 0);
            }
            else
            {
                double tmp = System.Convert.ToDouble(val);
                TDSetGlobalKV(key, null, tmp);
            }
#endif
        }
    }

    public static void RemoveGlobalKV(string key)
    {
        if (Application.platform != RuntimePlatform.OSXEditor && Application.platform != RuntimePlatform.WindowsEditor)
        {
#if UNITY_ANDROID
            if (talkingdataClass != null)
            {
                talkingdataClass.CallStatic("removeGlobalKV", key);
            }
#endif
#if UNITY_IPHONE
            TDRemoveGlobalKV(key);
#endif
        }
    }
}
