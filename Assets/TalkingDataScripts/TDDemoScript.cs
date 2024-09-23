using UnityEngine;
using System.Collections.Generic;

public class TDDemoScript : MonoBehaviour
{
    private const int top = 100;
    private const int left = 80;
    private const int height = 60;
    private const int spacing = 20;
    private readonly int width = (Screen.width - (left * 2) - spacing) / 2;
    private const int step = 80;
    private string tdid;
    private string oaid;

    private void OnGUI()
    {
        int i = 0;
        GUI.Box(new Rect(10, 10, Screen.width - 20, Screen.height - 20), "Demo Menu");

        GUI.Label(new Rect(left + i % 2 * (width + spacing), top + step * (i++ / 2), width, height), tdid);
        if (GUI.Button(new Rect(left + i % 2 * (width + spacing), top + step * (i++ / 2), width, height), "getTDID"))
        {
            tdid = TalkingDataSDK.GetDeviceId();
        }

#if UNITY_ANDROID
        GUI.Label(new Rect(left + i % 2 * (width + spacing), top + step * (i++ / 2), width, height), oaid);
        if (GUI.Button(new Rect(left + i % 2 * (width + spacing), top + step * (i++ / 2), width, height), "getOAID"))
        {
            oaid = TalkingDataSDK.GetOAID();
        }
#endif

        if (GUI.Button(new Rect(left + i % 2 * (width + spacing), top + step * (i++ / 2), width, height), "OnPageBegin"))
        {
            TalkingDataSDK.OnPageBegin("home_page");
        }

        if (GUI.Button(new Rect(left + i % 2 * (width + spacing), top + step * (i++ / 2), width, height), "OnPageEnd"))
        {
            TalkingDataSDK.OnPageEnd("home_page");
        }

        if (GUI.Button(new Rect(left + i % 2 * (width + spacing), top + step * (i++ / 2), width, height), "OnReceiveDeepLink"))
        {
            TalkingDataSDK.OnReceiveDeepLink("https://www.talkingdata.com");
        }

        if (GUI.Button(new Rect(left + i % 2 * (width + spacing), top + step * (i++ / 2), width, height), "OnRegister"))
        {
            TalkingDataProfile profile = TalkingDataProfile.CreateProfile();
            profile.SetName("name01");
            profile.SetType(TalkingDataProfileType.WEIXIN);
            profile.SetGender(TalkingDataGender.MALE);
            profile.SetAge(18);
            profile.SetProperty1("property1");
            profile.SetProperty2(2);
            profile.SetProperty3(3.14);
            profile.SetProperty4("property4");
            profile.SetProperty5("property5");
            profile.SetProperty6(0.618);
            profile.SetProperty7("property7");
            profile.SetProperty8("property8");
            profile.SetProperty9(9.8);
            profile.SetProperty10("property10");
            Dictionary<string, object> eventValue = new Dictionary<string, object>
            {
                { "key", "value" }
            };
            TalkingDataSDK.OnRegister("user01", profile, "123456", eventValue);
        }

        if (GUI.Button(new Rect(left + i % 2 * (width + spacing), top + step * (i++ / 2), width, height), "OnLogin"))
        {
            TalkingDataProfile profile = TalkingDataProfile.CreateProfile();
            profile.SetName("name01");
            profile.SetType(TalkingDataProfileType.WEIXIN);
            profile.SetGender(TalkingDataGender.MALE);
            profile.SetAge(18);
            profile.SetProperty1("property1");
            profile.SetProperty2(2);
            profile.SetProperty3(3.14);
            profile.SetProperty4("property4");
            profile.SetProperty5("property5");
            profile.SetProperty6(0.618);
            profile.SetProperty7("property7");
            profile.SetProperty8("property8");
            profile.SetProperty9(9.8);
            profile.SetProperty10("property10");
            Dictionary<string, object> eventValue = new Dictionary<string, object>
            {
                { "key", "value" }
            };
            TalkingDataSDK.OnLogin("user01", profile, eventValue);
        }

        if (GUI.Button(new Rect(left + i % 2 * (width + spacing), top + step * (i++ / 2), width, height), "OnProfileUpdate"))
        {
            TalkingDataProfile profile = TalkingDataProfile.CreateProfile();
            profile.SetName("name01");
            profile.SetType(TalkingDataProfileType.WEIXIN);
            profile.SetGender(TalkingDataGender.MALE);
            profile.SetAge(18);
            profile.SetProperty1("property1");
            profile.SetProperty2(2);
            profile.SetProperty3(3.14);
            profile.SetProperty4("property4");
            profile.SetProperty5("property5");
            profile.SetProperty6(0.618);
            profile.SetProperty7("property7");
            profile.SetProperty8("property8");
            profile.SetProperty9(9.8);
            profile.SetProperty10("property10");
            TalkingDataSDK.OnProfileUpdate(profile);
        }

        if (GUI.Button(new Rect(left + i % 2 * (width + spacing), top + step * (i++ / 2), width, height), "OnCreateCard"))
        {
            TalkingDataSDK.OnCreateCard("user01", "支付宝", "支付宝账号123456789");
        }

        if (GUI.Button(new Rect(left + i % 2 * (width + spacing), top + step * (i++ / 2), width, height), "OnFavorite"))
        {
            Dictionary<string, object> eventValue = new Dictionary<string, object>
            {
                { "key", "value" }
            };
            TalkingDataSDK.OnFavorite("服装", "2019新款", eventValue);
        }

        if (GUI.Button(new Rect(left + i % 2 * (width + spacing), top + step * (i++ / 2), width, height), "OnShare"))
        {
            Dictionary<string, object> eventValue = new Dictionary<string, object>
            {
                { "key", "value" }
            };
            TalkingDataSDK.OnShare("user01", "课程", eventValue);
        }

        if (GUI.Button(new Rect(left + i % 2 * (width + spacing), top + step * (i++ / 2), width, height), "OnPunch"))
        {
            TalkingDataSDK.OnPunch("user01", "签到0023");
        }

        if (GUI.Button(new Rect(left + i % 2 * (width + spacing), top + step * (i++ / 2), width, height), "OnSearch"))
        {
            TalkingDataSearch search = TalkingDataSearch.CreateSearch();
            search.SetCategory("类型");
            search.SetContent("内容");
#if TD_RETAIL
            search.SetItemId("商品ID");
            search.SetItemLocationId("location12314");
#endif
#if TD_TOUR
            search.SetDestination("目的地");
            search.SetOrigin("出发地");
            search.SetStartDate(1565176907309);
            search.SetEndDate(1565176908309);
#endif
            TalkingDataSDK.OnSearch(search);
        }

#if TD_RETAIL || TD_FINANCE || TD_TOUR || TD_ONLINEEDU
        if (GUI.Button(new Rect(left + i % 2 * (width + spacing), top + step * (i++ / 2), width, height), "OnContact"))
        {
            TalkingDataSDK.OnContact("user01", "联系平台内容");
        }
#endif

#if TD_GAME || TD_TOUR || TD_ONLINEEDU || TD_READING || TD_OTHER
        if (GUI.Button(new Rect(left + i % 2 * (width + spacing), top + step * (i++ / 2), width, height), "OnPay"))
        {
            TalkingDataSDK.OnPay("user01", "order01", 1077600, "CNY", "Apple Pay", "item01", 2);
        }
#endif

#if TD_RETAIL || TD_FINANCE || TD_TOUR || TD_ONLINEEDU
        if (GUI.Button(new Rect(left + i % 2 * (width + spacing), top + step * (i++ / 2), width, height), "OnChargeBack"))
        {
            TalkingDataSDK.OnChargeBack("user01", "order01", "7天无理由退货", "仅退款");
        }
#endif

#if TD_FINANCE || TD_ONLINEEDU
        if (GUI.Button(new Rect(left + i % 2 * (width + spacing), top + step * (i++ / 2), width, height), "OnReservation"))
        {
            TalkingDataSDK.OnReservation("user01", "AdTracking_123456", "借贷类", 12, "商品信息");
        }
#endif

#if TD_RETAIL || TD_TOUR
        if (GUI.Button(new Rect(left + i % 2 * (width + spacing), top + step * (i++ / 2), width, height), "OnBooking"))
        {
            TalkingDataSDK.OnBooking("user01", "002391", "电子", 123, "商品信息");
        }
#endif

#if TD_RETAIL
        if (GUI.Button(new Rect(left + i % 2 * (width + spacing), top + step * (i++ / 2), width, height), "OnViewItem"))
        {
            Dictionary<string, object> eventValue = new Dictionary<string, object>
            {
                { "key", "value" }
            };
            TalkingDataSDK.OnViewItem("A1660", "手机", "iPhone 7", 538800, eventValue);
        }

        if (GUI.Button(new Rect(left + i % 2 * (width + spacing), top + step * (i++ / 2), width, height), "OnAddItemToShoppingCart"))
        {
            Dictionary<string, object> eventValue = new Dictionary<string, object>
            {
                { "key", "value" }
            };
            TalkingDataSDK.OnAddItemToShoppingCart("MLH12CH", "电脑", "MacBook Pro", 1388800, 1, eventValue);
        }

        if (GUI.Button(new Rect(left + i % 2 * (width + spacing), top + step * (i++ / 2), width, height), "OnViewShoppingCart"))
        {
            TalkingDataShoppingCart shoppingCart = TalkingDataShoppingCart.CreateShoppingCart();
            if (shoppingCart != null)
            {
                shoppingCart.AddItem("A1660", "手机", "iPhone 7", 538800, 2);
                shoppingCart.AddItem("MLH12CH", "电脑", "MacBook Pro", 1388800, 1);
                TalkingDataSDK.OnViewShoppingCart(shoppingCart);
            }
        }

        if (GUI.Button(new Rect(left + i % 2 * (width + spacing), top + step * (i++ / 2), width, height), "OnPlaceOrder"))
        {
            TalkingDataOrder order = TalkingDataOrder.CreateOrder("order01", 2466400, "CNY");
            order.AddItem("A1660", "手机", "iPhone 7", 538800, 2);
            order.AddItem("MLH12CH", "电脑", "MacBook Pro", 1388800, 1);
            Dictionary<string, object> eventValue = new Dictionary<string, object>
            {
                { "key", "value" }
            };
            TalkingDataSDK.OnPlaceOrder(order, "user01", eventValue);
        }

        if (GUI.Button(new Rect(left + i % 2 * (width + spacing), top + step * (i++ / 2), width, height), "OnOrderPaySucc"))
        {
            TalkingDataOrder order = TalkingDataOrder.CreateOrder("order01", 2466400, "CNY");
            order.AddItem("A1660", "手机", "iPhone 7", 538800, 2);
            order.AddItem("MLH12CH", "电脑", "MacBook Pro", 1388800, 1);
            TalkingDataSDK.OnOrderPaySucc(order, "AliPay", "user01");
        }

        if (GUI.Button(new Rect(left + i % 2 * (width + spacing), top + step * (i++ / 2), width, height), "OnCancelOrder"))
        {
            TalkingDataOrder order = TalkingDataOrder.CreateOrder("order01", 2466400, "CNY");
            order.AddItem("A1660", "手机", "iPhone 7", 538800, 2);
            order.AddItem("MLH12CH", "电脑", "MacBook Pro", 1388800, 1);
            TalkingDataSDK.OnCancelOrder(order);
        }
#endif

#if TD_FINANCE
        if (GUI.Button(new Rect(left + i % 2 * (width + spacing), top + step * (i++ / 2), width, height), "OnCredit"))
        {
            TalkingDataSDK.OnCredit("user01", 123456, "授信详情为......");
        }

        if (GUI.Button(new Rect(left + i % 2 * (width + spacing), top + step * (i++ / 2), width, height), "OnTransaction"))
        {
            TalkingDataTransaction transaction = TalkingDataTransaction.CreateTransaction();
            transaction.SetTransactionId("AdTracking_123456");
            transaction.SetCategory("定期");
            transaction.SetAmount(3222);
            transaction.SetPersonA("张三");
            transaction.SetPersonB("金融平台");
            transaction.SetStartDate(1565176907309);
            transaction.SetEndDate(1565176908309);
            transaction.SetCurrencyType("CNY");
            transaction.SetContent("交易详情为......");
            TalkingDataSDK.OnTransaction("user01", transaction);
        }
#endif

#if TD_GAME
        if (GUI.Button(new Rect(left + i % 2 * (width + spacing), top + step * (i++ / 2), width, height), "OnCreateRole"))
        {
            TalkingDataSDK.OnCreateRole("role01");
        }

        if (GUI.Button(new Rect(left + i % 2 * (width + spacing), top + step * (i++ / 2), width, height), "OnLevelPass"))
        {
            TalkingDataSDK.OnLevelPass("user01", "AdTracking_123456");
        }

        if (GUI.Button(new Rect(left + i % 2 * (width + spacing), top + step * (i++ / 2), width, height), "OnGuideFinished"))
        {
            TalkingDataSDK.OnGuideFinished("user01", "新手教程顺利通过");
        }
#endif

#if TD_ONLINEEDU
        if (GUI.Button(new Rect(left + i % 2 * (width + spacing), top + step * (i++ / 2), width, height), "OnLearn"))
        {
            TalkingDataSDK.OnLearn("user01", "成人教育第一节", 1501234567890, 20);
        }

        if (GUI.Button(new Rect(left + i % 2 * (width + spacing), top + step * (i++ / 2), width, height), "OnPreviewFinished"))
        {
            TalkingDataSDK.OnPreviewFinished("user01", "基础课程试听结束");
        }
#endif

#if TD_READING
        if (GUI.Button(new Rect(left + i % 2 * (width + spacing), top + step * (i++ / 2), width, height), "OnRead"))
        {
            TalkingDataSDK.OnRead("user01", "西游记第一章", 1501234567890, 20);
        }

        if (GUI.Button(new Rect(left + i % 2 * (width + spacing), top + step * (i++ / 2), width, height), "OnFreeFinished"))
        {
            TalkingDataSDK.OnFreeFinished("user01", "免费章节阅读结束");
        }
#endif

#if TD_GAME || TD_ONLINEEDU
        if (GUI.Button(new Rect(left + i % 2 * (width + spacing), top + step * (i++ / 2), width, height), "OnAchievementUnlock"))
        {
            TalkingDataSDK.OnAchievementUnlock("user01", "AdTracking_123456");
        }
#endif

#if TD_FINANCE || TD_TOUR || TD_OTHER
        if (GUI.Button(new Rect(left + i % 2 * (width + spacing), top + step * (i++ / 2), width, height), "OnBrowse"))
        {
            TalkingDataSDK.OnBrowse("user01", "详情页page1", 1501234567890, 20);
        }
#endif

#if TD_RETAIL || TD_FINANCE || TD_TOUR || TD_OTHER
        if (GUI.Button(new Rect(left + i % 2 * (width + spacing), top + step * (i++ / 2), width, height), "OnTrialFinished"))
        {
            TalkingDataSDK.OnTrialFinished("user01", "试用体验结束");
        }
#endif

        if (GUI.Button(new Rect(left, top + (step * i++), width, height), "OnEvent"))
        {
            Dictionary<string, object> dic = new Dictionary<string, object>
            {
                { "StringValue", "Pi" },
                { "NumberValue", 3.14 }
            };
            Dictionary<string, object> eventValue = new Dictionary<string, object>
            {
                { "key", "value" }
            };
            TalkingDataSDK.OnEvent("action_id", dic, eventValue);
        }
    }

    void Start()
    {
        Debug.Log("Start");
        // TalkingDataSDK.SetVerboseLogDisable();
        TalkingDataSDK.BackgroundSessionEnabled();
        TalkingDataSDK.InitSDK("your_app_id", "your_channel_id", "your_custom_parameter");
        TalkingDataSDK.StartA();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void OnDestroy()
    {
        Debug.Log("onDestroy");
        TalkingDataSDK.OnPause();
    }

    void Awake()
    {
        Debug.Log("Awake");
    }

    void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    void OnDisable()
    {
        Debug.Log("OnDisable");
    }
}
